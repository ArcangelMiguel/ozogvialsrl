using Clases;
using Conexiones;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clase
{
    public class Usuario
    {
        private int idUsuario;
        private String nombreUsuario;
        private String pass;
        private String nombre;
        private String apellido;
        private String nivel;
        private String email;


        public int IDUSUARIO { get => idUsuario; set => idUsuario = value; }
        public String NOMBREUSUARIO { get => nombreUsuario; set => nombreUsuario = value; }
        public String PASS { get => pass; set => pass = value; }
        public String NOMBRE { get => nombre; set => nombre = value; }
        public String APELLIDO { get => apellido; set => apellido = value; }
        public String NIVEL { get => nivel; set => nivel = value; }
        public String EMAIL { get => email; set => email = value; }

        //==================  Métodos estáticos de la clase ===============================

        public static int guardaUsuario(Usuario rep)
        {
            // almacenamos usuarios
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO usuarios(idUsuario,nombreUsuario,pass,nombre,apellido,nivel,email)" +
                                     " VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}'" +
                                     ")", rep.IDUSUARIO, rep.NOMBREUSUARIO, rep.PASS, rep.NOMBRE, rep.APELLIDO, rep.NIVEL, rep.EMAIL), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
        public static DataTable extraeUsuario()
        {
            String cmd = "SELECT idUsuario,nombreUsuario,pass FROM usuarios";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
    }
}
