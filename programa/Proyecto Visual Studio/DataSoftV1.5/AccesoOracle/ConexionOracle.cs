using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace AccesoOracle
{
    public abstract class ConexionOracle
    {
        private readonly string conexionOracle;
        public ConexionOracle()
        {
            OracleConnectionStringBuilder = "Data Source=XE; PASSWORD= DATASOFTALPHA; User ID=DATASOFTALPHA;";
            
        }

        private string OracleConnectionStringBuilder { get; set; }
         
        protected OracleConnection GetOracleConnection()
        {
            return new OracleConnection(OracleConnectionStringBuilder);
        }
      
    }
}
