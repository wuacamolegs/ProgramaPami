using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Conexion;
using Excepciones;
using Utilities;

namespace Clases
{
    public abstract class Base : IDisposable
    {
        // Textos para identificar los storeds en la base
        protected string _strInsertar = "Insert";
        protected string _strModificar = "Update";
        protected string _strEliminar = "Delete";
        protected string _strDeshabilitar = "Deshabilitar";
        protected string _strTraerListado = "TraerListado";
        protected string _strRetornoID = "_RetornarID";

        public static DataTable TablaMeses()
        {
            DataTable TablaMes = new DataTable();
            TablaMes.Columns.Add("numeroMes", typeof(string));
            TablaMes.Columns.Add("nombreMes", typeof(string));
            TablaMes.Rows.Add(new Object[] { "01", "Enero" });
            TablaMes.Rows.Add(new Object[] { "02", "Febrero" });
            TablaMes.Rows.Add(new Object[] { "03", "Marzo" });
            TablaMes.Rows.Add(new Object[] { "04", "Abril" });
            TablaMes.Rows.Add(new Object[] { "05", "Mayo" });
            TablaMes.Rows.Add(new Object[] { "06", "Junio" });
            TablaMes.Rows.Add(new Object[] { "07", "Julio" });
            TablaMes.Rows.Add(new Object[] { "08", "Agosto" });
            TablaMes.Rows.Add(new Object[] { "09", "Septiembre" });
            TablaMes.Rows.Add(new Object[] { "10", "Octubre" });
            TablaMes.Rows.Add(new Object[] { "11", "Noviembre" });
            TablaMes.Rows.Add(new Object[] { "12", "Diciembre" });
            return TablaMes;
        }

        public virtual void DataRowToObject(DataRow dr)
        {
            DataRowToObject(dr, true);
        }
        public virtual void DataRowToObject(DataRow dr, bool conEstructurasInt64ernas)
        {
        }

        public abstract string NombreTabla();
        public abstract string NombreEntidad();

        public void Guardar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteDataSet(_strInsertar + NombreEntidad(), CommandType.StoredProcedure, NombreTabla(), parameterList);
        }

        public DataSet GuardarYObtenerID(List<SqlParameter> parameterList)
        {
            DataSet ds = SQLHelper.ExecuteDataSet(_strInsertar + NombreEntidad() + _strRetornoID, CommandType.StoredProcedure, NombreTabla(), parameterList);
            return ds;
        }

        public bool Modificar(List<SqlParameter> parameterList)
        {
            Int64 result = SQLHelper.ExecuteNonQuery(_strModificar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool Modificar(List<SqlParameter> parameterList, string Condiciones)
        {
            Int64 result = SQLHelper.ExecuteNonQuery(_strModificar + NombreEntidad() + Condiciones, CommandType.StoredProcedure, parameterList);
            if (result > 0)
            {
                return true;
            }
            return false;
        }


        public void Eliminar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteNonQuery(_strEliminar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
        }

        public void Deshabilitar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteNonQuery(_strDeshabilitar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
        }

        public DataSet TraerListado(List<SqlParameter> parameterList, string Condiciones)
        {
            return SQLHelper.ExecuteDataSet(_strTraerListado + NombreTabla() + Condiciones, CommandType.StoredProcedure, NombreTabla(), parameterList);
        }


        public DataSet TraerListado(string Condiciones)
        {
            return SQLHelper.ExecuteDataSet(_strTraerListado + NombreTabla() + Condiciones, CommandType.StoredProcedure, NombreTabla());
        }


        /// <summary>
        /// Libero memoria
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
