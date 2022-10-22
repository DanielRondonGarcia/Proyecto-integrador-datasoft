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
    public class ACrearServicios:ConexionOracle
    {
        private int id;
        private string nombre;
        private double costo;
        private int idcategoria;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public double _Costo { get => costo; set => costo = value; }
        public int _Idcategoria { get => idcategoria; set => idcategoria = value; }

        public ACrearServicios() { }
        public ACrearServicios(int id, string nombre,double costo, int idcategoria)
        {
            _Id = id;
            _Nombre = nombre;
            _Costo = costo;
            _Idcategoria = idcategoria;
        }
        public DataTable MostrarServicios()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARSERVICIO";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertarServicios(ACrearServicios c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into SERVICIOS values (AUMENTARSERVICIO.NEXTVAL,'"+c._Nombre + "',:costo," +c._Idcategoria + "," + 1 + ")";
                        conexion.Parameters.Add(":costo", OracleType.Float);
                        conexion.Parameters[":costo"].Value = c._Costo;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Agregado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al guardar "+ex);
            }
        }
        public void EditarServicio(ACrearServicios s)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update servicios set nomser='" + s._Nombre + "',costser=:costo, idcatser=" + s._Idcategoria + " WHERE idser =" + s._Id;
                        conexion.Parameters.Add(":costo", OracleType.Float);
                        conexion.Parameters[":costo"].Value = s._Costo;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void EliminarServicios(ACrearServicios s)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update servicios set ESTADO = 0 WHERE idser=" + s._Id;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable ListarCategoriaServicio()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM categoriaservicios where estado=1 ORDER BY nomcat", conectar);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }
    }
}
