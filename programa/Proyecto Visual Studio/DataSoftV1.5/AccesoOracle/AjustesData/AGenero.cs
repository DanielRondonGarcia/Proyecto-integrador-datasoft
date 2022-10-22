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
    public class AGenero : ConexionOracle
    {
        private int id;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public AGenero() { }
        public AGenero(int id, string nombre)
        {
            _Id = id;
            _Nombre = nombre;
        }
        public DataTable MostrarGenero()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARGENERO";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertGenero(AGenero g)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into SEXO values (AUMENTARSEXO.NEXTVAL,'" + g._Nombre + "',"+1+")";
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EditarGenero(AGenero g)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update SEXO set NOMSEX='" + g._Nombre + "' WHERE IDSEX =" + g._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EliminarGenero(AGenero g)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update SEXO set ESTADO = 0 WHERE IDSEX=" + g._Id;
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
