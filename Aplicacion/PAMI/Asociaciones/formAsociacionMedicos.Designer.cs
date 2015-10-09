namespace PAMI.Asociaciones
{
    partial class formAsociacionMedicos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgMedicosAsociacion = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicosAsociacion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAsociacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 104);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // cmbAsociacion
            // 
            this.cmbAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsociacion.Font = new System.Drawing.Font("Calibri", 11F);
            this.cmbAsociacion.FormattingEnabled = true;
            this.cmbAsociacion.Location = new System.Drawing.Point(11, 51);
            this.cmbAsociacion.Name = "cmbAsociacion";
            this.cmbAsociacion.Size = new System.Drawing.Size(404, 30);
            this.cmbAsociacion.TabIndex = 16;
            this.cmbAsociacion.SelectedValueChanged += new System.EventHandler(this.cmbAsociacion_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre Asociación";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 29);
            this.textBox1.TabIndex = 0;
            // 
            // dgMedicosAsociacion
            // 
            this.dgMedicosAsociacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMedicosAsociacion.Location = new System.Drawing.Point(12, 137);
            this.dgMedicosAsociacion.Name = "dgMedicosAsociacion";
            this.dgMedicosAsociacion.RowTemplate.Height = 24;
            this.dgMedicosAsociacion.Size = new System.Drawing.Size(435, 380);
            this.dgMedicosAsociacion.TabIndex = 18;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Agency FB", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnGuardar.Location = new System.Drawing.Point(286, 540);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(161, 37);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // formAsociacionMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 589);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgMedicosAsociacion);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "formAsociacionMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asociacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicosAsociacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgMedicosAsociacion;
        private System.Windows.Forms.Button btnGuardar;
    }
}