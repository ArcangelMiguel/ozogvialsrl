using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class EstCivil
    {
        private int idEstCiv;
        private String nombre;
        private String estado;


        public int IDESTCIV { get => idEstCiv; set => idEstCiv = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }
        public string ESTADO { get => estado; set => estado = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeESTCIVIL()
        {
            String cmd = "SELECT idEstCiv, nombre,estado  FROM estcivil";
            // 
            DataSet ds = Accesos.datos(cmd); 
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaESTCIVIL(EstCivil rep)
        {
            // almacenamos nuevo tipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO estcivil(idEstCiv, nombre,estado )" +
                " VALUES ('{0}','{1}','(2)')", rep.IDESTCIV, rep.NOMBRE, rep.ESTADO, connn));

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
