using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Clases;
using Utilities;
using Excepciones;

namespace PAMI.Diagnosticos
{
    public partial class ListadoDiagnostico : Form
    {

        Diagnostico unDiagnostico = new Diagnostico();

        public ListadoDiagnostico()
        {
            InitializeComponent();
        }

        private void Diagnostico_Load(object sender, EventArgs e)
        {
            try
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message, "Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(cmbAsociacion.SelectedIndex) != -1)
                {
                    unDiagnostico.Codigo = txtCodigo.Text;
                    DataSet ds = unDiagnostico.TraerDiagnosticosPorFiltros(Convert.ToInt64(cmbAsociacion.SelectedIndex));//AORN ES 0 HYHNP ES 1
                    cargarGrilla(ds);

                    btnEliminar.Enabled = true;
                    btnEditar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Asociación");
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message, "Error");
            }
        }

        private void cargarGrilla(DataSet ds)
        {
            dgDiagnosticos.Columns.Clear();
            dgDiagnosticos.AutoGenerateColumns = false;
            dgDiagnosticos.RowHeadersVisible = false;

            DataGridViewTextBoxColumn clm_codigo = new DataGridViewTextBoxColumn();
            clm_codigo.Width = Convert.ToInt32(Convert.ToDouble(dgDiagnosticos.Size.Width * 0.2));
            clm_codigo.ReadOnly = true;
            clm_codigo.DataPropertyName = "diagnostico_codigo";
            clm_codigo.HeaderText = "Código";
            dgDiagnosticos.Columns.Add(clm_codigo);

            DataGridViewTextBoxColumn clm_Descripcion = new DataGridViewTextBoxColumn();
            clm_Descripcion.Width = Convert.ToInt32(Convert.ToDouble(dgDiagnosticos.Size.Width * 0.8));
            clm_Descripcion.ReadOnly = true;
            clm_Descripcion.DataPropertyName = "diagnostico_descripcion";
            clm_Descripcion.HeaderText = "Diagnostico";
            dgDiagnosticos.Columns.Add(clm_Descripcion);

            //le inserto a la grilla el dataset obtenido
            dgDiagnosticos.DataSource = ds.Tables[0];
            dgDiagnosticos.AllowUserToAddRows = false;

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 9);

            dgDiagnosticos.EnableHeadersVisualStyles = false;
            dgDiagnosticos.ColumnHeadersDefaultCellStyle = miestilo;
            dgDiagnosticos.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgDiagnosticos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            dgDiagnosticos.AllowUserToAddRows = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            dgDiagnosticos.Columns.Clear();
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatosGridDiagnostico();
                formDiagnostico formDiagn = new formDiagnostico();
                formDiagn.abrirParaEditar(unDiagnostico);
                formDiagn.Show();
                btnLimpiar_Click(sender, e);
                unDiagnostico.Dispose();
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message, "Error");
            }
        }

        private void cargarDatosGridDiagnostico()
        {
            unDiagnostico.Codigo = dgDiagnosticos.CurrentRow.Cells[0].Value.ToString();
            unDiagnostico.TraerDiagnosticoPorCodigo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Está seguro?", "Eliminar Diagnóstico", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    unDiagnostico.Codigo = dgDiagnosticos.CurrentRow.Cells[0].Value.ToString();
                    unDiagnostico.EliminarDiagnostico();
                    btnLimpiar_Click(sender, e);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                formDiagnostico form = new formDiagnostico();
                form.abrirParaNuevo();
                form.Show();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error");
            }

        }
    }
}
