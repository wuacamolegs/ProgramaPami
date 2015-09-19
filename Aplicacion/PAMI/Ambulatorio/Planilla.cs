using System;
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
using System.Text.RegularExpressions;

namespace PAMI.PlanillaPami
{
    public partial class PlanillasPami : Form
    {       
        public PlanillasPami()
        {
            InitializeComponent();

        }

        private void Planilla_Load(object sender, EventArgs e)
        {
            CrearGrilla();
            txtAnio.Text = DateTime.Now.Year.ToString();
            cmbMes.SelectedIndex = DateTime.Now.Month - 2;

        }

        private void CrearGrilla()
        {
            dgPlanilla.Columns.Clear();
            dgPlanilla.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clm_Fecha = new DataGridViewTextBoxColumn();
            clm_Fecha.Width = 100;
            clm_Fecha.ReadOnly = false;
            clm_Fecha.HeaderText = "Fecha";
            dgPlanilla.Columns.Add(clm_Fecha);

            DataGridViewTextBoxColumn clm_Nombre = new DataGridViewTextBoxColumn();
            clm_Nombre.Width = 160;
            clm_Nombre.ReadOnly = false;
            clm_Nombre.HeaderText = "Apellido y Nombre";
            dgPlanilla.Columns.Add(clm_Nombre);

            DataGridViewTextBoxColumn clm_Beneficio = new DataGridViewTextBoxColumn();
            clm_Beneficio.Width = 160;
            clm_Beneficio.ReadOnly = false;
            clm_Beneficio.HeaderText = "Beneficio";
            dgPlanilla.Columns.Add(clm_Beneficio);

            DataGridViewTextBoxColumn clm_Diagnostico = new DataGridViewTextBoxColumn();
            clm_Diagnostico.Width = 100;
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
            clm_Estado.Width = 53;
            clm_Estado.ReadOnly = true;
            clm_Estado.HeaderText = "Estado";
            dgPlanilla.Columns.Add(clm_Estado);

            DataGridViewTextBoxColumn clm_Validacion = new DataGridViewTextBoxColumn();
            clm_Validacion.Width = 400;
            clm_Validacion.ReadOnly = true;
            clm_Validacion.HeaderText = "Validación";
            dgPlanilla.Columns.Add(clm_Validacion);

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
                            if (col + i < this.dgPlanilla.ColumnCount)
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
                        dgPlanilla.Rows[row].Cells[column].Value = " ";
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
            if (true)//rellenarCeldas() != 0)
            {
                try{

                    Planilla unaPlanilla = new Planilla();
                    int estado = 0;

                    foreach (DataGridViewRow oneRow in dgPlanilla.Rows)
                    {

                        if (oneRow.Cells[0].Value.ToString() == "")
                        {
                            break;
                        }
                        string strErrores = "";
                        strErrores = strErrores + Validator.ValidarFecha(oneRow.Cells[0].Value.ToString(), "Fecha");
                        strErrores = strErrores + Validator.ValidarSoloLetras(oneRow.Cells[1].Value.ToString(), "Afiliado");
                        strErrores = strErrores + Validator.SoloNumeros(oneRow.Cells[4].Value.ToString(), "Práctica");
                        strErrores = strErrores + Validator.ValidarHora(oneRow.Cells[5].Value.ToString(), "Hora");

                        if (strErrores == "")
                        {
                            oneRow.Cells[6].Value = true;
                            unaPlanilla.tablaPlanilla.Rows.Add(oneRow);
                            oneRow.Cells[7].Value = "Correcto";
                        }
                        else
                        {
                            oneRow.DefaultCellStyle.BackColor = Color.LightBlue;
                            oneRow.Cells[6].Value = false;
                            estado = -1;
                            oneRow.Cells[7].Value = strErrores;
                        }
                    }
                    if (estado == -1)
                    {
                        MessageBox.Show("Datos Invalidos", "");
                    }

                    else
                    {
                        unaPlanilla.Mes = cmbMes.SelectedIndex + 1;
                        unaPlanilla.Anio = Convert.ToInt64(txtAnio.Text);
                        unaPlanilla.Medico = Convert.ToInt64(cmbMedico.SelectedValue);
                        unaPlanilla.Asociacion = Convert.ToInt64(cmbAsociacion.SelectedValue);

                        //   unaPlanilla.ImportarPlanilla();
                        //   unaPlanilla.Dispose();  o crearGrilla. dispose la elimina completamente!
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
        }

        private int rellenarCeldas()
        {
            //Completar espacios vacios en fecha, nombre,beneficio y diagnostico\
            int filaActual = 0;
            int columnaActual = 0;
            int cantidadFilas = 0; //contador filas con datos

            try
            {
                //Cuento cantidad de filas con datos
                while (dgPlanilla.Rows[filaActual].Cells[4].Value != null) { cantidadFilas++; filaActual++; }

                if (cantidadFilas != 0)
                {
                    filaActual = 0;

                    //COMPLETO Y PONGO EN MAYS LAS CADENAS (las fechas quedan todas juntas sin barras ni guiones)
                    while (columnaActual < 4)
                    {
                        while (filaActual < cantidadFilas)
                        {
                            if (dgPlanilla.Rows[filaActual].Cells[columnaActual].Value.ToString() == "")
                            {
                                dgPlanilla.Rows[filaActual].Cells[columnaActual].Value = dgPlanilla.Rows[filaActual - 1].Cells[columnaActual].Value;
                            }
                            dgPlanilla.Rows[filaActual].Cells[columnaActual].Value = Editor.NormalizarCadena(dgPlanilla.Rows[filaActual].Cells[columnaActual].Value.ToString());
                            filaActual++;
                        }
                        filaActual = 0;
                        columnaActual++;
                    }

                    //Arreglar Fechas y Horas

                    while (filaActual < cantidadFilas)
                    {

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
            return cantidadFilas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgPlanilla.Rows.Clear();
        }
    }
}









