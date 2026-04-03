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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            apertura();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            alAgregar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            apertura();
        }

        //============================== ALGORITMOS DE LIMPIEZA Y PRESENTACION =============================

        private void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            
            txtNombre.Enabled = false;
            txtNombre.Text = "Nombre";
            txtPass.Enabled = false;
            txtPass.Text = "Contraseña";
            txtUser.Enabled = false;
            txtUser.Text = "Usuario";
            txtApellido.Enabled = false;
            txtApellido.Text = "Apellido";
            txtCargo.Enabled = false;
            txtCargo.Text = "Cargo";
            txtEmail.Enabled = false;
            txtEmail.Text = "E-mail";
        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtNombre.Enabled = true;
            txtPass.Enabled = true;
            txtUser.Enabled = true;
            txtApellido.Enabled = true;
            txtCargo.Enabled = true;
            txtEmail.Enabled = true;
            
        }
        // ==========================================================================

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.LightGray;
                // txtNombre.UseSystemPasswordChar = false;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
                //txtNombre.UseSystemPasswordChar = true;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.LightGray;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.LightGray;
                //txtApellido.UseSystemPasswordChar = true;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Text = "Apellido";
                txtApellido.ForeColor = Color.LightGray;
            }
        }

        private void txtCargo_Enter(object sender, EventArgs e)
        {
            if (txtCargo.Text == "Cargo")
            {
                txtCargo.Text = "";
                txtCargo.ForeColor = Color.LightGray;
                //txtApellido.UseSystemPasswordChar = true;
            }
        }

        private void txtCargo_Leave(object sender, EventArgs e)
        {
            if (txtCargo.Text == "")
            {
                txtCargo.Text = "Cargo";
                txtCargo.ForeColor = Color.LightGray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "E-mail")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
                //txtApellido.UseSystemPasswordChar = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "E-mail";
                txtEmail.ForeColor = Color.LightGray;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre" || txtNombre.Text == "" ||
              txtApellido.Text == "Apellido" || txtApellido.Text == "" ||
              txtUser.Text == "Usuario°" || txtUser.Text == "" ||
              txtPass.Text == "Contraseña" || txtPass.Text == "" ||
                   txtCargo.Text == "Cargo" || txtCargo.Text == "" ||
                   txtEmail.Text == "E-mail" || txtEmail.Text == "")
            {
                MessageBox.Show("Falta cargar datos");
            }
            else
            {
                Usuario User = new Usuario();
                User.NOMBREUSUARIO = txtUser.Text.Trim();
                User.PASS = txtPass.Text.Trim();
                User.NOMBRE = txtNombre.Text.Trim();
                User.APELLIDO = txtApellido.Text.Trim();
                User.NIVEL = txtCargo.Text.Trim();
                User.EMAIL = txtEmail.Text.Trim();

                int res = Usuario.guardaUsuario(User);

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
        }
    }
}
