namespace PAMI.Profesionales
{
    partial class FacturacionAmbulatoriosExistentes
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.dgPlanilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAnio);
            this.groupBox3.Controls.Add(this.cmbMes);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox3.Location = new System.Drawing.Point(11, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 83);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PERIODO";
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(292, 36);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(94, 32);
            this.txtAnio.TabIndex = 5;
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Font = new System.Drawing.Font("Calibri Light", 13.8F);
            this.cmbMes.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "11"});
            this.cmbMes.Location = new System.Drawing.Point(60, 33);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(169, 36);
            this.cmbMes.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(245, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAsociacion);
            this.groupBox2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Location = new System.Drawing.Point(11, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 83);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ASOCIACION";
            // 
            // cmbAsociacion
            // 
            this.cmbAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsociacion.Font = new System.Drawing.Font("Calibri Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAsociacion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbAsociacion.FormattingEnabled = true;
            this.cmbAsociacion.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbAsociacion.Location = new System.Drawing.Point(6, 36);
            this.cmbAsociacion.Name = "cmbAsociacion";
            this.cmbAsociacion.Size = new System.Drawing.Size(391, 36);
            this.cmbAsociacion.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMedico);
            this.groupBox1.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(11, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROFESIONAL";
            // 
            // cmbMedico
            // 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Font = new System.Drawing.Font("Calibri Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedico.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbMedico.Location = new System.Drawing.Point(6, 36);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(391, 36);
            this.cmbMedico.TabIndex = 0;
            this.cmbMedico.SelectedIndexChanged += new System.EventHandler(this.cmbMedico_SelectedIndexChanged);
            // 
            // dgPlanilla
            // 
            this.dgPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlanilla.Location = new System.Drawing.Point(464, 30);
            this.dgPlanilla.Margin = new System.Windows.Forms.Padding(4);
            this.dgPlanilla.Name = "dgPlanilla";
            this.dgPlanilla.RowTemplate.Height = 30;
            this.dgPlanilla.Size = new System.Drawing.Size(897, 350);
            this.dgPlanilla.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::PAMI.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(363, 331);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 37);
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FacturacionAmbulatoriosExistentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 393);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgPlanilla);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FacturacionAmbulatoriosExistentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FacturacionAmbulatoriosExistentes";
            this.Load += new System.EventHandler(this.FacturacionAmbulatoriosExistentes_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.DataGridView dgPlanilla;
        private System.Windows.Forms.PictureBox btnBuscar;
    }
}