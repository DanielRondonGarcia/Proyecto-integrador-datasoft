using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using AccesoOracle.AOModelos;
using EnMemoria.Cache;
using System.Windows.Forms;

namespace AccesoOracle.AjustesData
{
    public class AStock :ConexionOracle
    {
        public DataTable MostrarStock()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARSTOCK";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
    }
}
