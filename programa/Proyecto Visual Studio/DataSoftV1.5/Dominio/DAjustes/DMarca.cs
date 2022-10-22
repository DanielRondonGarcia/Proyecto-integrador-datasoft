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
    public class DMarca
    {
        AMarca con = new AMarca();
        public DataTable Mostrar_Marca()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarMarca();
            return tabla;
        }
        public void Insertar_Marca(AMarca m)
        {
            con.InsertMarca(m);
        }
        public void Editar_Marca(AMarca m)
        {
            con.EditarMarca(m);
        }
    }
}
