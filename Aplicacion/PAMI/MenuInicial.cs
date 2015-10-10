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

        private void aMBULATORIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void búsquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoAfiliados afiliados = new listadoAfiliados();
            afiliados.Show();
        }

        private void nuevoAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAfiliado nuevoAfiliado = new formAfiliado();
            nuevoAfiliado.abrirNuevo();
            nuevoAfiliado.Show();
        }

        private void aFILIADOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImportarPadron padron = new ImportarPadron();
            padron.Show();
        }

        private void eXPORTARDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarDatos exportar = new ExportarDatos();
            exportar.Show();

        }

        private void cargarPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlanilla planilla = new formPlanilla();
            planilla.AbrirParaNuevaPlanilla();
            planilla.Show();
        }

        private void búsquedaPrácticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoNomenclador nomenclador = new ListadoNomenclador();
            nomenclador.Show();
        }

        private void listadoAmbulatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlanilla planilla = new formPlanilla();
            planilla.AbrirParaBuscar();
            planilla.Show();
        }

        private void cargarNuevoAmbulatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoEditarAmbulatorio ambulatorio = new NuevoEditarAmbulatorio();
            ambulatorio.Show();
        }

        private void dIAGNOSTICOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string ruta = openFileDialog1.FileName;
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@Ruta", ruta));
                    Conexion.SQLHelper.ExecuteNonQuery("ImportarDiagnosticos", CommandType.StoredProcedure, parameterList);
                    MessageBox.Show("Listo", "");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pRESTADORESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profesionalesPorPrestadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAsociacionMedicos asocMedicos = new formAsociacionMedicos();
            asocMedicos.Show();
        }

        private void nuevaPrácticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPracticas practicas = new formPracticas();
            practicas.Show();
        }

        private void nuevoPrestadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPrestador prestador = new formPrestador("Nuevo");
            prestador.Show();
        }

        private void editarPrestadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPrestador prestador = new formPrestador("Editar");
            prestador.Show();
        }

        private void nOMENCLADORToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImportarNomenclador nomenclador = new ImportarNomenclador();
            nomenclador.Show();
        }

        private void lISTADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListadoProfesional prof = new ListadoProfesional();
            prof.Show();
        }

    }
}
