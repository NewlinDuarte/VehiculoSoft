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
    public partial class rPersona : Form
    {
        bool Modificar = false;
        int IdModificar = 0;
        public rPersona()
        {
            InitializeComponent();
        }

        public rPersona(int IdPersona)
        {
            InitializeComponent();
            BLL.Personas persona = new BLL.Personas();
            if (persona.Buscar(IdPersona))
            {
                Modificar = true;
                IdModificar = IdPersona;
                IdtextBox.AppendText(IdPersona.ToString());
                NombreTextBox.AppendText(persona.Nombre);
                ApellidoTextBox.AppendText(persona.Apellido);
                CedulamaskedTextBox.AppendText(persona.Cedula);
                DireccionTextBox.AppendText(persona.Direccion);
                IngresoTextBox.AppendText(persona.Ingreso.ToString());
                TelefonomaskedTextBox.AppendText(persona.Telefono);
                if (persona.IsClient == 1)
                    ClienteRadioButton.Select();
                else
                    GaranteRadioButton.Select();
                IdtextBox.Enabled = false;
                
                    

            }
           
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            IdtextBox.Enabled = true;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            if (!Modificar && string.IsNullOrWhiteSpace(IdtextBox.Text))
                IdtextBox.AppendText("0");
            if (Util.ValidarVacio(this) && Util.ValidarCharacteres(NombreTextBox, error)) 
            {
                int IsClient = -1;
                if(ClienteRadioButton.Checked)
                    IsClient = 1;
                else
                    IsClient = 0;
                BLL.Personas persona = new BLL.Personas(IsClient, CedulamaskedTextBox.Text, Convert.ToSingle(IngresoTextBox.Text), DireccionTextBox.Text, TelefonomaskedTextBox.Text, NombreTextBox.Text, ApellidoTextBox.Text);
                
                if (Modificar)
                {
                    persona.IdPersona = IdModificar;
                    if (persona.Modificar(IsClient, Convert.ToSingle(IngresoTextBox.Text),CedulamaskedTextBox.Text, TelefonomaskedTextBox.Text , DireccionTextBox.Text, NombreTextBox.Text, ApellidoTextBox.Text)) 
                    {
                        MessageBox.Show("Exito");
                        Util.Limpiar(this);
                        Modificar = false;
                        IdModificar = 0;
                    }
                }
                else
                {  
                    if (persona.Insertar())
                    {
                        MessageBox.Show("Exito");
                        Util.Limpiar(this);
                    }
                }
            }
            
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            BLL.Personas persona = new BLL.Personas();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text)) 
            { 
                if (persona.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    DialogResult Resultado = MessageBox.Show("Estas seguro que deseas elminiar estos datos?", "Aviso", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        persona.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        Util.Limpiar(this);
                    }                            
                }
                else
                    MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK);
                }
        }

        private void rPersona_Load(object sender, EventArgs e)
        {
            
        }

        private void TelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarChar(e);
        }

        private void ApellidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarChar(e);
        }

        private void CedulaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void IngresoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void CedulamaskedTextBox_Click(object sender, EventArgs e)
        {
            CedulamaskedTextBox.SelectionStart = CedulamaskedTextBox.MaskedTextProvider.LastAssignedPosition + 1;
            CedulamaskedTextBox.SelectionLength = 0;
        }

        private void TelefonomaskedTextBox_Click(object sender, EventArgs e)
        {
            TelefonomaskedTextBox.SelectionStart = TelefonomaskedTextBox.MaskedTextProvider.LastAssignedPosition + 1;
            TelefonomaskedTextBox.SelectionLength = 0;

        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void BuscarButtom_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text) && Convert.ToInt32(IdtextBox.Text) > 0)
            {
                BLL.Personas persona = new BLL.Personas();
                if (persona.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    int id = Convert.ToInt32(IdtextBox.Text);
                    Util.Limpiar(this);
                    Modificar = true;
                    IdModificar = id;
                    IdtextBox.AppendText(id.ToString());
                    NombreTextBox.AppendText(persona.Nombre);
                    ApellidoTextBox.AppendText(persona.Apellido);
                    CedulamaskedTextBox.AppendText(persona.Cedula);
                    DireccionTextBox.AppendText(persona.Direccion);
                    IngresoTextBox.AppendText(persona.Ingreso.ToString());
                    TelefonomaskedTextBox.AppendText(persona.Telefono);
                    if (persona.IsClient == 1)
                        ClienteRadioButton.Select();
                    else
                        GaranteRadioButton.Select();
                    IdtextBox.Enabled = false;
                }


            }else
                {
                    Modificar = true;
                    Util.Limpiar(this);
                    Consultas.cPersonas consulta = new Consultas.cPersonas();
                    consulta.ShowDialog(this);
                    BLL.Personas persona = consulta.ObtenerPersona();
                    if(persona.IdPersona > 0)
                    {
                        IdModificar = persona.IdPersona;
                        IdtextBox.AppendText(persona.IdPersona.ToString());
                        NombreTextBox.AppendText(persona.Nombre);
                        ApellidoTextBox.AppendText(persona.Apellido);
                        CedulamaskedTextBox.AppendText(persona.Cedula);
                        DireccionTextBox.AppendText(persona.Direccion);
                        IngresoTextBox.AppendText(persona.Ingreso.ToString());
                        TelefonomaskedTextBox.AppendText(persona.Telefono);
                        if (persona.IsClient == 1)
                            ClienteRadioButton.Select();
                        else
                            GaranteRadioButton.Select();
                        IdtextBox.Enabled = false;

                    
                    }                  
                }

            }
        }
    }

