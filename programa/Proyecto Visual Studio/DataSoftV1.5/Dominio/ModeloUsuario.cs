using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoOracle;

namespace Dominio
{
    public class ModeloUsuario
    {
        DatosUsuario datosUser = new DatosUsuario();
        public bool LoginUser(string correo, string PWD)
        {
            return datosUser.Login(correo, PWD);
        }

    } 
}
