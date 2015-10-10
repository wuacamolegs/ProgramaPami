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
    public partial class ListadoNomenclador : Form
    {

        public Practica unaPractica = new Practica();

        public ListadoNomenclador()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void ListadoNomenclador_Load(object sender, EventArgs e)
        {
            /*
             
             PARA CUANDO HAGA LA GRILLA. ABAJO PONER
            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Agency FB", 11);

            dgNomenclador.EnableHeadersVisualStyles = false;
            dgNomenclador.ColumnHeadersDefaultCellStyle = miestilo;
            dgNomenclador.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgNomenclador.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro; 
             
             
             */
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbAsociacion.SelectedIndex = -1;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            cmbModulo.SelectedIndex = -1;
            dgNomenclador.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatosFiltros();
                DataSet dsNomenclador = unaPractica.BuscarPracticasPorFiltros();
                cargarGrillaCon(dsNomenclador);
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

        private void cargarGrillaCon(DataSet dsNomenclador)
        {
            dgNomenclador.Columns.Clear();
            dgNomenclador.AutoGenerateColumns = false;
            dgNomenclador.RowHeadersVisible = false;

            DataGridViewTextBoxColumn clm_codigo = new DataGridViewTextBoxColumn();
            clm_codigo.Width = 100;
            clm_codigo.ReadOnly = true;
            clm_codigo.DataPropertyName = "practica_codigo";
            clm_codigo.HeaderText = "Código";
            dgNomenclador.Columns.Add(clm_codigo);

            DataGridViewTextBoxColumn clm_Descripcion = new DataGridViewTextBoxColumn();
            clm_Descripcion.Width = 348;
            clm_Descripcion.ReadOnly = true;
            clm_Descripcion.DataPropertyName = "practica_descripcion";
            clm_Descripcion.HeaderText = "Práctica";
            dgNomenclador.Columns.Add(clm_Descripcion);

            DataGridViewTextBoxColumn clm_cantidad = new DataGridViewTextBoxColumn();
            clm_cantidad.Width = 70;
            clm_cantidad.ReadOnly = true;
            clm_cantidad.DataPropertyName = "cantidad_maxima";
            clm_cantidad.HeaderText = "Max Cant";
            dgNomenclador.Columns.Add(clm_cantidad);

            DataGridViewTextBoxColumn clm_modulo = new DataGridViewTextBoxColumn();
            clm_modulo.Width = 58;
            clm_modulo.ReadOnly = true;
            clm_modulo.DataPropertyName = "codigo_modulo";
            clm_modulo.HeaderText = "Módulo";
            dgNomenclador.Columns.Add(clm_modulo);

            //le inserto a la grilla el dataset obtenido
            dgNomenclador.DataSource = dsNomenclador.Tables[0];
            dgNomenclador.AllowUserToAddRows = false;

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Agency FB", 11);

            dgNomenclador.EnableHeadersVisualStyles = false;
            dgNomenclador.ColumnHeadersDefaultCellStyle = miestilo;
            dgNomenclador.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgNomenclador.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void cargarDatosFiltros()
        {

            limpiarPractica();

            if (txtDescripcion.Text != "")
            {
                unaPractica.Descripcion = txtDescripcion.Text;
            }
            if (txtCodigo.Text != "")
            {
                unaPractica.Codigo = txtCodigo.Text;
            }
            unaPractica.Modulo = Convert.ToInt64(cmbModulo.SelectedIndex);
            unaPractica.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedIndex);
        }

        private void limpiarPractica()
        {
            unaPractica.Dispose();
            unaPractica = new Practica();
            dgNomenclador.DataSource = null;
        }

        private void dgNomenclador_SelectionChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formPracticas practicas = new formPracticas();
            practicas.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                formPracticas formAfiliado = new formPracticas();
                if (cargarDatosGridNomenclador())
                {
                    formAfiliado.abrirParaEditar(unaPractica);
                    formAfiliado.Show();
                    btnLimpiar_Click(sender, e);
                    limpiarPractica();
                }
            }
            catch (Exception mess)
            {
                MessageBox.Show(mess.Message, "Error");
            }
        }

        private bool cargarDatosGridNomenclador()
        {
            try
            {
                unaPractica.Codigo = dgNomenclador.CurrentRow.Cells[0].FormattedValue.ToString();

                if (!unaPractica.TraerPracticaPorCodigo())
                {
                    MessageBox.Show("No se encontró la Práctica en la Base de datos");
                    return false;
                }
                else { return true; }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro?", "Eliminar Práctica", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cargarDatosGridNomenclador();
                unaPractica.EliminarPractica();
                btnLimpiar_Click(sender, e);
            }
        }
    }
}
