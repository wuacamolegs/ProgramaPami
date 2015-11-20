using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace PAMI.Configuracion
{
    public partial class formConfiguracion : Form
    {
        bool cargado = false;

        public formConfiguracion()
        {
            InitializeComponent();
        }

        private void chChico_CheckedChanged(object sender, EventArgs e)
        {
            if (chChico.Checked && cargado)
            {
                chMediano.Checked = !chChico.Checked;
                chGrande.Checked = !chGrande.Checked;
            }
        }

        private void chMediano_CheckedChanged(object sender, EventArgs e)
        {
            if (chMediano.Checked && cargado)
            {
                chChico.Checked = !chMediano.Checked;
                chGrande.Checked = !chMediano.Checked;
            }
        }

        private void chGrande_CheckedChanged(object sender, EventArgs e)
        {
            if (chGrande.Checked && cargado)
            {
                chChico.Checked = !chGrande.Checked;
                chMediano.Checked = !chGrande.Checked;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["ConsultaMensual"].Value = chConsultaMensual.Checked.ToString();


                if (chChico.Checked)
                {
                    config.AppSettings.Settings["TamanioPlanilla"].Value = "Chico";
                }
                else if (chMediano.Checked)
                {
                    config.AppSettings.Settings["TamanioPlanilla"].Value = "Mediano";
                }
                else if (chGrande.Checked)
                {
                    config.AppSettings.Settings["TamanioPlanilla"].Value = "Grande";
                }

                config.Save(ConfigurationSaveMode.Modified);
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se Pudo Cambiar la Configuracion del Sistema, \npor favor reinicie la aplicacion y vuelva a inetentarlo.","Error Al Actualizar.",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void formConfiguracion_Load(object sender, EventArgs e)
        {
            bool Consulta = Convert.ToBoolean(ConfigurationManager.AppSettings["ConsultaMensual"]);
            chConsultaMensual.Checked = Consulta;

            string Resolucion = ConfigurationManager.AppSettings["TamanioPlanilla"].ToString();

            if (Resolucion == "Chico")
            {
                chChico.Checked = true;
            }
            else if (Resolucion == "Mediano")
            {
                chMediano.Checked = true;
            }
            else if (Resolucion == "Grande")
            {
                chGrande.Checked = true;
            }

            cargado = true;
        }
    }
}
