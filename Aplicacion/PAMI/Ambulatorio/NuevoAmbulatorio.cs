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

namespace PAMI.Ambulatorio
{
    public partial class NuevoAmbulatorio : Form
    {
        #region Variables

        Afiliado unAfiliado = new Afiliado();
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        #endregion


        public NuevoAmbulatorio()
        {
            InitializeComponent();
        }

        private void NuevoAmbulatorio_Load(object sender, EventArgs e)
        {
            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            //Combo Diagnosticos
            Diagnostico unDiagnostico = new Diagnostico();
            DataSet dsDiagnostico = unDiagnostico.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbDiagnostico, dsDiagnostico.Tables[0], "diagnostico_codigo", "diagnostico_descripcion", false, "");
            unDiagnostico.Dispose();

            //Grilla ComboBox Practicas
            Planilla unaPlanilla = new Planilla();
            DataSet dsPracticas = unaPlanilla.TraerListado("Nomenclador");
            cargarGrillaPracticasCon(dsPracticas);
            unaPlanilla.Dispose();

            cmbMedico.SelectedIndex = -1;
            cmbAsociacion.SelectedIndex = -1;
            cmbDiagnostico.SelectedIndex = -1;
        }

        #region keypress

        private void txtNombreApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtBeneficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloNumeros(e);
        }


        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Profesional Medico = new Profesional();
                Medico.Matricula = cmbMedico.SelectedValue.ToString() ;
                cargarDatosFiltros();
                DataSet dsAfiliados = unAfiliado.TraerAfiliadosConFiltrosPorMedico(Medico);
                cargarGrillaAfiliadosCon(dsAfiliados);
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

        private void cargarDatosFiltros()
        {
            limpiarUnAfiliado();
            if (txtBeneficio.Text != "")
            {
                unAfiliado.Beneficio = Convert.ToInt64(txtBeneficio.Text);
            }
            if (txtDocumento.Text != "")
            {
                unAfiliado.Documento = Convert.ToInt64(txtDocumento.Text);
            }
            if (txtNombreApellido.Text != "")
            {
                unAfiliado.Nombre = txtNombreApellido.Text;
            }
            txtBeneficio.Text = "";
            txtDocumento.Text = "";
            txtNombreApellido.Text = "";
        }

        private void limpiarUnAfiliado()
        {
            unAfiliado.Dispose();
            unAfiliado = new Afiliado();
        }

        private void cargarGrillaAfiliadosCon(DataSet dsAfiliados)
        {
            dgAfiliados.Columns.Clear();
            dgAfiliados.AutoGenerateColumns = false;
            dgAfiliados.RowHeadersVisible = false;
            //dgAfiliados.ColumnHeadersVisible = false;

            DataGridViewTextBoxColumn clm_ApellidoNombre = new DataGridViewTextBoxColumn();
            clm_ApellidoNombre.Width = 240;
            clm_ApellidoNombre.ReadOnly = true;
            clm_ApellidoNombre.DataPropertyName = "apellido_nombre";
            clm_ApellidoNombre.HeaderText = "Afiliado";
            dgAfiliados.Columns.Add(clm_ApellidoNombre);

            DataGridViewTextBoxColumn clm_beneficio = new DataGridViewTextBoxColumn();
            clm_beneficio.ReadOnly = true;
            clm_beneficio.DataPropertyName = "beneficio";
            clm_beneficio.HeaderText = "Beneficio";
            clm_beneficio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgAfiliados.Columns.Add(clm_beneficio);

            DataGridViewTextBoxColumn clm_parentesco = new DataGridViewTextBoxColumn();
            clm_parentesco.ReadOnly = true;
            clm_parentesco.DataPropertyName = "parentesco";
            clm_parentesco.HeaderText = "";
            clm_parentesco.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgAfiliados.Columns.Add(clm_parentesco);

            DataGridViewTextBoxColumn clm_tipoDni = new DataGridViewTextBoxColumn();
            clm_tipoDni.ReadOnly = true;
            clm_tipoDni.DataPropertyName = "documento_tipo";
            clm_tipoDni.HeaderText = "";
            clm_tipoDni.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgAfiliados.Columns.Add(clm_tipoDni);

            DataGridViewTextBoxColumn clm_numero_documento = new DataGridViewTextBoxColumn();
            clm_numero_documento.ReadOnly = true;
            clm_numero_documento.DataPropertyName = "documento_numero";
            clm_numero_documento.HeaderText = "Doc";
            clm_numero_documento.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgAfiliados.Columns.Add(clm_numero_documento);

            //Achico tamanios letras
            Font fontdg = new Font("Microsoft Sans Serif", 9);
            dgAfiliados.DefaultCellStyle.Font = fontdg;
           
            //le inserto a la grilla el dataset obtenido
            dgAfiliados.DataSource = dsAfiliados.Tables[0];

        }

        public void cargarGrillaPracticasCon(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                scAutoComplete.Add(dr["practica_descripcion"].ToString());
            }

            dgPracticas.Columns.Clear();
            dgPracticas.RowHeadersVisible = false;
            dgPracticas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clm_CodigoPractica = new DataGridViewTextBoxColumn();
            clm_CodigoPractica.Width = 373;
            clm_CodigoPractica.ReadOnly = false;
            clm_CodigoPractica.HeaderText = "Práctica";
            dgPracticas.Columns.Add(clm_CodigoPractica);
            
            DataGridViewTextBoxColumn clm_Hora = new DataGridViewTextBoxColumn();
            clm_Hora.Width = 80;
            clm_Hora.ReadOnly = false;
            clm_Hora.HeaderText = "Hora";
            dgPracticas.Columns.Add(clm_Hora);

            Font fontdg = new Font("Microsoft Sans Serif", 9);
            dgPracticas.DefaultCellStyle.Font = fontdg;
        }
        
        private void dgPracticas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgPracticas.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl))
            {
                TextBox prodCode = e.Control as TextBox;
                if (dgPracticas.CurrentCell.ColumnIndex == 0)
                {
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = scAutoComplete;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else { prodCode.AutoCompleteCustomSource = null; }
            }
        }

        private void dgPracticas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != 0)
            {
                int rowIndex = dgPracticas.CurrentRow.Index;
                DateTime diaHora = new DateTime();
                diaHora = Convert.ToDateTime(dgPracticas.Rows[rowIndex - 1].Cells[1].Value.ToString());
                dgPracticas.CurrentRow.Cells[1].Value = diaHora.AddMinutes(1).ToString("HH:mm", CultureInfo.InvariantCulture);
            }
        }

        private void cmbAsociacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Asociacion unaAsociacion = new Asociacion();
            unaAsociacion.ID = Convert.ToInt64(cmbAsociacion.SelectedValue);
            unaAsociacion.Nombre = cmbAsociacion.Text;
            DataSet ds = unaAsociacion.TraerMedicosPorAsociacion();
            unaAsociacion.Dispose();

            Utilities.DropDownListManager.CargarCombo(cmbMedico, ds.Tables[0], "profesional_matricula", "profesional_nombre", false, "");
        }

        private void ValidarCampos()
        {
            //validar fecha es fecha
            //validar horas
            //validar combos != -1 
            //validar afiliado seleccionado
        }
    
    }
}
