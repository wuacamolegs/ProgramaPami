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
using Utilities;

namespace PAMI.Afiliados
{
    public partial class formAfiliado : Form
    {

        #region variables

        private Afiliado unAfiliado = new Afiliado();

        #endregion

        #region initialize

        public formAfiliado()
        {
            InitializeComponent();
        }

        public void abrirParaEditar(Afiliado afiliado)
        {
            try
            {
                this.Text = "Editar Afiliado";
                btnNuevo.Visible = false;
                btnGuardar.Visible = true;
                txtApellidoNombre.Text = afiliado.Nombre;
                txtBeneficio.Text = afiliado.Beneficio.ToString();
                txtParentesco.Text = afiliado.Parentesco.ToString();
                txtDocumento.Text = afiliado.Documento.ToString();
                txtFechaNacimiento.Text = afiliado.FechaNacimiento.ToString();
                cmbSexo.SelectedItem = afiliado.Sexo;
                cmbTipoDocumento.SelectedItem = afiliado.TipoDocumento;

                txtBeneficio.Enabled = false;
                txtParentesco.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        
        public void abrirNuevo()
        {
            btnGuardar.Visible = false;
            btnNuevo.Visible = true;
            cmbSexo.BackColor = Color.White;
        }

        #endregion

        #region botones

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          try
          {
               if (cargarDatosAunAfiliado())
               {
                   if (unAfiliado.NuevoAfiliado())
                   {
                       MessageBox.Show("Nuevo Afiliado: \n\nNombre: " + unAfiliado.Nombre +
                       "\nBeneficio: " + unAfiliado.Beneficio + " " + unAfiliado.Parentesco +
                       "\nDocumento: " + unAfiliado.TipoDocumento + " " + unAfiliado.Documento +
                       "\nFecha Nacimiento: " + unAfiliado.FechaNacimiento, "Nuevo Afiliado");
                       this.Close();
                   }
                   else
                   {
                       DialogResult result = MessageBox.Show("El Afiliado ya existe: \n\nNombre: " + unAfiliado.Nombre +
                       "\nBeneficio: " + unAfiliado.Beneficio + " " + unAfiliado.Parentesco +
                       "\nDocumento: " + unAfiliado.TipoDocumento + " " + unAfiliado.Documento +
                       "\nFecha Nacimiento: " + unAfiliado.FechaNacimiento + "\n\n Presione SI para editar", "Afiliado ya existe", MessageBoxButtons.YesNo);

                       if (result == DialogResult.Yes)
                       {
                           //Saque el this.traerAfiliadoPorBeneficio porque ya en nuevoAfiliado me hace el data row. 
                           //fijarme si no rompe esto.
                           this.abrirParaEditar(unAfiliado);
                       }
                       if (result == DialogResult.No)
                       {
                           this.Close();
                       }
                   }
               }
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoEntidadException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cargarDatosAunAfiliado())
                {
                    unAfiliado.UpdateAfiliado();
                    MessageBox.Show("Se actualizaron los datos de: \n\nNombre: " + unAfiliado.Nombre +
                        "\nBeneficio: " + unAfiliado.Beneficio + " " + unAfiliado.Parentesco +
                        "\nDocumento: " + unAfiliado.TipoDocumento + " " + unAfiliado.Documento +
                        "\nFecha Nacimiento: " + unAfiliado.FechaNacimiento, "Editar Afiliado");
                    this.Close();
                }
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoEntidadException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region metodos privados

        private bool cargarDatosAunAfiliado()
        {
            try
            {
                string validacion = validarCampos();
                if (validacion != "")
                {
                    MessageBox.Show(validacion, "Faltan Datos");
                    return false;
                }
                else
                {
                    unAfiliado.Nombre = txtApellidoNombre.Text;
                    unAfiliado.Beneficio = Convert.ToInt64(txtBeneficio.Text);
                    unAfiliado.Parentesco = txtParentesco.Text;
                    unAfiliado.Documento = Convert.ToInt64(txtDocumento.Text);
                    unAfiliado.FechaNacimiento = txtFechaNacimiento.Text;
                    unAfiliado.Sexo = cmbSexo.SelectedItem.ToString();
                    unAfiliado.TipoDocumento = cmbTipoDocumento.SelectedItem.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private string validarCampos()
        {
            string strErrores = "";
            try
            {
                strErrores = strErrores + Validator.ValidarNulo(txtApellidoNombre.Text, "Nombre y Apellido");
                strErrores = strErrores + Validator.ValidarNulo(txtBeneficio.Text, "Beneficio");
                if (txtBeneficio.Text != "")
                {
                    strErrores = strErrores + Validator.ValidarEsBeneficio(txtBeneficio.Text, "Beneficio");
                }
                strErrores = strErrores + Validator.ValidarNulo(txtParentesco.Text, "Parentesco");
                if (txtParentesco.Text != "")
                {
                    strErrores = strErrores + Validator.ValidarEsParentesco(txtParentesco.Text, "Parentesco");
                }
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbTipoDocumento.SelectedIndex, "Tipo Documento");
                strErrores = strErrores + Validator.ValidarNulo(txtDocumento.Text, "Numero Documento");
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbSexo.SelectedIndex, "Sexo");
                strErrores = strErrores + Validator.ValidarFecha(txtFechaNacimiento.Text, "Fecha Nacimiento");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strErrores;
        }

        #endregion

        #region eventos

        private void txtBeneficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtParentesco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtApellidoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        

        #endregion

        private void formAfiliado_Load(object sender, EventArgs e)
        {
            cmbSexo.ForeColor = SystemColors.WindowText;
        }


    }
}
