using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;
using Clase;

namespace Clases
{
    public class Tipologia
    {
        private int idTipol;
        private String nombre;

        public int IDTIPO { get => idTipol; set => idTipol = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeTipos()
        {
            String cmd = "SELECT idTipol, nombre FROM tipologia";
            // 
            DataSet ds = Accesos.datos(cmd); 
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaTipo(Tipologia rep)
        {
            // almacenamos nuevo tipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO tipologia(idTipol,nombre) VALUES ('{0}','{1}')", rep.IDTIPO,rep.NOMBRE), connn);

            if (connn.State != ConnectionState.Open)
            {
                connn.Open();
            }

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static int modificaTipologia(Tipologia rep, int orden) // Almacena los datos modificados de la tipología seleccionada
        {
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE tipologia SET idTipol='{0}', nombre='{1}' where idTipol='{2}'", rep.IDTIPO, rep.NOMBRE, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
