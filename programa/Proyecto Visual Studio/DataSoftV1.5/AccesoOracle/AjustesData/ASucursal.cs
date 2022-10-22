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
    public class ASucursal : ConexionOracle
    {
        private int id;
        private string contacto;
        private string direccion;
        private int zona;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Direccion { get => direccion; set => direccion = value; }
        public int _Zona { get => zona; set => zona = value; }
        public string _Contacto { get => contacto; set => contacto = value; }
        public string _Nombre { get => nombre; set => nombre = value; }

        public ASucursal() { }
        public ASucursal(int id, string contacto, string direccion, int zona, string nombre)
        {
            _Id = id;
            _Contacto = contacto;
            _Direccion = direccion;
            _Zona = zona;
            _Nombre = nombre;
        }
        public DataTable MostrarSucursal()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARSUCURSAL";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertarSucursal(ASucursal s)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into SUCURSAL values (AUMENTARSUCURSAL.NEXTVAL,'" + s._Nombre + "','"+s._Contacto+"','"+s._Direccion+"',"+s._Zona+"," + 1 + ")";
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Guardado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar "+ex);
            }
        }
        public void EditarSucursal(ASucursal s)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update SUCURSAL set CONSUC='" + s._Contacto +",nombre="+s._Nombre+"',DIRSUC='"+s._Direccion+"',IDZONA="+s._Zona+" WHERE IDSUC =" + s._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EliminarSucursal(ASucursal s)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update SUCURSAL set ESTADO = 0 WHERE IDSUC=" + s._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable ListarDepartamento()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM DEPARTAMENTO ORDER BY NOMDEP", conectar);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }
        public DataTable ListarMunicipios(int id_dep)
        {
            using (var conectar = GetOracleConnection())
            {
                DataTable tabla = new DataTable();
                try
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {

                        conexion.Connection = conectar;
                        conexion.CommandText = ("SELECT * FROM MUNICIPIO WHERE IDDEP =:IDE ORDER BY NOMMUN");
                        conexion.Parameters.AddWithValue(":IDE", id_dep);
                        OracleDataAdapter da = new OracleDataAdapter(conexion);
                        da.Fill(tabla);
                        return tabla;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public DataTable ListarZona(int id_mun)
        {
            using (var conectar = GetOracleConnection())
            {
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM ZONA WHERE IDMUN =:IDMUNI ORDER BY NOMZONA";
                    conexion.Parameters.AddWithValue(":IDMUNI", id_mun);
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }

    }
}
