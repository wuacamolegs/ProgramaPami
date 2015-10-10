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
    public class Prestador: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _nombrePrestador;
        string _cuit;
        string _bocaAtencion;
        string _codigoSap;
        Int64 _tipoPres;
        string _fechaAlta;
        string _nombreCortoPrestador;
        string _usuario;
        string _calle;
        Int64 _numero;
        Int64 _piso;
        string _depto;
        string _mail;
        Int64 _asoc;
        Int64 _padron;

        #endregion
      
        public Prestador()
        {
        }

        #region Constructores

        public string NombrePrestador
        {
            get { return _nombrePrestador; }
            set { _nombrePrestador = value; }
        }

        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }

        public string BocaAtencion
        {
            get { return _bocaAtencion; }
            set { _bocaAtencion = value; }
        }

        public string CodigoSap
        {
            get { return _codigoSap; }
            set { _codigoSap = value; }
        }

        public Int64 TipoPrestador
        {
            get { return _tipoPres; }
            set { _tipoPres = value; }
        }

        public string FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public string NombreCortoPrestador
        {
            get { return _nombreCortoPrestador; }
            set { _nombreCortoPrestador = value; }
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string DireccionCalle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public Int64 DireccionNumero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public Int64 DireccionPiso
        {
            get { return _piso; }
            set { _piso = value; }
        }

        public string DireccionDepto
        {
            get { return _depto; }
            set { _depto = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public Int64 AsocID
        {
            get { return _asoc; }
            set { _asoc = value; }
        }

        public Int64 Padron
        {
            get { return _padron; }
            set { _padron = value; }
        }
        
        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Prestador";
        }

        public override string NombreEntidad()
        {
            return "Prestador";
        }
        #endregion

        private void DataRowToObjectCompleto(DataRow dataRow)
        {
            this.NombrePrestador = dataRow["prestador_nombre"].ToString();
            this.Cuit = dataRow["prestador_cuit"].ToString();
            this.BocaAtencion = dataRow["c_boca_atencion"].ToString();
            this.CodigoSap = dataRow["nro_sap"].ToString();
            this.FechaAlta = dataRow["f_fecha_alta"].ToString();
            this.NombreCortoPrestador = dataRow["prestador_nombre_corto"].ToString();
            this.Usuario = dataRow["usuario_nombre"].ToString();
            this.DireccionCalle = dataRow["d_calle"].ToString();
            this.DireccionNumero = Convert.ToInt64(dataRow["d_puerta"]);
            this.DireccionPiso = Convert.ToInt64(dataRow["d_piso"]);
            this.DireccionDepto = dataRow["d_departamento"].ToString();
            this.TipoPrestador = Convert.ToInt64(dataRow["tipo_prestador"]);
            this.Mail = (dataRow["d_mail"]).ToString();
            this.Padron = Convert.ToInt64(dataRow["padron"]);
        }

        private void setearListaParametrosConCuitYUsuario()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Cuit", this.Cuit));
            parameterList.Add(new SqlParameter("@Usuario", this.Usuario));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Cuit", this.Cuit));
            parameterList.Add(new SqlParameter("@Nombre",this.NombrePrestador));
            parameterList.Add(new SqlParameter("@BocaAtencion", this.BocaAtencion));
            parameterList.Add(new SqlParameter("@Sap",this.CodigoSap));
            parameterList.Add(new SqlParameter("@FechaAlta",this.FechaAlta));
            parameterList.Add(new SqlParameter("@NombreCorto",this.NombreCortoPrestador));
            parameterList.Add(new SqlParameter("@Usuario", this.Usuario));
            parameterList.Add(new SqlParameter("@Calle",this.DireccionCalle));
            parameterList.Add(new SqlParameter("@Numero",this.DireccionNumero));
            parameterList.Add(new SqlParameter("@Piso", this.DireccionPiso));
            parameterList.Add(new SqlParameter("@Depto",this.DireccionDepto));
            parameterList.Add(new SqlParameter("@TipoPrestador", this.TipoPrestador));
            parameterList.Add(new SqlParameter("@Mail", this.Mail));
            parameterList.Add(new SqlParameter("@AsocID", this.AsocID));
            parameterList.Add(new SqlParameter("@Padron", this.Padron));

        }

        private void setearListaParametrosConAsociacionID(Int64 AsocID)
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", AsocID));
        }



        public bool NuevoPrestador()
        {
            if (this.TraerPrestadorPorCuitYUsuario())

            { //el prestador ya existe, le cargue los datos
                return false;
            }
            else
            { //no existe. lo inserta
                setearListaParametrosCompleta();
                this.Guardar(parameterList);
                return true;
            }
        }

        public bool TraerPrestadorPorCuitYUsuario()  //TODO TRY CATCH
        {
            setearListaParametrosConCuitYUsuario();
            DataSet ds = TraerListado(parameterList, "PorCuitYUsuario");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
                return true;
            }
        }

        public void UpdatePrestador()
        {
            setearListaParametrosCompleta();
            this.Modificar(parameterList);
        }

        public bool TraerListadoPorAsociacionID(Int64 AsocID)
        {
            setearListaParametrosConAsociacionID(AsocID);
            DataSet ds = TraerListado(parameterList, "PorAsociacionID");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
                return true;
            }
        }


        public void DeletePrestador()
        {
            setearListaParametrosConAsociacionID(this.AsocID);
            this.Eliminar(parameterList);
        }
    }
}
