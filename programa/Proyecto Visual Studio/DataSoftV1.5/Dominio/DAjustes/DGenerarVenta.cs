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
    public class DGenerarVenta
    {
        AGenerarVenta ven = new AGenerarVenta();
        public void Insertar_EncabezadoVenta(AGenerarVenta v)
        {
            ven.InsertarEncabezadoVenta(v);
        }
        public void Insertar_DetalleVenta(AGenerarVenta v)
        {
            ven.InsertarDetalleVenta(v);
        }
        public int Mostrar_IDFactura()
        {
            return ven.MostrarIDFactura();
        }
    }
}
