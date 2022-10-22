using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using AccesoOracle.AOModelos;

namespace AccesoOracle.AjustesData
{
    public class AMarca : ConexionOracle
    {
        private int id;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public AMarca() { }
        public AMarca(int id, string nombre)
        {
            _Id = id;
            _Nombre = nombre;
        }
        public DataTable MostrarMarca()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARMARCA";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertMarca(AMarca m)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into MARCA values (AUMENTARMARCA.NEXTVAL,'" + m._Nombre + "',"+1+")";
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EditarMarca(AMarca m)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update MARCA set NOMMAR='" + m._Nombre + "' WHERE IDMAR =" + m._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
