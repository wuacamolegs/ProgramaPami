namespace PAMI.Ambulatorio
{
    partial class AmbulatorioExistente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbulatorioExistente));
            this.label1 = new System.Windows.Forms.Label();
            this.dgAmbulatorios = new System.Windows.Forms.DataGridView();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnSI = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAmbulatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ya existen los ambulatorios:";
            // 
            // dgAmbulatorios
            // 
            this.dgAmbulatorios.AllowUserToAddRows = false;
            this.dgAmbulatorios.AllowUserToDeleteRows = false;
            this.dgAmbulatorios.AllowUserToResizeRows = false;
            this.dgAmbulatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAmbulatorios.Location = new System.Drawing.Point(22, 47);
            this.dgAmbulatorios.Name = "dgAmbulatorios";
            this.dgAmbulatorios.RowTemplate.Height = 30;
            this.dgAmbulatorios.RowTemplate.ReadOnly = true;
            this.dgAmbulatorios.Size = new System.Drawing.Size(796, 247);
            this.dgAmbulatorios.TabIndex = 1;
            this.dgAmbulatorios.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgAmbulatorios_RowPrePaint);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnNo.Location = new System.Drawing.Point(657, 336);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(161, 37);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnSI
            // 
            this.btnSI.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSI.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnSI.Location = new System.Drawing.Point(490, 336);
            this.btnSI.Name = "btnSI";
            this.btnSI.Size = new System.Drawing.Size(161, 37);
            this.btnSI.TabIndex = 3;
            this.btnSI.Text = "SI";
            this.btnSI.UseVisualStyleBackColor = true;
            this.btnSI.Click += new System.EventHandler(this.btnSI_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(420, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desea agregarlos a los ambulatorios existentes?";
            // 
            // AmbulatorioExistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 385);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSI);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.dgAmbulatorios);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AmbulatorioExistente";
            this.Text = "Ambulatorios Existentes";
            ((System.ComponentModel.ISupportInitialize)(this.dgAmbulatorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAmbulatorios;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnSI;
        private System.Windows.Forms.Label label2;
    }
}