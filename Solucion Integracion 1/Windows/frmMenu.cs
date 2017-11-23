using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria agregarCategoria = new frmAgregarCategoria();
            agregarCategoria.MdiParent = this;
            agregarCategoria.Show();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmPrendas prenda = new frmPrendas();
            prenda.MdiParent = this;
            prenda.Show();


        }
    }
}
