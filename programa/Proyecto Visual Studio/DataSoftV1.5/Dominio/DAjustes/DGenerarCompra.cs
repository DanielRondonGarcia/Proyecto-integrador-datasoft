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
    public class DGenerarCompra
    {
        AGenerarCompra con = new AGenerarCompra();
        public void Insertar_Encabezado(AGenerarCompra c)
        {
            con.InsertarEncabezado(c);
        }
        public void Insertar_Detalle(AGenerarCompra c)
        {
            con.InsertarDetalle(c);
        }
        public void Editar_Descuento(AGenerarCompra c)
        {
            con.EditarDescuento(c);
        }
        public DataTable Listar_Proveedor()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarProveedor();
            return tabla;
        }
        public DataTable Mostrar_Productos()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarProductos();
            return tabla;
        }
        public int Mostrar_IDFactura()
        {
            return con.MostrarIDFactura();
        }
    }
}
