using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoOracle;
using AccesoOracle.AOModelos;
using AccesoOracle.AjustesData;


namespace Dominio.DAjustes
{
    public class DReportes
    {
        AReportes r = new AReportes();
        public DataTable Mostrar_Auditoria()
        {
            DataTable tabla = new DataTable();
            tabla = r.MostrarAuditoria();
            return tabla;
        }
        public DataTable Mostrar_Asistencia()
        {
            DataTable tabla = new DataTable();
            tabla = r.MostrarAsistencia();
            return tabla;
        }
        public void Borra_Temp()
        {
            r.BorrarTemp();
        }
        public void Cerrar_Asistencia()
        {
            r.CerrarAsistencia();
        }
    }
}
