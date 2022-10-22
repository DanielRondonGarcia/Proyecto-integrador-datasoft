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
    public class DColor
    {
        AColor con = new AColor();
        public DataTable Mostrar_Color()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarColor();
            return tabla;
        }
        public void Insertar_Color(AColor c)
        {
            con.InsertColor(c);
        }
        public void Editar_color(AColor c)
        {
            con.EditarColor(c);
        }
        public void Eliminar_Color(AColor c)
        {
            con.EliminarColor(c);
        }
    }
}
