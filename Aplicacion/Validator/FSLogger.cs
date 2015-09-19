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
    public class FSLogger
    {
        private string fileName;
        private string path = "A:\\Documents\\PAMI\\Retransmitir\\Migracion\\SQL ARCHIVOS";
        private string rutaCompleta;
        
        // si pasamos la ruta de un archivo, se utilizará ese para hacer el log
        public FSLogger(string file)
        {   
            fileName = file;
            if (!File.Exists(path + "\\" + fileName + ".txt"))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path + "\\" + fileName + ".txt"))
                {

                }
            }
        }
            
        public void EscribirLog(string encabezado, string consulta)
        {
            rutaCompleta = path + "\\" + fileName + ".txt";
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
            rutaCompleta = path + "\\" + fileName + ".txt";
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
