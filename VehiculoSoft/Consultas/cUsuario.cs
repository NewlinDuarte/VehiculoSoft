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
    public partial class cUsuario : Form
    {
        bool Modificar;
        public cUsuario()
        {
            InitializeComponent();
        }
        public cUsuario(bool Mod)
        {
            InitializeComponent();
            Modificar = Mod;
        }

       private void cUsuario_Load(object sender, EventArgs e)
       {
           UsuarioDataGridView.DataSource = BLL.Usuarios.Listar();
           FiltroComboBox.DataSource = UsuarioDataGridView.Columns;
           FiltroComboBox.DisplayMember = "DataPropertyName";
           FiltroComboBox.ValueMember = "DataPropertyName";
       }
      
       private void BuscarButton_Click(object sender, EventArgs e)
       {
           ErrorProvider error = new ErrorProvider();

           if (Util.ValidarTextBoxVacio(BuscarTextBox, error, "El campo esta vacio"))
           {
                   UsuarioDataGridView.DataSource = BLL.Personas.Listar("*", FiltroComboBox.SelectedValue.ToString() + " LIKE '%" + BuscarTextBox.Text + "%';");
                   FiltroComboBox.DisplayMember = "DataPropertyName";
                   FiltroComboBox.ValueMember = "DataPropertyName";               
           }
       }

       private void ModificarButton_Click(object sender, EventArgs e)
       {
           if (!(UsuarioDataGridView.SelectedRows.Count > 1))
           {
               if (Modificar)
               {
                   Registros.rPersona registro = new Registros.rPersona(Convert.ToInt32(UsuarioDataGridView.SelectedRows[0].Cells["IdPersona"].Value));
                   registro.ShowDialog();
                   UsuarioDataGridView.Refresh();
               }
               else
               {
                   this.Close();
               }
           }
       }

       public BLL.Usuarios ObtenerUsuario()
       {
           BLL.Usuarios user = new BLL.Usuarios();
           if ((UsuarioDataGridView.SelectedRows.Count > 1))
           {
               
               user.Buscar(Convert.ToInt32(UsuarioDataGridView.SelectedRows[0].Cells["IdUsuario"].Value));
               return user;
           }
           else
               return user;
       }

       private void LimpiarButton_Click(object sender, EventArgs e)
       {
           UsuarioDataGridView.DataSource = BLL.Usuarios.Listar();
       }

       private void imprimirButton_Click(object sender, EventArgs e)
       {
           Reportes.UsuarioRep reporte = new Reportes.UsuarioRep();
           reporte.ShowDialog();
       }
    }
}
