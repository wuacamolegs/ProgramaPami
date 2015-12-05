using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PAMI.Ambulatorio
{
    public partial class AmbulatorioExistente : Form
    {
        Planilla unaPlanilla = new Planilla();
        Int64 MedicoPosta;
        
        public AmbulatorioExistente()
        {
            InitializeComponent();
        }

        public void abrirCon(Planilla planilla, Int64 Medico)
        {
            MedicoPosta = Medico;
            unaPlanilla = planilla;
            crearGrilla();
        }

        public void crearGrilla()
        {
            dgAmbulatorios.Columns.Clear();
            dgAmbulatorios.AutoGenerateColumns = false;
            dgAmbulatorios.RowHeadersVisible = false;

            DataGridViewCheckBoxColumn clm_checkbox = new DataGridViewCheckBoxColumn();
            clm_checkbox.Width = 50;
            clm_checkbox.ReadOnly = false;
            clm_checkbox.DataPropertyName = "Existe";
            clm_checkbox.HeaderText = "";
            dgAmbulatorios.Columns.Add(clm_checkbox);

            DataGridViewTextBoxColumn clm_Medico = new DataGridViewTextBoxColumn();
            clm_Medico.Width = 260;
            clm_Medico.ReadOnly = true;
            clm_Medico.DataPropertyName = "Planilla_medico_secundario_nombre";
            clm_Medico.HeaderText = "Profesional";
            dgAmbulatorios.Columns.Add(clm_Medico);

            DataGridViewTextBoxColumn clm_Beneficio = new DataGridViewTextBoxColumn();
            clm_Beneficio.Width = 160;
            clm_Beneficio.ReadOnly = true;
            clm_Beneficio.DataPropertyName = "Planilla_beneficio";
            clm_Beneficio.HeaderText = "Beneficio";
            dgAmbulatorios.Columns.Add(clm_Beneficio);

            DataGridViewTextBoxColumn clm_Practica = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 120;
            clm_Practica.ReadOnly = true;
            clm_Practica.DataPropertyName = "Planilla_practica";
            clm_Practica.HeaderText = "Práctica";
            dgAmbulatorios.Columns.Add(clm_Practica);

            DataGridViewTextBoxColumn clm_Fecha = new DataGridViewTextBoxColumn();
            clm_Fecha.Width = 100;
            clm_Fecha.ReadOnly = true;
            clm_Fecha.DataPropertyName = "Planilla_fecha";
            clm_Fecha.HeaderText = "Fecha";
            dgAmbulatorios.Columns.Add(clm_Fecha);

            DataGridViewTextBoxColumn clm_Hora = new DataGridViewTextBoxColumn();
            clm_Hora.Width = 80;
            clm_Hora.ReadOnly = true;
            clm_Hora.DataPropertyName = "Planilla_hora";
            clm_Hora.HeaderText = "Hora";
            dgAmbulatorios.Columns.Add(clm_Hora);
            
            dgAmbulatorios.DataSource = unaPlanilla.tablaPlanilla;
            dgAmbulatorios.AllowUserToAddRows = false;

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 11);

            dgAmbulatorios.EnableHeadersVisualStyles = false;
            dgAmbulatorios.ColumnHeadersDefaultCellStyle = miestilo;
            dgAmbulatorios.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgAmbulatorios.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro; 
        }

        private void dgAmbulatorios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToInt64(dgAmbulatorios.Rows[e.RowIndex].Cells[0].Value).ToString() == "0")
            {
                dgAmbulatorios.Rows[e.RowIndex].ReadOnly = true;
                dgAmbulatorios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void btnSI_Click(object sender, EventArgs e)
        {
            int indice = 0;
            foreach (DataGridViewRow row in dgAmbulatorios.Rows)
            {
                if (Convert.ToInt64(row.Cells[0].Value).ToString() == "1")
                {
                    unaPlanilla.Medico = Convert.ToInt64(unaPlanilla.tablaPlanilla.Rows[indice]["Planilla_medico_secundario_matricula"]);
                    unaPlanilla.Beneficio = row.Cells[2].Value.ToString();
                    unaPlanilla.Diagnostico = unaPlanilla.tablaPlanilla.Rows[indice]["Planilla_diagnostico"].ToString();
                    unaPlanilla.Practica = row.Cells[3].Value.ToString();
                    unaPlanilla.Fecha = row.Cells[4].Value.ToString();
                    unaPlanilla.Hora = row.Cells[5].Value.ToString();                   
                    
                    DataSet dsImportar = unaPlanilla.ImportarAmbulatorioExistente(MedicoPosta);

                    if (dsImportar.Tables[0].Rows[0][0].ToString() != unaPlanilla.Hora)
                    {
                        row.Cells[5].Value = dsImportar.Tables[0].Rows[0][0].ToString();
                        row.Cells[5].Style.BackColor = Color.LightBlue;  //SIGNIFICA QUE LE CAMBIE LA HORA!!
                    }
                }
            }
            MessageBox.Show("Importado Correctamente");
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
