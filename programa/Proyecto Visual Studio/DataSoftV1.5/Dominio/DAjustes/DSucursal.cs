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
    public class DSucursal
    {
        ASucursal con = new ASucursal();
        public DataTable Mostrar_Sucursal()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarSucursal();
            return tabla;
        }
        public void Insertar_Sucursal(ASucursal s)
        {
            con.InsertarSucursal(s);
        }
        public void Editar_Sucursal(ASucursal s)
        {
            con.EditarSucursal(s);
        }
        public void Eliminar_Cliente(ASucursal s)
        {
            con.EliminarSucursal(s);
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
    }
}
