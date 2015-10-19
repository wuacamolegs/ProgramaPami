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
    public class Afiliado : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _nombre;
        string _beneficio;
        string _parentesco;
        string _tipoDocumento;
        Int64 _documento;
        string _fechaNacimiento;
        string _sexo;
        Int64 _padron;

        #endregion

        #region constructor
      
        public Afiliado()
        {

        }

        #endregion

        #region properties


        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Beneficio
        {
            get { return _beneficio; }
            set { _beneficio = value; }
        }

        public string Parentesco
        {
            get { return _parentesco; }
            set { _parentesco = value; }
        }

        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        public Int64 Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        public string FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
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
            return "Afiliados";
        }

        public override string NombreEntidad()
        {
            return "Afiliado";
        }
        #endregion

        #region dataRowToObject

        public void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB

            this.Nombre = (dr["apellido_nombre"]).ToString();
            this.Beneficio = (dr["beneficio"]).ToString();
            this.Parentesco = (dr["parentesco"]).ToString();
            this.TipoDocumento = (dr["documento_tipo"]).ToString();
            this.Documento = Convert.ToInt64(dr["documento_numero"]);
            this.FechaNacimiento = (dr["fecha_nacimiento"]).ToString();
            this.Sexo = (dr["sexo"]).ToString();
            this.Padron = Convert.ToInt64(dr["padron_codigo"]);
        }

        #endregion

        #region setters

        private void setearListaParametrosConFiltros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));
            parameterList.Add(new SqlParameter("@Sexo", this.Sexo));
            parameterList.Add(new SqlParameter("@FechaNac", this.FechaNacimiento));
            parameterList.Add(new SqlParameter("@Padron", this.Padron));
        }

        private void setearListaParametrosConBeneficioParentesco()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
        }

        private void setearListaParametrosConFiltrosYAsoc(Int64 asocID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", asocID));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));
        }
       
        #endregion


        public DataSet BuscarAfiliadoPorFiltros() //TODO AGREGAR TRY
        {
            setearListaParametrosConFiltros();
            return this.TraerListado(parameterList, "ConFiltros");
        }

        public bool TraerAfiliadoPorBeneficio()  //TODO TRY CATCH
        {
            setearListaParametrosConBeneficioParentesco();
            DataSet ds = TraerListado(parameterList, "PorBeneficio");
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

        public bool NuevoAfiliado()  //TODO TRY CATCH
        {
            if (this.TraerAfiliadoPorBeneficio())
            { //el afiliado ya existe
                return false;
            }
            else
            { //no existe. lo inserta
                setearListaParametrosCompleta();
                this.Guardar(parameterList);
                return true;
            }
        }

        public void UpdateAfiliado() //TODO TRY CATCH
        {
            setearListaParametrosCompleta();
            this.Modificar(parameterList);
        }

        public void EliminarAfiliado()  //TODO TRY CATCH
        {
            setearListaParametrosConBeneficioParentesco();
            this.Eliminar(parameterList);
        }

        public DataSet TraerAfiliadosConFiltrosPorAsociacionID(Int64 asocID)
        {
            setearListaParametrosConFiltrosYAsoc(asocID);
            return this.TraerListado(parameterList, "ConFiltrosPorPadronAsociacion");
        }
    }
}
