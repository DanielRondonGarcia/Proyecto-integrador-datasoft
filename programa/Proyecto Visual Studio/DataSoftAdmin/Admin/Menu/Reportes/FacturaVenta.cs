using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoOracle.AjustesData;
namespace Admin
{
    public partial class FacturaVenta : Form
    {
        public FacturaVenta()
        {
            InitializeComponent();
        }

        private void FacturaVenta_Load(object sender, EventArgs e)
        {
            mostrarventareporte();
            sumar();
        }
        AReportes r = new AReportes();
        public void mostrarventareporte()
        {
            dgReporteVentas.DataSource = r.MostrarRVentas();
        }
        double resultado = 0;
        public void sumar()
        {
            int filas = dgReporteVentas.RowCount;
            int con = 0;


            while (con != filas)
            {
                resultado = resultado + Convert.ToDouble(dgReporteVentas.Rows[con].Cells[4].Value);
                con++;
            }
            lblTotal.Text = resultado.ToString("C");
        }
    }
}
