using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Configuration;
using Excepciones;
using Utilities;

namespace Clases
{
    public class Planilla: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _fecha;
        string _nombre;
        Int64 _beneficio;
        string _diagnostico;
        string _practica;
        string _hora;
        DataTable _planilla = new DataTable();
        Int64 _medico;
        Int64 _anio;
        Int64 _mes;
        Int64 _asociacion;

        #endregion

        #region constructor
      
        public Planilla()
        {
            tablaPlanilla.Columns.Add("Planilla_fecha", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_nombre", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_beneficio", typeof(Int64));
            tablaPlanilla.Columns.Add("Planilla_diagnostico", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_hora", typeof(string));
        }

        #endregion

        #region properties

        public DataTable tablaPlanilla
        {
            get { return _planilla; }
            set { _planilla = value; }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Int64 Beneficio
        {
            get { return _beneficio; }
            set { _beneficio = value; }
        }

        public string Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value; }
        }

        public string Practica
        {
            get { return _practica; }
            set { _practica = value; }
        }

        public string Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        public Int64 Medico
        {
            get { return _medico; }
            set { _medico = value; }
        }

        public Int64 Asociacion
        {
            get { return _asociacion; }
            set { _asociacion = value; }
        }

        public Int64 Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        public Int64 Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }



        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Planilla";
        }

        public override string NombreEntidad()
        {
            return "Planilla";
        }
        #endregion

        #region dataRowToObject


        #endregion

        #region setters

        private void settearListaParametros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Diagnostico", this.Diagnostico));
            parameterList.Add(new SqlParameter("@Practica", this.Practica));
            parameterList.Add(new SqlParameter("@Hora", this.Hora));
        }

        private void settearListaParametrosConPlanilla()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Planilla", this.tablaPlanilla));
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Medico", this.Medico));
            parameterList.Add(new SqlParameter("@Mes", this.Mes));
            parameterList.Add(new SqlParameter("@Anio", this.Anio));
        }

        private void settearListaParametrosConAsociacionMedico()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsociacionID", this.Asociacion));
            parameterList.Add(new SqlParameter("@MedicoID", this.Medico));
        }
       
        #endregion


        public string Validar()
        {
            settearListaParametros();
            DataSet ds = SQLHelper.ExecuteDataSet("ValidarPlanillaPorFila", CommandType.StoredProcedure, NombreTabla(), parameterList);
            return ds.Tables[0].Rows[0]["Estado"].ToString();
        }

        public DataSet  ImportarPlanilla()
        {
            settearListaParametrosConPlanilla();
            DataSet ds = SQLHelper.ExecuteDataSet("ImportarPlanilla", CommandType.StoredProcedure, NombreTabla(), parameterList);
            return ds;
        }

        
        public DataSet TraerPlanillasPorMedico(long AsociacionID, long MedicoID)
        {
            settearListaParametrosConAsociacionMedico();
            return this.TraerListado(parameterList, "ActualPorMedicoAsociacion");
        }



        public DataSet TraerTablasPlanilla()
        {
            throw new NotImplementedException();
        }
    }
}