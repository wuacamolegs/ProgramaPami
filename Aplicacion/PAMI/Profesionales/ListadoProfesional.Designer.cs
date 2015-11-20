namespace PAMI.Profesionales
{
    partial class ListadoProfesional
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
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgProfesionales = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEspecialidad);
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.txtMatricula);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 145);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DisplayMember = "\"Value\"";
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Font = new System.Drawing.Font("Calibri Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(373, 40);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(289, 30);
            this.cmbEspecialidad.TabIndex = 24;
            this.cmbEspecialidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEspecialidad_KeyDown);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(11, 99);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(121, 32);
            this.cmbTipoDoc.TabIndex = 23;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Calibri Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(151, 101);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(204, 29);
            this.txtDocumento.TabIndex = 22;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Calibri Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(373, 100);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(289, 29);
            this.txtMatricula.TabIndex = 20;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Calibri Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(11, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(344, 29);
            this.txtNombre.TabIndex = 10;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(7, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tipo Doc.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(149, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(369, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Especialidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(369, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Matricula Nacional";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre y Apellido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscar.Location = new System.Drawing.Point(708, 97);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(161, 37);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpiar.Location = new System.Drawing.Point(708, 51);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(161, 37);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminar.Location = new System.Drawing.Point(541, 693);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 37);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNuevo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnNuevo.Location = new System.Drawing.Point(12, 693);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(161, 37);
            this.btnNuevo.TabIndex = 32;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditar.Location = new System.Drawing.Point(708, 693);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(161, 37);
            this.btnEditar.TabIndex = 33;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgProfesionales
            // 
            this.dgProfesionales.AllowUserToAddRows = false;
            this.dgProfesionales.AllowUserToDeleteRows = false;
            this.dgProfesionales.AllowUserToOrderColumns = true;
            this.dgProfesionales.AllowUserToResizeRows = false;
            this.dgProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfesionales.Location = new System.Drawing.Point(12, 156);
            this.dgProfesionales.Name = "dgProfesionales";
            this.dgProfesionales.RowTemplate.Height = 30;
            this.dgProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfesionales.Size = new System.Drawing.Size(857, 519);
            this.dgProfesionales.TabIndex = 34;
            // 
            // ListadoProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(890, 742);
            this.Controls.Add(this.dgProfesionales);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ListadoProfesional";
            this.Text = "ListadoProfesional";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgProfesionales;
    }
}