using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Clase;
using Clase.Chache;
using Gest;// para mover el formulario



namespace Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //--------------- esta rutina es para mover con el mouse el formulario ----------
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //--------------- termina la rutina ----------

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor= Color.LightGray;

            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;

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
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // haciendo click en el formulario, podemos moverlo para cualquier parte
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // haciendo click en el panel izquierdo, podemos mover el formulario para cualquier parte
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPass.Text=="" || txtPass.Text=="Contraseña" || txtUsuario.Text=="" || txtUsuario.Text == "Usuario")
            {
                MessageBox.Show("Faltan ingresar datos");
            }
            else
            {
               DataTable dt= Usuario.verificaUsuario(txtUsuario.Text.Trim(),txtPass.Text.Trim());

                if (dt.Rows.Count == 1)
                {
                    UsuarioCache.loginName = dt.Rows[0][1].ToString();
                    UsuarioCache.password = dt.Rows[0][2].ToString();
                    UsuarioCache.Nombre = dt.Rows[0][3].ToString();
                    UsuarioCache.Apellido = dt.Rows[0][4].ToString();
                    UsuarioCache.posicion = dt.Rows[0][5].ToString();
                    UsuarioCache.email = dt.Rows[0][6].ToString();

                    this.Hide();

                   frmMain fne = new frmMain();
                   fne.Show();
                }
                else
                {
                    MessageBox.Show("Los datos son incorrectos");
                }
            }
        }        
    }
}
