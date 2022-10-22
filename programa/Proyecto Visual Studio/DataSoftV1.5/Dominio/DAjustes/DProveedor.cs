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
    public class DProveedor
    {
        AProveedor con = new AProveedor();
        public void Insertar_Proveedor(AProveedor p)
        {
            con.InsertarProveedor(p);
        }
        public string Cantidad_Proveedor()
        {
            return con.CantidadProveedor();
        }
        //public bool verificar_Proveedor(AProveedor p)
        //{
        //    return con.VerificarProveedor(p);
        //}
        public void Editar_Proveedor(AProveedor p)
        {
            con.EditarProveedor(p);
        }
        public void Eliminar_Proveedor(AProveedor p)
        {
            con.EliminarProveedor(p);
        }
        public DataTable Mostrar_Proveedor()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarProveedor();
            return tabla;
        }
        public DataTable Filtrar_Proveedor(AProveedor p)
        {
            DataTable tabla = new DataTable();
            tabla = con.FiltrarProveedor(p);
            return tabla;
        }
        public DataTable Listar_TipoDocumento()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarTipoDocumento();
            return tabla;
        }
    }
}
