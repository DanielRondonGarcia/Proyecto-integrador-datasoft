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
    public class ACliente : ConexionOracle
    {
        
        public DataTable MostrarClientes()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM MOSTRARCLIENTES";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }

        public bool VerificarClientes(AOCliente c)
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM USUARIO WHERE DOCUSU="+c._NDocumento1+"AND ESTADO = 1";
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
        }

       

        public void InsertCliente(AOCliente c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "insert into CLIENTE values (AUMENTARCLIENTE.NEXTVAL,'" +c._Nombre+"','"+ c._Apellido+"',"+c._TipoDocumento+","+c._NDocumento1+"," + c._Telefono + ",'" + c._Correo + "'," + c._Sexo + ",'" + c._Direccion + "'," +c._Zona+","+1+")";
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Agregado Correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El número de documento ya se encuantra registrado, vuelva a ingresar los datos","Error al registrar",MessageBoxButtons.OK,MessageBoxIcon.Error);
                CacheUsuarioLog.cedulaC = 0;
                CacheUsuarioLog.nombreC = "";
                CacheUsuarioLog.apellidoC = "";

            }
        }
        public void EditarCliente(AOCliente c)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update CLIENTE set NOMCLI='" + c._Nombre + "', APECLI='" + c._Apellido + "',IDTIPDOC=" + c._TipoDocumento + ",DOCCLI=" + c._NDocumento1 + ",TELCLI=" + c._Telefono + ", CORCLI='" + c._Correo + "',IDSEX=" + c._Sexo + ",DIRCLI='" + c._Direccion + "',IDZONA=" + c._Zona + " WHERE IDCLI =" + c._ID1;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Número de documento existente");
            }
        }
        public void EliminarCliente(int IDCLIENTE)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update CLIENTE set ESTADO = 0 WHERE IDCLI="+IDCLIENTE;
                        conexion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public int ConsultaIDCliente()
        {
            using (var conectar = GetOracleConnection())
            {
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    try
                    {

                        conexion.Connection = conectar;
                        conexion.CommandText = ("select max(idcli)+1 from cliente");
                        return Convert.ToInt32(conexion.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Error de Cnsultar ID");
                        return 0;
                    }
                }

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
        public DataTable ListarSexo()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM SEXO ORDER BY NOMSEX";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
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
        public DataTable FiltrarCliente(string doc)
        {
            using (var conectar = GetOracleConnection())
            {
                
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "select * from CLIENTE where DOCCLI like('"+doc+"%') AND ESTADO = 1";
                    conexion.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable FiltrarClienteID(string id)
        {
            using (var conectar = GetOracleConnection())
            {

                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "select * from CLIENTE where IDCLI like('" + id + "%') AND ESTADO = 1";
                    conexion.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public string CantidadClientes()
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
                string consulta = "SELECT COUNT(*) FROM CLIENTE where estado = 1";
                cmd = new OracleCommand(consulta, conectar);
                Int32 cuenta = Convert.ToInt32(cmd.ExecuteScalar());

                    return cuenta.ToString();
                
                }
        }
        //Invertir combobox-----------------------------------------------------------------
        public string IListarMunicipios(int id_zona)
        {
            using (var conectar = GetOracleConnection())
            {
                try
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {

                        conexion.Connection = conectar;
                        conexion.CommandText = ("select mun.idmun from zona zo join municipio mun on zo.idmun = mun.idmun where zo.idzona = " + id_zona);
                        return conexion.ExecuteScalar().ToString(); ;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public string IListarDepartamento(int id_mun)
        {
            using (var conectar = GetOracleConnection())
            {
                try
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {

                        conexion.Connection = conectar;
                        conexion.CommandText = ("select dep.iddep from departamento dep join municipio mun on mun.iddep = dep.iddep where mun.idmun = " + id_mun);
                        return conexion.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}

    

