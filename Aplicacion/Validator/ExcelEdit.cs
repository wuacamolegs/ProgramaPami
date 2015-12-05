using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Utilities
{
    public class ExcelEdit
    {        
        
        private string fileName;
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PAMI\\Archivos Para Emulacion";
        private string rutaCompleta;
        
        public ExcelEdit(string file)
        {   
            fileName = file;

            Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + fileName + ".csv"))
            {
                File.Delete(path + "\\" + fileName + ".csv");
            }

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path + "\\" + fileName + ".csv"))
            {

            }
        }
            
        public void EscribirLog(string encabezado, string consulta)
        {
            rutaCompleta = path + "\\" + fileName + ".csv";
            try
            {
                using (StreamWriter w = File.AppendText(rutaCompleta))
                {
                   // w.WriteLine(consulta);
                    w.Write(consulta);
                }
            }
            catch { }
        }


        public void EscribirEncabezado(string Encabezado)
        {
            rutaCompleta = path + "\\" + fileName + ".csv";
            try
            {
                using (StreamWriter w = File.AppendText(rutaCompleta))
                {
                   w.WriteLine(Encabezado);
                }
            }
            catch { }
        }

    }
}
