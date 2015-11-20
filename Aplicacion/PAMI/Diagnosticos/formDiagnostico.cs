using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;

namespace PAMI.Diagnosticos
{
    public partial class formDiagnostico : Form
    {
        Diagnostico unDiagnostico = new Diagnostico();

        public formDiagnostico()
        {
            InitializeComponent();
        }

        internal void abrirParaEditar(Diagnostico diag)
        {
            txtCodigo.Text = diag.Codigo;
            txtDescripcion.Text = diag.Descripcion;
            txtCodigo.Enabled = false;
            btnEditar.Visible = true;
            btnNuevo.Visible = false;
        }

        internal void abrirParaNuevo()
        {
            btnEditar.Visible = false;
            btnNuevo.Visible = true;
            txtCodigo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                unDiagnostico.Codigo = txtCodigo.Text;
                unDiagnostico.Descripcion = txtDescripcion.Text;
                unDiagnostico.Editar();
                MessageBox.Show("Editado Correctamente", "Editar Diagnóstico");
                this.Close();
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                unDiagnostico.Codigo = txtCodigo.Text;
                unDiagnostico.Descripcion = txtDescripcion.Text;
                unDiagnostico.Nuevo();  //TODO AGREGAR ASOCIACION!!!!
                MessageBox.Show("Nuevo Diagnostico", "Nuevo Diagnóstico");
                this.Close();
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
