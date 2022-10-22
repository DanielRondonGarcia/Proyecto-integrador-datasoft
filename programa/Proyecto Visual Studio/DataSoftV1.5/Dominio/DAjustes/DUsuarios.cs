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
    public class DUsuarios
    {
        AUsuarios con = new AUsuarios();
        public DataTable Mostrar_Usuarios()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarUsuarios();
            return tabla;
        }
        public DataTable Mostrar_UsuariosGerente()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarUsuariosGerente();
            return tabla;
        }
        public void Insert_Usuario(AUsuarios da)
        {
            con.InsertUsuario(da);
        }
        public void Editar_Usuario(AUsuarios da)
        {
            con.EditarUsuario(da);
        }
        public void Eliminar_Usuario(AUsuarios da)
        {
            con.EliminarUsuario(da);
        }
        public DataTable Filtrar_Cliente(string f)
        {
            DataTable tabla = new DataTable();
            tabla = con.FiltrarUsuario(f);
            return tabla;
        }
        public DataTable Listar_TipoDocumento()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarTipoDocumento();
            return tabla;
        }
        public DataTable Listar_Sucursal()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarSucursal();
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

        public DataTable Listar_Roles()
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla = con.ListarRol();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Listar_RolesGerente()
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla = con.ListarRolGerente();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Cantidad_Usuario()
        {
            return con.CantidadUsuario();
        }
    } 
}
