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
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            unDiagnostico.Codigo = txtCodigo.Text;
            DataSet ds = unDiagnostico.TraerDiagnosticosPorFiltros();
            cargarGrilla(ds);

            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void cargarGrilla(DataSet ds)
        {
            dgDiagnosticos.Columns.Clear();
            dgDiagnosticos.AutoGenerateColumns = false;
            dgDiagnosticos.RowHeadersVisible = false;

            DataGridViewTextBoxColumn clm_codigo = new DataGridViewTextBoxColumn();
            clm_codigo.Width = 100;
            clm_codigo.ReadOnly = true;
            clm_codigo.DataPropertyName = "diagnostico_codigo";
            clm_codigo.HeaderText = "Código";
            dgDiagnosticos.Columns.Add(clm_codigo);

            DataGridViewTextBoxColumn clm_Descripcion = new DataGridViewTextBoxColumn();
            clm_Descripcion.Width = 476;
            clm_Descripcion.ReadOnly = true;
            clm_Descripcion.DataPropertyName = "diagnostico_descripcion";
            clm_Descripcion.HeaderText = "Práctica";
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
            formDiagnostico formDiagn = new formDiagnostico();
            cargarDatosGridDiagnostico();

            formDiagn.abrirParaEditar(unDiagnostico);
            formDiagn.Show();
            btnLimpiar_Click(sender, e);
            unDiagnostico.Dispose();
        }

        private void cargarDatosGridDiagnostico()
        {
            try
            {
                unDiagnostico.Codigo = dgDiagnosticos.CurrentRow.Cells[0].Value.ToString();
                unDiagnostico.TraerDiagnosticoPorCodigo();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
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
            formDiagnostico form = new formDiagnostico();
            form.abrirParaNuevo();
            form.Show();
        }
    }
}
