namespace PAMI.Importar_Datos
{
    partial class ImportarNomenclador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportarNomenclador));
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbAsociacion
            // 
            this.cmbAsociacion.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAsociacion.FormattingEnabled = true;
            this.cmbAsociacion.Items.AddRange(new object[] {
            "Asociación de Oftalmólogos de Río Negro",
            "Asociación de Hematologia y Hemoterapia Norpatagónica"});
            this.cmbAsociacion.Location = new System.Drawing.Point(15, 110);
            this.cmbAsociacion.Name = "cmbAsociacion";
            this.cmbAsociacion.Size = new System.Drawing.Size(365, 32);
            this.cmbAsociacion.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(10, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Asociación";
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnImportar.Location = new System.Drawing.Point(219, 159);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(161, 37);
            this.btnImportar.TabIndex = 34;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "Ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtRuta.Location = new System.Drawing.Point(16, 44);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(364, 29);
            this.txtRuta.TabIndex = 31;
            this.txtRuta.DoubleClick += new System.EventHandler(this.txtRuta_DoubleClick);
            // 
            // ImportarNomenclador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 211);
            this.Controls.Add(this.cmbAsociacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRuta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportarNomenclador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportarNomenclador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRuta;

    }
}