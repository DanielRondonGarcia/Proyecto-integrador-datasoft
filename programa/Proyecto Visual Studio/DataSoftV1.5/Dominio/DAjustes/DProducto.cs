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
    public class DProducto
    {
        AProductos con = new AProductos();

        public void Insert_Producto(AProductos ip)
        {
            con.InsertarProducto(ip);
        }
        public void Editar_Producto(AProductos ep)
        {
            con.EditarProducto(ep);
        }
        public void Eliminar_Producto(AProductos elp)
        {
            con.EliminarProducto(elp);
        }
        public DataTable Filtrar_Producto(string f)
        {
            DataTable tabla = new DataTable();
            tabla = con.FiltrarProducto(f);
            return tabla;
        }
     
        public DataTable MostrarProducto()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarInventario();
            return tabla;
        }
        public DataTable Listar_Categoria()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarCategoria();
            return tabla;
        }
        public DataTable Listar_Color()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarColor();
            return tabla;
        }
        public DataTable Listar_Marca()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarMarca();
            return tabla;
        }
    }
}
