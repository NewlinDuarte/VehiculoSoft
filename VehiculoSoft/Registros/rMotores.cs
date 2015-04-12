using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace VehiculoSoft.Registros
{
    public partial class rMotores : Form
    {
        bool Modificar = false;
        int IdModificar = 0;
        public rMotores()
        {
            InitializeComponent();
        }
        public rMotores(int IdMotor)
        {
            InitializeComponent();
            ColorComboBox.DataSource = BLL.Colores.Listar();
            ColorComboBox.DisplayMember = "Color";
            ColorComboBox.ValueMember = "IdColor";
            for (int year = 1960; year <= DateTime.Now.Year; year++)
            {
                AComboBox.Items.Add(year);
                AComboBox.ValueMember = "year";
            }
            BLL.Motores motor = new BLL.Motores();
            if (motor.Buscar(IdMotor)) 
            {
                Modificar = true;
                IdModificar = IdMotor ;
                FabricanteTextBox.AppendText(motor.Fabricante);
                ModeloTextBox.AppendText(motor.Modelo);
                ColorComboBox.SelectedIndex = motor.IdColor;
                NumeroTextBox.AppendText(motor.NumeroChasis);
                AComboBox.SelectedItem = motor.AProduccion;
                PrecioTextBox.AppendText(motor.Precio.ToString());
            }

        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            IdtextBox.Enabled = true;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Util.ValidarVacio(this)) 
            {
                ErrorProvider error = new ErrorProvider();
                if (Util.ValidarCharacteres(FabricanteTextBox, error))
                {
                    BLL.Motores motor = new BLL.Motores(FabricanteTextBox.Text, ModeloTextBox.Text, Convert.ToInt32(ColorComboBox.SelectedValue), NumeroTextBox.Text, Convert.ToInt32(AComboBox.SelectedItem), Convert.ToSingle(PrecioTextBox.Text));
                    if (Modificar)
                    {
                        motor.IdMotor = IdModificar;
                        if (motor.Modificar(FabricanteTextBox.Text, ModeloTextBox.Text, Convert.ToInt32(ColorComboBox.SelectedValue), NumeroTextBox.Text, Convert.ToInt32(AComboBox.SelectedItem), Convert.ToSingle(PrecioTextBox.Text))) 
                        {
                            MessageBox.Show("Exito");
                            Util.Limpiar(this);
                            IdtextBox.Enabled = true;
                        }
                            
                    }
                    else
                    {
                        motor.Insert();
                        if (motor.IdMotor > 0)
                        {
                            MessageBox.Show("Exito");
                            Util.Limpiar(this);
                            IdtextBox.Enabled = true;
                        }                           
                    }
                }
                
            }
            
        }

        private void rMotores_Load(object sender, EventArgs e)
        {
            ColorComboBox.DataSource = BLL.Colores.Listar();
            ColorComboBox.DisplayMember = "Color";
            ColorComboBox.ValueMember = "IdColor";
            for (int year = 1960; year <= DateTime.Now.Year; year++)
            {
                AComboBox.Items.Add(year);
                AComboBox.ValueMember = "year";
            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            BLL.Motores motor = new BLL.Motores();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text))
            {
                if (motor.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    DialogResult Resultado = MessageBox.Show("Estas seguro que deseas elminiar estos datos?", "Aviso", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        motor.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        Util.Limpiar(this);
                    }
                }
                else
                    MessageBox.Show("El motor no existe", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void FabricanteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarChar(e);
        }

        private void ModeloTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarDoble(e);
        }

        private void BuscarButtom_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text) && Convert.ToInt32(IdtextBox.Text) > 0)
            {
                BLL.Motores motor = new BLL.Motores();
                if (motor.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    IdtextBox.Enabled = false;
                    int id = Convert.ToInt32(IdtextBox.Text);
                    Util.Limpiar(this);
                    Modificar = true;
                    IdModificar = id;
                    IdtextBox.AppendText(id.ToString());
                    FabricanteTextBox.AppendText(motor.Fabricante);
                    ModeloTextBox.AppendText(motor.Modelo);
                    ColorComboBox.SelectedValue = motor.IdColor;
                    NumeroTextBox.AppendText(motor.NumeroChasis);
                    AComboBox.SelectedValue = motor.AProduccion;
                    PrecioTextBox.AppendText(motor.Precio.ToString());
                }
            }else
                {
                    Modificar = true;
                    Util.Limpiar(this);
                    Consultas.cMotores consulta = new Consultas.cMotores();
                    consulta.ShowDialog(this);
                    BLL.Motores motor = consulta.ObtenerMotor();
                    if(motor.IdMotor > 0)
                    {
                        IdtextBox.Enabled = false;
                        IdModificar = motor.IdMotor;
                        IdtextBox.AppendText(motor.IdMotor.ToString());
                        FabricanteTextBox.AppendText(motor.Fabricante);
                        ModeloTextBox.AppendText(motor.Modelo);
                        ColorComboBox.SelectedValue = motor.IdColor;
                        NumeroTextBox.AppendText(motor.NumeroChasis);
                        AComboBox.SelectedIndex = AComboBox.Items.Count - (DateTime.Now.Year - motor.AProduccion + 1);
                        PrecioTextBox.AppendText(motor.Precio.ToString());                   
                    }
                    


                }

            }          
        
        }
    }

