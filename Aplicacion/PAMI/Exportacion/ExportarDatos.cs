using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;
using Excepciones;
using Conexion;


namespace PAMI.Exportacion
{
    public partial class ExportarDatos : Form
    {

        public FSLogger fs;
        private int columnaNro = 0;
        private int cantidadFilas = 0;
        private string cadena = "";
        private List<SqlParameter> parameterList = new List<SqlParameter>();


        public ExportarDatos()
        {
            InitializeComponent();
        }

        private bool ValidarExistenAmbulatoriosAsociacion()
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", Convert.ToInt64(cmbAsociacion.SelectedValue)));
            parameterList.Add(new SqlParameter("@Mes", cmbMes.SelectedValue.ToString()));
            parameterList.Add(new SqlParameter("@Anio", txtAnio.Text));

            DataSet ds = Conexion.SQLHelper.ExecuteDataSet("ValidarExistenAmbulatoriosAsociacion", CommandType.StoredProcedure, parameterList);
            return Convert.ToInt64(ds.Tables[0].Rows[0][0]) != 0;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidarCampos() && ValidarExistenAmbulatoriosAsociacion())
                {

                    //Traer DATOS ASOCIACION para armar archivo .TXT
                    parameterList.Clear();
                    parameterList.Add(new SqlParameter("@AsocID", cmbAsociacion.SelectedValue));
                    DataSet dsAmbulatorio = new DataSet();
                    dsAmbulatorio = Conexion.SQLHelper.ExecuteDataSet("TraerListadoPrestadorPorAsociacionID", CommandType.StoredProcedure, parameterList);

                    string nombreArchivo = "";
                    nombreArchivo = dsAmbulatorio.Tables[0].Rows[0]["prestador_nombre_corto"].ToString() + '_' +
                                    dsAmbulatorio.Tables[0].Rows[0]["usuario_nombre"].ToString() + '_' + cmbMes.SelectedValue.ToString() + '-' + txtAnio.Text;

                    fs = new FSLogger(nombreArchivo);

                    DataSet ds = new DataSet();

                    //Traigo los datos y los voy copiando al txt

                    //CABECERA
                    ds = traerListadosBD("Cabecera",2);
                    ExportarEncabezado("CABECERA", ds);

                    //PROFESIONALES                  
                    ds = traerListadosBD("Profesionales",2);
                    ExportarEncabezado("PROFESIONAL", ds);

                    //PRESTADOR
                    ds = traerListadosBD("Prestador",1);
                    ExportarEncabezado("PRESTADOR", ds);

                    //REL_PROFESIONALESXPRESTADOR
                    ds = traerListadosBD("REL_PROFESIONALESXPRESTADOR",2);
                    ExportarEncabezado("REL_PROFESIONALESXPRESTADOR", ds);

                    //BOCA ATENCION
                    ds = traerListadosBD("BocaAtencion",1);
                    ExportarEncabezado("BOCA_ATENCION", ds);

                    //REL_MODULOSXPRESTADOR
                    ds = traerListadosBD("REL_MODULOSXPRESTADOR",1);
                    ExportarEncabezado("REL_MODULOSXPRESTADOR", ds);

                    //BENEFICIO
                    ds = traerListadosBD("BENEFICIO",2);
                    ExportarEncabezado("BENEFICIO", ds);

                    //AFILIADO
                    ds = traerListadosBD("AFILIADO",2);
                    ExportarEncabezado("AFILIADO", ds);

                    //PRESTACIONES
                    fs.EscribirEncabezado("PRESTACIONES");

                    //AMBULATORIOS
                    ds = traerListadosBD("AMBULATORIOS",2);
                    ExportarAmbulatorios(ds);

                    parameterList.Clear();
                    parameterList.Add(new SqlParameter("@AsocID", cmbAsociacion.SelectedValue));
                    Conexion.SQLHelper.ExecuteDataSet("AumentarContadorEmulaciones", CommandType.StoredProcedure, parameterList);
                    MessageBox.Show("Se ha generado el archivo: " + nombreArchivo + "\nAsociacion: " + cmbAsociacion.Text + "\nCantidad ambulatorios: " + ds.Tables[0].Rows.Count, " ");
                    

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


        //ENCABEZADOS EMULADOR. CABECERA, BOCA ATENCION, AFILIADOS, BENEFICIOS, RED ETC.
        private void ExportarEncabezado(string encabezado, DataSet ds)
        {
            columnaNro = ds.Tables[0].Columns.Count;
            cantidadFilas = ds.Tables[0].Rows.Count;

            fs.EscribirEncabezado(encabezado);

            for (int j = 0; j < cantidadFilas; j++)
            {
                escribirLinea(j,ds);
            }
        }

        //ARMAR LOS AMBULATORIOS
        private void ExportarAmbulatorios(DataSet ds)
        {
            cantidadFilas = ds.Tables[0].Rows.Count;
            //COLUMNAS AMBULATORIO = 16

            cadena = "";

            for (int j = 0; j < cantidadFilas; j++)
            {
                //TABLA AMBULATORIOS
                fs.EscribirEncabezado("AMBULATORIO");
                columnaNro = 16;
                for (int i = 0; i < columnaNro; i++)
                {
                    cadena = cadena + ds.Tables[0].Rows[j][i].ToString();

                    if (i != columnaNro - 1)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";


                //TABLA REL_DIAGNOSTICOS X AMBULATORIOS
                fs.EscribirEncabezado("REL_DIAGNOSTICOSXAMBULATORIO");
                columnaNro = 23;
                for (int i = 16; i < columnaNro; i++)
                {
                    cadena = cadena + ds.Tables[0].Rows[j][i].ToString();

                    if (i != columnaNro - 1)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";

                //TABLA REL_PRACTICASREALIZADASXAMBULATORIO
                fs.EscribirEncabezado("REL_PRACTICASREALIZADASXAMBULATORIO");
                columnaNro = 33;
                for (int i = 23; i < columnaNro; i++)
                {
                    cadena = cadena + ds.Tables[0].Rows[j][i].ToString();

                    if (i != columnaNro - 1)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";               

                fs.EscribirEncabezado("FIN AMBULATORIO");
            }
        }

        private void escribirDatosAmbulatorio(int ambulatorio)
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@Ambulatorio", ambulatorio));
            DataSet dsAmbulatorio = new DataSet();
            dsAmbulatorio = Conexion.SQLHelper.ExecuteDataSet("TraerListadoDatosAmbulatorio", CommandType.StoredProcedure, parameterList);

            int filas = 0;
            int columnas = 0;

            filas = dsAmbulatorio.Tables[0].Rows.Count;
            columnas = dsAmbulatorio.Tables[0].Columns.Count;


            fs.EscribirEncabezado("REL_DIAGNOSTICOSXAMBULATORIO");
            for (int j = 0; j < filas; j++)
            {
                for (int i = 0; i < columnas; i++)
                {
                    cadena = cadena + dsAmbulatorio.Tables[0].Rows[j][i].ToString();
                    if (i != columnaNro - 2)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";
            }

            filas = dsAmbulatorio.Tables[1].Rows.Count;
            columnas = dsAmbulatorio.Tables[1].Columns.Count;

            fs.EscribirEncabezado("REL_PRACTICASREALIZADASXAMBULATORIO");
            for (int j = 0; j < filas; j++)
            {
                for (int i = 0; i < columnas; i++)
                {
                    cadena = cadena + dsAmbulatorio.Tables[1].Rows[j][i].ToString();
                    if (i != columnaNro - 3)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";
            }
        }

        private void escribirLinea(int j, DataSet ds)
        {

            for (int i = 0; i < columnaNro; i++)
            {
                cadena = cadena + ds.Tables[0].Rows[j][i].ToString();
                if (i != columnaNro - 1)  //POR QUE MENOS DOS????????
                {
                    cadena = cadena + ";";
                }
            }
            fs.EscribirEncabezado(cadena);
            cadena = "";
        }

        private DataSet traerListadosBD(string Tabla, int parametros)
        {
            if (parametros == 1)
            {
                parameterList.Clear();
                parameterList.Add(new SqlParameter("@AsocID",  Convert.ToInt64(cmbAsociacion.SelectedValue)));
            }
            else if (parametros == 2)
            {
                parameterList.Clear();
                parameterList.Add(new SqlParameter("@AsocID", Convert.ToInt64(cmbAsociacion.SelectedValue)));
                parameterList.Add(new SqlParameter("@Mes", cmbMes.SelectedValue.ToString()));
                parameterList.Add(new SqlParameter("@Anio", txtAnio.Text));
            }
            return SQLHelper.ExecuteDataSet("TraerListado" + Tabla + "ParaExportar", CommandType.StoredProcedure, Tabla,parameterList);
        }

        private void ExportarDatos_Load(object sender, EventArgs e)
        {            
            Utilities.DropDownListManager.CargarCombo(cmbMes, Base.TablaMeses(), "numeroMes", "nombreMes", false, "");
            cmbMes.SelectedIndex = DateTime.Today.AddMonths(-2).Month;
            txtAnio.Text = DateTime.Now.Year.ToString();

            //Combo Asociacion
            Asociacion unaAsociacion = new Asociacion();
            DataSet dsAsociacion = unaAsociacion.TraerListado("Completo");
            Utilities.DropDownListManager.CargarCombo(cmbAsociacion, dsAsociacion.Tables[0], "asociacion_id", "asociacion_nombre", false, "");
            unaAsociacion.Dispose();
        }
      

        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbAsociacion.SelectedIndex, "Asociación");
            strErrores = strErrores + Validator.ValidarNulo(txtAnio.Text, "Año");
            strErrores = strErrores + Validator.validarNuloEnComboBox(cmbMes.SelectedIndex, "Mes");
            if (strErrores != "")
            {
                MessageBox.Show(strErrores);
                return false;
            }
            else
            {
                return true;
            }
        }        
    }
}
