using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Editor
    {

        public static string NormalizarCadena(string cadena){

            cadena = cadena.ToString().ToUpper();
            cadena = cadena.ToString().Normalize(NormalizationForm.FormD);
            Regex reg = new Regex("[^a-zA-Z0-9 ]");
            cadena = reg.Replace(cadena.ToString(), "");

            return cadena; 

        }

        public static string NormalizarHora(string cadena)
        {
            cadena = Regex.Replace(cadena, @"[^\d]", "");

            if (cadena.Length == 3)
            {
                cadena = '0' + cadena.Substring(0, 1) + ':' + cadena.Substring(1, 2);
            }else if (cadena.Length == 4)
            {
                cadena = cadena.Substring(0, 2) + ':' + cadena.Substring(2, 2);
            }
                        
            return cadena;
        }

        public static string NormalizarFecha(string cadena)
        {
            cadena = Regex.Replace(cadena, @"[^\d]", "");

            if (cadena.Length == 8)
            {
                cadena = cadena.Substring(0, 2) + '/' + cadena.Substring(2, 2) + '/' + cadena.Substring(4, 4);
            }
            else if (cadena.Length == 7)
            {
                cadena = '0' + cadena.Substring(0, 1) + '/' + cadena.Substring(1, 2) + '/' + cadena.Substring(3, 4);
            }

            return cadena;
        }
    
    }
}
