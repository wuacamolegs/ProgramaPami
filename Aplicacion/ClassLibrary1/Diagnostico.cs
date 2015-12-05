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
    public class Diagnostico: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _nombre;
        string _codigo;
        Int64 _asoc;

        #endregion
      
        public Diagnostico()
        {

        }

        #region Constructores

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Descripcion
        {
            get { return _nombre; }
            set { _nombre = value; }
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
            return "Diagnosticos";
        }

        public override string NombreEntidad()
        {
            return "Diagnosticos";
        }
        #endregion

        #region seters

        private void setearListaParametrosConFiltros(Int64 AsocID)
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", AsocID.ToString()));
            parameterList.Add(new SqlParameter("@Codigo", this.Codigo));
        }

        private void setearListaParametrosConAsociacion(Int64 AsocID)
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", AsocID)); //TIENE QUE SER CON INT64!! NO STRING se usa en nuevo ambulatorio
        }

        private void setearListaParametrosConCodigoDiagnostico()
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@Codigo", this.Codigo));
        }

        private void setearListaParametrosCompleta()
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@Codigo", this.Codigo));
            parameterList.Add(new SqlParameter("@Descripcion", this.Descripcion));
            parameterList.Add(new SqlParameter("@AsocID", this.Asociacion.ToString()));

        }

        #endregion

        public DataSet TraerListadoDiagnosticoPorAsociacion(Int64 AsocID)
        {
            setearListaParametrosConAsociacion(AsocID);
            return this.TraerListado(parameterList, "PorAsocID");
        }


        public DataSet TraerDiagnosticosPorFiltros(Int64 asocid)
        {
            setearListaParametrosConFiltros(asocid);
            return this.TraerListado(parameterList, "ConFiltros");
        }

        public void TraerDiagnosticoPorCodigo()
        {
            setearListaParametrosConCodigoDiagnostico();
            DataSet ds = this.TraerListado(parameterList, "PorCodigo");

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Codigo = ds.Tables[0].Rows[0][0].ToString();
                this.Descripcion = ds.Tables[0].Rows[0][1].ToString();
                this.Asociacion = Convert.ToInt64(ds.Tables[0].Rows[0][2]);
            }
        }

        public void EliminarDiagnostico()
        {
            setearListaParametrosConCodigoDiagnostico();
            this.Eliminar(parameterList);
        }

        public void Editar()
        {
            setearListaParametrosCompleta();
            this.Modificar(parameterList);
        }

        public void Nuevo()
        {
            setearListaParametrosCompleta();
            this.Guardar(parameterList);
        }
    }
}
