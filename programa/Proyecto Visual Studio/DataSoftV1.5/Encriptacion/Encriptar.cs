using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encriptacion
{
    public class Encriptar
    {
        private string password;

        public string Password { get => password; set => password = value; }

        public string _Encriptar(string password)
        {
            string resultado = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(password);
            resultado = Convert.ToBase64String(encriptar);
            return resultado;
        }
        public string _Desencriptar(string password)
        {
            string resultado = string.Empty;
            Byte[] Desencriptar = Convert.FromBase64String(password);
            resultado = System.Text.Encoding.Unicode.GetString(Desencriptar);
            return resultado;
        }
    }
}
