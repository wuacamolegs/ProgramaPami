using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;
using Excepciones;

namespace PAMI.Profesionales
{
    public partial class ContadorPracticasProfesional : Form
    {
        Profesional unProfesional = new Profesional();
       

        public ContadorPracticasProfesional()
        {
            InitializeComponent();
        }

        private void ContadorPracticasProfesional_Load(object sender, EventArgs e)
        {
            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            Utilities.DropDownListManager.CargarCombo(cmbMes, Base.TablaMeses(), "numeroMes", "nombreMes", false, "");
            cmbMes.SelectedIndex = DateTime.Today.AddMonths(-2).Month; 
            
            cmbMedico.SelectedIndex = -1;
        }

        private void cmbAsociacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsociacion.Text != "")
            {
                //Cargar Combo Medicos
                Asociacion unaAsociacion = new Asociacion();
                unaAsociacion.ID = Convert.ToInt64(cmbAsociacion.SelectedValue);
                unaAsociacion.Nombre = cmbAsociacion.Text;
                DataSet ds = unaAsociacion.TraerMedicosPorAsociacion();
                unaAsociacion.Dispose();

                Utilities.DropDownListManager.CargarCombo(cmbMedico, ds.Tables[0], "profesional_matricula", "profesional_nombre", false, "");
                cmbMedico.AutoCompleteCustomSource = Utilities.AutocompleteComboBox.LoadAutoComplete(ds, "profesional_nombre");
                cmbMedico.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbMedico.AutoCompleteSource = AutoCompleteSource.CustomSource;
                dgContador.DataSource = null;
            }
            if (cmbAsociacion.SelectedIndex == -1)
            {
                cmbMedico.DataSource = null;
                dgContador.DataSource = null;
            }
        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgContador.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarCombos())
            {
                unProfesional.Matricula = cmbMedico.SelectedValue.ToString();
                unProfesional.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                DataSet ds = unProfesional.TraerContadorPracticas(Convert.ToInt64(cmbMes.SelectedValue),txtAnio.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cargarGrillaCon(ds);
                }
                else
                {
                    MessageBox.Show("No posee ambulatorios para ese periodo5");
                }
            }
        }

        private void cargarGrillaCon(DataSet ds)
        {
            dgContador.Columns.Clear();
            dgContador.AutoGenerateColumns = false;
            dgContador.RowHeadersVisible = false;

            DataGridViewTextBoxColumn clm_Practica = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 400;
            clm_Practica.ReadOnly = true;
            clm_Practica.DataPropertyName = "planilla_practica";
            clm_Practica.HeaderText = "Practica";
            dgContador.Columns.Add(clm_Practica);

            DataGridViewTextBoxColumn clm_cantidad = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 108;
            clm_cantidad.ReadOnly = true;
            clm_cantidad.DataPropertyName = "Cantidad";
            clm_cantidad.HeaderText = "Cantidad";
            dgContador.Columns.Add(clm_cantidad);

            //Achico tamanios letras
            Font fontdg = new Font("Microsoft Sans Serif", 9);
            dgContador.DefaultCellStyle.Font = fontdg;

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 9);
            dgContador.EnableHeadersVisualStyles = false;
            dgContador.ColumnHeadersDefaultCellStyle = miestilo;
            dgContador.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgContador.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            dgContador.AllowUserToAddRows = false;

            //le inserto a la grilla el dataset obtenido
            dgContador.DataSource = ds.Tables[0];
        }

        private bool validarCombos()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbAsociacion.SelectedIndex, "Asociacion");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbMedico.SelectedIndex, "Profesional");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbMes.SelectedIndex, "Mes");
            strErrores = strErrores + Validator.ValidarNulo(txtAnio.Text, "Año");
            if (strErrores == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(strErrores);
                return false;
            }
        }
    }
}
