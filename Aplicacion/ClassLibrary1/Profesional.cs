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
    public class Profesional: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _nombre;
        string _matricula;
        string _especialidad_id;
        string _tipoDocumento;
        string _documento;
        string _calle;
        string _dirNumero;
        Int64 _dirPiso;
        string _dirDepto;
        Int64 _asoc;

        #endregion

        #region constructor
      
        public Profesional()
        {

        }

        #endregion

        #region properties

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public string Especialidad
        {
            get { return _especialidad_id; }
            set { _especialidad_id = value; }
        }

        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        public string Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        public string Direccion_Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public string Direccion_Numero
        {
            get { return _dirNumero; }
            set { _dirNumero = value; }
        }

        public Int64 Direccion_Piso
        {
            get { return _dirPiso; }
            set { _dirPiso = value; }
        }

        public string Direccion_Depto
        {
            get { return _dirDepto; }
            set { _dirDepto = value; }
        }

        public Int64 Asociacion
        {
            get { return _asoc; }
            set { _asoc = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Profesional";
        }

        public override string NombreEntidad()
        {
            return "Profesional";
        }
        #endregion

        private void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Nombre = (dr["profesional_nombre"]).ToString();
            this.Matricula = (dr["profesional_matricula_nacional"]).ToString();
            this.TipoDocumento = (dr["documento_tipo"]).ToString();
            this.Documento = (dr["documento_numero"]).ToString();
            this.Especialidad = (dr["profesional_especialidad_id"]).ToString();
            this.Direccion_Calle = (dr["profesional_direccion_calle"]).ToString();
            this.Direccion_Numero = (dr["profesional_direccion_numero"]).ToString();
            this.Direccion_Piso = Convert.ToInt32(dr["profesional_direccion_piso"]);
            this.Direccion_Depto = (dr["profesional_direccion_depto"]).ToString();
        }

        private void setearListaParametrosConMatricula()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Matricula", this.Matricula));
        }

        private void setearListaParametrosParaContador(long mes, string anio)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Matricula", this.Matricula));
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Mes", mes.ToString()));
            parameterList.Add(new SqlParameter("@Anio", anio));
        }

        private void setearListaParametrosConFiltros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Matricula", this.Matricula));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@TipoDoc", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Documento", this.Documento));
            parameterList.Add(new SqlParameter("@Especialidad", this.Especialidad));
        }

        public DataSet BuscarProfesionalPorFiltros()
        {
            setearListaParametrosConFiltros();
            return this.TraerListado(parameterList, "PorFiltros");
        }
        
        public void EliminarProfesional()
        {
            setearListaParametrosConMatricula();
            this.Eliminar(parameterList);
        }

        public bool TraerProfesionalPorMatricula()
        {
            setearListaParametrosConMatricula();
            DataSet ds = this.TraerListado(parameterList, "PorMatricula");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Dispose();
                return false;
            }
            else
            {
                DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
                return true;
            }
        }

        public DataSet TraerContadorPracticas(Int64 mes, string anio)
        {
            setearListaParametrosParaContador(mes,anio);
            return this.TraerListado(parameterList, "ContadorPracticas");
        }



    }
}
