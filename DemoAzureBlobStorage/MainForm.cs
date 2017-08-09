using System;
using System.Drawing;
using System.IO;
using System.Linq;
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

            gdvData.DoubleClick += GdvDataOnDoubleClick;
        }

        private async void GdvDataOnDoubleClick(object sender, EventArgs eventArgs)
        {
            try
            {

                var seleccionado = dataBlobBindingSource.Current as DataBlob;
                if (seleccionado == null) return;

                var documento = await AzureStorageBlobUtils.DownloadDocument(seleccionado.Alias);

                pictureBox1.Image = Image.FromStream(documento);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListData()
        {
            using (var ctx = new DataContext())
            {
                var data = ctx.Set<DataBlob>().ToList();

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
                var fileInfo = new FileInfo(_dataBlob.RutaArchivo);
                _dataBlob.Alias = fileInfo.Name;

                editDataBlobBindingSource.ResetBindings(false);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            editDataBlobBindingSource.EndEdit();
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var ctx = new DataContext())
                {
                    _dataBlob.RutaNube = await AzureStorageBlobUtils.UploadDocumentToAzure(new UploadDocumentAzureRequest
                    {
                        NombreArchivo = _dataBlob.RutaArchivo,
                        NombreReferencia = _dataBlob.Alias
                    });

                    ctx.Set<DataBlob>().Add(_dataBlob);
                    await ctx.SaveChangesAsync();

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
