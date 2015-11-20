using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Validator
    {
        public static string SoloNumeros(string textoAValidar, string nombreCampo)
        {
            string strError = "";

            if (strError.Length == 0 && !EsNumero(textoAValidar))
            {
                strError += nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }

        public static string SoloNumerosODecimales(string textoAValidar, string nombreCampo)
        {
            string strError = "";

            if (strError.Length == 0 && !EsDecimal(textoAValidar))
            {
                strError += nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }

        public static bool EsNumero(object obj)
        {
            try
            {
                int.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EsDecimal(object obj)
        {
            try
            {
                decimal.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ValidarNulo(string textoAValidar, string nombreCampo)
        {
            if (string.IsNullOrEmpty(textoAValidar))
            {
                return "Tiene que ingresar un valor para " + nombreCampo + "\n";
            }
            return string.Empty;
        }

        public static string EsAño(string año, string nombreCampo)
        {
            int unAño = Convert.ToInt32(año);
            if (unAño < 1900 || unAño > DateTime.Now.Year)
                return "Tiene que ingresar un año válido, entre 1900 y " + DateTime.Now.Year + ", para " + nombreCampo + "\n";

            return string.Empty;

        }
       
              
        public static string ValidarCantidadMenor(string cant, int cant2, string nombreCampo)
        {
            int cantidad = Convert.ToInt32(cant);
            if (cantidad > cant2)
                return "Debe ingresar una cantidad menor a " + cant2 + nombreCampo + "\n";
            return string.Empty;
        }

        public static string SoloNumerosPeroOpcional(string textoAValidar, string nombreCampo)
        {
            string strError = "";
            if (String.IsNullOrEmpty(textoAValidar))
                return strError;
            if (!EsNumero(textoAValidar))
            {
                strError += nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }


        public static string MayorACero(string textoAValidar, string nombreCampo)
        {
            string strError = "";
            if (Convert.ToInt32(textoAValidar) <= 0)
            {
                strError += nombreCampo + " debe ser mayor que cero\n";
            }
            return strError;

        }

        public static string validarNuloEnComboBox(Int64 selectedIndex, string nombreCombo)
        {
            string strError = "";
            if (selectedIndex == -1)
            {
                strError += "Seleccionar " + nombreCombo + "\n";
            }
            return strError;
        }

        public static string validarNuloEnListaDeCheckbox(CheckedListBox lstRubros, string nombreListado)
        {
            string strError = "";
            if (lstRubros.CheckedItems.Count == 0)
            {
                strError += "El " + nombreListado + " debe tener seleccionado al menos un elemento. \n";
            }
            return strError;
        }

        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if (Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }

        public static void SoloLetrasYPuntuacion(KeyPressEventArgs pE)
        {
            if (Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }

        public static void SoloNumeros(KeyPressEventArgs e) 
        {
            if (Char.IsDigit(e.KeyChar)) 
                { 
                  e.Handled = false; 
                } 
            else 
            if (Char.IsControl(e.KeyChar)) 
              { 
                e.Handled = false; 
              } 
              else 
              {
                e.Handled = true; 
              }         
        }

        public static string ValidarFecha(string textoAValidar, string nombreCampo)
        {
            bool bValid;
            DateTime fecha = new DateTime();
            string str = "";

            bValid = DateTime.TryParse(textoAValidar, out fecha);
                 
            if (!bValid)
            {
                str = nombreCampo + " Inválida \n";
            }

            return str;
        }

        public static string ValidarHora(string hora, string nombreCampo)
        {
            Regex Val = new Regex(@"(1?[0-9]|2[0-3]):[0-5][0-9]");
            Regex Val2 = new Regex(@"(2[0-3]|[01]?[0-9]):[0-5][0-9]:[0-5][0-9]");

            if (Val2.IsMatch(hora) || Val.IsMatch(hora))
                return string.Empty;
            return "Hora Inválida. \n";
        }

        public static string ValidarSoloLetras(string textoAValidar, string nombreCampo)
        {
            Regex Val = new Regex(@"^([a-zA-Z '-]+)$");

            if (!Val.IsMatch(textoAValidar))
            {
                return nombreCampo + " Inválido \n";
            }
            return string.Empty;
        }

        public static string ValidarEsBeneficio(string beneficio, string campo)
        {
            if (beneficio.Length == 12)
            {
                return "";
            }
            else
            {
                return "El Beneficio debe tener 8 dígitos\n";
            }
            
        }

        public static string ValidarEsParentesco(string parentesco, string campo)
        {
            if (parentesco.Length == 2)
            {
                return "";
            }
            else
            {
                return "El Parentesco debe tener 2 dígitos\n";
            }
        }

        public static string ValidarEsMail(string mail, string campo)
        {
           String expresion;
           expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
           if (Regex.IsMatch(mail,expresion))
           {
              if (Regex.Replace(mail, expresion, String.Empty).Length == 0)
              {
                 return "";
              }
              else
              {
                  return "Mail inválido\n";
              }
           }
           else
           {
               return "Mail inválido\n";
           }
        }

        public static string ValidarHoraEnDataGrid(DataGridView dtg, int nroCol)
        {
            string str = "";
            foreach (DataGridViewRow oneRow in dtg.Rows)
            {
                if (oneRow.Cells[nroCol].Value != null || (oneRow.Cells[nroCol].Value == null && oneRow.Cells[nroCol - 1].Value != null))
                {
                    if (oneRow.Cells[nroCol].Value != null)
                    {
                        str = str + Validator.ValidarHora(oneRow.Cells[nroCol].Value.ToString(), "Hora");
                    }
                    else
                    {
                        str = str + "no existe";
                    }
                }
            }
            if (str == "")
            {
                return "";
            }
            else
            {
                return "Horas Inválidas\n";
            }
        }
    }
}
