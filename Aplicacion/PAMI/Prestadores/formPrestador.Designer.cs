namespace PAMI.Prestadores
{
    partial class formPrestador
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtSap = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoPrestador = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFechaAlta = new System.Windows.Forms.MaskedTextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNombreCorto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBocaAtencion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(7, 52);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(477, 29);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtNumero.Location = new System.Drawing.Point(257, 69);
            this.txtNumero.MaxLength = 5;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 29);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtCalle.Location = new System.Drawing.Point(11, 69);
            this.txtCalle.MaxLength = 30;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(240, 29);
            this.txtCalle.TabIndex = 2;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // txtSap
            // 
            this.txtSap.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtSap.Location = new System.Drawing.Point(197, 132);
            this.txtSap.MaxLength = 5;
            this.txtSap.Name = "txtSap";
            this.txtSap.Size = new System.Drawing.Size(287, 29);
            this.txtSap.TabIndex = 3;
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtCuit.Location = new System.Drawing.Point(510, 52);
            this.txtCuit.MaxLength = 15;
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(281, 29);
            this.txtCuit.TabIndex = 5;
            this.txtCuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre Prestador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(253, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Número";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(506, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo Prestador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(193, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Código SAP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(7, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Calle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(506, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cuit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(7, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha de Alta";
            // 
            // cmbTipoPrestador
            // 
            this.cmbTipoPrestador.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPrestador.FormattingEnabled = true;
            this.cmbTipoPrestador.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbTipoPrestador.Location = new System.Drawing.Point(510, 129);
            this.cmbTipoPrestador.Name = "cmbTipoPrestador";
            this.cmbTipoPrestador.Size = new System.Drawing.Size(281, 32);
            this.cmbTipoPrestador.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFechaAlta);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtNombreCorto);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBocaAtencion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbTipoPrestador);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCuit);
            this.groupBox1.Controls.Add(this.txtSap);
            this.groupBox1.Controls.Add(this.cmbNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 318);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtFechaAlta.Location = new System.Drawing.Point(7, 210);
            this.txtFechaAlta.Mask = "00/00/0000";
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.Size = new System.Drawing.Size(160, 29);
            this.txtFechaAlta.TabIndex = 23;
            this.txtFechaAlta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaAlta_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtUsuario.Location = new System.Drawing.Point(510, 210);
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(281, 29);
            this.txtUsuario.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkCyan;
            this.label13.Location = new System.Drawing.Point(506, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 24);
            this.label13.TabIndex = 21;
            this.label13.Text = "Usuario";
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtNombreCorto.Location = new System.Drawing.Point(197, 210);
            this.txtNombreCorto.MaxLength = 30;
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(287, 29);
            this.txtNombreCorto.TabIndex = 20;
            this.txtNombreCorto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCorto_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkCyan;
            this.label12.Location = new System.Drawing.Point(193, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 24);
            this.label12.TabIndex = 19;
            this.label12.Text = "Prestador Nombre Corto";
            // 
            // txtBocaAtencion
            // 
            this.txtBocaAtencion.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtBocaAtencion.Location = new System.Drawing.Point(7, 131);
            this.txtBocaAtencion.MaxLength = 5;
            this.txtBocaAtencion.Name = "txtBocaAtencion";
            this.txtBocaAtencion.Size = new System.Drawing.Size(160, 29);
            this.txtBocaAtencion.TabIndex = 18;
            this.txtBocaAtencion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBocaAtencion_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkCyan;
            this.label11.Location = new System.Drawing.Point(7, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 24);
            this.label11.TabIndex = 17;
            this.label11.Text = "Código Boca Atención";
            // 
            // cmbNombre
            // 
            this.cmbNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNombre.Font = new System.Drawing.Font("Calibri", 11F);
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Location = new System.Drawing.Point(7, 52);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(477, 30);
            this.cmbNombre.TabIndex = 16;
            this.cmbNombre.SelectedIndexChanged += new System.EventHandler(this.cmbNombre_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDepto);
            this.groupBox2.Controls.Add(this.txtPiso);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCalle);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Location = new System.Drawing.Point(5, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 167);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Direccion";
            // 
            // txtDepto
            // 
            this.txtDepto.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepto.Location = new System.Drawing.Point(136, 128);
            this.txtDepto.MaxLength = 5;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(115, 29);
            this.txtDepto.TabIndex = 15;
            // 
            // txtPiso
            // 
            this.txtPiso.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPiso.Location = new System.Drawing.Point(11, 128);
            this.txtPiso.MaxLength = 2;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(115, 29);
            this.txtPiso.TabIndex = 14;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPiso_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(7, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "Piso";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(132, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "Departamento";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnNuevo.Location = new System.Drawing.Point(656, 451);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(161, 37);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Agency FB", 12F);
            this.btnEditar.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnEditar.Location = new System.Drawing.Point(656, 451);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(161, 37);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Agency FB", 12F);
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnEliminar.Location = new System.Drawing.Point(656, 408);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 37);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtMail.Location = new System.Drawing.Point(11, 282);
            this.txtMail.MaxLength = 30;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(473, 29);
            this.txtMail.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(7, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mail Prestador";
            // 
            // formPrestador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(827, 500);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "formPrestador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtSap;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoPrestador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBocaAtencion;
        private System.Windows.Forms.TextBox txtNombreCorto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtFechaAlta;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
    }
}