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

        private void setearListaParametrosConMedicoMatricula()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@MedicoMatricula", this.Matricula));
        }
    }
}
