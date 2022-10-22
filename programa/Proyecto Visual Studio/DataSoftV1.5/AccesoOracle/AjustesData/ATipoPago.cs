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
    public class ATipoPago : ConexionOracle
    {
        private string nombre;
        private int id;
        public string _Nombre { get => nombre; set => nombre = value; }
        public int _Id { get => id; set => id = value; }

        public ATipoPago() { }
        public ATipoPago(string nombre, int id)
        {
            _Nombre = nombre;
            _Id = id;
        }
        public DataTable MostrarTipoPago()
        {
           using (var conectar = GetOracleConnection())
          {
                OracleDataReader leer;
                DataTable tabla = new DataTable();

                conectar.Open();


               using (var conexion = new OracleCommand())
               {
               conexion.Connection = conectar;
                     conexion.CommandText = "SELECT * FROM MOSTRARTIPOPAGO";
                     leer = conexion.ExecuteReader();
                     tabla.Load(leer);
                     return tabla;
               }
           }                                 
        }
        public DataTable ListarTipoPago()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();

                conectar.Open();


                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM tipopago";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertTipoPago(ATipoPago tp)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into TIPOPAGO values (AUMENTARTIPOPAGO.NEXTVAL,'"+tp._Nombre+"',"+1+")";
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EditarTipoPago(ATipoPago tp)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update TIPOPAGO set NOMTIPPAGO='" + tp._Nombre + "' WHERE IDTIPPAGO =" + tp._Id;
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
