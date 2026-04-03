using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase.Chache
{
    public static class UsuarioCache // guarda los datos del usuario que ingresa al sistema
        //para poder usarlos en cualquier rutina
    {
        public static int idUser { get; set; }
        public static String loginName { get; set; }
        public static String password { get; set; }
        public static String Nombre { get; set; }
        public static String Apellido { get; set; }
        public static String posicion { get; set; }
        public static String email { get; set; }
    }
}
