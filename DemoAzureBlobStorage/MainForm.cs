using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAzureBlobStorage
{
    public partial class MainForm : Form
    {
        private DataBlob _dataBlob;

        public MainForm()
        {
            InitializeComponent();

            Shown += (s, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    ListData();

                    _dataBlob = new DataBlob();
                    editDataBlobBindingSource.DataSource = _dataBlob;
                    editDataBlobBindingSource.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };

        }

        private void ListData()
        {
            using (var ctx = new DataContext())
            {
                var data = ctx.Set<DataBlob>().ToList();

                data.ForEach(x =>
                {
                    x.Imagen = (Bitmap) Image.FromFile(x.RutaArchivo);
                });

                dataBlobBindingSource.DataSource = data;
                dataBlobBindingSource.ResetBindings(false);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() ) 
            {
                ofd.Filter = @"Archivos de Imagen (*.jpg;*.gif;*.png)|*.jpg;*.gif;*.png";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() != DialogResult.OK) return;

                _dataBlob.RutaArchivo = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            editDataBlobBindingSource.EndEdit();
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var ctx = new DataContext())
                {
                    ctx.Set<DataBlob>().Add(_dataBlob);
                    ctx.SaveChanges();

                    AzureStorageBlobUtils.UploadDocumentToAzure(new UploadDocumentAzureRequest
                    {
                        NombreArchivo = _dataBlob.RutaArchivo,
                        NombreReferencia = _dataBlob.Alias
                    });

                    ListData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListData();
        }
    }
}
