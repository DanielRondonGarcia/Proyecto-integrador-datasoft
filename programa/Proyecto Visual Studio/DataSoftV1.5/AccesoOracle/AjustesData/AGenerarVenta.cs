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
    public class AGenerarVenta:ConexionOracle
    {
        private int facturaventa, idproducto, cantidad;
        private int idCliente;
        private long iduser;
        private double valor;

        public int _Facturaventa { get => facturaventa; set => facturaventa = value; }
        public int _Idproducto { get => idproducto; set => idproducto = value; }
        public int _Cantidad { get => cantidad; set => cantidad = value; }
        public double _Valor { get => valor; set => valor = value; }
        public int _IdCliente { get => idCliente; set => idCliente = value; }
        public long _Iduser { get => iduser; set => iduser = value; }

        public AGenerarVenta() { }
        public AGenerarVenta(int fac,int id,int cantidad,double valor,int cliente,long iduser)
        {
            _Facturaventa = fac;
            _Idproducto = id;
            _Cantidad = cantidad;
            _Valor = valor;
            _IdCliente = cliente;
            _Iduser = iduser;
        }
       
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
        public void InsertarEncabezadoVenta(AGenerarVenta v)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into facturaventa values ("+v._Facturaventa+"," +v._IdCliente+ "," +v._Iduser+ ",sysdate)";
                        
                        conexion.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar factura" + ex.ToString());
            }
        }
        public void InsertarDetalleVenta(AGenerarVenta v)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into detalleventa values (" +v._Facturaventa + "," + v._Idproducto + "," + v._Cantidad + ",:precio)";
                        conexion.Parameters.Add(":precio", OracleType.Float);
                        conexion.Parameters[":precio"].Value = v._Valor;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar Venta " + ex.ToString());
            }
        }
        public int MostrarIDFactura()
        {
            using (var conectar = GetOracleConnection())
            {
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    try
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = ("select max(idfacven)+1 from facturaventa");
                        return Convert.ToInt32(conexion.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }
                }

            }
        }
    }
}
