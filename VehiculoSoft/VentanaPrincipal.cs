using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiculoSoft
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Login log = new Login();
            log.ShowDialog();
            if (!(log.DialogResult == DialogResult.OK)) 
            {
                this.Close();
            }
        }

        

        private void usuarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Registros.rUsuario registro = new Registros.rUsuario();
            registro.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Registros.rPersona registro = new Registros.rPersona();
            registro.ShowDialog();
        }

        private void motoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rMotores registro = new Registros.rMotores();
            registro.ShowDialog();
        }

        private void financiamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rFinanciamiento registro = new Registros.rFinanciamiento();
            registro.ShowDialog();
        }

        private void cobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rCobros registro = new Registros.rCobros();
            registro.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.cUsuario consulta = new Consultas.cUsuario();
            consulta.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cPersonas consulta = new Consultas.cPersonas();
            consulta.ShowDialog();
        }

        private void motoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cMotores consulta = new Consultas.cMotores();
            consulta.ShowDialog();
        }

        private void financiamientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cFinanciamientos consulta = new Consultas.cFinanciamientos();
            consulta.ShowDialog();
        }

        private void cobrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cCobros consulta = new Consultas.cCobros();
            consulta.ShowDialog();
        }
    }
}
