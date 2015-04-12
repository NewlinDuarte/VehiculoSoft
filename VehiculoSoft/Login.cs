using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace VehiculoSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error= new ErrorProvider();
            bool result = false;
            NombreTextBox.Text.Trim();
            ContraTextBox.Text.Trim();
            if (Util.ValidarTextBoxVacio(NombreTextBox, error, "Este campo es obligatorio") && Util.ValidarTextBoxVacio(ContraTextBox, error, "Este campo es obligatorio")) 
            {
                BLL.Usuarios user = new BLL.Usuarios();
                if (user.Autenticar(NombreTextBox.Text, ContraTextBox.Text)) 
                {
                    this.DialogResult = DialogResult.OK;
                    result = true;
                    this.Close();
                }


            }
                if(!result) 
                   MessageBox.Show("Nombre de Usuario o Contraseña equivocado", "Important Note");
            }                    
        

        private void Login_Load(object sender, EventArgs e)
        {
            
            

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelarButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
