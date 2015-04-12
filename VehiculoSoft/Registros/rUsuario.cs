using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiculoSoft.Registros
{
    public partial class rUsuario : Form
    {
        bool Modificar = false;
        int IdModificar = 0;
        public rUsuario()
        {
            InitializeComponent();
        }

        public rUsuario(int IdUsuario)
        {
            InitializeComponent();
            BLL.Usuarios user = new BLL.Usuarios();
            if (user.Buscar(IdUsuario)) 
            {
                Modificar = true;
                IdModificar = IdUsuario;
                UsuarioTextBox.AppendText(user.NombreUsuario);
                NombreTextBox.AppendText(user.Nombres);
                ContraTextBox.AppendText(user.Contra);
                EmailTextBox.AppendText(user.Email);
            }

        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            err.Clear();
            if (!Modificar && string.IsNullOrWhiteSpace(IdtextBox.Text))
                IdtextBox.AppendText("0");
            if( Util.ValidarVacio(this) && ContraTextBox.Text.Equals(ConfirmarTextBox.Text))
            {
                BLL.Usuarios user = new BLL.Usuarios(UsuarioTextBox.Text, NombreTextBox.Text, ContraTextBox.Text, EmailTextBox.Text);
                if (Modificar) 
                {
                    user.IdUsuario = IdModificar;
                    if (user.Modificar(UsuarioTextBox.Text, NombreTextBox.Text, ContraTextBox.Text, EmailTextBox.Text))
                        MessageBox.Show("Exito");
                }
                else
                {
                    if (user.Insert())
                        MessageBox.Show("Exito");
                }
                Util.Limpiar(this);
                IdtextBox.Enabled = true;
            }                           
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            BLL.Usuarios user = new BLL.Usuarios();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text))
            {
                if (user.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    DialogResult Resultado = MessageBox.Show("Estas seguro que deseas elminiar estos datos?", "Aviso", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        user.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        Util.Limpiar(this);
                        IdtextBox.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("El usuario no existe", "Aviso", MessageBoxButtons.OK);
                
            }
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarButton_Click_1(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            IdtextBox.Enabled = true;
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarChar(e);
        }

        private void BuscarButtom_Click(object sender, EventArgs e)
        {
             ErrorProvider error = new ErrorProvider();
            if(!string.IsNullOrWhiteSpace(IdtextBox.Text) && Convert.ToInt32(IdtextBox.Text) > 0)
            {
                 BLL.Usuarios usuario = new BLL.Usuarios();
                 if (usuario.Buscar(Convert.ToInt32(IdtextBox.Text))) 
                 {
                     int id = Convert.ToInt32(IdtextBox.Text);
                     Util.Limpiar(this);
                     Modificar = true;
                     IdModificar = id;
                     IdtextBox.AppendText(id.ToString());
                     NombreTextBox.AppendText(usuario.Nombres);
                     ContraTextBox.AppendText(usuario.Contra);
                     UsuarioTextBox.AppendText(usuario.NombreUsuario);
                     EmailTextBox.AppendText(usuario.Email);
                     IdtextBox.Enabled = false;
                     
                 }
            }else
            {
               Util.Limpiar(this);
               Modificar = true;
               Consultas.cUsuario consulta = new Consultas.cUsuario();  
               consulta.ShowDialog(this);                           
               BLL.Usuarios usuario = consulta.ObtenerUsuario();
               if (usuario.IdUsuario > 0)
               {
                   IdModificar = usuario.IdUsuario;
                   IdtextBox.AppendText(usuario.IdUsuario.ToString());
                   NombreTextBox.AppendText(usuario.Nombres);
                   ContraTextBox.AppendText(usuario.Contra);
                   UsuarioTextBox.AppendText(usuario.NombreUsuario);
                   EmailTextBox.AppendText(usuario.Email);
                   IdtextBox.Enabled = false; 
               }
                          
            }          
        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarDoble(e);
        }

        private void ContraTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarDoble(e);
        }

        private void ConfirmarTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarDoble(e);
        }
        }
    }


