namespace PAMI.PlanillaPami
{
    partial class formPlanilla
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
            this.dgPlanilla = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.gbProfesional = new System.Windows.Forms.GroupBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.gbAsociacion = new System.Windows.Forms.GroupBox();
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.gbAfiliado = new System.Windows.Forms.GroupBox();
            this.txtBeneficio = new System.Windows.Forms.TextBox();
            this.lblCantAmbulatorios = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilla)).BeginInit();
            this.gbProfesional.SuspendLayout();
            this.gbAsociacion.SuspendLayout();
            this.gbPeriodo.SuspendLayout();
            this.gbAfiliado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPlanilla
            // 
            this.dgPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlanilla.Location = new System.Drawing.Point(13, 189);
            this.dgPlanilla.Margin = new System.Windows.Forms.Padding(4);
            this.dgPlanilla.Name = "dgPlanilla";
            this.dgPlanilla.RowTemplate.Height = 30;
            this.dgPlanilla.Size = new System.Drawing.Size(1515, 539);
            this.dgPlanilla.TabIndex = 0;
            this.dgPlanilla.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPlanilla_CellContentDoubleClick);
            this.dgPlanilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPlanilla_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // cmbMes
            // 
            this.cmbMes.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // gbProfesional
            // 
            this.gbProfesional.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbProfesional.Controls.Add(this.cmbMedico);
            this.gbProfesional.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProfesional.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbProfesional.Location = new System.Drawing.Point(567, 12);
            this.gbProfesional.Name = "gbProfesional";
            this.gbProfesional.Size = new System.Drawing.Size(549, 83);
            this.gbProfesional.TabIndex = 5;
            this.gbProfesional.TabStop = false;
            this.gbProfesional.Text = "PROFESIONAL";
            this.gbProfesional.SizeChanged += new System.EventHandler(this.gbProfesional_SizeChanged);
            // 
            // cmbMedico
            // 
            this.cmbMedico.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.cmbMedico.Size = new System.Drawing.Size(525, 36);
            this.cmbMedico.TabIndex = 0;
            // 
            // gbAsociacion
            // 
            this.gbAsociacion.Controls.Add(this.cmbAsociacion);
            this.gbAsociacion.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsociacion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbAsociacion.Location = new System.Drawing.Point(12, 12);
            this.gbAsociacion.Name = "gbAsociacion";
            this.gbAsociacion.Size = new System.Drawing.Size(549, 83);
            this.gbAsociacion.TabIndex = 6;
            this.gbAsociacion.TabStop = false;
            this.gbAsociacion.Text = "ASOCIACION";
            this.gbAsociacion.SizeChanged += new System.EventHandler(this.gbAsociacion_SizeChanged);
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
            this.cmbAsociacion.Size = new System.Drawing.Size(525, 36);
            this.cmbAsociacion.TabIndex = 0;
            this.cmbAsociacion.SelectedIndexChanged += new System.EventHandler(this.cmbAsociacion_SelectedIndexChanged);
            // 
            // gbPeriodo
            // 
            this.gbPeriodo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbPeriodo.Controls.Add(this.txtAnio);
            this.gbPeriodo.Controls.Add(this.cmbMes);
            this.gbPeriodo.Controls.Add(this.label3);
            this.gbPeriodo.Controls.Add(this.label2);
            this.gbPeriodo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPeriodo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbPeriodo.Location = new System.Drawing.Point(1135, 12);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Size = new System.Drawing.Size(392, 83);
            this.gbPeriodo.TabIndex = 7;
            this.gbPeriodo.TabStop = false;
            this.gbPeriodo.Text = "PERIODO";
            // 
            // txtAnio
            // 
            this.txtAnio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAnio.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(292, 36);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(94, 32);
            this.txtAnio.TabIndex = 5;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimpiar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpiar.Location = new System.Drawing.Point(13, 735);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(161, 37);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnValidar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnValidar.Location = new System.Drawing.Point(1367, 127);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(161, 37);
            this.btnValidar.TabIndex = 9;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImportar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnImportar.Location = new System.Drawing.Point(1195, 735);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(161, 37);
            this.btnImportar.TabIndex = 10;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCerrar.Location = new System.Drawing.Point(1366, 735);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(161, 37);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscar.Location = new System.Drawing.Point(1367, 127);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(161, 37);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEliminar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminar.Location = new System.Drawing.Point(12, 735);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 37);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSeleccionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSeleccionar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeleccionar.Location = new System.Drawing.Point(179, 735);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(181, 37);
            this.btnSeleccionar.TabIndex = 14;
            this.btnSeleccionar.Text = "Seleccionar Todos";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // gbAfiliado
            // 
            this.gbAfiliado.Controls.Add(this.txtBeneficio);
            this.gbAfiliado.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAfiliado.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbAfiliado.Location = new System.Drawing.Point(12, 101);
            this.gbAfiliado.Name = "gbAfiliado";
            this.gbAfiliado.Size = new System.Drawing.Size(549, 83);
            this.gbAfiliado.TabIndex = 7;
            this.gbAfiliado.TabStop = false;
            this.gbAfiliado.Text = "NRO BENEFICIO";
            this.gbAfiliado.SizeChanged += new System.EventHandler(this.gbAfiliado_SizeChanged);
            // 
            // txtBeneficio
            // 
            this.txtBeneficio.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtBeneficio.Location = new System.Drawing.Point(6, 34);
            this.txtBeneficio.Margin = new System.Windows.Forms.Padding(4);
            this.txtBeneficio.MaxLength = 14;
            this.txtBeneficio.Name = "txtBeneficio";
            this.txtBeneficio.Size = new System.Drawing.Size(524, 29);
            this.txtBeneficio.TabIndex = 5;
            // 
            // lblCantAmbulatorios
            // 
            this.lblCantAmbulatorios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantAmbulatorios.AutoSize = true;
            this.lblCantAmbulatorios.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCantAmbulatorios.Location = new System.Drawing.Point(860, 746);
            this.lblCantAmbulatorios.Name = "lblCantAmbulatorios";
            this.lblCantAmbulatorios.Size = new System.Drawing.Size(276, 20);
            this.lblCantAmbulatorios.TabIndex = 15;
            this.lblCantAmbulatorios.Text = "Cantidad Ambulatorios Importados: ";
            // 
            // formPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1534, 784);
            this.Controls.Add(this.lblCantAmbulatorios);
            this.Controls.Add(this.gbAfiliado);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.gbPeriodo);
            this.Controls.Add(this.gbAsociacion);
            this.Controls.Add(this.gbProfesional);
            this.Controls.Add(this.dgPlanilla);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planilla";
            this.Load += new System.EventHandler(this.Planilla_Load);
            this.SizeChanged += new System.EventHandler(this.formPlanilla_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilla)).EndInit();
            this.gbProfesional.ResumeLayout(false);
            this.gbAsociacion.ResumeLayout(false);
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.gbAfiliado.ResumeLayout(false);
            this.gbAfiliado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPlanilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.GroupBox gbProfesional;
        private System.Windows.Forms.GroupBox gbAsociacion;
        private System.Windows.Forms.GroupBox gbPeriodo;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.GroupBox gbAfiliado;
        private System.Windows.Forms.TextBox txtBeneficio;
        private System.Windows.Forms.Label lblCantAmbulatorios;
    }
}