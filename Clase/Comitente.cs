using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;
using Clases;

namespace Clase
{
    public class Comitente
    {
        private int idComitente;
        private String nombre;
        private String domicilio;
        private String cuit;
        private String condicion;
        
        public int IDCOMITENTE { get => idComitente; set => idComitente = value; }
        public String NOMBRE { get => nombre; set => nombre = value; }
        public String DOMICILIO { get => domicilio; set => domicilio = value; }
        public String CUIT { get => cuit; set => cuit = value; }
        public String CONDICION { get => condicion; set => condicion = value; }

        public static int guardaComitente(Comitente rep)
        {
            // almacenamos materiales
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO comitente(idComit,nombre,domicilio,cuit,condicion)" +
                                     " VALUES ({0},'{1}','{2}','{3}','{4}'" +
                                     ")", rep.IDCOMITENTE, rep.NOMBRE, rep.DOMICILIO, rep.CUIT, rep.CONDICION), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static DataTable extraeComitente() // extrae todos los comitentes para presentarlos
        {
            String cmd = "SELECT idComit, nombre,domicilio,cuit,condicion FROM comitente";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
       
        
        public static int modificaComitente(Comitente rep, int orden) // Almacena los datos modificados de un comitente seleccionado
        {
            // almacenamos la modificación del movimiento de equipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE comitente SET idComit='{0}', nombre='{1}', domicilio='{2}', cuit='{3}', condicion='{4}' where idComit='{5}'", rep.IDCOMITENTE, rep.NOMBRE, rep.DOMICILIO, rep.CUIT, rep.CONDICION, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }




    }
}
