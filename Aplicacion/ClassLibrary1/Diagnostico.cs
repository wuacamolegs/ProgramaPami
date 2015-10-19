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

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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

        private void setearListaParametrosConAsociacionID(long AsocID)
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", AsocID));
        }

        #endregion

        public DataSet TraerListadoDiagnosticoPorAsociacion(Int64 AsocID)
        {
            setearListaParametrosConAsociacionID(AsocID);
            return this.TraerListado(parameterList, "PorAsocID");
        }

    }
}
