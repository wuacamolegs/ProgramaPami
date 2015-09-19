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
        Int64 _beneficio;
        Int64 _parentesco;
        string _tipoDocumento;
        Int64 _documento;
        string _fechaNacimiento;
        string _sexo;

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

        public Int64 Beneficio
        {
            get { return _beneficio; }
            set { _beneficio = value; }
        }

        public Int64 Parentesco
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
            this.Nombre = (dr["afiliado_apellidoNombre"]).ToString();
            this.Beneficio = Convert.ToInt64(dr["afiliado_beneficio_id"]);
            this.Parentesco = Convert.ToInt64(dr["afiliado_parentesco_id"]);
            this.TipoDocumento = (dr["afiliado_tipo_documento"]).ToString();
            this.Documento = Convert.ToInt64(dr["afiliado_numero_documento"]);
            this.FechaNacimiento = (dr["afiliado_fecha_nacimiento"]).ToString();
            this.Sexo = (dr["afiliado_sexo"]).ToString();
        }

        #endregion

        #region setters

        private void setearListaParametrosConFiltros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
            parameterList.Add(new SqlParameter("@TipoDni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
            parameterList.Add(new SqlParameter("@TipoDni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));
            parameterList.Add(new SqlParameter("@Sexo", this.Sexo));
            parameterList.Add(new SqlParameter("@FechaNac", this.FechaNacimiento));
        }

        private void setearListaParametrosConBeneficioParentesco()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Parentesco", this.Parentesco));
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
    }
}
