using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using AccesoOracle.AOModelos;
using System.Windows.Forms;

namespace AccesoOracle.AjustesData
{
    public class ACategoria : ConexionOracle
    {
        private int id;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public ACategoria() { }
        public ACategoria(int id, string nombre)
        {
            _Id = id;
            _Nombre = nombre;
        }
        public DataTable MostrarCategoria()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARCATEGORIA";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertarCategoria(ACategoria c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into categoria values (AUMENTARCATEGORIA.NEXTVAL,'" + c._Nombre + "'," + 1 + ")";
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Agragado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar");
            }
        }
        public void EditarCategoria(ACategoria c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update CATEGORIA set NOMCAT='" + c._Nombre + "' WHERE IDCAT =" + c._Id;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado Correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar");
            }
        }
        public void EliminarCategoria(ACategoria c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update categoria set ESTADO = 0 WHERE IDCAT=" + c._Id;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Eliminado Correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar");
            }
        }
    }
}
