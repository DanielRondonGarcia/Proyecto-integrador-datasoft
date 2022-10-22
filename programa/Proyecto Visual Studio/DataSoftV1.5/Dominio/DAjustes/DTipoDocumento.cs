using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoOracle;
using AccesoOracle.AOModelos;
using AccesoOracle.AjustesData;

namespace Dominio.DAjustes
{
    public class DTipoDocumento
    {
        ATipoDocumento con = new ATipoDocumento();
        public DataTable Mostrar_TipoDocumento()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarTipoDocumento();
            return tabla;
        }
        public void Insertar_TipoDocumento(ATipoDocumento td)
        {
            con.InsertTipoDocumento(td);
        }
        public void Editar_TipoDocumento(ATipoDocumento td)
        {
            con.EditarTipoDocumento(td);
        }
    }
}
