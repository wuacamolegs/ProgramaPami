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
            this.lbl1Nombreapellido = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbAsociacion = new System.Windows.Forms.ComboBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbAfiliado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtBeneficio = new System.Windows.Forms.TextBox();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.dgAfiliados = new System.Windows.Forms.DataGridView();
            this.lbl1Documento = new System.Windows.Forms.Label();
            this.lbl1NroAfiliado = new System.Windows.Forms.Label();
            this.gbAfiliadoSeleccionado = new System.Windows.Forms.GroupBox();
            this.btn2Atras = new System.Windows.Forms.PictureBox();
            this.txt2Documento = new System.Windows.Forms.TextBox();
            this.txt2NroAfiliado = new System.Windows.Forms.TextBox();
            this.lbl2Documento = new System.Windows.Forms.Label();
            this.lbl2Afiliado = new System.Windows.Forms.Label();
            this.lbl2NyA = new System.Windows.Forms.Label();
            this.txt2NombreyApellido = new System.Windows.Forms.TextBox();
            this.sas = new System.Windows.Forms.GroupBox();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chOP = new System.Windows.Forms.CheckBox();
            this.cmbDiagnostico = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.dgPracticas = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbAfiliado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAfiliados)).BeginInit();
            this.gbAfiliadoSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn2Atras)).BeginInit();
            this.sas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPracticas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1Nombreapellido
            // 
            this.lbl1Nombreapellido.AutoSize = true;
            this.lbl1Nombreapellido.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Nombreapellido.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl1Nombreapellido.Location = new System.Drawing.Point(11, 50);
            this.lbl1Nombreapellido.Name = "lbl1Nombreapellido";
            this.lbl1Nombreapellido.Size = new System.Drawing.Size(153, 24);
            this.lbl1Nombreapellido.TabIndex = 16;
            this.lbl1Nombreapellido.Text = "Nombre y Apellido";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DarkCyan;
            this.label24.Location = new System.Drawing.Point(18, 38);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 24);
            this.label24.TabIndex = 23;
            this.label24.Text = "Fecha";
            // 
            // cmbAsociacion
            // 
            this.cmbAsociacion.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsociacion.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbAsociacion.FormattingEnabled = true;
            this.cmbAsociacion.Location = new System.Drawing.Point(6, 29);
            this.cmbAsociacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAsociacion.Name = "cmbAsociacion";
            this.cmbAsociacion.Size = new System.Drawing.Size(497, 30);
            this.cmbAsociacion.TabIndex = 0;
            this.cmbAsociacion.SelectedIndexChanged += new System.EventHandler(this.cmbAsociacion_SelectedIndexChanged);
            // 
            // cmbMedico
            // 
            this.cmbMedico.BackColor = System.Drawing.Color.White;
            this.cmbMedico.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(6, 29);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(497, 30);
            this.cmbMedico.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAsociacion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(533, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ASOCIACION";
            // 
            // gbAfiliado
            // 
            this.gbAfiliado.Controls.Add(this.btnBuscar);
            this.gbAfiliado.Controls.Add(this.txtDocumento);
            this.gbAfiliado.Controls.Add(this.txtBeneficio);
            this.gbAfiliado.Controls.Add(this.txtNombreApellido);
            this.gbAfiliado.Controls.Add(this.dgAfiliados);
            this.gbAfiliado.Controls.Add(this.lbl1Documento);
            this.gbAfiliado.Controls.Add(this.lbl1NroAfiliado);
            this.gbAfiliado.Controls.Add(this.lbl1Nombreapellido);
            this.gbAfiliado.Controls.Add(this.gbAfiliadoSeleccionado);
            this.gbAfiliado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbAfiliado.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAfiliado.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbAfiliado.Location = new System.Drawing.Point(12, 202);
            this.gbAfiliado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAfiliado.Name = "gbAfiliado";
            this.gbAfiliado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAfiliado.Size = new System.Drawing.Size(533, 423);
            this.gbAfiliado.TabIndex = 3;
            this.gbAfiliado.TabStop = false;
            this.gbAfiliado.Text = "AFILIADO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::PAMI.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(482, 131);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 37);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtDocumento.Location = new System.Drawing.Point(251, 139);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocumento.MaxLength = 15;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(220, 29);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtBeneficio
            // 
            this.txtBeneficio.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtBeneficio.Location = new System.Drawing.Point(13, 139);
            this.txtBeneficio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBeneficio.MaxLength = 14;
            this.txtBeneficio.Name = "txtBeneficio";
            this.txtBeneficio.Size = new System.Drawing.Size(217, 29);
            this.txtBeneficio.TabIndex = 1;
            this.txtBeneficio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBeneficio_KeyDown);
            this.txtBeneficio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBeneficio_KeyPress);
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtNombreApellido.Location = new System.Drawing.Point(13, 75);
            this.txtNombreApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreApellido.MaxLength = 60;
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(457, 29);
            this.txtNombreApellido.TabIndex = 0;
            this.txtNombreApellido.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged);
            this.txtNombreApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreApellido_KeyDown);
            this.txtNombreApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreApellido_KeyPress);
            // 
            // dgAfiliados
            // 
            this.dgAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAfiliados.Location = new System.Drawing.Point(15, 192);
            this.dgAfiliados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgAfiliados.Name = "dgAfiliados";
            this.dgAfiliados.RowTemplate.Height = 30;
            this.dgAfiliados.RowTemplate.ReadOnly = true;
            this.dgAfiliados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAfiliados.Size = new System.Drawing.Size(501, 216);
            this.dgAfiliados.TabIndex = 4;
            this.dgAfiliados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgAfiliados_KeyPress);
            // 
            // lbl1Documento
            // 
            this.lbl1Documento.AutoSize = true;
            this.lbl1Documento.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Documento.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl1Documento.Location = new System.Drawing.Point(246, 116);
            this.lbl1Documento.Name = "lbl1Documento";
            this.lbl1Documento.Size = new System.Drawing.Size(102, 24);
            this.lbl1Documento.TabIndex = 32;
            this.lbl1Documento.Text = "Documento";
            // 
            // lbl1NroAfiliado
            // 
            this.lbl1NroAfiliado.AutoSize = true;
            this.lbl1NroAfiliado.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1NroAfiliado.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl1NroAfiliado.Location = new System.Drawing.Point(11, 116);
            this.lbl1NroAfiliado.Name = "lbl1NroAfiliado";
            this.lbl1NroAfiliado.Size = new System.Drawing.Size(84, 24);
            this.lbl1NroAfiliado.TabIndex = 30;
            this.lbl1NroAfiliado.Text = "Beneficio";
            // 
            // gbAfiliadoSeleccionado
            // 
            this.gbAfiliadoSeleccionado.Controls.Add(this.btn2Atras);
            this.gbAfiliadoSeleccionado.Controls.Add(this.txt2Documento);
            this.gbAfiliadoSeleccionado.Controls.Add(this.txt2NroAfiliado);
            this.gbAfiliadoSeleccionado.Controls.Add(this.lbl2Documento);
            this.gbAfiliadoSeleccionado.Controls.Add(this.lbl2Afiliado);
            this.gbAfiliadoSeleccionado.Controls.Add(this.lbl2NyA);
            this.gbAfiliadoSeleccionado.Controls.Add(this.txt2NombreyApellido);
            this.gbAfiliadoSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbAfiliadoSeleccionado.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAfiliadoSeleccionado.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbAfiliadoSeleccionado.Location = new System.Drawing.Point(0, 0);
            this.gbAfiliadoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAfiliadoSeleccionado.Name = "gbAfiliadoSeleccionado";
            this.gbAfiliadoSeleccionado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAfiliadoSeleccionado.Size = new System.Drawing.Size(533, 423);
            this.gbAfiliadoSeleccionado.TabIndex = 0;
            this.gbAfiliadoSeleccionado.TabStop = false;
            this.gbAfiliadoSeleccionado.Text = "AFILIADO";
            // 
            // btn2Atras
            // 
            this.btn2Atras.Image = global::PAMI.Properties.Resources._81_at_blue_canvas_left;
            this.btn2Atras.Location = new System.Drawing.Point(456, 274);
            this.btn2Atras.Name = "btn2Atras";
            this.btn2Atras.Size = new System.Drawing.Size(33, 32);
            this.btn2Atras.TabIndex = 34;
            this.btn2Atras.TabStop = false;
            this.btn2Atras.Click += new System.EventHandler(this.btn2Atras_Click);
            // 
            // txt2Documento
            // 
            this.txt2Documento.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txt2Documento.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt2Documento.Location = new System.Drawing.Point(269, 228);
            this.txt2Documento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt2Documento.MaxLength = 15;
            this.txt2Documento.Name = "txt2Documento";
            this.txt2Documento.Size = new System.Drawing.Size(220, 29);
            this.txt2Documento.TabIndex = 3;
            // 
            // txt2NroAfiliado
            // 
            this.txt2NroAfiliado.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txt2NroAfiliado.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt2NroAfiliado.Location = new System.Drawing.Point(31, 228);
            this.txt2NroAfiliado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt2NroAfiliado.MaxLength = 14;
            this.txt2NroAfiliado.Name = "txt2NroAfiliado";
            this.txt2NroAfiliado.Size = new System.Drawing.Size(217, 29);
            this.txt2NroAfiliado.TabIndex = 2;
            // 
            // lbl2Documento
            // 
            this.lbl2Documento.AutoSize = true;
            this.lbl2Documento.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2Documento.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl2Documento.Location = new System.Drawing.Point(264, 205);
            this.lbl2Documento.Name = "lbl2Documento";
            this.lbl2Documento.Size = new System.Drawing.Size(102, 24);
            this.lbl2Documento.TabIndex = 32;
            this.lbl2Documento.Text = "Documento";
            // 
            // lbl2Afiliado
            // 
            this.lbl2Afiliado.AutoSize = true;
            this.lbl2Afiliado.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2Afiliado.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl2Afiliado.Location = new System.Drawing.Point(29, 205);
            this.lbl2Afiliado.Name = "lbl2Afiliado";
            this.lbl2Afiliado.Size = new System.Drawing.Size(136, 24);
            this.lbl2Afiliado.TabIndex = 30;
            this.lbl2Afiliado.Text = "Número Afiliado";
            // 
            // lbl2NyA
            // 
            this.lbl2NyA.AutoSize = true;
            this.lbl2NyA.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2NyA.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl2NyA.Location = new System.Drawing.Point(29, 139);
            this.lbl2NyA.Name = "lbl2NyA";
            this.lbl2NyA.Size = new System.Drawing.Size(153, 24);
            this.lbl2NyA.TabIndex = 16;
            this.lbl2NyA.Text = "Nombre y Apellido";
            // 
            // txt2NombreyApellido
            // 
            this.txt2NombreyApellido.Location = new System.Drawing.Point(33, 166);
            this.txt2NombreyApellido.Name = "txt2NombreyApellido";
            this.txt2NombreyApellido.Size = new System.Drawing.Size(456, 28);
            this.txt2NombreyApellido.TabIndex = 37;
            // 
            // sas
            // 
            this.sas.Controls.Add(this.txtOP);
            this.sas.Controls.Add(this.label1);
            this.sas.Controls.Add(this.chOP);
            this.sas.Controls.Add(this.cmbDiagnostico);
            this.sas.Controls.Add(this.label26);
            this.sas.Controls.Add(this.txtFecha);
            this.sas.Controls.Add(this.label24);
            this.sas.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sas.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.sas.Location = new System.Drawing.Point(551, 25);
            this.sas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sas.Name = "sas";
            this.sas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sas.Size = new System.Drawing.Size(504, 168);
            this.sas.TabIndex = 4;
            this.sas.TabStop = false;
            this.sas.Text = "AMBULATORIO";
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(288, 65);
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(189, 28);
            this.txtOP.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(210, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "OP";
            // 
            // chOP
            // 
            this.chOP.AutoSize = true;
            this.chOP.Location = new System.Drawing.Point(247, 69);
            this.chOP.Name = "chOP";
            this.chOP.Size = new System.Drawing.Size(18, 17);
            this.chOP.TabIndex = 1;
            this.chOP.UseVisualStyleBackColor = true;
            this.chOP.CheckedChanged += new System.EventHandler(this.chOP_CheckedChanged);
            // 
            // cmbDiagnostico
            // 
            this.cmbDiagnostico.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbDiagnostico.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.cmbDiagnostico.FormattingEnabled = true;
            this.cmbDiagnostico.Location = new System.Drawing.Point(22, 121);
            this.cmbDiagnostico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDiagnostico.Name = "cmbDiagnostico";
            this.cmbDiagnostico.Size = new System.Drawing.Size(455, 30);
            this.cmbDiagnostico.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.DarkCyan;
            this.label26.Location = new System.Drawing.Point(18, 95);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 24);
            this.label26.TabIndex = 27;
            this.label26.Text = "Diagnóstico";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Calibri Light", 10.8F);
            this.txtFecha.Location = new System.Drawing.Point(22, 64);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(149, 29);
            this.txtFecha.TabIndex = 0;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            this.txtFecha.Leave += new System.EventHandler(this.txtFecha_Leave);
            // 
            // dgPracticas
            // 
            this.dgPracticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPracticas.Location = new System.Drawing.Point(22, 37);
            this.dgPracticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPracticas.Name = "dgPracticas";
            this.dgPracticas.RowTemplate.Height = 30;
            this.dgPracticas.Size = new System.Drawing.Size(472, 371);
            this.dgPracticas.TabIndex = 0;
            this.dgPracticas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPracticas_CellValueChanged);
            this.dgPracticas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgPracticas_EditingControlShowing);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnNuevo.Location = new System.Drawing.Point(894, 630);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(161, 37);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Aceptar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbMedico);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox3.Location = new System.Drawing.Point(12, 117);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(533, 76);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PROFESIONAL";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgPracticas);
            this.groupBox4.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox4.Location = new System.Drawing.Point(551, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 423);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PRACTICAS";
            // 
            // NuevoEditarAmbulatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 676);
            this.Controls.Add(this.gbAfiliado);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.sas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NuevoEditarAmbulatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Ambulatorio";
            this.Load += new System.EventHandler(this.NuevoAmbulatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbAfiliado.ResumeLayout(false);
            this.gbAfiliado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAfiliados)).EndInit();
            this.gbAfiliadoSeleccionado.ResumeLayout(false);
            this.gbAfiliadoSeleccionado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn2Atras)).EndInit();
            this.sas.ResumeLayout(false);
            this.sas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPracticas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl1Nombreapellido;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbAsociacion;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbAfiliado;
        private System.Windows.Forms.GroupBox sas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.Label lbl1Documento;
        private System.Windows.Forms.Label lbl1NroAfiliado;
        private System.Windows.Forms.DataGridView dgAfiliados;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtBeneficio;
        private System.Windows.Forms.ComboBox cmbDiagnostico;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView dgPracticas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chOP;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.GroupBox gbAfiliadoSeleccionado;
        private System.Windows.Forms.TextBox txt2Documento;
        private System.Windows.Forms.TextBox txt2NroAfiliado;
        private System.Windows.Forms.Label lbl2Documento;
        private System.Windows.Forms.Label lbl2Afiliado;
        private System.Windows.Forms.Label lbl2NyA;
        private System.Windows.Forms.PictureBox btn2Atras;
        private System.Windows.Forms.TextBox txt2NombreyApellido;
        private System.Windows.Forms.PictureBox btnBuscar;
    }
}