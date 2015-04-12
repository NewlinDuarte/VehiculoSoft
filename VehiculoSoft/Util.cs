using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiculoSoft
{
    class Util
    {


        public static bool ValidarTextBoxVacio(TextBox TextoValidar, ErrorProvider ErrProvider, string MensajedeError)
        {
            bool valido = true;

            if (TextoValidar.Text.Trim().Length == 0)
            {
                ErrProvider.SetError(TextoValidar, MensajedeError);
                TextoValidar.Focus();
                valido = false;
            }

            return valido;
        }

        public static bool ValidarVacio (Control principal)
        {
            ErrorProvider err = new ErrorProvider();
            int valido = 0;
            foreach (Control cont in principal.Controls) 
            {  
                if (cont is TextBox) 
                {
                    
                    TextBox x = (TextBox)cont;
                    if (string.IsNullOrWhiteSpace(x.Text))
                    {
                        err.SetError(x, "El campo esta vacio");
                        valido++;
                    }
                    else
                    {
                        err.Clear();
                    }    
                }    
            }
            if (valido > 0)
                return false;
            else
                return true;
        }

        public static void Limpiar(Control principal) 
        { 
            foreach (Control cont in principal.Controls) 
            {  
                if (cont is TextBox) 
                {
                    TextBox x = (TextBox)cont;
                    x.Clear();                    
                }else
                    if (cont is MaskedTextBox) 
                    {
                        MaskedTextBox x = (MaskedTextBox)cont;
                        x.Clear();
                    }
            }
        }

        public static bool ValidarCharacteres(TextBox box, ErrorProvider error) 
        {
            char[] c;
            bool validacion = true;
            c = box.Text.ToArray();
            foreach (char ch in c) 
            {
                if (char.IsDigit(ch))
                {
                    error.SetError(box, "No se permiten numeros en este campo.");
                    validacion = false;
                }
                else
                    error.Clear();
            }
            return validacion;
        }

        public static bool ValidarEntrada( KeyPressEventArgs e) 
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;
            
        }

        public static bool ValidarChar(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) && ch != 8)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;

        }

        public static bool ValidarDoble(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetterOrDigit(ch) && ch != 8)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;

        }
    }
}
