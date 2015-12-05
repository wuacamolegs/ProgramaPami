using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;
using Utilities;
using System.Data.SqlClient;

namespace PAMI.Importar_Datos
{
    public partial class ImportarProfesionales : Form
    {
        public ImportarProfesionales()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (txtRuta.Text != "" && Convert.ToInt64(cmbAsociacion.SelectedIndex) != -1)
            {
                try
                {
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@Ruta", txtRuta.Text));
                    parameterList.Add(new SqlParameter("@Cuit", cmbAsociacion.SelectedIndex.ToString()));
                    Conexion.SQLHelper.ExecuteNonQuery("ImportarProfesionales", CommandType.StoredProcedure, parameterList);
                    MessageBox.Show("Profesionales Importados Correctamente", "");
                }
                catch (ErrorConsultaException ex)
                {
                    MessageBox.Show("Error al importar. Profesionales con matriculas nacionales repetidas\n\n detalles: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtRuta_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog1.FileName;
                txtRuta.Enabled = false;
            }
        }


    }
}
