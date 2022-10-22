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
    public class AProveedor: ConexionOracle
    {
        private int id;
        private string nombre;
        private int tipoDocumento;
        private long documento;
        private string correo;
        private long telefono;
        private string url;
        private string filtro;

        public string _Nombre { get => nombre; set => nombre = value; }
        public int _TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public long _Documento { get => documento; set => documento = value; }
        public string _Correo { get => correo; set => correo = value; }
        public long _Telefono { get => telefono; set => telefono = value; }
        public string _Url { get => url; set => url = value; }
        public int _Id { get => id; set => id = value; }
        public string _Filtro { get => filtro; set => filtro = value; }

        public AProveedor() { }
        public AProveedor(int id, string nombre, int tipodoc, long doc, string correo, long tel, string url, string filtro)
        {
            _Id = id;
            _Nombre = nombre;
            _TipoDocumento = tipodoc;
            _Documento = doc;
            _Correo = correo;
            _Telefono = tel;
            _Url = url;
            _Filtro = filtro;
        }
        public DataTable MostrarProveedor()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARPROVEEDOR";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        /*/public bool VerificarProveedor(AProveedor p)
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM PROVEEDOR WHERE DOCPROV=" + p._Documento + "AND ESTADO = 1";
                    leer = conexion.ExecuteReader();
                    if (leer.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }*/
        public void InsertarProveedor(AProveedor p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into PROVEEDOR values (AUMENTARPROVEEDOR.NEXTVAL,'" + p._Nombre + "',"+ p._Documento + ",'" +p._Correo+ "'," +p._Telefono+ ",'" + p._Url+ "',"+ 1 +")";
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Guardado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar");
            }
        }
        public void EditarProveedor(AProveedor p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update PROVEEDOR set NOMPRO='" + p._Nombre + "',nit=" + p._Documento + ",CORPRO='" + p._Correo+ "',TELPRO=" +p._Telefono + ", URLPRO='" + p._Url + "' WHERE IDPRO =" +p._Id;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar  "+ex);
            }
        }
        public void EliminarProveedor(AProveedor p)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update PROVEEDOR set ESTADO = 0 WHERE IDPRO=" + p._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable ListarTipoDocumento()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM TIPODOCUMENTO";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable FiltrarProveedor(AProveedor p)
        {
            using (var conectar = GetOracleConnection())
            {

                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "select * from PROVEEDOR where nit like('" + p._Filtro + "%') AND ESTADO = 1";
                    conexion.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public string CantidadProveedor()
        {
            using (var conectar = GetOracleConnection())
            {
                try
                {
                    conectar.Open();
                }
                catch (Exception ex)
                {

                }
                OracleCommand cmd;
                string consulta = "SELECT COUNT(*) FROM PROVEEDOR where estado = 1";
                cmd = new OracleCommand(consulta, conectar);
                Int32 cuenta = Convert.ToInt32(cmd.ExecuteScalar());

                return cuenta.ToString();

            }
        }
    }
}
