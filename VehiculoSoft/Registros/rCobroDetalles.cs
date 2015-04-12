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
    public partial class rCobroDetalles : Form
    {
        public rCobroDetalles()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void rCobroDetalles_Load(object sender, EventArgs e)
        {
            CobroComboBox.DataSource = BLL.Cobros.Listar();
            CobroComboBox.DisplayMember = "Fecha";
            CobroComboBox.ValueMember = "IdCobro";

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Util.ValidarVacio(this)) 
            {
                BLL.Cobros cobro = new BLL.Cobros();
                cobro.Buscar(Convert.ToInt32(CobroComboBox.SelectedValue));
                BLL.Financiamientos fin = new BLL.Financiamientos();
                fin.Buscar(cobro.IdFinanciamiento);                
                BLL.CobroDetalles detalle = new BLL.CobroDetalles(Convert.ToSingle(QuotaTextBox.Text), Convert.ToSingle(InteresTextBox.Text), Convert.ToSingle(BalanceIntTextBox.Text), fin.IntervaloPago);
                detalle.Insert();
            }
        }

        private void QuotaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QuotaTextBox.Text))
            {
                BalanceIntTextBox.Clear();
                TotalTextBox.Clear();
                BalanceIntTextBox.AppendText((Convert.ToDouble(QuotaTextBox.Text) * Convert.ToDouble(InteresTextBox.Text) / 100).ToString());
                TotalTextBox.AppendText((Convert.ToDouble(BalanceIntTextBox.Text) + Convert.ToDouble(QuotaTextBox.Text)).ToString());
            }
            else
            {
                Util.Limpiar(this);
                InteresTextBox.AppendText("4");
            }
                
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            InteresTextBox.AppendText("4");
        }
    }
}
