using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Gest
{
    public partial class frmEstCivil : Form
    {
        public frmEstCivil()
        {
            InitializeComponent();
        }

        private void frmTipos_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtNombre.Text = "";
            txtEstado.Enabled = true;
            txtEstado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre.");
            }
            else
            {
                EstCivil PO = new EstCivil();
                PO.NOMBRE = txtNombre.Text;
                PO.ESTADO = txtEstado.Text;
                int res = EstCivil.guardaESTCIVIL(PO);

                if (res == 1)
                {
                    MessageBox.Show("Datos almacenados");
                }
                else
                {
                    MessageBox.Show("Los datos no se guardaron");
                }
            }
        }       
    }
}
