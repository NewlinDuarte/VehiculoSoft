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
    public partial class cCobros : Form
    {
        public cCobros()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();

            if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
            {

                CobrosDataGridView.DataSource = BLL.Cobros.Listar("*", FiltroComboBox.SelectedValue.ToString() + " LIKE '%" + BuscarTextBox.Text + "%';");
                FiltroComboBox.DisplayMember = "DataPropertyName";
                FiltroComboBox.ValueMember = "DataPropertyName";
            }
        }

        private void cCobros_Load(object sender, EventArgs e)
        {
            CobrosDataGridView.DataSource = BLL.Cobros.Listar();
            FiltroComboBox.DataSource = CobrosDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            CobrosDataGridView.DataSource = BLL.Cobros.Listar();
            FiltroComboBox.DataSource = CobrosDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";
        }

        public BLL.Cobros ObtenerCobro()
        {
            BLL.Cobros cobro = new BLL.Cobros();
            if ((CobrosDataGridView.SelectedRows.Count > 1))
            {
                
                cobro.Buscar(Convert.ToInt32(CobrosDataGridView.SelectedRows[0].Cells["IdCobro"].Value));
                return cobro;
            }
            else
                return cobro ;
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            Reportes.CobrosRep reporte = new Reportes.CobrosRep();
            reporte.ShowDialog();
        }
    }
}
