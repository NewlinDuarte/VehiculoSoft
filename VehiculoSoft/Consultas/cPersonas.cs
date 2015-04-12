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
    public partial class cPersonas : Form
    {
        bool Modificar;
        public cPersonas()
        {
            InitializeComponent();
        }

        public cPersonas(bool Mod)
        {
            InitializeComponent();
            Modificar = Mod;

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider error = new ErrorProvider();

            if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
            {
                
                PersonasDataGridView.DataSource = BLL.Personas.Listar("*", FiltroComboBox.SelectedValue.ToString() + " LIKE '%" + BuscarTextBox.Text +"%';");
                FiltroComboBox.DisplayMember = "DataPropertyName";
                FiltroComboBox.ValueMember = "DataPropertyName";
             }

            
        }

        private void cPersonas_Load(object sender, EventArgs e)
        {
            PersonasDataGridView.DataSource = BLL.Personas.Listar();
            FiltroComboBox.DataSource = PersonasDataGridView.Columns;
            FiltroComboBox.DisplayMember = "DataPropertyName";
            FiltroComboBox.ValueMember = "DataPropertyName";
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            
            if(!(PersonasDataGridView.SelectedRows.Count > 1))
            {
                if (Modificar) 
                { 
                    Registros.rPersona registro = new Registros.rPersona(Convert.ToInt32(PersonasDataGridView.SelectedRows[0].Cells["IdPersona"].Value));
                    registro.ShowDialog();
                    PersonasDataGridView.Refresh();
                }
                else                
                {
                    this.Close();
                }
            }
        }

        public BLL.Personas ObtenerPersona() 
        {
            BLL.Personas persona = new BLL.Personas();
            if ((PersonasDataGridView.SelectedRows.Count > 1))
            {
                
                persona.Buscar(Convert.ToInt32(PersonasDataGridView.SelectedRows[0].Cells["IdPersona"].Value));
                return persona;
            }
            else
                return persona;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonasDataGridView.DataSource = BLL.Personas.Listar();
           
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            Reportes.Personasrep reporte = new Reportes.Personasrep();
            reporte.ShowDialog();
        }
    }
}
