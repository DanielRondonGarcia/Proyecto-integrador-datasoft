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
    public class ATipoDocumento : ConexionOracle
    {
        private int id;
        private string nombre;

        public int _Id { get => id; set => id = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public ATipoDocumento() { }
        public ATipoDocumento(int id, string nombre)
        {
            _Id = id;
            _Nombre = nombre;
        }
        public DataTable MostrarTipoDocumento()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARTIPODOCUMENTO";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public void InsertTipoDocumento(ATipoDocumento td)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into TIPODOCUMENTO values (AUMENTARTIPODOCUMENTO.NEXTVAL,'" + td._Nombre +"',"+1+")";
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Guardado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se genero error guardaba "+ex.ToString());
            }
        }
        public void EditarTipoDocumento(ATipoDocumento td)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update TIPODOCUMENTO set NOMTIPDOC='" + td._Nombre + "' WHERE IDTIPDOC =" + td._Id;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se genero error mientras editaba "+ex.ToString());
            }
        }
    }
}
