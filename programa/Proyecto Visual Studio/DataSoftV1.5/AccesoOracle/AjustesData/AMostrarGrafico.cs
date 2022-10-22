using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using AccesoOracle.AOModelos;
using System.Windows.Forms;
using EnMemoria.Cache;
using System.Collections;

namespace AccesoOracle.AjustesData
{
    public class AMostrarGrafico: ConexionOracle
    {
        public ArrayList cantidad { get; set; }
        public ArrayList fecha { get; set; }
        public void MostrarMarca()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;

                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT count(difacven), fecha FROM facturaventa where idusu="+CacheUsuarioLog.id+ "and fecha=sysdate";
                    leer = conexion.ExecuteReader();
                    while (leer.Read())
                    {
                        cantidad.Add(leer.GetInt32(0));
                        fecha.Add(leer.GetDateTime(1));
                    }
                }
            }
        }
    }
}
