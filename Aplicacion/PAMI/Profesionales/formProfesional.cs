using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;

namespace PAMI.Profesionales
{
    public partial class formProfesional : Form
    {
        private Profesional unProfesional = new Profesional();

        public formProfesional()
        {
            InitializeComponent();
            Utilities.DropDownListManager.CargarCombo(cmbEspecialidad, unProfesional.ObtenerListadoEspecialidad(), "EspecialidadID", "Especialidad", false, "");
            cmbEspecialidad.SelectedIndex = -1;
        }
    
        internal void abrirParaEditar(Profesional prof)
        {
            unProfesional = prof;
            txtDocumento.Text = prof.Documento;
            txtMatricula.Text = prof.Matricula;
            txtNombre.Text = prof.Nombre;
            cmbDocumento.SelectedItem = prof.TipoDocumento;
            txtMatricula.Enabled = false;
            btnNuevo.Visible = false;
            cmbEspecialidad.SelectedValue = unProfesional.Especialidad;
        }


        #region eventos Keypress
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetrasYPuntuacion(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }
        #endregion

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    unProfesional.Nombre = txtNombre.Text;
                    unProfesional.TipoDocumento = cmbDocumento.SelectedItem.ToString();
                    unProfesional.Especialidad = cmbEspecialidad.SelectedValue.ToString();
                    unProfesional.Matricula = txtMatricula.Text;
                    unProfesional.Documento = txtDocumento.Text;
                    unProfesional.EditarProfesional();

                    MessageBox.Show("Editar Profesional:\n" + unProfesional.Nombre + "\nMatricula: " + unProfesional.Matricula);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.ValidarNulo(txtNombre.Text,"Nombre");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbDocumento.SelectedIndex,"Tipo Documento");
            strErrores = strErrores + Validator.ValidarNulo(txtDocumento.Text, "Documento");
            strErrores = strErrores + Validator.ValidarNulo(txtMatricula.Text, "Matricula");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbEspecialidad.SelectedIndex, "Especialidad");

            if (strErrores != "")
            {
                MessageBox.Show(strErrores);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    unProfesional.Nombre = txtNombre.Text;
                    unProfesional.TipoDocumento = cmbDocumento.SelectedItem.ToString();
                    unProfesional.Especialidad = cmbEspecialidad.SelectedValue.ToString();
                    unProfesional.Matricula = txtMatricula.Text;
                    unProfesional.Documento = txtDocumento.Text;

                    string prof = unProfesional.NuevoProfesional();

                    MessageBox.Show(prof);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
    }
}
