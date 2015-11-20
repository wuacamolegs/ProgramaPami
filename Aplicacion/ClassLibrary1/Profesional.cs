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
        Int64 _dirPiso;
        string _dirDepto;
        Int64 _asoc;

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

        public Int64 Direccion_Piso
        {
            get { return _dirPiso; }
            set { _dirPiso = value; }
        }

        public string Direccion_Depto
        {
            get { return _dirDepto; }
            set { _dirDepto = value; }
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
            return "Profesional";
        }

        public override string NombreEntidad()
        {
            return "Profesional";
        }
        #endregion

        private void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Nombre = (dr["profesional_nombre"]).ToString();
            this.Matricula = (dr["profesional_matricula_nacional"]).ToString();
            this.TipoDocumento = (dr["documento_tipo"]).ToString();
            this.Documento = (dr["documento_numero"]).ToString();
            this.Especialidad = (dr["profesional_especialidad_id"]).ToString();
            this.Direccion_Calle = (dr["profesional_direccion_calle"]).ToString();
            this.Direccion_Numero = (dr["profesional_direccion_numero"]).ToString();
            this.Direccion_Piso = Convert.ToInt32(dr["profesional_direccion_piso"]);
            this.Direccion_Depto = (dr["profesional_direccion_depto"]).ToString();
        }

        private void setearListaParametrosConMatricula()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Matricula", this.Matricula));
        }

        private void setearListaParametrosParaContador(long mes, string anio)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@MedicoID", this.Matricula));
            parameterList.Add(new SqlParameter("@AsociacionID", this.Asociacion));
            parameterList.Add(new SqlParameter("@Mes", mes.ToString()));
            parameterList.Add(new SqlParameter("@Anio", anio));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Matricula", this.Matricula));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@TipoDoc", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Documento", this.Documento));
            parameterList.Add(new SqlParameter("@Especialidad", this.Especialidad));
        }

        public DataSet BuscarProfesionalPorFiltros()
        {
            setearListaParametrosCompleta();
            return this.TraerListado(parameterList, "PorFiltros");
        }
        
        public void EliminarProfesional()
        {
            setearListaParametrosConMatricula();
            this.Eliminar(parameterList);
        }

        public bool TraerProfesionalPorMatricula()
        {
            setearListaParametrosConMatricula();
            DataSet ds = this.TraerListado(parameterList, "PorMatricula");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Dispose();
                return false;
            }
            else
            {
                DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
                return true;
            }
        }

        public DataSet TraerContadorPracticas(Int64 mes, string anio)
        {
            setearListaParametrosParaContador(mes,anio);
            return this.TraerListado(parameterList, "ContadorPracticas");
        }

        public DataTable ObtenerListadoEspecialidad()
        {
            DataTable TablaMes = new DataTable();
            TablaMes.Columns.Add("EspecialidadID", typeof(Int64));
            TablaMes.Columns.Add("Especialidad", typeof(string));
            TablaMes.Rows.Add(new Object[] { "8", "ALERGIA E INMUNOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "41", "ANATOMIA PATOLOGICA"});
            TablaMes.Rows.Add(new Object[] { "9", "ANESTESIOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "500", "BIOQUIMICO GENERAL"});
            TablaMes.Rows.Add(new Object[] { "10", "CARDIOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "54", "CARDIOLOGIA PEDRIATRICA"});
            TablaMes.Rows.Add(new Object[] { "60", "CIRUGIA CARDIOVASC. PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "33", "CIRUGIA CARDIOVASCULAR"});
            TablaMes.Rows.Add(new Object[] { "30", "CIRUGIA DEL TORAX"});
            TablaMes.Rows.Add(new Object[] { "61", "CIRUGIA GASTROENTER. PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "65", "CIRUGIA GENERAL"});
            TablaMes.Rows.Add(new Object[] { "29", "CIRUGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "27", "CIRUGIA REPARADORA"});
            TablaMes.Rows.Add(new Object[] { "34", "CIRUGIA VASCULAR PERIFERICA"});
            TablaMes.Rows.Add(new Object[] { "1", "CLINICA MEDICA"});
            TablaMes.Rows.Add(new Object[] { "20", "CLINICA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "24", "CLINICA QUIRURGICA"});
            TablaMes.Rows.Add(new Object[] { "7", "DERMATOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "44", "DIAG. POR IMAGENES Y RADIODIAGNOSTICO"});
            TablaMes.Rows.Add(new Object[] { "57", "ENDOCRINOLOGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "15", "ENDOCRINOLOGIA Y NUTRICION"});
            TablaMes.Rows.Add(new Object[] { "21", "FISIOTERAPIA"});
            TablaMes.Rows.Add(new Object[] { "400", "FONOAUDIOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "11", "GASTROENTEROLOGIA"});
            TablaMes.Rows.Add(new Object[] { "55", "GASTROENTEROLOGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "23", "GENETICA"});
            TablaMes.Rows.Add(new Object[] { "18", "GERIATRIA"});
            TablaMes.Rows.Add(new Object[] { "46", "GINECOLOGIA Y OBSTETRICA"});
            TablaMes.Rows.Add(new Object[] { "6", "HEMATOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "43", "HEMOTERAPIA"});
            TablaMes.Rows.Add(new Object[] { "2", "INFECTOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "600", "KINESIOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "42", "MEDICINA NUCLEAR"});
            TablaMes.Rows.Add(new Object[] { "19", "NEFROLOGIA"});
            TablaMes.Rows.Add(new Object[] { "58", "NEFROLOGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "28", "NEUROCIRUGIA"});
            TablaMes.Rows.Add(new Object[] { "3", "NEUROLOGIA"});
            TablaMes.Rows.Add(new Object[] { "40", "NEUROLOGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "4", "NUTRICION"});
            TablaMes.Rows.Add(new Object[] { "37", "OBSTETRICIA"});
            TablaMes.Rows.Add(new Object[] { "700", "ODONTOLOGO GENERAL"});
            TablaMes.Rows.Add(new Object[] { "25", "OFTALMOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "12", "ONCOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "31", "ORTOPEDIA Y TRAUMATOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "26", "OTORRINOLARINGOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "22", "PERINATOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "1000", "PSICOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "32", "PSICOPEDAGOGIA"});
            TablaMes.Rows.Add(new Object[] { "39", "PSIQUIATRIA Y PSICOLOGIA PEDIATRICA"});
            TablaMes.Rows.Add(new Object[] { "5", "PSIQUIATRIA Y PSICOLOGIA MEDICA"});
            TablaMes.Rows.Add(new Object[] { "45", "RADIOTERAPIA"});
            TablaMes.Rows.Add(new Object[] { "16", "REHABILITACION"});
            TablaMes.Rows.Add(new Object[] { "13", "REUMATOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "36", "TOCOGINECOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "17", "TOXICOLOGIA"});
            TablaMes.Rows.Add(new Object[] { "35", "UROLOGIA"});
            return TablaMes;
        }

        public void EditarProfesional()
        {
            setearListaParametrosCompleta();
            this.Modificar(parameterList);
        }

        public string NuevoProfesional()
        {
            if (!TraerProfesionalPorMatricula())
            {
                setearListaParametrosCompleta();
                this.Guardar(parameterList);
                return "Nuevo Profesional:\n" + this.Nombre + "\nMatricula: " + this.Matricula;

            }else{
                return "Ya Existe un Profesional con esa Matrícula.";
            }
        }
    }
}
