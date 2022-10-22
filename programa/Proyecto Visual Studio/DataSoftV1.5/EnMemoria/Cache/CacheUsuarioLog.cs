using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMemoria.Cache
{
    public static class CacheUsuarioLog
    {
        public static int id { get; set; }
       public static int IdUser { get; set; }
       public static string nombre { get; set; }
       public static string Apellido { get; set; }
       public static int Rol { get; set; }
        public static int sucursal { get; set; }
        public static int idCliente { get; set; }
        public static long cedulaC { get; set; }
        public static string nombreC { get; set; }
        public static string apellidoC { get; set; }
        public static byte[] imagen { get; set; }
        //public static string apellido { get; set; }

    }
}
