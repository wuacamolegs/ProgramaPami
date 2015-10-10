namespace PAMI.Ambulatorio
{
    partial class NuevoEditarAmbulatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoEditarAmbulatorio));
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtBeneficio = new System.Windows.Forms.TextBox();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.dgAfiliados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.sas = new System.Windows.Forms.GroupBox();
            this.dgPracticas = new System.Windows.Forms.DataGridView();
            this.cmbDiagnostico = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAfiliados)).BeginInit();
            this.sas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPracticas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asociación";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkCyan;
            this.label17.Location = new System.Drawing.Point(11, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(153, 24);
            this.label17.TabIndex = 16;
            this.label17.Text = "Nombre y Apellido";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkCyan;
            this.label18.Location = new System.Drawing.Point(11, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 24);
            this.label18.TabIndex = 17;
            this.label18.Text = "Médico";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DarkCyan;
            this.label24.Location = new System.Drawing.Point(11, 186);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 24);
            this.label24.TabIndex = 23;
            this.label24.Text = "Fecha";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkCyan;
            this.label25.Location = new System.Drawing.Point(11, 286);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 24);
            this.label25.TabIndex = 24;
            this.label25.Text = "Prácticas";
            // 
            // cmbAsociacion
            // 
            this.cmbAsociacion.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsociacion.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbAsociacion.FormattingEnabled = true;
            this.cmbAsociacion.Location = new System.Drawing.Point(15, 42);
            this.cmbAsociacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAsociacion.Name = "cmbAsociacion";
            this.cmbAsociacion.Size = new System.Drawing.Size(456, 30);
            this.cmbAsociacion.TabIndex = 1;
            this.cmbAsociacion.SelectedIndexChanged += new System.EventHandler(this.cmbAsociacion_SelectedIndexChanged);
            // 
            // cmbMedico
            // 
            this.cmbMedico.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(15, 105);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(456, 30);
            this.cmbMedico.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMedico);
            this.groupBox1.Controls.Add(this.cmbAsociacion);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(13, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(533, 143);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtDocumento);
            this.groupBox2.Controls.Add(this.txtBeneficio);
            this.groupBox2.Controls.Add(this.txtNombreApellido);
            this.groupBox2.Controls.Add(this.dgAfiliados);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Location = new System.Drawing.Point(13, 169);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(533, 526);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Afiliado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(488, 132);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 25);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtDocumento.Location = new System.Drawing.Point(251, 130);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocumento.MaxLength = 15;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(220, 29);
            this.txtDocumento.TabIndex = 36;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtBeneficio
            // 
            this.txtBeneficio.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtBeneficio.Location = new System.Drawing.Point(13, 130);
            this.txtBeneficio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBeneficio.MaxLength = 14;
            this.txtBeneficio.Name = "txtBeneficio";
            this.txtBeneficio.Size = new System.Drawing.Size(217, 29);
            this.txtBeneficio.TabIndex = 35;
            this.txtBeneficio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBeneficio_KeyPress);
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtNombreApellido.Location = new System.Drawing.Point(13, 66);
            this.txtNombreApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreApellido.MaxLength = 60;
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(457, 29);
            this.txtNombreApellido.TabIndex = 34;
            this.txtNombreApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreApellido_KeyPress);
            // 
            // dgAfiliados
            // 
            this.dgAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAfiliados.Location = new System.Drawing.Point(13, 175);
            this.dgAfiliados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgAfiliados.Name = "dgAfiliados";
            this.dgAfiliados.RowTemplate.Height = 24;
            this.dgAfiliados.Size = new System.Drawing.Size(501, 334);
            this.dgAfiliados.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(247, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "Documento";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DarkCyan;
            this.label27.Location = new System.Drawing.Point(11, 98);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 24);
            this.label27.TabIndex = 30;
            this.label27.Text = "Beneficio";
            // 
            // sas
            // 
            this.sas.Controls.Add(this.dgPracticas);
            this.sas.Controls.Add(this.cmbDiagnostico);
            this.sas.Controls.Add(this.label26);
            this.sas.Controls.Add(this.maskedTextBox1);
            this.sas.Controls.Add(this.label25);
            this.sas.Controls.Add(this.label24);
            this.sas.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sas.ForeColor = System.Drawing.Color.DarkCyan;
            this.sas.Location = new System.Drawing.Point(563, 17);
            this.sas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sas.Name = "sas";
            this.sas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sas.Size = new System.Drawing.Size(489, 677);
            this.sas.TabIndex = 36;
            this.sas.TabStop = false;
            this.sas.Text = "AMBULATORIO";
            // 
            // dgPracticas
            // 
            this.dgPracticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPracticas.Location = new System.Drawing.Point(13, 327);
            this.dgPracticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPracticas.Name = "dgPracticas";
            this.dgPracticas.RowTemplate.Height = 24;
            this.dgPracticas.Size = new System.Drawing.Size(457, 332);
            this.dgPracticas.TabIndex = 38;
            this.dgPracticas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPracticas_CellValueChanged);
            this.dgPracticas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgPracticas_EditingControlShowing);
            // 
            // cmbDiagnostico
            // 
            this.cmbDiagnostico.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagnostico.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbDiagnostico.FormattingEnabled = true;
            this.cmbDiagnostico.Location = new System.Drawing.Point(15, 102);
            this.cmbDiagnostico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDiagnostico.Name = "cmbDiagnostico";
            this.cmbDiagnostico.Size = new System.Drawing.Size(455, 30);
            this.cmbDiagnostico.TabIndex = 26;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.DarkCyan;
            this.label26.Location = new System.Drawing.Point(11, 76);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 24);
            this.label26.TabIndex = 27;
            this.label26.Text = "Diagnóstico";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.maskedTextBox1.Location = new System.Drawing.Point(15, 219);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(113, 29);
            this.maskedTextBox1.TabIndex = 25;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnNuevo.Location = new System.Drawing.Point(872, 718);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(161, 37);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // NuevoEditarAmbulatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 766);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.sas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NuevoEditarAmbulatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Ambulatorio";
            this.Load += new System.EventHandler(this.NuevoAmbulatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAfiliados)).EndInit();
            this.sas.ResumeLayout(false);
            this.sas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPracticas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox sas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridView dgAfiliados;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtBeneficio;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.ComboBox cmbDiagnostico;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView dgPracticas;
    }
}