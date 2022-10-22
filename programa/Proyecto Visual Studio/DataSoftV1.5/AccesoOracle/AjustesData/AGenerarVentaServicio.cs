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
    public class AGenerarVentaServicio : ConexionOracle
    {
        private int facturaventa;
        private int idServicio;
        private string detalle;
        private int idCliente;
        private long iduser;
        private double valor;

        public int _Facturaventa { get => facturaventa; set => facturaventa = value; }
        public double _Valor { get => valor; set => valor = value; }
        public int _IdCliente { get => idCliente; set => idCliente = value; }
        public long _Iduser { get => iduser; set => iduser = value; }
        public int _IdServicio { get => idServicio; set => idServicio = value; }
        public string _Detalle { get => detalle; set => detalle = value; }

        public AGenerarVentaServicio() { }
        public AGenerarVentaServicio(int fac, int id,string detalle, double valor, int cliente, long iduser)
        {
            _Facturaventa = fac;
            _IdCliente = id;
            _Detalle = detalle;
            _Valor = valor;
            _IdCliente = cliente;
            _Iduser = iduser;
        }

        public void InsertarEncabezadoVenta(AGenerarVentaServicio v)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into facturaventa values (" + v._Facturaventa + "," + v._IdCliente + "," + v._Iduser + ",sysdate)";

                        conexion.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar factura" + ex.ToString());
            }
        }
        public void InsertarDetalleVenta(AGenerarVentaServicio v)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into detalleventaservicio values (" + v._Facturaventa + "," + v._IdServicio+ ",'" + v._Detalle + "',:precio)";
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
