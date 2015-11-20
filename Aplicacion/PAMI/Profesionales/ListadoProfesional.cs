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

namespace PAMI.Profesionales
{
    public partial class ListadoProfesional : Form
    {
        Profesional unProfesional = new Profesional();

        public ListadoProfesional()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
            btnEditar.Enabled = false;

            Utilities.DropDownListManager.CargarCombo(cmbEspecialidad, unProfesional.ObtenerListadoEspecialidad(), "EspecialidadID", "Especialidad", false, "");
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtMatricula.Text = "";
            txtDocumento.Text = "";
            cmbEspecialidad.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;
            limpiarUnPrestador();
            dgProfesionales.Columns.Clear();
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void limpiarUnPrestador()
        {
            unProfesional.Dispose();
            unProfesional = new Profesional();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatosFiltros();
                DataSet dsProfesionales = unProfesional.BuscarProfesionalPorFiltros();
                cargarGrillaCon(dsProfesionales);
                btnEditar.Enabled = true;
                btnEditar.Enabled = true;
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

        private void cargarGrillaCon(DataSet dsProfesionales)
        {
            dgProfesionales.Columns.Clear();
            dgProfesionales.AutoGenerateColumns = false;
            dgProfesionales.RowHeadersVisible = false;

            DataGridViewTextBoxColumn clm_matricula = new DataGridViewTextBoxColumn();
            clm_matricula.Width = 160;
            clm_matricula.ReadOnly = true;
            clm_matricula.DataPropertyName = "profesional_matricula_nacional";
            clm_matricula.HeaderText = "Matrícula";
            dgProfesionales.Columns.Add(clm_matricula);

            DataGridViewTextBoxColumn clm_ApellidoNombre = new DataGridViewTextBoxColumn();
            clm_ApellidoNombre.Width = 410;
            clm_ApellidoNombre.ReadOnly = true;
            clm_ApellidoNombre.DataPropertyName = "profesional_nombre";
            clm_ApellidoNombre.HeaderText = "Nombre y Apellido";
            dgProfesionales.Columns.Add(clm_ApellidoNombre);

            DataGridViewTextBoxColumn clm_tipoDoc = new DataGridViewTextBoxColumn();
            clm_tipoDoc.Width = 100;
            clm_tipoDoc.ReadOnly = true;
            clm_tipoDoc.DataPropertyName = "documento_tipo";
            clm_tipoDoc.HeaderText = "Tipo Doc";
            dgProfesionales.Columns.Add(clm_tipoDoc);

            DataGridViewTextBoxColumn clm_numero_documento = new DataGridViewTextBoxColumn();
            clm_numero_documento.Width = 160;
            clm_numero_documento.ReadOnly = true;
            clm_numero_documento.DataPropertyName = "documento_numero";
            clm_numero_documento.HeaderText = "Documento";
            dgProfesionales.Columns.Add(clm_numero_documento);

            //le inserto a la grilla el dataset obtenido
            dgProfesionales.DataSource = dsProfesionales.Tables[0];


            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 9);

            dgProfesionales.EnableHeadersVisualStyles = false;
            dgProfesionales.ColumnHeadersDefaultCellStyle = miestilo;
            dgProfesionales.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgProfesionales.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            dgProfesionales.AllowUserToAddRows = false;

        }

        private void cargarDatosFiltros()
        {
            limpiarUnPrestador();
            if (txtNombre.Text != "")
            {
                unProfesional.Nombre = txtNombre.Text;
            }
            if (txtMatricula.Text != "")
            {
                unProfesional.Matricula = txtMatricula.Text;
            }
            if (txtDocumento.Text != "")
            {
                unProfesional.Documento = txtDocumento.Text;
            }
            if (cmbTipoDoc.SelectedValue != null)
            {
                unProfesional.TipoDocumento = cmbTipoDoc.SelectedValue.ToString();
            }
            if (cmbEspecialidad.SelectedValue != null)
            {
                unProfesional.Especialidad = cmbEspecialidad.SelectedValue.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formProfesional prof = new formProfesional();
            prof.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro?", "Eliminar Profesional", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cargarDatosGridProfesional();
                unProfesional.EliminarProfesional();
                btnLimpiar_Click(sender, e);
            }
        }

        private bool cargarDatosGridProfesional()
        {
            try
            {
                unProfesional.Matricula = dgProfesionales.CurrentRow.Cells[0].Value.ToString();
                return unProfesional.TraerProfesionalPorMatricula();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cargarDatosGridProfesional())
                {
                    formProfesional formProf = new formProfesional();
                    formProf.abrirParaEditar(unProfesional);
                    formProf.Show();
                    btnLimpiar_Click(sender, e);
                }
            }
            catch (Exception emes)
            {
                MessageBox.Show(emes.Message, "Error");
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void cmbEspecialidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }
    }
}
