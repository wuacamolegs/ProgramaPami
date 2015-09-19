using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
    public class MessageBoxPersonalizado
    {
        public static void ShowDialogCommonText(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 100, Top = 20, Width = 400, Text = text };
            Button Editar = new Button() { Text = "Editar", Left = 150, Width = 100, Top = 70 };
            Button cancel = new Button() { Text = "Cancelar", Left = 250, Width = 100, Top = 70 };
            Editar.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(Editar);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = Editar;
            prompt.CancelButton = cancel;
            prompt.ShowDialog();
        }
    }
}
