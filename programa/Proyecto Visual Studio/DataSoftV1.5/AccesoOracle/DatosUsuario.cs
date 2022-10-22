using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using EnMemoria.Cache;
using System.Windows.Forms;

namespace AccesoOracle
{
    public class DatosUsuario : ConexionOracle
    {
        public bool Login(string correo, string PWD)
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
                using (var conexion = new OracleCommand())
                {
                    conexion.Connection = conectar;
                    conexion.CommandText = "SELECT * FROM USUARIO WHERE corusu = :correo AND passusu = :password and estado = 1";
                    conexion.Parameters.AddWithValue(":correo", correo);
                    conexion.Parameters.AddWithValue(":password", PWD);

                    OracleDataReader leer = conexion.ExecuteReader();

                    if (leer.HasRows)
                    {
                        while (leer.Read())
                        {
                            CacheUsuarioLog.id = leer.GetInt32(0);
                            CacheUsuarioLog.IdUser = leer.GetInt32(8);
                            CacheUsuarioLog.nombre = leer.GetString(1);
                            CacheUsuarioLog.Apellido = leer.GetString(2);
                            CacheUsuarioLog.Rol = leer.GetInt32(8);
                            CacheUsuarioLog.sucursal = leer.GetInt32(3);
                            if (leer.GetValue(13).Equals(DBNull.Value))

                            {

                            }
                            else
                            {
                                CacheUsuarioLog.imagen = (byte[])leer.GetValue(13);
                            }
                            AjustesData.AReportes r = new AjustesData.AReportes();
                            r.BorrarTemp();
                            using (var CON = new OracleCommand())
                            {
                                try
                                {
                                    CON.Connection = conectar;
                                    CON.CommandText = "INSERT INTO TEMP VALUES(AUMENTARTEMP.NEXTVAL," + leer.GetInt64(6) +",'"+ leer.GetInt32(8)+ "',1)";
                                    CON.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Mostrar Error   "+ex);
                                }


                            }
                            using (var asi = new OracleCommand())
                            {
                                asi.Connection = conectar;
                                asi.CommandText = "INSERT INTO REPORTES VALUES(AUMENTARREPORTE.NEXTVAL," + leer.GetInt64(6) + ", sysdate, NULL,1)";
                                asi.ExecuteNonQuery();
                            }

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
    }
}
