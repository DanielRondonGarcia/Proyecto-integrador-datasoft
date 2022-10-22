using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoOracle;
using AccesoOracle.AjustesData;

namespace Dominio.DAjustes
{
    public class DCategoria
    {
        ACategoria con = new ACategoria();
        public DataTable Mostrar_Categoria()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarCategoria();
            return tabla;
        }
        public void Insertar_Categoria(ACategoria c)
        {
            con.InsertarCategoria(c);
        }
        public void Editar_Categoria(ACategoria c)
        {
            con.EditarCategoria(c);
        }
        public void Eliminar_Categoria(ACategoria c)
        {
            con.EliminarCategoria(c);
        }
    }
}
