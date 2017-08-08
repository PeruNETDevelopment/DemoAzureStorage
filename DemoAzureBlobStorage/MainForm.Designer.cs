namespace DemoAzureBlobStorage
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gdvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alias:";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(91, 23);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(343, 20);
            this.txtAlias.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(440, 47);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(53, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Grabar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gdvData
            // 
            this.gdvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvData.Location = new System.Drawing.Point(12, 114);
            this.gdvData.Name = "gdvData";
            this.gdvData.Size = new System.Drawing.Size(481, 189);
            this.gdvData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ruta Archivo:";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(91, 49);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(343, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(97, 85);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "Listar";
            this.btnList.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 315);
            this.Controls.Add(this.gdvData);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Azure Storage";
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gdvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button btnList;
    }
}

