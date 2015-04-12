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
    public partial class cFinanciamientos : Form
    {
        bool Modificar;
        public cFinanciamientos()
        {
            InitializeComponent();
        }
        public cFinanciamientos(bool Mod)
        {
            InitializeComponent();
            Modificar = Mod;
        }

        private void cFinanciamientos_Load(object sender, EventArgs e)
        {
            FinanciamientoDataGridView.DataSource = BLL.Financiamientos.Listar();
            FiltroComboBox.DataSource = FinanciamientoDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();

            if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
            {

                FinanciamientoDataGridView.DataSource = BLL.Financiamientos.Listar("*", FiltroComboBox.SelectedValue.ToString() + " LIKE '%" + BuscarTextBox.Text + "%';");
                FiltroComboBox.DisplayMember = "DataPropertyName";
                FiltroComboBox.ValueMember = "DataPropertyName";
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {

            if (!(FinanciamientoDataGridView.SelectedRows.Count > 1))
            {
                if (Modificar)
                {
                    Registros.rFinanciamiento registro = new Registros.rFinanciamiento(Convert.ToInt32(FinanciamientoDataGridView.SelectedRows[0].Cells["IdFinanciamiento"].Value));
                    registro.ShowDialog();
                    FinanciamientoDataGridView.Refresh();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            FinanciamientoDataGridView.DataSource = BLL.Financiamientos.Listar();
        }

        public BLL.Financiamientos ObtenerFinanciamiento()
        {
            BLL.Financiamientos fin = new BLL.Financiamientos();
            if ((FinanciamientoDataGridView.SelectedRows.Count > 1))
            {              
                fin.Buscar(Convert.ToInt32(FinanciamientoDataGridView.SelectedRows[0].Cells["IdFinanciamiento"].Value));
                return fin;
            }
            else
                return fin;
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            Reportes.Financiamientosrep reporte = new Reportes.Financiamientosrep();
            reporte.ShowDialog();
        }
    }
}
