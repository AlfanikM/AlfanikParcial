using PrimerParcialAlfanik.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcialAlfanik
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroProducto regpro = new RegistroProducto();
            regpro.Show();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alfanik Garcia Colon 2014-0633", "Informacion!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
