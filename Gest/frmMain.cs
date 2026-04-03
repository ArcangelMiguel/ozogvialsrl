using Clase;
using Clase.Chache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            //label1.Text=UsuarioCache.loginName;
            //label2.Text=UsuarioCache.Nombre;
            //label3.Text = UsuarioCache.posicion;
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
            frmComit frec = new frmComit();
            frec.MdiParent = this;
            frec.Show();
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstCivil frec = new frmEstCivil();
            frec.MdiParent = this;
            frec.Show();
        }

        private void temasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipología frec = new frmTipología();
            //frec.MdiParent = this;
            frec.Show();
        }

        private void ingresarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsuarioCache.posicion != "00")
            {
                MessageBox.Show("No tiene el NIVEL para hacer Ingresos ni Mantenimiento de Usuarios.-");
            }
            else
            {
                frmUsuarios fusu = new frmUsuarios();
                //frec.MdiParent = this;
                fusu.Show();
            }
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsuarioCache.posicion != "00")
            {
                MessageBox.Show("No tiene el NIVEL para hacer Ingresos ni Mantenimiento de Usuarios.-");
            }
            else
            {
                frmPerfil fperf = new frmPerfil();
                //frec.MdiParent = this;
                fperf.Show();
            }
        }
    }
}
