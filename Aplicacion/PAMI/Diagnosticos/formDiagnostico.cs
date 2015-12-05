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
            cmbAsociacion.SelectedIndex = Convert.ToInt32(diag.Asociacion);
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

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            cmbAsociacion.SelectedIndex = -1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    unDiagnostico.Codigo = txtCodigo.Text;
                    unDiagnostico.Descripcion = txtDescripcion.Text;
                    unDiagnostico.Asociacion = cmbAsociacion.SelectedIndex;
                    unDiagnostico.Editar();
                    MessageBox.Show("Editado Correctamente", "Editar Diagnóstico");
                }

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
                if (validarCampos())
                {
                    unDiagnostico.Codigo = txtCodigo.Text;
                    unDiagnostico.Descripcion = txtDescripcion.Text;
                    unDiagnostico.Asociacion = cmbAsociacion.SelectedIndex;
                    unDiagnostico.Nuevo();
                    MessageBox.Show("Nuevo Diagnostico", "Nuevo Diagnóstico");
                    limpiar();
                }
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

        private bool validarCampos()
        {
            string strErrores = "";
            strErrores = strErrores + Utilities.Validator.validarNuloEnComboBox(cmbAsociacion.SelectedIndex, "Asociación");
            strErrores = strErrores + Utilities.Validator.ValidarNulo(txtCodigo.Text,"Código");
            strErrores = strErrores + Utilities.Validator.ValidarNulo(txtDescripcion.Text, "Descripcion");
            if (strErrores != "") { MessageBox.Show(strErrores); }
            return strErrores == "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Está seguro?", "Eliminar Diagnóstico", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    unDiagnostico.Codigo = txtCodigo.Text;
                    unDiagnostico.EliminarDiagnostico();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error");
            }
        }
    }
}
