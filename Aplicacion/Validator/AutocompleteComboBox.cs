using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
    public class AutocompleteComboBox
    {

        public static AutoCompleteStringCollection LoadAutoComplete(DataSet ds, string nombre_columna)
        {
            DataTable dt = (DataTable)ds.Tables[0];

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row[nombre_columna]));
            }

            return stringCol;
        }

    }
}
