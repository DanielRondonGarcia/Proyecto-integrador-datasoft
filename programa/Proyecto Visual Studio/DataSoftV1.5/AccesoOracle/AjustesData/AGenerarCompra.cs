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
    public class AGenerarCompra:ConexionOracle
    {

        private int idfactura;
        private int idproveedor;
        private int idusuario;
        private int idproducto;
        private int cantidad;
        private double valor;
        private double iva;
        private double descuento;

        public int _Idfactura { get => idfactura; set => idfactura = value; }
        public int _Idproveedor { get => idproveedor; set => idproveedor = value; }
        public int _Idusuario { get => idusuario; set => idusuario = value; }
        public int _Idproducto { get => idproducto; set => idproducto = value; }
        public int _Cantidad { get => cantidad; set => cantidad = value; }
        public double _Valor { get => valor; set => valor = value; }
        public double _Iva { get => iva; set => iva = value; }
        public double _Descuento { get => descuento; set => descuento = value; }

        public AGenerarCompra() { }
        public AGenerarCompra(int id, int proveedor, int usuario, int producto, int cantidad, double valor, double iva, double descuento)
        {
            _Idfactura = id;
            _Idproveedor = proveedor;
            _Idusuario = usuario;
            _Idproducto = producto;
            _Cantidad = cantidad;
            _Valor = valor;
            _Iva = iva;
            _Descuento = descuento;
        }
        public void InsertarEncabezado(AGenerarCompra c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into facturacompra values ("+c._Idfactura+"," + c._Idproveedor + "," + c._Idusuario +",sysdate"+")";

                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar factura"+ex.ToString());
            }
        }
        public void EditarDescuento(AGenerarCompra c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update detallecompra set DESCUENTO =:descuento where idprod="+c._Idproducto+"and valor=:valor";
                        conexion.Parameters.Add(":descuento", OracleType.Float);
                        conexion.Parameters[":descuento"].Value = c._Descuento;
                        conexion.Parameters.Add(":valor", OracleType.Float);
                        conexion.Parameters[":valor"].Value = c._Valor;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar el Descuento");
            }
        }
        public void InsertarDetalle(AGenerarCompra c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into detallecompra values (" + c._Idfactura + "," + c._Idproducto + "," + c._Cantidad + ",:precio,:iva,0)";
                        conexion.Parameters.Add(":precio", OracleType.Float);
                        conexion.Parameters[":precio"].Value = c._Valor;
                        conexion.Parameters.Add(":iva", OracleType.Float);
                        conexion.Parameters[":iva"].Value = c._Iva;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar compra "+ex.ToString());
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
                        conexion.CommandText = ("select max(idfaccom)+1 from facturacompra");
                        return Convert.ToInt32(conexion.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }
                }

            }
        }
        public DataTable ListarProveedor()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM PROVEEDOR where estado=1";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable MostrarProductos()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM PRODUCTO";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
    }
}
