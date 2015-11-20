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
using System.Text.RegularExpressions;

namespace PAMI.Asociaciones
{
    public partial class formAsociacionMedicos : Form
    {
        public Asociacion unaAsociacion = new Asociacion();


        public formAsociacionMedicos()
        {
            InitializeComponent();
            //Combo Asociacion
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            cmbAsociacion.SelectedIndex = -1;

        }

        private void crearGrilla()
        {
            dgMedicosAsociacion.Columns.Clear();
            dgMedicosAsociacion.AutoGenerateColumns = false;
            dgMedicosAsociacion.RowHeadersVisible = false;

            DataGridViewCheckBoxColumn clm_checkbox = new DataGridViewCheckBoxColumn();
            clm_checkbox.Width = 50;
            clm_checkbox.ReadOnly = false;
            clm_checkbox.DataPropertyName = "Estado";
            clm_checkbox.HeaderText = "";
            dgMedicosAsociacion.Columns.Add(clm_checkbox);

            DataGridViewTextBoxColumn clm_matricula = new DataGridViewTextBoxColumn();
            clm_matricula.Width = 80;
            clm_matricula.ReadOnly = false;
            clm_matricula.DataPropertyName = "matricula";
            clm_matricula.HeaderText = "Matricula";
            dgMedicosAsociacion.Columns.Add(clm_matricula);

            DataGridViewTextBoxColumn clm_medico = new DataGridViewTextBoxColumn();
            clm_medico.Width = 280;
            clm_medico.ReadOnly = false;
            clm_medico.DataPropertyName = "medico";
            clm_medico.HeaderText = "Médico";
            dgMedicosAsociacion.Columns.Add(clm_medico);

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Agency FB", 11);

            dgMedicosAsociacion.EnableHeadersVisualStyles = false;
            dgMedicosAsociacion.ColumnHeadersDefaultCellStyle = miestilo;
            dgMedicosAsociacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgMedicosAsociacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            dgMedicosAsociacion.AllowUserToAddRows = false;

        }

        private void cmbAsociacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbAsociacion.SelectedIndex == -1)
            {
                dgMedicosAsociacion.DataSource = null;
            }

            if (cmbAsociacion.SelectedIndex != -1)
            {
                crearGrilla();
                unaAsociacion.ID = Convert.ToInt64(cmbAsociacion.SelectedValue);
                DataSet dsAsociacion = unaAsociacion.TraerMedicosPorAsociacionParaSeleccion();
                dgMedicosAsociacion.DataSource = dsAsociacion.Tables[0];
            }           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            unaAsociacion.ID = Convert.ToInt64(cmbAsociacion.SelectedValue);

            medicosPorAsociacion();

            unaAsociacion.GuardarListadoMedicos();
            MessageBox.Show("Se actualizó el listado de Profesionales para la asociación: " + cmbAsociacion.Text.ToString(),"Actualización");
        }

        private void medicosPorAsociacion()
        {
            unaAsociacion.TablaMedicos.Rows.Clear();

            foreach (DataGridViewRow row in dgMedicosAsociacion.Rows)
            {
                if (row.Cells[0].Value.ToString() == "1")
                {   
                    unaAsociacion.TablaMedicos.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value);
                }
            }

        }

    }
}
