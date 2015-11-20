using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excepciones;
using PAMI.Afiliados;
using PAMI.PlanillaPami;
using PAMI.Exportacion;
using PAMI.Nomenclador;
using PAMI.Ambulatorio;
using PAMI.Asociaciones;
using PAMI.Prestadores;
using PAMI.Importar_Datos;
using PAMI.Profesionales;
using PAMI.Diagnosticos;
using PAMI.Configuracion;
using Utilities;


namespace PAMI
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.SQLHelper.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAfiliado_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnAfiliado.BackColor = Color.DarkCyan;
            btnAfiliado.ForeColor = Color.White;

            btn2BusquedaAfiliado.Visible = true;
            btn2NuevoAfiliado.Visible = true;

        }


        private void btnAmbulatorio_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnAmbulatorio.BackColor = Color.DarkCyan;
            btnAmbulatorio.ForeColor = Color.White;

            btn3NuevoAmbulatorio.Visible = true;
            btn3NuevaPlanilla.Visible = true;
            btn3Busqueda.Visible = true;
        }


        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnDiagnostico.BackColor = Color.DarkCyan;
            btnDiagnostico.ForeColor = Color.White;

            btn4NuevoDiagnostico.Visible = true;
            btn4ListadoDiagnostico.Visible = true;
        }

        private void btnProfesionales_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnProfesionales.BackColor = Color.DarkCyan;
            btnProfesionales.ForeColor = Color.White;

            btn5BusquedaProfesional.Visible = true;
            btn5NuevoProfesional.Visible = true;
            btn5Contador.Visible = true;
            btn5AmbulatoriosTransferidos.Visible = true;
        }

        private void btnPrestadores_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnPrestadores.BackColor = Color.DarkCyan;
            btnPrestadores.ForeColor = Color.White;

            btn6BusquedaPrestador.Visible = true;
            btn6NuevoPrestador.Visible = true;
            btn6ProfesionalesxAsociacion.Visible = true;
        }

        private void btnNomenclador_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnNomenclador.BackColor = Color.DarkCyan;
            btnNomenclador.ForeColor = Color.White;

            btn7Busqueda.Visible = true;
            btn7Nuevo.Visible = true;
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            botonesACero();
            btnDatos.BackColor = Color.DarkCyan;
            btnDatos.ForeColor = Color.White;

            btn8Diagnosticos.Visible = true;
            btn8Exportar.Visible = true;
            btn8Nomenclador.Visible = true;
            btn8Padron.Visible = true;
        }


        private void botonesACero()
        {
            btnAfiliado.BackColor = Color.LightGray;
            btnAmbulatorio.BackColor = Color.LightGray;
            btnDatos.BackColor = Color.LightGray;
            btnDiagnostico.BackColor = Color.LightGray;
            btnNomenclador.BackColor = Color.LightGray;
            btnPrestadores.BackColor = Color.LightGray;
            btnProfesionales.BackColor = Color.LightGray;

            btnAfiliado.ForeColor = Color.DarkCyan;
            btnAmbulatorio.ForeColor = Color.DarkCyan;
            btnDatos.ForeColor = Color.DarkCyan;
            btnDiagnostico.ForeColor = Color.DarkCyan;
            btnNomenclador.ForeColor = Color.DarkCyan;
            btnPrestadores.ForeColor = Color.DarkCyan;
            btnProfesionales.ForeColor = Color.DarkCyan;

            btn2BusquedaAfiliado.Visible = false;
            btn2NuevoAfiliado.Visible = false;

            btn3NuevoAmbulatorio.Visible = false;
            btn3NuevaPlanilla.Visible = false;
            btn3Busqueda.Visible = false;

            btn4NuevoDiagnostico.Visible = false;
            btn4ListadoDiagnostico.Visible = false;
            
            btn5BusquedaProfesional.Visible = false;
            btn5NuevoProfesional.Visible = false;
            btn5Contador.Visible = false;
            btn5AmbulatoriosTransferidos.Visible = false;   

            btn6BusquedaPrestador.Visible = false;
            btn6NuevoPrestador.Visible = false;
            btn6ProfesionalesxAsociacion.Visible = false;

            btn7Busqueda.Visible = false;
            btn7Nuevo.Visible = false;

            btn8Diagnosticos.Visible = false;
            btn8Exportar.Visible = false;
            btn8Nomenclador.Visible = false;
            btn8Padron.Visible = false;
        }

        private void btn2NuevoAfiliado_Click(object sender, EventArgs e)
        {
            formAfiliado nuevoAfiliado = new formAfiliado();
            nuevoAfiliado.abrirNuevo();
            nuevoAfiliado.Show();
            botonesACero();
        }

        private void btn2BusquedaAfiliado_Click(object sender, EventArgs e)
        {
            listadoAfiliados afiliados = new listadoAfiliados();
            afiliados.Show();
            botonesACero();
        }

        private void btn3NuevoAmbulatorio_Click(object sender, EventArgs e)
        {
            NuevoEditarAmbulatorio ambulatorio = new NuevoEditarAmbulatorio();
            ambulatorio.Show();
            botonesACero();
        }

        private void btn3NuevaPlanilla_Click(object sender, EventArgs e)
        {

            formPlanilla planilla = new formPlanilla();
            planilla.AbrirParaNuevaPlanilla();
            planilla.Show();
            botonesACero();
        }

        private void btn3Busqueda_Click(object sender, EventArgs e)
        {
            formPlanilla planilla = new formPlanilla();
            planilla.AbrirParaBuscar();
            planilla.Show();
            botonesACero();
        }

        private void btn4NuevoDiagnostico_Click(object sender, EventArgs e)
        {
            formDiagnostico Diag = new formDiagnostico();
            Diag.abrirParaNuevo();
            Diag.Show();
            botonesACero();
        }

        private void btn4ListadoDiagnostico_Click(object sender, EventArgs e)
        {
            ListadoDiagnostico listDiag = new ListadoDiagnostico();
            listDiag.Show();
            botonesACero();
        }

        private void btn5Contador_Click(object sender, EventArgs e)
        {
            ContadorPracticasProfesional contador = new ContadorPracticasProfesional();
            contador.Show();
            botonesACero();
        }

        private void btn5NuevoProfesional_Click(object sender, EventArgs e)
        {
            formProfesional prof = new formProfesional();
            prof.Show();
            botonesACero();
        }

        private void btn5BusquedaProfesional_Click(object sender, EventArgs e)
        {
            ListadoProfesional prof = new ListadoProfesional();
            prof.Show();
            botonesACero();
        }

        private void btn5AmbulatoriosTransferidos_Click(object sender, EventArgs e)
        {
            FacturacionAmbulatoriosExistentes fact = new FacturacionAmbulatoriosExistentes();
            fact.Show();
            botonesACero();
        }

        private void btn6NuevoPrestador_Click(object sender, EventArgs e)
        {
            formPrestador prestador = new formPrestador("Nuevo");
            prestador.Show();
            botonesACero();
        }

        private void btn6ProfesionalesxAsociacion_Click(object sender, EventArgs e)
        {
            formAsociacionMedicos asocMedicos = new formAsociacionMedicos();
            asocMedicos.Show();
            botonesACero();
        }

        private void btn6BusquedaPrestador_Click(object sender, EventArgs e)
        {
            formPrestador prestador = new formPrestador("Editar");
            prestador.Show();
            botonesACero();
        }

        private void btn7NuevaPractica_Click(object sender, EventArgs e)
        {
            formPracticas practicas = new formPracticas();
            practicas.Show();
            botonesACero();
        }

        private void btn7Busqueda_Click(object sender, EventArgs e)
        {
            ListadoNomenclador nomenclador = new ListadoNomenclador();
            nomenclador.Show();
            botonesACero();
        }

        private void btn8Padron_Click(object sender, EventArgs e)
        {
            ImportarPadron padron = new ImportarPadron();
            padron.Show();
            botonesACero();
        }

        private void btn8Exportar_Click(object sender, EventArgs e)
        {
            ExportarDatos exportar = new ExportarDatos();
            exportar.Show();
            botonesACero();
        }

        private void btn8Nomenclador_Click(object sender, EventArgs e)
        {
            ImportarNomenclador nomenclador = new ImportarNomenclador();
            nomenclador.Show();
            botonesACero();
        }

        private void btn8Diagnosticos_Click(object sender, EventArgs e)
        {
            ImportarDiagnosticos diagnosticos = new ImportarDiagnosticos();
            diagnosticos.Show();
            botonesACero();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formConfiguracion config = new formConfiguracion();
            config.Show();
            botonesACero();
        }






    }
}
