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

namespace PAMI.PlanillaPami
{
    public partial class formPlanilla : Form
    {       
        //Variables
        Planilla unaPlanilla = new Planilla();
        DataTable TablaDiagnosticos = new DataTable();
        DataTable TablaAfiliados = new DataTable();
        DataTable TablaNomenclador = new DataTable();
        DataTable TablaFechaHora = new DataTable();

        public formPlanilla()
        {
            InitializeComponent();
        }

        public void AbrirParaNuevaPlanilla()
        {
            btnBuscar.Visible = false;
            btnValidar.Visible = true;
        }

        public void AbrirParaBuscar()
        {
            btnValidar.Visible = false;
            btnBuscar.Visible = true;
            btnImportar.Visible = false;
        }

        private void Planilla_Load(object sender, EventArgs e)
        {
            Utilities.DropDownListManager.CargarCombo(cmbMes, Base.TablaMeses(), "numeroMes", "nombreMes", false, "");
            cmbMes.SelectedIndex = DateTime.Today.AddMonths(-2).Month; 
            txtAnio.Text = DateTime.Now.Year.ToString();
            CrearGrilla();
            rellenarGrillaCeldasBlancas();
            crearTablas();

            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();

            cmbAsociacion.SelectedIndex = -1;
            
        }

        private void crearTablas()
        {
            //TABLA DIAGNOSTICOS
            TablaDiagnosticos.Columns.Add("Diagnostico_Codigo",typeof(string));
            TablaDiagnosticos.Columns.Add("Diagnostico_Descripcion", typeof(string));

            //TABLA AFILIADOS
            TablaAfiliados.Columns.Add("Beneficio", typeof(string));
            TablaAfiliados.Columns.Add("Documento", typeof(string));

            //TABLA NOMENCLADOR
            TablaNomenclador.Columns.Add("Practica", typeof(string));

            //TABLA FECHA Y HORA
            TablaFechaHora.Columns.Add("Fecha", typeof(string));
            TablaFechaHora.Columns.Add("Hora", typeof(string));
        }

        private void CrearGrilla()
        {
            dgPlanilla.Columns.Clear();
            dgPlanilla.AutoGenerateColumns = false;
            dgPlanilla.RowHeadersVisible = false;
            dgPlanilla.AllowUserToResizeRows = false;

            DataGridViewTextBoxColumn clm_Fecha = new DataGridViewTextBoxColumn();
            clm_Fecha.Width = 100;
            clm_Fecha.ReadOnly = false;
            clm_Fecha.HeaderText = "Fecha";
            dgPlanilla.Columns.Add(clm_Fecha);

            DataGridViewTextBoxColumn clm_Nombre = new DataGridViewTextBoxColumn();
            clm_Nombre.Width = 400;
            clm_Nombre.ReadOnly = false;
            clm_Nombre.HeaderText = "Apellido y Nombre";
            dgPlanilla.Columns.Add(clm_Nombre);

            DataGridViewTextBoxColumn clm_Beneficio = new DataGridViewTextBoxColumn();
            clm_Beneficio.Width = 160;
            clm_Beneficio.ReadOnly = false;
            clm_Beneficio.HeaderText = "Beneficio";
            dgPlanilla.Columns.Add(clm_Beneficio);

            DataGridViewTextBoxColumn clm_Diagnostico = new DataGridViewTextBoxColumn();
            clm_Diagnostico.Width = 250;
            clm_Diagnostico.ReadOnly = false;
            clm_Diagnostico.HeaderText = "Diagnóstico";
            dgPlanilla.Columns.Add(clm_Diagnostico);

            DataGridViewTextBoxColumn clm_Practica = new DataGridViewTextBoxColumn();
            clm_Practica.Width = 100;
            clm_Practica.ReadOnly = false;
            clm_Practica.HeaderText = "Práctica";
            dgPlanilla.Columns.Add(clm_Practica);

            DataGridViewTextBoxColumn clm_Hora = new DataGridViewTextBoxColumn();
            clm_Hora.Width = 100;
            clm_Hora.ReadOnly = false;
            clm_Hora.HeaderText = "Hora";
            dgPlanilla.Columns.Add(clm_Hora);

            DataGridViewCheckBoxColumn clm_Estado = new DataGridViewCheckBoxColumn();
            clm_Estado.Width = 63;
            clm_Estado.ReadOnly = true;
            clm_Estado.HeaderText = "Estado";
            dgPlanilla.Columns.Add(clm_Estado);

            DataGridViewTextBoxColumn clm_Validacion = new DataGridViewTextBoxColumn();
            clm_Validacion.Width = 405;
            clm_Validacion.ReadOnly = true;
            clm_Validacion.HeaderText = "Validación";
            dgPlanilla.Columns.Add(clm_Validacion);

            DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
            miestilo.Font = new Font("Franklin Gothic Book", 11);           

            dgPlanilla.EnableHeadersVisualStyles = false;
            dgPlanilla.ColumnHeadersDefaultCellStyle = miestilo;
            dgPlanilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkCyan;
            dgPlanilla.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro; 
        }

