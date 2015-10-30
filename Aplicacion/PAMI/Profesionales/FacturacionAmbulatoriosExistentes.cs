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
using PAMI.Ambulatorio;
using System.Text.RegularExpressions;

namespace PAMI.Profesionales
{
    public partial class FacturacionAmbulatoriosExistentes : Form
    {
        Planilla unaPlanilla = new Planilla();

        public FacturacionAmbulatoriosExistentes()
        {
            InitializeComponent();
        }


        private void FacturacionAmbulatoriosExistentes_Load(object sender, EventArgs e)
        {
            Utilities.DropDownListManager.CargarCombo(cmbMes, Base.TablaMeses(), "numeroMes", "nombreMes", false, "");
            cmbMes.SelectedIndex = -1;

            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            cmbAsociacion.SelectedIndex = -1;
        }

        private void CargarGrillaCon()
        {
            dgPlanilla.Columns.Clear();
            dgPlanilla.AutoGenerateColumns = false;
            dgPlanilla.RowHeadersVisible = false;
            dgPlanilla.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn clm_MedicoFacturado = new DataGridViewTextBoxColumn();
            clm_MedicoFacturado.Width = 400;
            clm_MedicoFacturado.ReadOnly = true;
            clm_MedicoFacturado.DataPropertyName = "profesional_facturado";
            clm_MedicoFacturado.HeaderText = "Profesional Facturado";
            dgPlanilla.Columns.Add(clm_MedicoFacturado);

            DataGridViewTextBoxColumn clm_Profesional = new DataGridViewTextBoxColumn();
            clm_Profesional.Width = 400;
            clm_Profesional.ReadOnly = true;
            clm_Profesional.DataPropertyName = "profesional_posta";
            clm_Profesional.HeaderText = "Profesional";
            dgPlanilla.Columns.Add(clm_Profesional);

            DataGridViewTextBoxColumn clm_Fecha = new DataGridViewTextBoxColumn();
            clm_Fecha.Width = 100;
            clm_Fecha.ReadOnly = true;
            clm_Fecha.DataPropertyName = "planilla_fecha";
            clm_Fecha.HeaderText = "Fecha";
            dgPlanilla.Columns.Add(clm_Fecha);

            DataGridViewTextBoxColumn clm_Nombre = new DataGridViewTextBoxColumn();
            clm_Nombre.Width = 400;
            clm_Nombre.ReadOnly = true;
            clm_Nombre.DataPropertyName = "planilla_afiliado_nombre";
            clm_Nombre.HeaderText = "Apellido y Nombre";
            dgPlanilla.Columns.Add(clm_Nombre);

            DataGridViewTextBoxColumn clm_Beneficio = new DataGridViewTextBoxColumn();
            clm_Beneficio.Width = 160;
            clm_Beneficio.ReadOnly = true;
            clm_Beneficio.DataPropertyName = "planilla_afiliado_beneficio";
            clm_Beneficio.HeaderText = "Beneficio";
            dgPlanilla.Columns.Add(clm_Beneficio);

            DataGridViewTextBoxColumn clm_Diagnostico = new DataGridViewTextBoxColumn();
            clm_Diagnostico.Width = 250;
            clm_Diagnostico.ReadOnly = true;
            clm_Diagnostico.DataPropertyName = "planilla_diagnostico";
            clm_Diagnostico.HeaderText = "Diagnóstico";
            dgPlanilla.Columns.Add(clm_Diagnostico);

            DataGridViewTextBoxColumn clm_Practica = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 100;
            clm_Practica.ReadOnly = true;
            clm_Practica.DataPropertyName = "planilla_practica";
            clm_Practica.HeaderText = "Práctica";
            dgPlanilla.Columns.Add(clm_Practica);

            DataGridViewTextBoxColumn clm_Hora = new DataGridViewTextBoxColumn();
            clm_Hora.Width = 100;
            clm_Hora.ReadOnly = true;
            clm_Hora.DataPropertyName = "planilla_hora";
            clm_Hora.HeaderText = "Hora";
            dgPlanilla.Columns.Add(clm_Hora);

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 11);

            dgPlanilla.EnableHeadersVisualStyles = false;
            dgPlanilla.ColumnHeadersDefaultCellStyle = miestilo;
            dgPlanilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgPlanilla.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro; 
        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Asociacion unaAsociacion = new Asociacion();
            unaAsociacion.ID = Convert.ToInt64(cmbAsociacion.SelectedValue);
            unaAsociacion.Nombre = cmbAsociacion.Text;
            DataSet ds = unaAsociacion.TraerMedicosPorAsociacion();
            unaAsociacion.Dispose();

            Utilities.DropDownListManager.CargarCombo(cmbMedico, ds.Tables[0], "profesional_matricula", "profesional_nombre", false, "");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text != "")
            {
                unaPlanilla.Anio = Convert.ToInt64(txtAnio.Text);
            }

            unaPlanilla.Mes = Convert.ToInt64(cmbMes.SelectedIndex);
            unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedIndex);
            unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedIndex);

            unaPlanilla.TraerAmbulatoriosCargadosAOtroMedicoPorFiltros();
        }

    }
}
