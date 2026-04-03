using Clase;
using Clase.Chache;
using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gest
{
    public partial class frmTipología : Form
    {
        public frmTipología()
        {
            InitializeComponent();
            apertura();
            cargadgv();
        }
        //============================== ALGORITMOS DE LIMPIEZA Y PRESENTACION =============================

        private void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            txtNombre.Enabled = false;
            txtNombre.Text = "Tipología de obra";
            dgvTipologia.Enabled = true;

        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            txtNombre.Enabled = true;
            dgvTipologia.Enabled = true;
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            txtNombre.Enabled = true;
            dgvTipologia.Enabled = true;
        }

        public void cargadgv()
        {
            DataTable dt = new DataTable();
            dt = Tipologia.extraeTipos();

            dgvTipologia.DataSource = dt;
            dgvTipologia.ReadOnly = true;

            dgvTipologia.Columns[0].HeaderText = "Orden";
            dgvTipologia.Columns[0].Width = 60;
            dgvTipologia.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTipologia.Columns[1].HeaderText = "Tipología";
            dgvTipologia.Columns[1].Width = 200;
        }
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Tipología de obra")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Tipología de obra";
                txtNombre.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            alAgregar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            apertura();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Tipología de obra" || txtNombre.Text == "")
            {
                MessageBox.Show("Falta cargar datos");
            }
            else
            {
                Tipologia Tipo = new Tipologia();
                Tipo.NOMBRE = txtNombre.Text;

                int res = Tipologia.guardaTipo(Tipo);

                if (res == 1)
                {
                    MessageBox.Show("Datos almacenados");
                }
                else
                {
                    MessageBox.Show("Los datos no se guardaron");
                }
            }
            apertura();
            cargadgv();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Tipologia Tipo = new Tipologia();
            int orden = int.Parse(dgvTipologia.CurrentRow.Cells[0].Value.ToString());
            Tipo.IDTIPO = orden;
            Tipo.NOMBRE = txtNombre.Text;

            int res = Tipologia.modificaTipologia(Tipo, orden);

            if (res == 1)
            {
                MessageBox.Show("Datos almacenados");
            }
            else
            {
                MessageBox.Show("Los datos no se guardaron");
            }
            apertura();
            cargadgv();
        }

        private void dgvTipologia_DoubleClick(object sender, EventArgs e)
        {
            if (UsuarioCache.posicion != "00")
            {
                MessageBox.Show("No tiene el NIVEL para hacer modificaciones. Solo puede ingresar Tipologías nuevas.-");
            }
            else
            {
                alModificar();
                txtNombre.Text = dgvTipologia.CurrentRow.Cells[1].Value.ToString();
            }
                
        }
    }
}
