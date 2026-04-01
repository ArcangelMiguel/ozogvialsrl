using Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        }
        //--------------- esta rutina es para mover con el mouse el formulario ----------
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //--------------- termina la rutina ----------
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text == "" || txtUser.Text == "Usuario" ||
                    txtPass.Text == "" || txtPass.Text == "Contraseña" ||
                    txtNombre.Text == "" || txtNombre.Text == "Nombre" ||
                    txtApellido.Text == "" || txtApellido.Text == "Apellido" ||
                    txtCargo.Text == "" || txtCargo.Text == "Cargo" ||
                    txtEmail.Text == "" || txtEmail.Text == "E-mail")
                {
                    MessageBox.Show("Alguno de los campos no tiene datos ingresados");
                }
                else
                {
                    Usuario USS = new Usuario();

                    USS.NOMBREUSUARIO = txtUser.Text;
                    USS.PASS = txtPass.Text;
                    USS.NOMBRE = txtNombre.Text;
                    USS.APELLIDO = txtApellido.Text;
                    USS.NIVEL = txtCargo.Text;
                    USS.EMAIL = txtEmail.Text;

                    int usu = Usuario.guardaUsuario(USS);

                    if (usu == 1)
                    {
                        MessageBox.Show("Los datos se han almacenado");
                    }
                    else
                    {
                        MessageBox.Show("Verifique que los datos esten correctos. No se han almacenado");
                    }
                }
            }
            catch
            {
                
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

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
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

        private void frmUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            // haciendo click en el formulario, podemos moverlo para cualquier parte
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            // haciendo click en el panel izquierdo, podemos mover el formulario para cualquier parte
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
