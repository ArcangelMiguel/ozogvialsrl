using Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void novedadesEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovedadEquipo fne = new frmNovedadEquipo();
            fne.MdiParent = this;
            fne.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void remitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemitos frem = new frmRemitos();
            frem.MdiParent = this;
            frem.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmComitente frec = new frmComitente();
            frec.MdiParent = this;
            frec.Show();
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstCivil frec = new frmEstCivil();
            frec.MdiParent = this;
            frec.Show();
        }
    }
}
