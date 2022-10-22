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
    public class AColor:ConexionOracle
    {
        private int id;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public AColor() { }
        public AColor(int id, string nombre)
        {
            _Id = id;
            _Nombre = nombre;
        }
        public DataTable MostrarColor()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARCOLOR";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertColor(AColor c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into COLOR values (AUMENTARCOLOR.NEXTVAL,'" + c._Nombre + "'," + 1 + ")";
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EditarColor(AColor c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update COLOR set NOMCOL='" + c._Nombre + "' WHERE IDCOL =" + c._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EliminarColor(AColor c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update COLOR set ESTADO = 0 WHERE IDCOL=" +c._Id;
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
