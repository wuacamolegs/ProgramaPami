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
using System.Configuration;
using Excepciones;

namespace PAMI.Ambulatorio
{
    public partial class NuevoEditarAmbulatorio : Form
    {
        #region Variables

        DataTable TablaNomenclador = new DataTable();
        DataView AfiliadosView = new DataView();

        DataTable TablaFechaHoras = new DataTable();

        Asociacion unaAsociacion = new Asociacion();
        Planilla unaPlanilla = new Planilla();

        Afiliado unAfiliado = new Afiliado();
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        bool diagnosticosCargados = false;
        bool abrirAmbulatorio = false;
        string fechaEditar = "";
        Int64 medicoPosta = 0;

        #endregion
        
        public NuevoEditarAmbulatorio()
        {
            InitializeComponent();

            //TABLA NOMENCLADOR
            TablaNomenclador.Columns.Add("Codigo", typeof(string));
            TablaNomenclador.Columns.Add("Descripcion", typeof(string));
            TablaNomenclador.Columns.Add("CantidadMax", typeof(Int64));

            //TABLA HORARIOS
            TablaFechaHoras.Columns.Add("Fecha", typeof(string));
            TablaFechaHoras.Columns.Add("Hora", typeof(string));

            txtOP.Visible = false;
            
            //MOSTRAR SOLO BUSCADOR AFILIADOS
            gbAfiliadoSeleccionado.Visible = false; 
            txt2Documento.Visible = false;
            txt2NroAfiliado.Visible = false;
            txt2NombreyApellido.Visible = false;
            btn2Atras.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        public void abrirCon(Planilla planilla)
        {
            unaPlanilla.Dispose();
            unaPlanilla = planilla;
            abrirAmbulatorio = true;
            dgPracticas.Focus();
        }

        private void NuevoAmbulatorio_Load(object sender, EventArgs e)
        {
            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            cmbMedico.SelectedIndex = -1;
            cmbAsociacion.SelectedIndex = -1;
            cmbDiagnosticoCodigo.SelectedIndex = -1;
            cmbDiagnosticoDescripcion.SelectedIndex = -1;

            cmbAsociacion.Focus();

            if (abrirAmbulatorio)
            {
                DataSet ds = unaPlanilla.ValidarAmbulatorioExistente();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbAsociacion.SelectedValue = unaPlanilla.Asociacion;
                    cmbMedico.SelectedValue = unaPlanilla.Medico;
                    cmbDiagnosticoCodigo.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["planilla_diagnostico"]);
                    unAfiliado.Beneficio = unaPlanilla.Beneficio;
                    unAfiliado.TraerAfiliadoPorBeneficio();
                    fechaEditar = unaPlanilla.Fecha;  //si vengo desde editar ambulatorio que lo elegi de la busqueda guardo aca la fecha editar

                    if (unaPlanilla.OrdenPrestacion != "0")
                    {
                        chOP.Checked = true;
                        txtOP.Text = unaPlanilla.OrdenPrestacion;
                    }
                    

                    int index = 0;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dgPracticas.Rows.Add(ds.Tables[0].Rows[index][1], ds.Tables[0].Rows[index][2]);
                        index++;
                    }

                    //OCULTAR BUSCADOR
                    dgAfiliados.Visible = false;
                    txtBeneficio.Visible = false;
                    txtDocumento.Visible = false;
                    txtNombreApellido.Visible = false;
                    lbl1Documento.Visible = false;
                    lbl1Nombreapellido.Visible = false;
                    lbl1NroAfiliado.Visible = false;
                    btnBuscar.Visible = false;

                    //MOSTRAR AFILIADO SELECCIONADO
                    gbAfiliadoSeleccionado.Visible = true;
                    txt2Documento.Visible = true;
                    txt2NroAfiliado.Visible = true;
                    txt2NombreyApellido.Visible = true;
                    btn2Atras.Visible = false;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    btnNuevo.Visible = false;

                    txt2Documento.Enabled = false;
                    txt2NroAfiliado.Enabled = false;
                    txt2NombreyApellido.Enabled = false;

                    txt2NombreyApellido.Text = unAfiliado.Nombre;
                    txt2NroAfiliado.Text = unAfiliado.Beneficio + unAfiliado.Parentesco;
                    txt2Documento.Text = unAfiliado.TipoDocumento + unAfiliado.Documento;
                    txtFecha.Text = unaPlanilla.Fecha;

                    cmbAsociacion.Enabled = false;
                    cmbMedico.Enabled = false;                    

                    cmbDiagnosticoCodigo.Focus();
                }
                else { MessageBox.Show("No existen ambulatorios"); }
            }
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
                if ("" != cmbAsociacion.Text)
                {
                    cargarDatosFiltros();
                    DataSet dsAfiliados = unAfiliado.TraerAfiliadosConFiltrosPorAsociacionID(Convert.ToInt64(cmbAsociacion.SelectedValue));
                    cargarGrillaAfiliadosCon(dsAfiliados);
                    dgAfiliados.Focus();
                }
                else
                {
                    MessageBox.Show("Seleccione una Asociación");
                }
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
                unAfiliado.Beneficio = txtBeneficio.Text;
            }
            if (txtDocumento.Text != "")
            {
                unAfiliado.Documento = txtDocumento.Text;
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

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 9);
            dgAfiliados.EnableHeadersVisualStyles = false;
            dgAfiliados.ColumnHeadersDefaultCellStyle = miestilo;
            dgAfiliados.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgAfiliados.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            dgAfiliados.AllowUserToAddRows = false;
           
            //le inserto a la grilla el dataset obtenido
            dgAfiliados.DataSource = dsAfiliados.Tables[0];

        }

        private void cargarGrillaPracticasCon(DataSet ds)
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
            clm_Hora.Width = 95;
            clm_Hora.ReadOnly = false;
            clm_Hora.HeaderText = "Hora";
            dgPracticas.Columns.Add(clm_Hora);

            //Achico tamanios letras
            Font fontdg = new Font("Microsoft Sans Serif", 9);
            dgPracticas.DefaultCellStyle.Font = fontdg;

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 9);
            dgPracticas.EnableHeadersVisualStyles = false;
            dgPracticas.ColumnHeadersDefaultCellStyle = miestilo;
            dgPracticas.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgPracticas.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
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
            try
           {
                DateTime diaHora = new DateTime();
                int rowIndex = dgPracticas.CurrentRow.Index;

                if (e.ColumnIndex == 0 )
                {                 
                    if (e.RowIndex != 0 && dgPracticas.Rows[rowIndex - 1].Cells[1].Value != null)
                    {
                        diaHora = Convert.ToDateTime(dgPracticas.Rows[rowIndex - 1].Cells[1].Value.ToString());
                        dgPracticas.CurrentRow.Cells[1].Value = diaHora.AddMinutes(5).ToString("HH:mm", CultureInfo.InvariantCulture);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAsociacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsociacion.Text != "")
            {
                //Grilla ComboBox Nomenclador
                Planilla unaPlanilla = new Planilla();
                unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                DataSet dsPracticas = unaPlanilla.TraerListadoNomencladorPorAsociacion();
                cargarGrillaPracticasCon(dsPracticas);
                unaPlanilla.Dispose();

                TablaNomenclador = null;
                TablaNomenclador = dsPracticas.Tables[0];

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

                //Cargar Combo Diagnosticos
                Diagnostico unDiagnostico = new Diagnostico();
                DataSet dsDiagnostico = unDiagnostico.TraerListadoDiagnosticoPorAsociacion(Convert.ToInt64(cmbAsociacion.SelectedValue));
                unDiagnostico.Dispose();

                //CARGAR COMBO DESCRIPCION
                Utilities.DropDownListManager.CargarCombo(cmbDiagnosticoDescripcion, dsDiagnostico.Tables[0], "diagnostico_id", "diagnostico_descripcion", false, "");
                cmbDiagnosticoDescripcion.AutoCompleteCustomSource = Utilities.AutocompleteComboBox.LoadAutoComplete(dsDiagnostico, "diagnostico_descripcion");
                cmbDiagnosticoDescripcion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDiagnosticoDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbDiagnosticoDescripcion.SelectedIndex = -1;

                //CARGAR COMBO CODIGO
                Utilities.DropDownListManager.CargarCombo(cmbDiagnosticoCodigo , dsDiagnostico.Tables[0], "diagnostico_id", "diagnostico_codigo", false, "");
                cmbDiagnosticoCodigo.AutoCompleteCustomSource = Utilities.AutocompleteComboBox.LoadAutoComplete(dsDiagnostico, "diagnostico_codigo");
                cmbDiagnosticoCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDiagnosticoCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbDiagnosticoCodigo.SelectedIndex = -1;

                diagnosticosCargados = true;

                //TABLA AFILIADOS
                DataSet dsAfiliados = unAfiliado.TraerAfiliadosConFiltrosPorAsociacionID(Convert.ToInt64(cmbAsociacion.SelectedValue));
                dgAfiliados.DataSource = dsAfiliados;
                dsAfiliados.Dispose();
            }
            if (cmbAsociacion.SelectedIndex == -1)
            {
                cmbMedico.DataSource = null;
                cmbDiagnosticoCodigo.DataSource = null;
                cmbDiagnosticoDescripcion.DataSource = null;
                dgPracticas.DataSource = null;                
            }
        }

        private string ValidarCampos()
        {
            //validar fecha es fecha ;)
            //validar horas ;)
            //validar combos != -1 ;)
            //validar afiliado seleccionado
            //validar filas en tabla practicas, que no me guarde las vacias, ni las que no sean practicas. 
            //validar si ord prestacion true --> txtOP <> ""
            
            string strErrores = "";
            try
            {
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbAsociacion.SelectedIndex, "Asociación");
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbMedico.SelectedIndex, "Profesional");
                if (txt2NroAfiliado.Text == "")
                {
                    strErrores = strErrores + "Debe seleccionar un Afiliado\n";
                }
                strErrores = strErrores + Validator.ValidarFecha(txtFecha.Text, "Fecha Ambulatorio");
                strErrores = strErrores + Validator.validarNuloEnComboBox(cmbDiagnosticoCodigo.SelectedIndex, "Diagnóstico");
                strErrores = strErrores + Validator.ValidarHoraEnDataGrid(dgPracticas, 1);

                if (chOP.Checked == true && txtOP.Text == "0")
                {
                    strErrores = strErrores + "Debe ingresar la Orden de Prestación";
                }

                if (strErrores != "")
                {
                    MessageBox.Show(strErrores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strErrores;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                fechaEditar = "";
                if (ValidarCampos() == "")
                {
                    unaPlanilla.Anio = Convert.ToInt64(txtFecha.Text.Substring(6, 4));
                    unaPlanilla.Mes = Convert.ToInt64(txtFecha.Text.Substring(3, 2));
                    unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                    unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                    unaPlanilla.Beneficio = txt2NroAfiliado.Text.ToString();
                    unaPlanilla.Fecha = txtFecha.Text.ToString();
                    unaPlanilla.Diagnostico = cmbDiagnosticoCodigo.SelectedValue.ToString();
                    unaPlanilla.tablaPlanilla.Clear();
                    unaPlanilla.OrdenPrestacion = txtOP.Text;

                    string importarAmbulatorio = "Nuevo Ambulatorio.\n\nProfesional: " + cmbMedico.Text +
                        "\nAfiliado: " + unaPlanilla.Beneficio.ToString() + "\n\nPRACTICAS:\n";

                    foreach (DataGridViewRow row in dgPracticas.Rows)
                    {
                        if (row.Cells[0].Value != null && row.ReadOnly == false)
                        {
                            unaPlanilla.Practica = extraerPractica(row.Cells[0].Value.ToString());
                            unaPlanilla.Hora = row.Cells[1].Value.ToString();

                            DataSet ds = unaPlanilla.ImportarAmbulatorio();

                            if (ds.Tables[0].Rows[0]["Existe"].ToString() == "-1")
                            {
                                if (ds.Tables[0].Rows[0][3].ToString() != unaPlanilla.Hora)
                                {
                                    row.Cells[1].Value = ds.Tables[0].Rows[0][3].ToString();
                                    row.Cells[1].Style.BackColor = Color.LightBlue;
                                }

                                importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + " - Importado Correctamente\n";
                            }
                            if (ds.Tables[0].Rows[0]["Medico"].ToString() == unaPlanilla.Medico.ToString() && ds.Tables[0].Rows[0]["Existe"].ToString() != "2")
                            {
                                importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + " - Ya existe en ambulatorio\n";
                                dgPracticas.Rows[row.Index].DefaultCellStyle.BackColor = Color.AliceBlue;
                            }
                            if (ds.Tables[0].Rows[0]["Existe"].ToString() == "2")
                            {
                                importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + " - Ya posee una Consulta en este mes\n";
                                dgPracticas.Rows[row.Index].DefaultCellStyle.BackColor = Color.AliceBlue;
                            }
                        }
                    }
                    if (importarAmbulatorio != "")
                    {
                        MessageBox.Show(importarAmbulatorio);
                    }
                    dgPracticas.Rows.Clear();
                    cmbDiagnosticoCodigo.SelectedIndex = -1;
                    btn2Atras_Click(sender, e);
                    dgAfiliados.DataSource = null;
                    chOP.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string extraerPractica(string practica)
        {
            string[] tr = practica.Split(' ');
            return tr[0];
        }

        private void txtNombreApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtBeneficio_KeyDown(object sender, KeyEventArgs e)
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

        private void chOP_CheckedChanged(object sender, EventArgs e)
        {
            if (chOP.Checked)
            {
                txtOP.Visible = true;
                txtOP.Text = "";
            }
            else
            {
                txtOP.Visible = false;
                txtOP.Text = "0";
            }
        }

        private void btn2Atras_Click(object sender, EventArgs e)
        {
            //MOSTRAR BUSCADOR
            gbAfiliado.Visible = true;
            txtBeneficio.Visible = true;
            txtDocumento.Visible = true;
            txtNombreApellido.Visible = true;
            lbl1Documento.Visible = true;
            lbl1Nombreapellido.Visible = true;
            lbl1NroAfiliado.Visible = true;
            btnBuscar.Visible = true;
            dgAfiliados.Visible = true;
            dgAfiliados.DataSource = null;

            //OCULTAR AFILIADO SELECCIONADO
            gbAfiliadoSeleccionado.Visible = false;
            txt2Documento.Visible = false;
            txt2NroAfiliado.Visible = false;
            txt2NombreyApellido.Visible = false;
            btn2Atras.Visible = false;

            txtBeneficio.Focus();

            txt2NombreyApellido.Text = "";
            txt2NroAfiliado.Text = "";
            txt2Documento.Text = "";
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Validator.ValidarFecha(txtFecha.Text, "Fecha Ambulatorio") != "" && txtFecha.Text != "")
                {
                    MessageBox.Show("Fecha Inválida");
                }
                else
                {
                    unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                    unaPlanilla.Beneficio = txt2NroAfiliado.Text.ToString();
                    unaPlanilla.Fecha = txtFecha.Text.ToString();
                    unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);

                    DataSet ds = unaPlanilla.ValidarAmbulatorioExistente();

                    DialogResult result;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) == unaPlanilla.Medico)
                        {
                            result = MessageBox.Show("El afiliado ya posee un ambulatorio en esta fecha con este Profesional. \n\n¿Desea editarlo?", "", MessageBoxButtons.YesNo);
                        }
                        else
                        {
                            result = MessageBox.Show("El afiliado ya posee un ambulatorio en esta fecha. \n\n¿Desea editarlo?", "", MessageBoxButtons.YesNo);
                        }

                        if (result == DialogResult.Yes || result == DialogResult.Ignore)
                        {
                            fechaEditar = txtFecha.Text;  //ACA GUARDO LA FECHA A EDITAR, SI ME DIJO QUE SI ES PORQUE YA EXISTE AMBULATORIO. GUARDO LA ANTERIOR POR SI QUIERO EDITAR LA FECHA!
                            medicoPosta = Convert.ToInt64(cmbMedico.SelectedValue); //ACA GUARDO EL MEDICO POSTA POR SI EL AMBULATORIO EXISTENTE ERA DE OTRO MEDICO
                            unaPlanilla.Medico = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
                            cmbMedico.SelectedValue = unaPlanilla.Medico;
                            cmbDiagnosticoCodigo.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["planilla_diagnostico"]);
                            unaPlanilla.OrdenPrestacion = ds.Tables[0].Rows[0]["planilla_modalidad_prestacion"].ToString();

                            if (unaPlanilla.OrdenPrestacion != "0")
                            {
                                chOP.Checked = true;
                                txtOP.Text = unaPlanilla.OrdenPrestacion;
                            }
                            dgPracticas.Rows.Clear();

                            btnNuevo.Visible = false;
                            btnEditar.Visible = true;

                            int index = 0;
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                dgPracticas.Rows.Add(ds.Tables[0].Rows[index][1], ds.Tables[0].Rows[index][2]);
                                dgPracticas.Rows[index].ReadOnly = true;
                                dgPracticas.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                                index++;
                            }
                        }
                    }
                    TablaFechaHoras = unaPlanilla.TraerTablasPlanilla().Tables[3];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDiagnosticoCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiagnosticoCodigo.SelectedValue != null && diagnosticosCargados == true)
            {
                cmbDiagnosticoDescripcion.SelectedValue = cmbDiagnosticoCodigo.SelectedValue;
            }
            else
            {
                cmbDiagnosticoDescripcion.SelectedIndex = -1;
            }
        }

        private void cmbDiagnosticoDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiagnosticoDescripcion.SelectedValue != null && diagnosticosCargados == true)
            {
                cmbDiagnosticoCodigo.SelectedValue = cmbDiagnosticoDescripcion.SelectedValue;
            }
            else
            {
                cmbDiagnosticoCodigo.SelectedIndex = -1;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == "")
            {
                unaPlanilla.Fecha = fechaEditar; //ESTA LA CARGUE CUANDO ME FUI DEL TXTFECHA Y PUSE QUE QUERIA EDITAR AMBULATORIO
                                                 // Y TAMBIEN CUANDO ABRI EL FORM PARA EDITAR AMBULATORIO DESDE LA BUSQUEDA.

                //Hice este fechaEditar porque ya cuando sale del textbox fecha me lo guarda en la planilla fecha para buscar ambulatorios existentes!
                //Elimina el ambulatorio que se eligio para editar. borro todo y lo vuelvo a cargar.
                //Borro los que estan en esa fecha, asi puedo cambiar la fecha tmb!
                unaPlanilla.Anio = Convert.ToInt64(txtFecha.Text.Substring(6, 4));
                unaPlanilla.Mes = Convert.ToInt64(txtFecha.Text.Substring(3, 2));
                unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                unaPlanilla.Beneficio = txt2NroAfiliado.Text.ToString();
                unaPlanilla.OrdenPrestacion = txtOP.Text;

                unaPlanilla.BorrarAmbulatorio();
                
                unaPlanilla.Fecha = txtFecha.Text.ToString();
                unaPlanilla.Diagnostico = cmbDiagnosticoCodigo.SelectedValue.ToString();
                unaPlanilla.tablaPlanilla.Clear();

                string importarAmbulatorio = "Editar Ambulatorio.\n\nProfesional: " + cmbMedico.Text +
                    "\nAfiliado: " + unaPlanilla.Beneficio.ToString() + "\n\nPRACTICAS:\n";

                foreach (DataGridViewRow row in dgPracticas.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        unaPlanilla.Practica = extraerPractica(row.Cells[0].Value.ToString());
                        unaPlanilla.Hora = row.Cells[1].Value.ToString();

                        DataSet ds = unaPlanilla.ImportarAmbulatorio();

                        if (ds.Tables[0].Rows[0]["Existe"].ToString() == "-1")
                        {
                            if (ds.Tables[0].Rows[0][3].ToString() != unaPlanilla.Hora)
                            {
                                row.Cells[1].Value = ds.Tables[0].Rows[0][3].ToString();
                                row.Cells[1].Style.BackColor = Color.LightBlue;
                            }

                            importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + "\n";
                            if(Convert.ToInt64(cmbMedico.SelectedValue) != medicoPosta && row.ReadOnly == false)
                            {
                               unaPlanilla.RegistrarAmbulatorioExistente(medicoPosta);
                            }
                        }
                        if (ds.Tables[0].Rows[0]["Medico"].ToString() == unaPlanilla.Medico.ToString() && ds.Tables[0].Rows[0]["Existe"].ToString() != "2")
                        {
                            importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + " - Ya existe en ambulatorio\n";
                            dgPracticas.Rows[row.Index].DefaultCellStyle.BackColor = Color.AliceBlue;                            
                        }
                        if (ds.Tables[0].Rows[0]["Existe"].ToString() == "2")
                        {
                            importarAmbulatorio = importarAmbulatorio + row.Cells[1].Value.ToString() + " - " + extraerPractica(row.Cells[0].Value.ToString()) + " - Ya posee una Consulta en este mes\n";
                            dgPracticas.Rows[row.Index].DefaultCellStyle.BackColor = Color.AliceBlue;
                        }
                    }
                }

                if (importarAmbulatorio != "")
                {
                    MessageBox.Show(importarAmbulatorio);
                    dgPracticas.Rows.Clear();
                    cmbDiagnosticoCodigo.SelectedIndex = -1;
                    btn2Atras_Click(sender, e);
                    dgAfiliados.DataSource = null;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = true;
                    cmbMedico.SelectedValue = medicoPosta;
                    chOP.Checked = false;
                }
            }
        }

        private void dgPracticas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    DataObject d = dgPracticas.GetClipboardContent();
                    Clipboard.SetDataObject(d);
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {

                    string s = Clipboard.GetText();
                    string[] lines = s.Split('\n');
                    int row = dgPracticas.CurrentCell.RowIndex;
                    int col = dgPracticas.CurrentCell.ColumnIndex;
                    foreach (string line in lines)
                    {
                        if (row < dgPracticas.RowCount && line.Length > 0)
                        {
                            string[] cells = line.Split('\t');
                            for (int i = 0; i < cells.GetLength(0); ++i)
                            {
                                if (col + i < this.dgPracticas.ColumnCount && (col + i) != 6 && (col + i) != 7)
                                {
                                    dgPracticas[col + i, row].Value = Convert.ChangeType(cells[i], dgPracticas[col + i, row].ValueType);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            row++;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                else if (e.KeyCode == Keys.Delete && dgPracticas.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell oneCell in dgPracticas.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            int row = oneCell.RowIndex;
                            int column = oneCell.ColumnIndex;
                            dgPracticas.Rows[row].Cells[column].Value = "";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fechaEditar == txtFecha.Text) //Porque si le cambie la fecha ya es otro ambulatorio. Tendria que eliminarlo antes de cambiarle la fecha.
            {
                DialogResult result = MessageBox.Show("¿Está seguro?\nSe eliminarán todas las practicas que posee \nel Afiliado en esa fecha con este Profesional", "Eliminar Ambulatorio", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                    unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                    unaPlanilla.Beneficio = txt2NroAfiliado.Text.ToString();
                    unaPlanilla.Fecha = txtFecha.Text.ToString();
                    unaPlanilla.BorrarAmbulatorio();

                    dgPracticas.Rows.Clear();
                    cmbDiagnosticoCodigo.SelectedIndex = -1;
                    cmbDiagnosticoDescripcion.SelectedIndex = -1;
                    btn2Atras_Click(sender, e);
                    dgAfiliados.DataSource = null;

                    btnEditar.Visible = false;
                    btnNuevo.Visible = true;
                }
            }
        }

        private void btnEditar_VisibleChanged(object sender, EventArgs e)
        {
            btnEliminar.Visible = btnEditar.Visible;
        }

        private void dgAfiliados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter) && dgAfiliados.Rows.Count > 0)
            {
                //OCULTAR BUSCADOR
                dgAfiliados.Visible = false;
                txtBeneficio.Visible = false;
                txtDocumento.Visible = false;
                txtNombreApellido.Visible = false;
                lbl1Documento.Visible = false;
                lbl1Nombreapellido.Visible = false;
                lbl1NroAfiliado.Visible = false;
                btnBuscar.Visible = false;

                //MOSTRAR AFILIADO SELECCIONADO
                gbAfiliadoSeleccionado.Visible = true;
                txt2Documento.Visible = true;
                txt2NroAfiliado.Visible = true;
                txt2NombreyApellido.Visible = true;
                btn2Atras.Visible = true;

                txt2Documento.Enabled = false;
                txt2NroAfiliado.Enabled = false;
                txt2NombreyApellido.Enabled = false;

                txt2NombreyApellido.Text = dgAfiliados.SelectedRows[0].Cells[0].Value.ToString();
                txt2NroAfiliado.Text = dgAfiliados.SelectedRows[0].Cells[1].Value.ToString() + dgAfiliados.SelectedRows[0].Cells[2].Value.ToString();
                txt2Documento.Text = dgAfiliados.SelectedRows[0].Cells[3].Value.ToString() + " " + dgAfiliados.SelectedRows[0].Cells[4].Value.ToString();

                txtFecha.Focus();
            }
        }

    }
}
