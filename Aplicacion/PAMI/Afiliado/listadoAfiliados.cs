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

namespace PAMI.Afiliados
{
    public partial class listadoAfiliados : Form
    {

        #region variables

        Afiliado unAfiliado = new Afiliado();

        #endregion

        #region initialize

        public listadoAfiliados()
        {
            InitializeComponent();
        }

        private void Afiliados_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            cmbTipoDni.SelectedIndex = -1;
        }

        #endregion

        #region botones

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatosFiltros();
                DataSet dsAfiliados = unAfiliado.BuscarAfiliadoPorFiltros();
                cargarGrillaCon(dsAfiliados);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreApellido.Text = "";
            txtBeneficio.Text = "";
            txtParentesco.Text = "";
            txtDocumento.Text = "";
            cmbTipoDni.SelectedIndex = -1;
            limpiarUnAfiliado();
            dgAfiliados.Columns.Clear();
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            formAfiliado formAfiliado = new formAfiliado();
            cargarDatosGridAfiliado();
            formAfiliado.abrirParaEditar(unAfiliado);
            formAfiliado.Show();
            btnLimpiar_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formAfiliado afiliado = new formAfiliado();
            afiliado.abrirNuevo();
            afiliado.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro?", "Eliminar Afiliado", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cargarDatosGridAfiliado();
                unAfiliado.EliminarAfiliado();
                btnLimpiar_Click(sender, e);
            }
        }

        #endregion

        #region metodos Grilla

        private void cargarGrillaCon(DataSet dsAfiliados)
        {
            dgAfiliados.Columns.Clear();
            dgAfiliados.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clm_ApellidoNombre = new DataGridViewTextBoxColumn();
            clm_ApellidoNombre.Width = 240;
            clm_ApellidoNombre.ReadOnly = true;
            clm_ApellidoNombre.DataPropertyName = "afiliado_apellidoNombre";
            clm_ApellidoNombre.HeaderText = "Apellido y Nombre";
            dgAfiliados.Columns.Add(clm_ApellidoNombre);

            DataGridViewTextBoxColumn clm_beneficio = new DataGridViewTextBoxColumn();
            clm_beneficio.Width = 160;
            clm_beneficio.ReadOnly = true;
            clm_beneficio.DataPropertyName = "afiliado_beneficio_id";
            clm_beneficio.HeaderText = "Beneficio";
            dgAfiliados.Columns.Add(clm_beneficio);

            DataGridViewTextBoxColumn clm_parentesco = new DataGridViewTextBoxColumn();
            clm_parentesco.Width = 80;
            clm_parentesco.ReadOnly = true;
            clm_parentesco.DataPropertyName = "afiliado_parentesco_id";
            clm_parentesco.HeaderText = "Parentesco";
            dgAfiliados.Columns.Add(clm_parentesco);

            DataGridViewTextBoxColumn clm_tipoDni = new DataGridViewTextBoxColumn();
            clm_tipoDni.Width = 80;
            clm_tipoDni.ReadOnly = true;
            clm_tipoDni.DataPropertyName = "afiliado_tipo_documento";
            clm_tipoDni.HeaderText = "Tipo Doc";
            dgAfiliados.Columns.Add(clm_tipoDni);

            DataGridViewTextBoxColumn clm_numero_documento = new DataGridViewTextBoxColumn();
            clm_numero_documento.Width = 80;
            clm_numero_documento.ReadOnly = true;
            clm_numero_documento.DataPropertyName = "afiliado_numero_documento";
            clm_numero_documento.HeaderText = "Documento";
            dgAfiliados.Columns.Add(clm_numero_documento);

            DataGridViewTextBoxColumn clm_fechaNacimiento = new DataGridViewTextBoxColumn();
            clm_fechaNacimiento.Width = 120;
            clm_fechaNacimiento.ReadOnly = true;
            clm_fechaNacimiento.DataPropertyName = "afiliado_fecha_nacimiento";
            clm_fechaNacimiento.HeaderText = "Fecha Nacimiento";
            dgAfiliados.Columns.Add(clm_fechaNacimiento);

            //le inserto a la grilla el dataset obtenido
            dgAfiliados.DataSource = dsAfiliados.Tables[0];

        }

        private void cargarDatosGridAfiliado()
        {
            try
            {
                unAfiliado.Beneficio = Convert.ToInt64(dgAfiliados.CurrentRow.Cells[1].Value);
                unAfiliado.Parentesco = Convert.ToInt64(dgAfiliados.CurrentRow.Cells[2].Value);
                unAfiliado.TraerAfiliadoPorBeneficio();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        #endregion

        #region metodos privados

        private void cargarDatosFiltros()
        {
            limpiarUnAfiliado();
            if (txtBeneficio.Text != "")
            {
                unAfiliado.Beneficio = Convert.ToInt64(txtBeneficio.Text);
            }
            if (txtParentesco.Text != "")
            {
                unAfiliado.Parentesco = Convert.ToInt64(txtParentesco.Text);
            }
            if (txtDocumento.Text != "")
            {
                unAfiliado.Documento = Convert.ToInt64(txtDocumento.Text);
            }
            if (txtNombreApellido.Text != "")
            {
                unAfiliado.Nombre = txtNombreApellido.Text;
            }
            if (cmbTipoDni.SelectedIndex != -1)
            {
                unAfiliado.TipoDocumento = cmbTipoDni.SelectedItem.ToString();
            }
        }

        private void limpiarUnAfiliado()
        {
            unAfiliado.Dispose();
            unAfiliado = new Afiliado();
        }

        #endregion
        
        #region Eventos

        private void txtNombreApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtBeneficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtParentesco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void dgAfiliados_SelectionChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        #endregion

    }
}
