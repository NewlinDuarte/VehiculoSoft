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
    public partial class rCobros : Form
    {
        bool Modificar;
        int IdModificar;
        public rCobros()
        {
            InitializeComponent();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Util.Limpiar(this);
            CobrosDataGridView.Rows.Clear();
            IdtextBox.Enabled = true;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            BLL.Cobros cobro = new BLL.Cobros();
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text))
            {
                if (cobro.Buscar(Convert.ToInt32(IdtextBox.Text)))
                {
                    DialogResult Resultado = MessageBox.Show("Estas seguro que deseas elminiar estos datos?", "Aviso", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        cobro.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        BLL.CobroDetalles detalle = new BLL.CobroDetalles();
                        detalle.Eliminar(Convert.ToInt32(IdtextBox.Text));
                        Util.Limpiar(this);
                        CobrosDataGridView.Rows.Clear();
                        IdtextBox.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("El motor no existe", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void rCobros_Load(object sender, EventArgs e)
        {
            FinanzaComboBox.DataSource = BLL.Financiamientos.Listar();
            FinanzaComboBox.ValueMember = "IdFinanciamiento";
            
            
        }

        private void FinanzaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BalanceTextBox.Clear();
            BLL.Financiamientos fin = new BLL.Financiamientos();
            fin.Buscar(Convert.ToInt32(FinanzaComboBox.SelectedValue));           
            BalanceTextBox.AppendText(fin.Balance.ToString());
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IdtextBox.Text)) 
            {
                if (CobrosDataGridView.Rows.Count > 0 && Convert.ToInt32(IdtextBox.Text) > 0) 
                {
                    float suma = 0;
                    BLL.CobroDetalles detalle = new BLL.CobroDetalles();
                    if(Modificar)                   
                    {
                        foreach (DataGridViewRow row in CobrosDataGridView.Rows)                
                        {
                            suma += Convert.ToSingle(row.Cells["Cantidad"].Value);
                            detalle.IdCobroDetalle = Convert.ToInt32(row.Cells["IdDetalle"].Value);                          
                            detalle.Modificar(Convert.ToSingle(row.Cells["Cantidad"].Value), 3,Convert.ToSingle(row.Cells["Cantidad"].Value) * (detalle.Interes / 100),0);
                        }
                        BLL.Financiamientos fin = new BLL.Financiamientos();
                        BLL.Cobros cobro = new BLL.Cobros();
                       if(cobro.Modificar(Convert.ToSingle(BalanceTextBox.Text), suma))
                           MessageBox.Show("Exito");
                        fin.Buscar(Convert.ToInt32(FinanzaComboBox.SelectedValue));
                        fin.Balance -= suma;
                        fin.Modificar(fin.IdPersona, fin.IdGarante, fin.IdMotor, fin.Balance, fin.IntervaloPago, fin.Inicial);
                        Modificar = false;
                        
                    }else
                    {
                        foreach (DataGridViewRow row in CobrosDataGridView.Rows)                
                        {
                            suma += Convert.ToSingle(row.Cells["Cantidad"].Value);
                            detalle.IdCobro = Convert.ToInt32(row.Cells["IdCobro"].Value);
                            detalle.Interes = 3;
                            detalle.Quotas = 0;
                            detalle.BalanceInteres = Convert.ToSingle(row.Cells["Cantidad"].Value) * (detalle.Interes / 100);
                            detalle.BalanceQuota = Convert.ToSingle(row.Cells["Cantidad"].Value);
                            detalle.Insert();
                        }
                        BLL.Financiamientos fin = new BLL.Financiamientos();
                        BLL.Cobros cobro = new BLL.Cobros(Convert.ToSingle(BalanceTextBox.Text), suma, Convert.ToInt32(FinanzaComboBox.SelectedValue));
                        if(cobro.Insert())
                            MessageBox.Show("Exito");
                        fin.Buscar(Convert.ToInt32(FinanzaComboBox.SelectedValue));
                        fin.Balance -= suma;
                        fin.Modificar(fin.IdPersona, fin.IdGarante, fin.IdMotor, fin.Balance, fin.IntervaloPago, fin.Inicial);
                        
                    }
                    Util.Limpiar(this);
                    CobrosDataGridView.Rows.Clear();
                    IdtextBox.Enabled = true;
                }
            }
        }

        private void BalanceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void AbonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void ClienteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarChar(e);
        }

        private void BalanceTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.ValidarEntrada(e);
        }

        private void AbonoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdtextBox.Text) || Modificar) 
            {
                if (string.IsNullOrWhiteSpace(IdtextBox.Text))
                {
                    IdtextBox.AppendText((BLL.Cobros.Listar().Rows.Count + 1).ToString());
                    IdtextBox.Enabled = false;
                }
                    
               if (Convert.ToInt32(IdtextBox.Text) > 0)
               {
                   string[] row = { IdtextBox.Text, (CobrosDataGridView.Rows.Count + 1).ToString(), FinanzaComboBox.SelectedValue.ToString(), CantidadTextBox.Text };
                   CobrosDataGridView.Rows.Add(row);
                   CantidadTextBox.Clear();
               }
               else
                   MessageBox.Show("Porfavor busque el Cobro que desea modificar");
            }
        }

        private void BuscarButtom_Click(object sender, EventArgs e)
        {
            BLL.Cobros cobro = new BLL.Cobros();
            if (string.IsNullOrWhiteSpace(IdtextBox.Text))
                IdtextBox.AppendText("0");
            if (cobro.Buscar(Convert.ToInt32(IdtextBox.Text)))
            {
                int id = Convert.ToInt32(IdtextBox.Text);
                Util.Limpiar(this);
                Modificar = true;
                IdModificar = cobro.IdCobro;
                IdtextBox.AppendText(id.ToString());
                FinanzaComboBox.SelectedValue = cobro.IdFinanciamiento;
                IdtextBox.Enabled = false;
                foreach (DataRow row in BLL.CobroDetalles.Listar("*", "IdCobro = " + cobro.IdCobro).Rows)
                {
                    string[] fila = { cobro.IdCobro.ToString(), row["IdCobroDetalle"].ToString(), FinanzaComboBox.SelectedValue.ToString(), row["BalanceQuota"].ToString() };
                    CobrosDataGridView.Rows.Add(fila);
                }
            }
            else
            
                Modificar = true;
                Util.Limpiar(this);
                Consultas.cCobros consulta = new Consultas.cCobros();
                consulta.ShowDialog(this);
                cobro = consulta.ObtenerCobro();
                if (cobro.IdCobro > 0)                
                {
                    IdtextBox.Enabled = false;
                    IdModificar = cobro.IdCobro;
                    IdtextBox.AppendText(cobro.IdCobro.ToString());
                    FinanzaComboBox.SelectedValue = cobro.IdFinanciamiento;
                    foreach (DataRow row in BLL.CobroDetalles.Listar("*", "IdCobro = " + cobro.IdCobro).Rows)
                    {
                        string[] fila = { cobro.IdCobro.ToString(), row["IdCobroDetalle"].ToString(), FinanzaComboBox.SelectedValue.ToString(), row["BalanceQuota"].ToString() };
                        CobrosDataGridView.Rows.Add(fila);
                    }
                }       
                
            }
        }
    }

