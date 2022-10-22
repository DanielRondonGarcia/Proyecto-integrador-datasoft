using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using AccesoOracle.AOModelos;
using System.Windows.Forms;

namespace AccesoOracle.AjustesData
{
    public class AProductos : ConexionOracle
    {
        private int id;
        private string nombre;
        private int marca;
        private int categoria;
        private int color;
        private long codigo;
        private string modelo;
        private string detalle;
        private string almacenamiento;
        private double precio;
        private double utilidad;
        private double iva;
        private byte[] imagen;

        public string _Nombre { get => nombre; set => nombre = value; }
        public int _Marca { get => marca; set => marca = value; }
        public int _Categoria { get => categoria; set => categoria = value; }
        public int _Color { get => color; set => color = value; }
        public double _Precio { get => precio; set => precio = value; }
        public byte[] _Imagen { get => imagen; set => imagen = value; }
        public int _Id { get => id; set => id = value; }
        public long _Codigo { get => codigo; set => codigo = value; }
        public string _Modelo { get => modelo; set => modelo = value; }
        public string _Detalle { get => detalle; set => detalle = value; }
        public string _Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
        public double _Utilidad { get => utilidad; set => utilidad = value; }
        public double _Iva { get => iva; set => iva = value; }

        public AProductos() { }
        public AProductos(int id, string nombre, int marca, int categoria, int color, long codigo, string modelo, string detalle, string almacenamiento, double precio,double utilidad,double iva, byte[] imagen)
        {
            _Id = id;
            _Nombre = nombre;
            _Marca = marca;
            _Categoria = categoria; 
            _Color = color;
            _Codigo = codigo;
            _Modelo = modelo;
            _Detalle = detalle;
            _Almacenamiento = almacenamiento;
            _Precio = precio;
            _Utilidad = utilidad;
            _Iva = iva;
            _Imagen = imagen;            
        }

        public void InsertarProducto(AProductos p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "INSERT INTO PRODUCTO VALUES (AUMENTARPRODUCTO.NEXTVAL,'" + p._Nombre + "'," + p._Marca + "," + p._Categoria + "," + p._Color + "," + p._Codigo + ",upper('" + p._Modelo + "'),'" + p._Detalle + "','" + p._Almacenamiento + "',:precio,:utilidad,:iva,:image," + 1 + ")";
                        conexion.Parameters.Add(":image", OracleType.Blob);
                        conexion.Parameters[":image"].Value = p._Imagen;                      
                        conexion.Parameters.Add(":precio", OracleType.Float);
                        conexion.Parameters[":precio"].Value = p._Precio;
                        conexion.Parameters.Add(":utilidad", OracleType.Float);
                        conexion.Parameters[":utilidad"].Value = p._Utilidad;
                        conexion.Parameters.Add(":iva", OracleType.Float);
                        conexion.Parameters[":iva"].Value = p._Iva;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Agregado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar un nuevo producto " + ex.ToString());
            }
        }
        public void EditarProducto(AProductos p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update producto set NOMPROD ='" + p._Nombre + "', idmar =" + p._Marca + ",idcat=" + p._Categoria + ", idcol=" + p._Color + ",codbarraprod =" + p._Codigo + ", modeloprod=upper('" + p._Modelo + "'),detalleprod= '" + p._Detalle + "', almaceprod='" + p._Almacenamiento + "',costprod =:precio ,utilidad=:utilidad,iva=:iva, imageprod = :image WHERE idprod=" + p._Id;
                        conexion.Parameters.Add(":image", OracleType.Blob);
                        conexion.Parameters[":image"].Value = p._Imagen;
                        conexion.Parameters.Add(":precio", OracleType.Float);
                        conexion.Parameters[":precio"].Value = p._Precio;
                        conexion.Parameters.Add(":utilidad", OracleType.Float);
                        conexion.Parameters[":utilidad"].Value = p._Utilidad;
                        conexion.Parameters.Add(":iva", OracleType.Float);
                        conexion.Parameters[":iva"].Value = p._Iva;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar los datos " + ex.ToString());
            }
        }
        public void EliminarProducto(AProductos p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update producto set ESTADO = 0 WHERE idprod=" + p._Id;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Eliminado Correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar");
            }
        }
        public DataTable FiltrarProducto(string fp)
        {
            using (var conectar = GetOracleConnection())
            {

                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "select * from mostrarproductos where upper(modelo) like upper('%" + fp + "%')";
                    conexion.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }

        public DataTable MostrarInventario()
        {
            //conexion con oracle llamando a la capa accesoOracle
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARPRODUCTOS";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable ListarCategoria()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM CATEGORIA";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable ListarColor()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM COLOR";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable ListarMarca()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MARCA";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
    }
}
