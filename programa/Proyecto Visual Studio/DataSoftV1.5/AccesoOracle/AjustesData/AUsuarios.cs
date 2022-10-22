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
    public class AUsuarios : ConexionOracle
    {

        private int id;
        private string nombre;
        private string apellido;
        private int idSucursal;
        private long documento;
        private string contraseña;
        private int idTipDoc;
        private string telefono;
        private int idRol;
        private string correo;
        private int genero;
        private string direccion;
        private int idZona;
        private byte[] imagen;
        
      

        public string _Nombre { get => nombre; set => nombre = value; }
        public string _Apellido { get => apellido; set => apellido = value; }
        public int _IdSucursal { get => idSucursal; set => idSucursal = value; }
        public string _Contraseña { get => contraseña; set => contraseña = value; }
        public int _IdTipDoc { get => idTipDoc; set => idTipDoc = value; }
        public string _Telefono { get => telefono; set => telefono = value; }
        public int _IdRol { get => idRol; set => idRol = value; }
        public string _Correo { get => correo; set => correo = value; }
        public int _Genero { get => genero; set => genero = value; }
        public string _Direccion { get => direccion; set => direccion = value; }
        public int _IdZona { get => idZona; set => idZona = value; }
        
        public long _Documento { get => documento; set => documento = value; }
        public int _Id { get => id; set => id = value; }
        public byte[] _Imagen { get => imagen; set => imagen = value; }

        public AUsuarios() { }
        public AUsuarios(int id,string nombre, string contraseña, int tipdoc,long documento, string telefono, int rol, string correo, int genero, string direccion, int zona, byte[] imagen)
        {
            _Id = id;
            _Nombre = nombre;
            _Contraseña = contraseña;
            _IdTipDoc = tipdoc;
            _Documento = documento;
            _Telefono = telefono;
            _IdRol = rol;
            _Correo = correo;
            _Genero = genero;
            _Direccion = direccion;
            _IdZona = zona;
            _Imagen = imagen;
            
        }
        
        public DataTable MostrarUsuarios()
        {
            using (var conectar = GetOracleConnection())
            {
                DataTable tabla = new DataTable();
                conectar.Open();
                OracleDataAdapter ora = new OracleDataAdapter("select * from MOSTRARUSUARIOS", conectar);
                ora.Fill(tabla);
                return tabla;

            }
        }
        public DataTable MostrarUsuariosGerente()
        {
            using (var conectar = GetOracleConnection())
            {
                DataTable tabla = new DataTable();
                conectar.Open();
                OracleDataAdapter ora = new OracleDataAdapter("select * from MOSTRARUSUARIOSGERENTE", conectar);
                ora.Fill(tabla);
                return tabla;

            }
        }
        public void InsertUsuario(AUsuarios da)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "INSERT INTO USUARIO VALUES (AUMENTARUSUARIO.NEXTVAL,'"+da._Nombre+"','"+da._Apellido+"',"+da._IdSucursal+",'"+da._Contraseña+"',"+da._IdTipDoc+","+da._Documento+",'"+da._Telefono+"',"+da._IdRol+",'"+da._Correo+"',"+da._Genero+",'"+da._Direccion+"',"+da._IdZona+ ",:foto,"+1+")";
                            conexion.Parameters.Add(":foto", OracleType.Blob);
                            conexion.Parameters[":foto"].Value = da._Imagen;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Agregado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar un nuevo usuario");
            }
        }
        public void EditarUsuario(AUsuarios u)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update USUARIO set NOMUSU ='" + u._Nombre + "', APEUSU ='" + u._Apellido + "',IDSUC=" + u._IdSucursal + ", PASSUSU='" + u._Contraseña +"',IDTIPDOC ="+u._IdTipDoc+", DOCUSU=" +u._Documento+",TELUSU="+u._Telefono+", IDROL="+u._IdRol+",CORUSU='"+u._Correo+"', IDSEX="+u._Genero+", DIRUSU='"+u._Direccion+"',IDZONA="+u._IdZona+",FOTOUSU= :foto WHERE IDUSU ="+u._Id;
                        conexion.Parameters.Add(":foto", OracleType.Blob);
                        conexion.Parameters[":foto"].Value = u._Imagen;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error al editar los datos");
            }
        }
        public void Modificarse(AUsuarios u)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update USUARIO set NOMUSU ='" + u._Nombre + "', APEUSU ='" + u._Apellido + "',PASSUSU='" + u._Contraseña + "',TELUSU=" + u._Telefono + ",CORUSU='" + u._Correo + "',FOTOUSU= :foto WHERE IDUSU =" + u._Id;
                        conexion.Parameters.Add(":foto", OracleType.Blob);
                        conexion.Parameters[":foto"].Value = u._Imagen;
                        conexion.ExecuteNonQuery();
                        MessageBox.Show("Editado correctamente, estos datos se mostraran al volver a iniciar la seccion");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error al editar los datos");
            }
        }
        public void EliminarUsuario(AUsuarios e)
        {
            try
            {
                using (var conectar = GetOracleConnection())
                {
                    conectar.Open();
                    using (var conexion = new OracleCommand())
                    {
                        conexion.Connection = conectar;
                        conexion.CommandText = "update USUARIO set ESTADO = 0 WHERE IDUSU=" + e._Id;
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
        public DataTable FiltrarUsuario(string f)
        {
            using (var conectar = GetOracleConnection())
            {

                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "select * from mostrarusuarios where (DOCUMENTO) like('" + f + "%')";
                    conexion.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(conexion);
                    da.Fill(tabla);
                    return tabla;
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
        public DataTable ListarSucursal()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM SUCURSAL";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable ListarRol()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM ROLES";
                    leer = conexion.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }
        public DataTable ListarRolGerente()
        {
            using (var conectar = GetOracleConnection())
            {
                OracleDataReader leer;
                DataTable tabla = new DataTable();
                conectar.Open();
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM ROLES where idrol <>1 and idrol <>2";
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
                    conexion.CommandText = "SELECT * FROM SEXO";
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
                        conexion.CommandText = ("select mun.idmun from zona zo join municipio mun on zo.idmun = mun.idmun where zo.idzona = "+id_zona);            
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
        public string CantidadUsuario()
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
                string consulta = "SELECT COUNT(*) FROM USUARIO where estado = 1";
                cmd = new OracleCommand(consulta, conectar);
                Int32 cuenta = Convert.ToInt32(cmd.ExecuteScalar());

                return cuenta.ToString();

            }
        }
    }
   
}
