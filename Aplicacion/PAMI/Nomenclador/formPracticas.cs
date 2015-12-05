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


namespace PAMI.Nomenclador
{
    public partial class formPracticas : Form
    {
        Practica unaPractica = new Practica();

        public formPracticas()
        {
            InitializeComponent();
            btnEditar.Visible = false;
        }

        internal void abrirParaEditar(Practica unaPractica)
        {
            this.Text = "Editar Práctica";
 
           try
            {
                btnNuevo.Visible = false;
                btnEditar.Visible = true;
                
                txtCodigo.Text = unaPractica.Codigo;
                txtDescripcion.Text = unaPractica.Descripcion;
                txtCantMax.Text = unaPractica.CantMaxima.ToString();
                txtModulo.Text = unaPractica.Modulo.ToString();

                txtCodigo.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            } 

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtModulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtCantMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cargarDatosAunaPractica())
                {
                    if (unaPractica.NuevaPractica())
                    {
                        MessageBox.Show("Nueva Práctica: \n\nCódigo: " + unaPractica.Codigo + 
                                        "\nMódulo: " + unaPractica.Modulo +
                                        "\nDescripción: " + unaPractica.Descripcion +
                                        "\nCantidad Máxima: " + unaPractica.CantMaxima
                                        ,"Nueva Práctica");
                        limpiar();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Ya existe una práctica con este código: " + unaPractica.Codigo +
                                        "\nMódulo: " + unaPractica.Modulo +
                                        "\nDescripción: " + unaPractica.Descripcion +
                                        "\nCantidad Máxima: " + unaPractica.CantMaxima +
                                        "\n\n Presione SI para editar", "Práctica " + unaPractica.Codigo + " ya existe", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            this.abrirParaEditar(unaPractica);
                        }
                        if (result == DialogResult.No)
                        {
                            limpiar();
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

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCantMax.Text = "";
            txtModulo.Text = "";
        }

        private bool cargarDatosAunaPractica()
        {
            if (validarCampos())
            {
                unaPractica.Codigo = txtCodigo.Text;
                unaPractica.Descripcion = txtDescripcion.Text;
                unaPractica.Modulo = Convert.ToInt64(txtModulo.Text);
                unaPractica.CantMaxima = Convert.ToInt64(txtCantMax.Text);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validarCampos()
        {
            string strErrores = "";

            strErrores = Validator.ValidarNulo(txtCodigo.Text, "Código");
            strErrores = strErrores + Validator.ValidarNulo(txtDescripcion.Text, "Descripción");
            strErrores = strErrores + Validator.ValidarNulo(txtModulo.Text, "Módulo");
            strErrores = strErrores + Validator.ValidarNulo(txtCantMax.Text, "Cantidad Maxima");

            if (strErrores != "")
            {
                MessageBox.Show(strErrores, "");
                return false;
            }
            else { return true; }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cargarDatosAunaPractica())
                {
                    unaPractica.Update();
                    MessageBox.Show("Se ha editado la práctica: " + unaPractica.Codigo + "\n" + unaPractica.Descripcion + "\nCantidad Maxima: " + unaPractica.CantMaxima.ToString());              
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



    }
}
