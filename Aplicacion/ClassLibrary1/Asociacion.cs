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
        DataTable _tablaMedicos = new DataTable();

        #endregion
      
        public Asociacion()
        {
            TablaMedicos.Columns.Add("Estado",typeof(Int64));
            TablaMedicos.Columns.Add("matricula",typeof(Int64));
            TablaMedicos.Columns.Add("medico",typeof(string));
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

        public DataTable TablaMedicos
        {
            get { return _tablaMedicos; }
            set { _tablaMedicos = value; }
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

        private void setearListaParametrosConAsociacionYlistadoMedicos()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsociacionID", this.ID));
            parameterList.Add(new SqlParameter("@Medicos", this.TablaMedicos));
        }

        #endregion


        public DataSet TraerMedicosPorAsociacion()
        {
            setearListaParametrosConAsociacionID();
            DataSet ds = this.TraerListado(parameterList, "Profesionales");
            return ds;
        }

        public DataSet TraerMedicosPorAsociacionParaSeleccion()
        {
            setearListaParametrosConAsociacionID();
            return this.TraerListado(parameterList, "ProfesionalesSeleccion");
        }

        public void GuardarListadoMedicos()
        {
            setearListaParametrosConAsociacionYlistadoMedicos();
            this.Modificar(parameterList,"_REL_Profesionales");
        }


    }
}
