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
    public class Categoria
    {
        private int idCateg;
        private String nombre;
        private String estado;
       
        public int IDCATEG { get => idCateg; set => idCateg = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }
        public string ESTADO { get => estado; set => estado = value; }
       
        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeCategoria()
        {
            String cmd = "SELECT idCateg, nombre, estado FROM categoria";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
       
        public static int guardaCategoria(Categoria rep)
        {
            // almacenamos nuevo proveedor. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO categoria(idCateg, nombre,estado)"+
                " VALUES ({0},'{1}','{2}','{3}')", rep.IDCATEG, rep.NOMBRE, rep.ESTADO), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
        public static int modificaEstCateg(Categoria rep, int orden)
        {
            // aca solamente modificamos los datos del proveedor
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE categoria SET idCateg='{0}',nombre='{1}',estado='{2}' WHERE idCateg='{3}'",
                +rep.IDCATEG, rep.NOMBRE, rep.ESTADO, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
