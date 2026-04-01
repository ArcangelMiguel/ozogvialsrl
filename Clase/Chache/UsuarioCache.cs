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
        private static int idUser { get; set; }
        private static String loginName { get; set; }
        private static String password { get; set; }
        private static String Nombre { get; set; }
        private static String Apellido { get; set; }
        private static String posicion { get; set; }
        private static String email { get; set; }
    }
}
