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
        }

        public void crearGrilla()
        {
            dgAmbulatorios.Columns.Clear();
            dgAmbulatorios.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn clm_Estado = new DataGridViewCheckBoxColumn();
            clm_Estado.Width = 53;
            clm_Estado.ReadOnly = true;
            clm_Estado.HeaderText = "Estado";
            dgAmbulatorios.Columns.Add(clm_Estado);

            DataGridViewTextBoxColumn clm_Medico = new DataGridViewTextBoxColumn();
            clm_Medico.Width = 160;
            clm_Medico.ReadOnly = false;
            clm_Medico.HeaderText = "Profesional";
            dgAmbulatorios.Columns.Add(clm_Medico);

            DataGridViewTextBoxColumn clm_Beneficio = new DataGridViewTextBoxColumn();
            clm_Beneficio.Width = 160;
            clm_Beneficio.ReadOnly = false;
            clm_Beneficio.HeaderText = "Beneficio";
            dgAmbulatorios.Columns.Add(clm_Beneficio);

            DataGridViewTextBoxColumn clm_Practica = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 100;
            clm_Practica.ReadOnly = false;
            clm_Practica.HeaderText = "Práctica";
            dgAmbulatorios.Columns.Add(clm_Practica);

            DataGridViewTextBoxColumn clm_Fecha = new DataGridViewTextBoxColumn();
            clm_Fecha.Width = 100;
            clm_Fecha.ReadOnly = false;
            clm_Fecha.HeaderText = "Fecha";
            dgAmbulatorios.Columns.Add(clm_Fecha);

            DataGridViewTextBoxColumn clm_Hora = new DataGridViewTextBoxColumn();
            clm_Hora.Width = 100;
            clm_Hora.ReadOnly = false;
            clm_Hora.HeaderText = "Hora";
            dgAmbulatorios.Columns.Add(clm_Hora);
            
            DataGridViewTextBoxColumn clm_Validacion = new DataGridViewTextBoxColumn();
            clm_Validacion.Width = 200;
            clm_Validacion.ReadOnly = true;
            clm_Validacion.HeaderText = "Validación";
            dgAmbulatorios.Columns.Add(clm_Validacion);

            dgAmbulatorios.DataSource = unaPlanilla.tablaPlanilla;
        }
    }
}
