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
    public class Practica: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _descripcion;
        string _codigo;
        Int64 _asoc;
        Int64 _modulo;
        Int64 _max;

        #endregion
      
        public Practica()
        {

        }

        #region Constructores

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Int64 Asociacion
        {
            get { return _asoc; }
            set { _asoc = value; }
        }
        

        public Int64 Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        public Int64 CantMaxima
        {
            get { return _max; }
            set { _max = value; }
        }

        
        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Nomenclador";
        }

        public override string NombreEntidad()
        {
            return "Nomenclador";
        }
        #endregion

        #region dataRowToObject

        public void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB

            this.Codigo = (dr["practica_codigo"]).ToString();
            this.Descripcion = dr["practica_descripcion"].ToString();
            this.Modulo = Convert.ToInt64(dr["codigo_modulo"]);
            this.CantMaxima = Convert.ToInt64(dr["cantidad_maxima"]);
        }

        #endregion

        #region seters


        private void setearListaParametrosFiltros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsociacionID", this.Asociacion));
            parameterList.Add(new SqlParameter("@Codigo",this.Codigo));
            parameterList.Add(new SqlParameter("@Descripcion",this.Descripcion));
            parameterList.Add(new SqlParameter("@Modulo", this.Modulo));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Codigo", this.Codigo));
            parameterList.Add(new SqlParameter("@Descripcion", this.Descripcion));
            parameterList.Add(new SqlParameter("@Modulo", this.Modulo));
            parameterList.Add(new SqlParameter("@CantMaxima", this.CantMaxima));
        }

        private void setearListaParametrosCodigo()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Codigo", this.Codigo));
        }

        #endregion

        public DataSet BuscarPracticasPorFiltros()
        {
            setearListaParametrosFiltros();
            return this.TraerListado(parameterList, "ConFiltros");
        }

        public bool TraerPracticaPorCodigo()
        {
            setearListaParametrosCodigo();
            DataSet ds = this.TraerListado(parameterList, "PorCodigo");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NuevaPractica()
        {
            if (this.TraerPracticaPorCodigo())
            { //la practica ya existe
                return false;
            }
            else
            { //no existe. lo inserta
                setearListaParametrosCompleta();
                this.Guardar(parameterList);
                return true;
            }
        }

        public void Update()
        {
            setearListaParametrosCompleta();
            this.Modificar(parameterList);
        }

        public void EliminarPractica()
        {
            setearListaParametrosCodigo();
            this.Eliminar(parameterList);
        }
    }
}
