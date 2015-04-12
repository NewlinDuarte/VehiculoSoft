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
    public partial class rFinanciamiento : Form
    {
        bool Modificar = false;
        int IdModificar = 0;
        public rFinanciamiento()
        {
            InitializeComponent();
        }

        public rFinanciamiento(int IdFinanciamiento)
        {
            InitializeComponent();
            BLL.Financiamientos fin = new BLL.Financiamientos();
            if (fin.Buscar(IdFinanciamiento)) 
            {
                Modificar = true;
                ClienteComboBox.SelectedValue = fin.IdPersona;
                GaranteComboBox.SelectedValue = fin.IdGarante;
                MotorComboBox.SelectedValue = fin.IdMotor;
                InicialTextBox.AppendText(fin.Inicial.ToString());
                QuotasComboBox.SelectedItem = fin.IntervaloPago;
            }

        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            IdtextBox.Enabled = true;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            BLL.Financiamientos fin = new BLL.Financiamientos();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text))
            {
                if (fin.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    DialogResult Resultado = MessageBox.Show("Estas seguro que deseas elminiar estos datos?", "Aviso", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        fin.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        Util.Limpiar(this);
                        InteresTextBox.AppendText("3");
                        IdtextBox.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK);
            }

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            if (Convert.ToInt32(ClienteComboBox.SelectedValue) > -1 && Convert.ToInt32(GaranteComboBox.SelectedValue) > -1 && Convert.ToInt32(MotorComboBox.SelectedValue) > -1 && Convert.ToInt32(QuotasComboBox.SelectedItem) > -1 && Util.ValidarTextBoxVacio(PrecioTextBox,error,"El campo esta vacio."))
            {
                BLL.Financiamientos finanza = new BLL.Financiamientos((int)ClienteComboBox.SelectedValue, (int)GaranteComboBox.SelectedValue, (int)MotorComboBox.SelectedValue, Convert.ToSingle(PrecioTextBox.Text), Convert.ToInt32(QuotasComboBox.SelectedItem), Convert.ToSingle(InicialTextBox.Text));
                if (Modificar) 
                {
                    if (finanza.Modificar(Convert.ToInt32(ClienteComboBox.SelectedValue), Convert.ToInt32(GaranteComboBox.SelectedValue), Convert.ToInt32(MotorComboBox.SelectedValue), Convert.ToSingle(PrecioTextBox.Text), Convert.ToInt32(QuotasComboBox.SelectedItem), Convert.ToSingle(InicialTextBox.Text))) 
                    {
                        MessageBox.Show("Exito");
                        Util.Limpiar(this);
                        InteresTextBox.AppendText("3");
                        IdtextBox.Enabled = true;
                    }

                }
                else
                {
                    if (finanza.Insert())
                    {
                        MessageBox.Show("Exito");
                        Util.Limpiar(this);
                        InteresTextBox.AppendText("3");
                        IdtextBox.Enabled = true;
                    }
                }
                
            }
        }

        private void rFinanciamiento_Load(object sender, EventArgs e)
        {
            ClienteComboBox.DataSource = BLL.Personas.Listar("*", "IsClient = 1");
            ClienteComboBox.DisplayMember = "Nombre";
            ClienteComboBox.ValueMember = "IdPersona";
            GaranteComboBox.DataSource = BLL.Personas.Listar("*", "IsClient = 0");
            GaranteComboBox.DisplayMember = "Nombre";
            GaranteComboBox.ValueMember = "IdPersona";
            MotorComboBox.DataSource = BLL.Motores.Listar();
            MotorComboBox.DisplayMember = "Modelo";
            MotorComboBox.ValueMember = "IdMotor";

            QuotasComboBox.Items.Add("15");
            QuotasComboBox.Items.Add("30");
            

        }

        private void MotorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MotorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            BLL.Motores motor = new BLL.Motores();
            BLL.Colores color = new BLL.Colores();
            motor.Buscar(Convert.ToInt32(MotorComboBox.SelectedValue));
            color.Buscar(motor.IdColor);
            ColorTextBox.Clear();
            ColorTextBox.AppendText(color.Color);
            NumeroTextBox.Clear();
            NumeroTextBox.AppendText(motor.NumeroChasis);
            PrecioTextBox.Clear();
            PrecioTextBox.AppendText(motor.Precio.ToString());
        }

        private void InteresTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ClienteComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BLL.Personas persona = new BLL.Personas();
            persona.Buscar(Convert.ToInt32(ClienteComboBox.SelectedValue));
            ClienteTextBox.Clear();
            ClienteTextBox.AppendText(persona.Ingreso.ToString());
        }

        private void GaranteComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BLL.Personas persona = new BLL.Personas();
            persona.Buscar(Convert.ToInt32(GaranteComboBox.SelectedValue));
            GaranteTextBox.Clear();
            GaranteTextBox.AppendText(persona.Ingreso.ToString());
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);        
        }

        private void InicialTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
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
                BLL.Financiamientos fin = new BLL.Financiamientos();
                if (fin.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    IdtextBox.Enabled = false;
                    int id = Convert.ToInt32(IdtextBox.Text);
                    Util.Limpiar(this);
                    InteresTextBox.AppendText("3");
                    Modificar = true;
                    IdModificar = id;
                    IdtextBox.AppendText(id.ToString());
                    ClienteComboBox.SelectedValue = fin.IdPersona;
                    GaranteComboBox.SelectedValue = fin.IdGarante;
                    MotorComboBox.SelectedValue = fin.IdMotor;
                    InicialTextBox.AppendText(fin.Inicial.ToString());
                    QuotasComboBox.SelectedItem = fin.IntervaloPago.ToString();            
                }
            }else
                {
                    Modificar = true;
                    Util.Limpiar(this);
                    InteresTextBox.AppendText("3");
                    Consultas.cFinanciamientos consulta = new Consultas.cFinanciamientos();
                    consulta.ShowDialog(this);
                    BLL.Financiamientos fin = consulta.ObtenerFinanciamiento();
                    if(fin.IdFinanciamiento > 0)
                    {
                        IdtextBox.Enabled = false;
                        IdModificar = fin.IdPersona;
                        IdtextBox.AppendText(fin.IdFinanciamiento.ToString());
                        ClienteComboBox.SelectedValue = fin.IdPersona;
                        GaranteComboBox.SelectedValue = fin.IdGarante;
                        MotorComboBox.SelectedValue = fin.IdMotor;
                        InicialTextBox.AppendText(fin.Inicial.ToString());
                        QuotasComboBox.SelectedItem = fin.IntervaloPago.ToString(); 
                        

                        
                    }
                }
            BLL.Motores motor = new BLL.Motores();
            BLL.Colores color = new BLL.Colores();
            motor.Buscar(Convert.ToInt32(MotorComboBox.SelectedValue));
            color.Buscar(motor.IdColor);
            ColorTextBox.Clear();
            ColorTextBox.AppendText(color.Color);
            NumeroTextBox.Clear();
            NumeroTextBox.AppendText(motor.NumeroChasis);
            PrecioTextBox.Clear();
            PrecioTextBox.AppendText(motor.Precio.ToString());
            BLL.Personas persona = new BLL.Personas();
            persona.Buscar(Convert.ToInt32(ClienteComboBox.SelectedValue));
            ClienteTextBox.Clear();
            ClienteTextBox.AppendText(persona.Ingreso.ToString());
            persona.Buscar(Convert.ToInt32(GaranteComboBox.SelectedValue));
            GaranteTextBox.Clear();
            GaranteTextBox.AppendText(persona.Ingreso.ToString());

            }
        }
    }

