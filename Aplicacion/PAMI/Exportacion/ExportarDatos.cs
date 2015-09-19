using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excepciones;
using Conexion;
using Utilities;


namespace PAMI.Exportacion
{
    public partial class ExportarDatos : Form
    {

        public FSLogger fs;
        private int cantidadColumnas = 0;
        private int cantidadFilas = 0;
        private string cadena = "";
        private List<SqlParameter> parameterList = new List<SqlParameter>();


        public ExportarDatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fs = new FSLogger("nov");

            //LO HAGO AHORA ASI PARA NOVIEMBRE!!!!

            this.barraEstado1.Value = 0;

            this.timer1.Interval = 1;
            this.timer1.Enabled = true; 


            DataSet ds = new DataSet();

            //CABECERA
            this.barraEstado1.Value++;
            ds = traerListadosBD("Cabecera");
            ExportarEncabezado("CABECERA", ds);

            //PROFESIONALES                  
            this.barraEstado1.Value++;
            ds = traerListadosBD("Profesionales");
            ExportarEncabezado("PROFESIONAL",ds);

            //PRESTADOR

            ds = traerListadosBD("Prestador");
            ExportarEncabezado("PRESTADOR", ds);

            //REL_PROFESIONALESXPRESTADOR

            ds = traerListadosBD("REL_PROFESIONALESXPRESTADOR");
            ExportarEncabezado("REL_PROFESIONALESXPRESTADOR", ds);

            //BOCA ATENCION

            ds = traerListadosBD("BocaAtencion");
            ExportarEncabezado("BOCA_ATENCION", ds);

            //REL_MODULOSXPRESTADOR

            ds = traerListadosBD("REL_MODULOSXPRESTADOR");
            ExportarEncabezado("REL_MODULOSXPRESTADOR", ds);

            //BENEFICIO

            ds = traerListadosBD("BENEFICIO");
            ExportarEncabezado("BENEFICIO", ds);

            //AFILIADO

            ds = traerListadosBD("AFILIADO");
            ExportarEncabezado("AFILIADO", ds);

            //PRESTACIONES

            fs.EscribirEncabezado("PRESTACIONES");

            //AMBULATORIOS

            ds = traerListadosBD("AMBULATORIOS");
            ExportarAmbulatorios(ds);

            MessageBox.Show("LISTOOO", " ");
        }

        private void ExportarEncabezado(string encabezado, DataSet ds)
        {
            cantidadColumnas = ds.Tables[0].Columns.Count;
            cantidadFilas = ds.Tables[0].Rows.Count;

            fs.EscribirEncabezado(encabezado);

            for (int j = 0; j < cantidadFilas; j++)
            {
                escribirLinea(j,ds);
            }
        }


        private void ExportarAmbulatorios(DataSet ds)
        {
            cantidadFilas = ds.Tables[0].Rows.Count;
            cantidadColumnas = ds.Tables[0].Columns.Count;

            for (int j = 0; j < cantidadFilas; j++)
            {
                this.barraEstado1.Value++;
                fs.EscribirEncabezado("AMBULATORIO");
                for (int i = 0; i < cantidadColumnas; i++)
                {
                    if (i != 3)
                    {
                        cadena = cadena + ds.Tables[0].Rows[j][i].ToString();
                    }
                    else 
                    {
                        cadena = cadena + "0";
                    }
                    if (i != cantidadColumnas - 1)
                    {
                        cadena = cadena + ";";
                    }
                }
                fs.EscribirEncabezado(cadena);
                cadena = "";

                escribirDatosAmbulatorio(ds, Convert.ToInt32(ds.Tables[0].Rows[j]["ambulatorio_codigo"]));
                fs.EscribirEncabezado("FIN AMBULATORIO");
            }
        }

        private void escribirDatosAmbulatorio(DataSet ds, int ambulatorio)
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
                    if (i != cantidadColumnas - 2)
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
                    if (i != cantidadColumnas - 3)
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
            for (int i = 0; i < cantidadColumnas; i++)
            {
                cadena = cadena + ds.Tables[0].Rows[j][i].ToString();
                if (i != cantidadColumnas - 2)
                {
                    cadena = cadena + ";";
                }
            }
            fs.EscribirEncabezado(cadena);
            cadena = "";
        }


        private DataSet traerListadosBD(string Tabla)
        {
            return SQLHelper.ExecuteDataSet("TraerListado" + Tabla, CommandType.StoredProcedure, Tabla);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.barraEstado1.Value > 0)
            {
                this.barraEstado1.Value++;
            }
            else
            {
                this.timer1.Enabled = false;
            } 
        }

    }
}