        private void rellenarGrillaCeldasBlancas()
        {
            for (int i = 1; i <= 1000; i++)
            {
                dgPlanilla.Rows.Add("");
            }
        }

        private void dgPlanilla_KeyDown(object sender, KeyEventArgs e)
        {

        try{
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dgPlanilla.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {

                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = dgPlanilla.CurrentCell.RowIndex;
                int col = dgPlanilla.CurrentCell.ColumnIndex;
                foreach (string line in lines)
                {
                    if (row < dgPlanilla.RowCount && line.Length >0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            if (col + i < this.dgPlanilla.ColumnCount && (col + i) != 6 && (col + i) != 7)
                            {
                                dgPlanilla[col + i, row].Value = Convert.ChangeType(cells[i], dgPlanilla[col + i, row].ValueType);
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
            else if (e.KeyCode == Keys.Delete && dgPlanilla.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell oneCell in dgPlanilla.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        int row = oneCell.RowIndex;
                        int column = oneCell.ColumnIndex;
                        dgPlanilla.Rows[row].Cells[column].Value = "";
                        if (oneCell.ColumnIndex == 6) { dgPlanilla.Rows[row].Cells[column].Value = false; }
                    }
                }
             }
        }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoEntidadException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string strCombos = validarCombosSeleccionados();

            if (rellenarCeldas() != 0 && strCombos == "")
            {
                try
                {
                    //traer tablas para verificar datos
                    unaPlanilla.Mes = cmbMes.SelectedIndex + 1;
                    unaPlanilla.Anio = Convert.ToInt64(txtAnio.Text);
                    unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                    unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);


                    DataSet ds = unaPlanilla.TraerTablasPlanilla();  
                    /*el ds va a tener en TABLE
                     * 0  beneficios afiliados
                     * 1  Diagnosticos
                     * 2  Nomenclador
                     * 3  Fechas y horas ya cargadas para el medico este*/

                    TablaAfiliados = ds.Tables[0];
                    TablaDiagnosticos = ds.Tables[1];
                    TablaNomenclador = ds.Tables[2];
                    TablaFechaHora = ds.Tables[3];

                    int estado = 0;
                    foreach (DataGridViewRow oneRow in dgPlanilla.Rows)
                    {
                        if (oneRow.Cells[0].Value.ToString() == "")
                        {
                            break;
                        }
                        string strErrores = "";
                        strErrores = strErrores + Validator.ValidarFecha(oneRow.Cells[0].Value.ToString(), "Fecha");
                        if (oneRow.Cells[0].Value.ToString().Substring(3, 2) == cmbMes.SelectedValue.ToString() && oneRow.Cells[0].Value.ToString().Substring(6, 4) == txtAnio.Text)
                        {
                            strErrores = strErrores + "La fecha no se corresponde al periodo seleccionado\n";
                        }
                        strErrores = strErrores + Validator.ValidarSoloLetras(oneRow.Cells[1].Value.ToString(), "Afiliado");
                        strErrores = strErrores + Validator.SoloNumeros(oneRow.Cells[4].Value.ToString(), "Práctica");
                        strErrores = strErrores + Validator.ValidarHora(oneRow.Cells[5].Value.ToString(), "Hora");

                        if (strErrores == "")
                        {
                            //VALIDAR QUE ESTEN EN LAS TABLAS!
                            strErrores = ValidarExistenciaEnTablas(oneRow);
                            if (strErrores == "")
                            {
                                oneRow.Cells[6].Value = true;
                                oneRow.Cells[7].Value = "Listo Para Importar";
                            }
                            else
                            {
                                estado = -1;
                                oneRow.Cells[6].Value = false;
                                oneRow.Cells[7].Value = strErrores;
                            }
                        }
                        else
                        {
                            oneRow.Cells[6].Value = false;
                            estado = -1;
                            oneRow.Cells[7].Value = strErrores;
                        }
                    }
                    if (estado == -1)
                    {
                        MessageBox.Show("Datos Inválidos.", "");
                    }
                    else
                    {
                        MessageBox.Show("Planilla lista para Importar.", "Validación Exitosa");
                    }
                }
                catch (ErrorConsultaException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (BadInsertException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NoDataException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NoEntidadException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {}
        }

        private string ValidarExistenciaEnTablas(DataGridViewRow oneRow)
        {
            //VERIFICA QUE SEAN COSAS VALIDAS. QUE LA PRACTICA EXISTA,EL DIAGNOSTICO EXISTE, BENEFICIO, ETC. tambien que no se pisen horas y dias.

            string strErrores = "No se encontró: ";
            
            //Verificar beneficio DNI
            bool beneficio = TablaAfiliados.AsEnumerable().Any(x => x.Field<string>("Beneficio") == oneRow.Cells[2].Value.ToString());
            bool dni = TablaAfiliados.AsEnumerable().Any(x => x.Field<string>("Documento") == oneRow.Cells[2].Value.ToString());
            if (dni || beneficio)  
            { }else {strErrores = strErrores + "Afiliado, ";}

            //Verificar Diagnostico
            if (TablaDiagnosticos.AsEnumerable().Any(x => x.Field<string>("Diagnostico_Codigo") == oneRow.Cells[3].Value.ToString())
                ||
                TablaDiagnosticos.AsEnumerable().Any(x => Editor.NormalizarCadena(x.Field<string>("Diagnostico_Descripcion")).Contains(oneRow.Cells[3].Value.ToString()))
                )
            {}else
                {strErrores = strErrores + "Diagnostico, ";}

            //Verificar Nomenclador
            if (!TablaNomenclador.AsEnumerable().Any(x => x.Field<string>("Practica") == oneRow.Cells[4].Value.ToString()))
            {
                strErrores = strErrores + "Practica.";
            }

            if (strErrores == "No se encontró: ")
            {
                strErrores = "";
            }

            return strErrores;    
        }

        private int rellenarCeldas()
        {
            //Completar espacios vacios en fecha, nombre, beneficio, diagnostico y horas.
            int filaActual = 0;
            int columnaActual = 0;
            int cantidadFilas = 0; //contador filas con datos

            try
            {          
                 //Cuento cantidad de filas con datos
                while (dgPlanilla.Rows[filaActual].Cells[4].Value != null) { cantidadFilas++; filaActual++; }

                if (cantidadFilas > 1)
                {
                    //Arreglo fila 0
                    filaActual = 0;

                    dgPlanilla.Rows[filaActual].Cells[0].Value = Editor.NormalizarFecha(dgPlanilla.Rows[filaActual].Cells[0].Value.ToString());
                    dgPlanilla.Rows[filaActual].Cells[1].Value = Editor.NormalizarCadena(dgPlanilla.Rows[filaActual].Cells[1].Value.ToString());
                    dgPlanilla.Rows[filaActual].Cells[2].Value = Regex.Replace(dgPlanilla.Rows[filaActual].Cells[2].Value.ToString(), @"[^\d]", "");
                    dgPlanilla.Rows[filaActual].Cells[3].Value = Editor.NormalizarCadena(dgPlanilla.Rows[filaActual].Cells[3].Value.ToString());
                    dgPlanilla.Rows[filaActual].Cells[4].Value = Regex.Replace(dgPlanilla.Rows[filaActual].Cells[4].Value.ToString(), @"[^\d]", "");
                    dgPlanilla.Rows[filaActual].Cells[5].Value = Editor.NormalizarHora(dgPlanilla.Rows[filaActual].Cells[5].Value.ToString());
                    
                    filaActual = 1;

                    while (!string.IsNullOrEmpty(dgPlanilla.Rows[filaActual].Cells[4].Value as string))
                    {
                        while (columnaActual < 4)
                        {
                            if (string.IsNullOrEmpty(dgPlanilla.Rows[filaActual].Cells[columnaActual].Value as string))
                            {
                                dgPlanilla.Rows[filaActual].Cells[columnaActual].Value = dgPlanilla.Rows[filaActual - 1].Cells[columnaActual].Value.ToString();
                            }
                            columnaActual++;
                        }
                       
                        columnaActual = 0;

                        dgPlanilla.Rows[filaActual].Cells[0].Value = Editor.NormalizarFecha(dgPlanilla.Rows[filaActual].Cells[0].Value.ToString());
                        dgPlanilla.Rows[filaActual].Cells[1].Value = Editor.NormalizarCadena(dgPlanilla.Rows[filaActual].Cells[1].Value.ToString());
                        dgPlanilla.Rows[filaActual].Cells[2].Value = Regex.Replace(dgPlanilla.Rows[filaActual].Cells[2].Value.ToString(), @"[^\d]", "");
                        dgPlanilla.Rows[filaActual].Cells[3].Value = Editor.NormalizarCadena(dgPlanilla.Rows[filaActual].Cells[3].Value.ToString());
                        dgPlanilla.Rows[filaActual].Cells[4].Value = Regex.Replace(dgPlanilla.Rows[filaActual].Cells[4].Value.ToString(), @"[^\d]", "");
                        dgPlanilla.Rows[filaActual].Cells[5].Value = Editor.NormalizarHora(dgPlanilla.Rows[filaActual].Cells[5].Value.ToString());
                        filaActual++;   
                    }
                }
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cantidadFilas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgPlanilla.Rows.Clear();
            rellenarGrillaCeldasBlancas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarCombosSeleccionados() == "")
            {
                unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);
                unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                DataSet ds = unaPlanilla.TraerPlanillasPorMedico();
                cargarGrilla(ds);
            }
            else
            {
                MessageBox.Show("Seleccionar Asociación / Médico", "Faltan Datos");
            }
        }

        private void cargarGrilla(DataSet ds)
        {
            dgPlanilla.DataSource = ds.Tables[0];
        }

        private string validarCombosSeleccionados()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbAsociacion.SelectedIndex, "Asociación");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbMedico.SelectedIndex, "Médico");
            return strErrores;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que todos estan correctos.
                bool estadocheckbox = false;
                estadocheckbox = (dgPlanilla.Rows[0].Cells[4].Value != null);

                unaPlanilla.tablaPlanilla.Clear();

                foreach (DataGridViewRow row in dgPlanilla.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[6];
                    if (chk.Value == chk.FalseValue && row.Cells[4].Value != null)
                    {
                        MessageBox.Show("Existen Datos Inválidos", "Error al Importar");
                        estadocheckbox = false;
                        break;
                    }
                    if (row.Cells[4].Value == null) { break; }
                }

                if (estadocheckbox)
                {
                    unaPlanilla.Mes = Convert.ToInt64(cmbMes.SelectedValue);
                    unaPlanilla.Anio = Convert.ToInt64(txtAnio.Text);
                    unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                    unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);

                   //Verificar que no tiene ambulatorios en ese dia con otro médico. 
                    DataSet ds = new DataSet();

                    foreach (DataGridViewRow row in dgPlanilla.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            unaPlanilla.Fecha = row.Cells[0].Value.ToString();
                            unaPlanilla.Beneficio = row.Cells[2].Value.ToString();
                            unaPlanilla.Diagnostico = row.Cells[3].Value.ToString();
                            unaPlanilla.Practica = row.Cells[4].Value.ToString();
                            unaPlanilla.Hora = row.Cells[5].Value.ToString();
                            unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);

                            ds = unaPlanilla.ImportarAmbulatorio();

                            //ERROR DE AMBULATORIO YA EXISTENTE. NO SE IMPORTO

                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                if (ds.Tables[0].Rows[0]["Existe"].ToString() == "-1")
                                {
                                    if (ds.Tables[0].Rows[0][3].ToString() != unaPlanilla.Hora)
                                    {
                                        row.Cells[5].Value = ds.Tables[0].Rows[0][3].ToString();
                                        row.Cells[5].Style.BackColor = Color.LightBlue;
                                    }
                                    row.Cells[6].Value = true;
                                    row.Cells[7].Value = "Importado Correctamente";
                                }
                                if (ds.Tables[0].Rows[0]["Medico"].ToString() == unaPlanilla.Medico.ToString())
                                {
                                    row.Cells[6].Value = true;
                                    row.Cells[7].Value = "Práctica ya cargada en ambulatorio con este Profesional";
                                }
                                if (ds.Tables[0].Rows[0]["Medico"].ToString() != unaPlanilla.Medico.ToString() &&
                                    ds.Tables[0].Rows[0]["Existe"].ToString() != "-1")
                                {
                                    DataRow newRow = unaPlanilla.tablaPlanilla.NewRow();
                                    newRow["Planilla_medico_secundario_matricula"] = ds.Tables[0].Rows[0]["Medico"].ToString();
                                    newRow["Planilla_medico_secundario_nombre"] = ds.Tables[0].Rows[0]["MedicoNombre"].ToString();
                                    newRow["Planilla_beneficio"] = unaPlanilla.Beneficio;
                                    newRow["Planilla_practica"] = unaPlanilla.Practica;
                                    newRow["Planilla_fecha"] = unaPlanilla.Fecha;
                                    newRow["Planilla_hora"] = unaPlanilla.Hora;
                                    newRow["Planilla_diagnostico"] = unaPlanilla.Diagnostico;
                                    newRow["Existe"] = ds.Tables[0].Rows[0]["Existe"].ToString();

                                    row.Cells[6].Value = false;
                                    row.Cells[7].Value = "Ya posee un ambulatorio existente";
                                    unaPlanilla.tablaPlanilla.Rows.Add(newRow);
                                }
                            }
                        }
                    }

                    //Mostrar ambulatorios no cargados.

                    if (unaPlanilla.tablaPlanilla.Rows.Count != 0)
                    {
                        AmbulatorioExistente ambulatorios = new AmbulatorioExistente();
                        ambulatorios.abrirCon(unaPlanilla, unaPlanilla.Medico);
                        ambulatorios.Show();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Planilla Importada Correctamente", "Importar Planilla", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}









