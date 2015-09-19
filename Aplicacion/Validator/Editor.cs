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
    
    
    }
}
