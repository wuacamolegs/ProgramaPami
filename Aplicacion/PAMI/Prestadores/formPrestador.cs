using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using Excepciones;
using Clases;

namespace PAMI.Prestadores
{
    public partial class formPrestador : Form
    {

        public Prestador unPrestador = new Prestador();
        

        public formPrestador()
        {
            InitializeComponent();
            cmbNombre.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;

            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbNombre, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();
            cmbNombre.SelectedIndex = -1;
        }


        #region eventos keypress
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtFechaAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtBocaAtencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtNombreCorto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cargarDatosAunPrestador())
                {
                    if (unPrestador.NuevoPrestador())
                    {
                        MessageBox.Show("Nuevo Prestador: \n\nNombre: " + unPrestador.NombrePrestador +
                        "\nCuit: " + unPrestador.Cuit + "\nCódigo SAP: " + unPrestador.CodigoSap +
                        "\nUsuario: " + unPrestador.Usuario, "Nuevo Prestador");
                        this.Close();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("El Prestador ya existe. \n\nNombre: " + unPrestador.NombrePrestador +
                        "\nCuit: " + unPrestador.Cuit + "\nCódigo SAP: " + unPrestador.CodigoSap +
                        "\nUsuario: " + unPrestador.Usuario + "\n\n Presione SI para editar", "Prestador ya existe", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            //Saque el this.traerAfiliadoPorBeneficio porque ya en nuevoAfiliado me hace el data row. 
                            //fijarme si no rompe esto.
                            Editar();
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

        private void Editar()
        {


            btnEditar.Visible = true;
            btnEliminar.Visible = true;

            txtCuit.Enabled = false;
            txtBocaAtencion.Enabled = true;
            txtSap.Enabled = true;
            txtFechaAlta.Enabled = true;
            txtNombreCorto.Enabled = true;
            txtUsuario.Enabled = false;
            txtCalle.Enabled = true;
            txtNumero.Enabled = true;
            txtPiso.Enabled = true;
            txtDepto.Enabled = true;
            cmbTipoPrestador.Enabled = true;

            txtNombre.Text = unPrestador.NombrePrestador;
            txtCuit.Text = unPrestador.Cuit ;
            txtBocaAtencion.Text = unPrestador.BocaAtencion;
            txtSap.Text = unPrestador.CodigoSap;
            txtFechaAlta.Text = unPrestador.FechaAlta;
            txtNombreCorto.Text = unPrestador.NombreCortoPrestador;
            txtUsuario.Text = unPrestador.Usuario;
            txtCalle.Text = unPrestador.DireccionCalle;
            txtNumero.Text = unPrestador.DireccionNumero.ToString();
            txtPiso.Text = unPrestador.DireccionPiso.ToString();
            txtDepto.Text = unPrestador.DireccionDepto;
            cmbTipoPrestador.SelectedIndex = Convert.ToInt32(unPrestador.TipoPrestador);


        }

        private bool cargarDatosAunPrestador()
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
                    unPrestador.NombrePrestador = txtNombre.Text;
                    unPrestador.Cuit = txtCuit.Text;
                    unPrestador.BocaAtencion = txtBocaAtencion.Text;
                    unPrestador.CodigoSap = txtSap.Text;
                    unPrestador.FechaAlta = txtFechaAlta.Text;
                    unPrestador.NombreCortoPrestador = txtNombreCorto.Text;
                    unPrestador.Usuario = txtUsuario.Text;
                    unPrestador.DireccionCalle = txtCalle.Text;
                    unPrestador.DireccionNumero = Convert.ToInt64(txtNumero.Text);
                    if (txtPiso.Text == "") { unPrestador.DireccionPiso = 0; } else { unPrestador.DireccionPiso = Convert.ToInt64(txtPiso.Text); }          
                    unPrestador.DireccionDepto = txtDepto.Text;
                    unPrestador.TipoPrestador = cmbTipoPrestador.SelectedIndex;
                    
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
                strErrores = strErrores + Validator.ValidarNulo(txtNombre.Text, "Nombre Prestador");
                strErrores = strErrores + Validator.ValidarNulo(txtCuit.Text, "Cuit");
                strErrores = strErrores + Validator.ValidarNulo(txtBocaAtencion.Text, "Código Boca Atencion");
                strErrores = strErrores + Validator.ValidarNulo(txtSap.Text, "Código SAP");
                strErrores = strErrores + Validator.ValidarNulo(txtFechaAlta.Text, "Fecha Alta");
                strErrores = strErrores + Validator.ValidarNulo(txtNombreCorto.Text, "Nombre Corto");
                strErrores = strErrores + Validator.ValidarNulo(txtUsuario.Text, "Nombre Usuario");
                strErrores = strErrores + Validator.ValidarNulo(txtCalle.Text, "Calle");
                strErrores = strErrores + Validator.ValidarNulo(txtNumero.Text, "Número");
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbTipoPrestador.SelectedIndex, "Tipo Prestador");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strErrores;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbTipoPrestador.SelectedIndex != -1)
            {
                cargarDatosAunPrestador();
                unPrestador.UpdatePrestador();
                MessageBox.Show("Se ha editado con éxito. \n\nNombre: " + unPrestador.NombrePrestador +
                        "\nCuit: " + unPrestador.Cuit + "\nCódigo SAP: " + unPrestador.CodigoSap +
                        "\nUsuario: " + unPrestador.Usuario, "Editar Prestador");
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un Prestador a editar");
            }
        }

        internal void AbrirParaBuscar()
        {
            cmbNombre.Visible = true;
            btnNuevo.Visible = false;
            txtNombre.Visible = false;
            txtCuit.Enabled = false;
            txtBocaAtencion.Enabled = false;
            txtSap.Enabled = false;
            txtFechaAlta.Enabled = false;
            txtNombreCorto.Enabled = false;
            txtUsuario.Enabled = false;
            txtCalle.Enabled = false;
            txtNumero.Enabled = false;
            txtPiso.Enabled = false;
            txtDepto.Enabled = false;
            cmbTipoPrestador.Enabled = false;
        }

        private void cmbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombre.SelectedIndex != -1 && cmbNombre.Enabled.ToString() == "True")
            {
                MessageBox.Show(cmbNombre.SelectedIndex.ToString());
                unPrestador.TraerListadoPorAsociacionID(cmbNombre.SelectedIndex);
                Editar();
            }
        }
    }
}
