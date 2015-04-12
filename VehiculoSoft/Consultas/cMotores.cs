using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiculoSoft.Consultas
{
    public partial class cMotores : Form
    {
        bool Modificar;
        public cMotores()
        {
            InitializeComponent();
        }

        public cMotores(bool Mod)
        {
            InitializeComponent();
            Modificar = Mod;
        }

        private void cMotores_Load(object sender, EventArgs e)
        {
            MotoresDataGridView.DataSource = BLL.Motores.Listar();           
            FiltroComboBox.DataSource = MotoresDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();

            if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
            {

                MotoresDataGridView.DataSource = BLL.Motores.Listar("*", FiltroComboBox.SelectedValue.ToString() + " LIKE '%" + BuscarTextBox.Text + "%';");
                FiltroComboBox.DisplayMember = "DataPropertyName";
                FiltroComboBox.ValueMember = "DataPropertyName";
            }         
        }

        private void BuscarTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if(!(MotoresDataGridView.SelectedRows.Count > 1))
            {
                if (Modificar) 
                {
                    Registros.rMotores registro = new Registros.rMotores(Convert.ToInt32(MotoresDataGridView.SelectedRows[0].Cells["IdMotor"].Value));
                    registro.ShowDialog();
                    MotoresDataGridView.Refresh();
                }
                else                
                {
                    this.Close();
                }
            }
        }

        public BLL.Motores ObtenerMotor()
        {
            BLL.Motores motor = new BLL.Motores();
            if ((MotoresDataGridView.SelectedRows.Count > 1))
            {
                
                motor.Buscar(Convert.ToInt32(MotoresDataGridView.SelectedRows[0].Cells["IdMotor"].Value));
                return motor;
            }
            else
                return motor;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            MotoresDataGridView.DataSource = BLL.Motores.Listar();
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            Reportes.MotoresRep reporte = new Reportes.MotoresRep();
            reporte.ShowDialog();
        }
    }
}
