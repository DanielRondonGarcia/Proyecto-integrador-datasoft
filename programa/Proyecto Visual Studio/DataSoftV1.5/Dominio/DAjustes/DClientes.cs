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
    public class DClientes
    {
        private ACliente con = new ACliente();
        public void Insertar_Cliente(AOCliente c)
        {
            con.InsertCliente(c);
        }
        public string Cantidad_Clientes()
        {
           return con.CantidadClientes();
        }
        public bool verificar_Cliente(AOCliente c)
        {
            return con.VerificarClientes(c);
        }
        public void Editar_Cliente(AOCliente O)
        {
            con.EditarCliente(O);
        }
        public void Eliminar_Cliente(string IDCLIENTE)
        {
            con.EliminarCliente(Convert.ToInt32(IDCLIENTE));
        }
        public DataTable Mostrar_Clientes()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarClientes();
            return tabla;
        }
        public DataTable Filtrar_Cliente(string doc)
        {
            DataTable tabla = new DataTable();
            tabla = con.FiltrarCliente(doc);
            return tabla;
        }
        public DataTable Filtrar_ClienteID(string id)
        {
            DataTable tabla = new DataTable();
            tabla = con.FiltrarClienteID(id);
            return tabla;
        }
        public DataTable Listar_TipoDocumento()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarTipoDocumento();
            return tabla;
        }
        public DataTable Listar_Sexo()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarSexo();
            return tabla;
        }
        public DataTable Listar_Departamento()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarDepartamento();
            return tabla;
        }
        public DataTable Listar_Municipios(string id_depa)
        {
            try
            {
                DataTable table = new DataTable();
                table = con.ListarMunicipios(Convert.ToInt32(id_depa));
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Listar_Zona(string id_munic)
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla = con.ListarZona(Convert.ToInt32(id_munic));
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //inversa -----------------------------------------------------------------------------
        public string IListar_Departamento(string id_mun)
        {
            return con.IListarDepartamento(Convert.ToInt32(id_mun));
        }
        public string IListar_Municipios(string id_zona)
        {
            return con.IListarMunicipios(Convert.ToInt32(id_zona));
        }
        //---------------------------------------------------------------------------------

    }
}
