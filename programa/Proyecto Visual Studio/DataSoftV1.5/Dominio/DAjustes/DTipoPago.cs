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
    public class DTipoPago
    {
        ATipoPago con = new ATipoPago();
        public DataTable Mostrar_TipoPago()
        {
            DataTable tabla = new DataTable();
            tabla = con.MostrarTipoPago();
            return tabla;
        }
        public DataTable Listar_Tipopago()
        {
            DataTable tabla = new DataTable();
            tabla = con.ListarTipoPago();
            return tabla;
        }
        public void Insertar_TipoPago(ATipoPago tp)
        {
            con.InsertTipoPago(tp);
        }
        public void Editar_TipoPago(ATipoPago tp)
        {
            con.EditarTipoPago(tp);
        }
    }
}
