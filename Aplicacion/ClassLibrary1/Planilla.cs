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
    public class Planilla: Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        string _fecha;
        string _nombre;
        string _beneficio;
        string _diagnostico;
        string _practica;
        string _hora;
        DataTable _planilla = new DataTable();
        Int64 _medico;
        Int64 _anio;
        Int64 _mes;
        Int64 _asociacion;
        string _op;

        #endregion

        #region constructor
      
        public Planilla()
        {
            tablaPlanilla.Columns.Add("Planilla_medico_secundario_matricula", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_medico_secundario_nombre", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_beneficio", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_practica", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_fecha", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_hora", typeof(string));
            tablaPlanilla.Columns.Add("Planilla_diagnostico", typeof(string));
            tablaPlanilla.Columns.Add("Existe", typeof(int));
        }

        #endregion

        #region properties

        public DataTable tablaPlanilla
        {
            get { return _planilla; }
            set { _planilla = value; }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

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

        public string Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value; }
        }

        public string Practica
        {
            get { return _practica; }
            set { _practica = value; }
        }

        public string Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        public Int64 Medico
        {
            get { return _medico; }
            set { _medico = value; }
        }

        public Int64 Asociacion
        {
            get { return _asociacion; }
            set { _asociacion = value; }
        }

        public Int64 Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        public Int64 Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public string OrdenPrestacion
        {
            get { return _op; }
            set { _op = value; }
        }


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Planilla";
        }

        public override string NombreEntidad()
        {
            return "Planilla";
        }
        #endregion

        #region dataRowToObject


        #endregion

        #region seters

        private void setearListaParametrosAmbulatorioExistente()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@Afiliado", this.Beneficio));
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
        }

        private void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Medico", this.Medico));
            parameterList.Add(new SqlParameter("@Mes", this.Mes));
            parameterList.Add(new SqlParameter("@Anio", this.Anio));

            parameterList.Add(new SqlParameter("@Fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
            parameterList.Add(new SqlParameter("@Diagnostico", this.Diagnostico));
            parameterList.Add(new SqlParameter("@Practica", this.Practica));
            parameterList.Add(new SqlParameter("@Hora", this.Hora));
            parameterList.Add(new SqlParameter("@OP", this.OrdenPrestacion));
            parameterList.Add(new SqlParameter("@Consulta", Convert.ToInt64(Convert.ToBoolean(ConfigurationManager.AppSettings["ConsultaMensual"]))));
        }

        private void setearListaParametrosConPlanilla()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Planilla", this.tablaPlanilla));
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Medico", this.Medico));
            parameterList.Add(new SqlParameter("@Mes", this.Mes));
            parameterList.Add(new SqlParameter("@Anio", this.Anio));
        }

        private void setearListaParametrosTablas()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsociacionID", this.Asociacion));
            parameterList.Add(new SqlParameter("@MedicoID", this.Medico));
            parameterList.Add(new SqlParameter("@Mes", this.Mes));
            parameterList.Add(new SqlParameter("@Anio", this.Anio));
        }

        private void setearListaParametrosAsociacionPeriodo()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Mes", this.Mes.ToString()));
            parameterList.Add(new SqlParameter("@Anio", this.Anio.ToString()));
        }

        private void setearListaParametrosParaBusqueda()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Medico", this.Medico));
            parameterList.Add(new SqlParameter("@Mes", this.Mes));
            parameterList.Add(new SqlParameter("@Anio", this.Anio));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
        }

        private void setearListaParametrosAsocMedicoFechaBeneficio()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Asociacion", this.Asociacion));
            parameterList.Add(new SqlParameter("@Medico", this.Medico));
            parameterList.Add(new SqlParameter("@Fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@Beneficio", this.Beneficio));
        }

        private void setearListaParametrosAgregarPractica()
        {
            parameterList.Add(new SqlParameter("@Practica", this.Practica));
        }

        private void setearListaParametrosConAsociacion()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@AsocID", this.Asociacion));
        }

        private void setearListaParametrosAgregarMedicoPosta(Int64 MedicoPosta)
        {
            parameterList.Add(new SqlParameter("@MedicoPosta", MedicoPosta));
        }

        #endregion

        public DataSet ImportarPlanilla()
        {
            setearListaParametrosConPlanilla();
            DataSet ds = SQLHelper.ExecuteDataSet("ImportarPlanilla", CommandType.StoredProcedure, NombreTabla(), parameterList);
            return ds;
        }

        //Para busqueda ambulatorios medico
        public DataSet TraerPlanillasPorMedico()
        {
            setearListaParametrosParaBusqueda(); 
            return this.TraerListado(parameterList, "ActualPorMedicoAsociacion");
        }

        //Para luego comparar que los datos sean validos. practicas, beneficios etc.
        public DataSet TraerTablasPlanilla()
        {
            setearListaParametrosTablas();
            return this.TraerListado(parameterList, "TablasParaValidar");
        }

        //Importar Practica a Practica y verificar que se importe, que no este repetida, que no exista otro ambulatorio. me trae codigos y ambulatorios.
        public DataSet ImportarAmbulatorio()
        {
            setearListaParametrosCompleta();
            return this.GuardarYObtenerID(parameterList);
        }

        //Para cargar el datagrid con las practicas de la asociacion
        public DataSet TraerListadoNomencladorPorAsociacion()
        {
            setearListaParametrosConAsociacion();
            return this.TraerListado(parameterList,"NomencladorPorAsociacion");
        }

        //Para nuevo ambualtorio, ver que no tenga un ambulatorio existente. si lo tiene me trae el ambulatorio.
        public DataSet ValidarAmbulatorioExistente()
        {
            setearListaParametrosAmbulatorioExistente();
            return SQLHelper.ExecuteDataSet("ValidarAmbulatorioExistenteEnPlanilla", CommandType.StoredProcedure, NombreTabla(), parameterList);
        }

        public DataSet ImportarAmbulatorioExistente(Int64 MedicoPosta)
        {
            setearListaParametrosCompleta();
            setearListaParametrosAgregarMedicoPosta(MedicoPosta);
            return this.GuardarYObtenerID(parameterList,"AmbulatorioExistente");
        }

        public DataSet TraerAmbulatoriosCargadosAOtroMedicoPorFiltros()
        {
            setearListaParametrosAsociacionPeriodo();
            return this.TraerListado(parameterList, "AmbulatoriosCargadosAOtroMedico");
        }

        public void BorrarAmbulatorio()
        {
            setearListaParametrosAsocMedicoFechaBeneficio();
            this.Eliminar(parameterList);
        }

        public void BorrarPracticas()
        {
            setearListaParametrosAsocMedicoFechaBeneficio();
            setearListaParametrosAgregarPractica();
            this.Eliminar(parameterList, "PracticaAPractica");
        }

        public void RegistrarAmbulatorioExistente(long medicoPosta)
        {
            setearListaParametrosAsocMedicoFechaBeneficio(); 
            setearListaParametrosAgregarMedicoPosta(medicoPosta);
            setearListaParametrosAgregarPractica();
            SQLHelper.ExecuteDataSet("RegistrarAmbulatorioExistente", CommandType.StoredProcedure, NombreTabla(), parameterList);            
        }
    }
}