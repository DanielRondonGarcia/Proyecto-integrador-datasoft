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
    public class DGenero
    {
        AGenero con = new AGenero();
        public DataTable Mostrar_Genero()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarGenero();
            return tabla;
        }
        public void Insertar_Genero(AGenero g)
        {
            con.InsertGenero(g);
        }
        public void Editar_Genero(AGenero g)
        {
            con.EditarGenero(g);
        }
        public void Eliminar_Genero(AGenero g)
        {
            con.EliminarGenero(g);
        }
    }
}

