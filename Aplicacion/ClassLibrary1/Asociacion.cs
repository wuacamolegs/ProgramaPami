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
    public class Asociacion: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _nombre;
        Int64 _id;

        #endregion
      
        public Asociacion()
        {

        }

        #region Constructores

        public Int64 ID
        {
            get { return _id; }
            set { _id = value; }
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
            return "Asociacion";
        }

        public override string NombreEntidad()
        {
            return "Asociacion";
        }
        #endregion

        #region seters

        public void setearListaParametrosConAsociacionID()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsociacionID", this.ID));
        }


        #endregion


        public DataSet TraerMedicosPorAsociacion()
        {
            setearListaParametrosConAsociacionID();
            DataSet ds = this.TraerListado(parameterList, "Profesionales");
            return ds;
        }
    }
}
