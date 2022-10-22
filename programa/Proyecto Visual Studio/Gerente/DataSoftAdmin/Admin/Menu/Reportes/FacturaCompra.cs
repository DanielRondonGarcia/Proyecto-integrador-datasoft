using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using AccesoOracle.AjustesData;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Gerente
{
    public partial class FacturaCompra : Form
    {
        public FacturaCompra()
        {
            InitializeComponent();
        }

        private void FacturaCompra_Load(object sender, EventArgs e)
        {
            mostrarcomprasreporte();
            sumar();

        }
         AReportes r = new AReportes();
        public void mostrarcomprasreporte()
        {
            dgReporteCompra.DataSource = r.MostrarRCompras();
        }
        double resultado = 0;
        public void sumar()
        {
            int filas = dgReporteCompra.RowCount;
            int con = 0;


            while (con != filas)
            {
                resultado = resultado + Convert.ToDouble(dgReporteCompra.Rows[con].Cells[4].Value);
                con++;
            }
            lblTotal.Text = resultado.ToString("C");
        }
    }
}
