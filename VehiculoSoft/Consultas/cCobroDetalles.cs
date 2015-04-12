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
    public partial class cCobroDetalles : Form
    {
        public cCobroDetalles()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();

            if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
            {
                CobroDetallesDataGridView.ClearSelection();
                foreach (DataGridViewRow row in CobroDetallesDataGridView.Rows)
                {
                    if (row.Cells[(int)FiltroComboBox.SelectedIndex].Value.ToString().Equals(BuscarTextBox.Text))
                    {
                        CobroDetallesDataGridView.Rows[row.Index].Selected = true;

                    }
                }

            }
        }

        private void cCobroDetalles_Load(object sender, EventArgs e)
        {
            CobroDetallesDataGridView.DataSource = BLL.CobroDetalles.Listar();
            FiltroComboBox.DataSource = CobroDetallesDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";
        }
    }
}
