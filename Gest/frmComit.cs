using Clase;
using Clase.Chache;
using Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace Gest
{
    public partial class frmComit : Form
    {
        public frmComit()
        {
            InitializeComponent();
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
            txtNombre.Text = "NOMBRE COMITENTE";
            txtDomicilio.Enabled = false;
            txtDomicilio.Text = "DOMICILIO";
            txtCuit.Enabled = false;
            txtCuit.Text = "CUIT  N°";
            txtCondicion.Enabled = false;
            txtCondicion.Text = "CONDICION ANTE EL IVA";
            dgvComitentes.Enabled = true;

        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            txtNombre.Enabled = true;
            txtDomicilio.Enabled = true;
            txtCuit.Enabled = true;
            txtCondicion.Enabled = true;
            dgvComitentes.Enabled = true;
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            txtNombre.Enabled = true;
            txtDomicilio.Enabled = true;
            txtCuit.Enabled = true;
            txtCondicion.Enabled = true;
            dgvComitentes.Enabled = true;
        }

        public void cargadgv()
        {
            DataTable dt = new DataTable();
            dt = Comitente.extraeComitente();

            dgvComitentes.DataSource = dt;
            dgvComitentes.ReadOnly = true;

            dgvComitentes.Columns[0].HeaderText = "Orden";
            dgvComitentes.Columns[0].Width = 60;
            dgvComitentes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComitentes.Columns[1].HeaderText = "Comitente";
            dgvComitentes.Columns[1].Width = 350;
            dgvComitentes.Columns[2].HeaderText = "Domicilio";
            dgvComitentes.Columns[2].Width = 100;
            dgvComitentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComitentes.Columns[3].HeaderText = "CUIT";
            dgvComitentes.Columns[3].Width = 100;
            dgvComitentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComitentes.Columns[4].HeaderText = "Condición de IVA";
            dgvComitentes.Columns[4].Width = 150;
            dgvComitentes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComit_Load(object sender, EventArgs e)
        {
            apertura();
            cargadgv();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE COMITENTE")
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
                txtNombre.Text = "NOMBRE COMITENTE";
                txtNombre.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = false;
            }
        }

        private void txtDomicilio_Enter(object sender, EventArgs e)
        {
            if (txtDomicilio.Text == "DOMICILIO")
            {
                txtDomicilio.Text = "";
                txtDomicilio.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtDomicilio_Leave(object sender, EventArgs e)
        {
            if (txtDomicilio.Text == "")
            {
                txtDomicilio.Text = "DOMICILIO";
                txtDomicilio.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = false;
            }
        }

        private void txtCuit_Enter(object sender, EventArgs e)
        {
            if (txtCuit.Text == "CUIT  N°")
            {
                txtCuit.Text = "";
                txtCuit.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtCuit_Leave(object sender, EventArgs e)
        {
            if (txtCuit.Text == "")
            {
                txtCuit.Text = "CUIT  N°";
                txtCuit.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = false;
            }
        }

        private void txtCondicion_Enter(object sender, EventArgs e)
        {
            if (txtCondicion.Text == "CONDICION ANTE EL IVA")
            {
                txtCondicion.Text = "";
                txtCondicion.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtCondicion_Leave(object sender, EventArgs e)
        {
            if (txtCondicion.Text == "")
            {
                txtCondicion.Text = "CONDICION ANTE EL IVA";
                txtCondicion.ForeColor = Color.LightGray;
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

        private void dgvComitentes_DoubleClick(object sender, EventArgs e)
        {
            if (UsuarioCache.posicion != "00")
            {
                MessageBox.Show("No tiene el NIVEL para hacer modificaciones. Solo puede ingresar Tipologías nuevas.-");
            }
            else
            {
                alModificar();
                txtNombre.Text = dgvComitentes.CurrentRow.Cells[1].Value.ToString();
                txtDomicilio.Text = dgvComitentes.CurrentRow.Cells[2].Value.ToString();
                txtCuit.Text = dgvComitentes.CurrentRow.Cells[3].Value.ToString();
                txtCondicion.Text = dgvComitentes.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Comitente Comit = new Comitente();
            int orden = int.Parse(dgvComitentes.CurrentRow.Cells[0].Value.ToString());
            Comit.IDCOMITENTE = orden;
            Comit.NOMBRE = txtNombre.Text;
            Comit.DOMICILIO = txtDomicilio.Text;
            Comit.CUIT= txtCuit.Text;
            Comit.CONDICION = txtCondicion.Text;
            
            int res = Comitente.modificaComitente(Comit, orden);

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRECOMITENTE" || txtNombre.Text == "" ||
                txtDomicilio.Text == "DOMICILIO" || txtDomicilio.Text == ""||
                txtCuit.Text == "CUIT  N°" || txtCuit.Text == "" ||
                txtCondicion.Text == "CONDICION ANTE EL IVA" || txtCondicion.Text == "")
            {
                MessageBox.Show("Falta cargar datos");
            }
            else
            {
                Comitente Comit = new Comitente();
                Comit.NOMBRE=txtNombre.Text;
                Comit.DOMICILIO= txtDomicilio.Text;
                Comit.CUIT = txtCuit.Text;
                Comit.CONDICION= txtCondicion.Text;

                int res = Comitente.guardaComitente(Comit);
                if (res==1)
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
    }
}
