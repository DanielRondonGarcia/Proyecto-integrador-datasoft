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
using Dominio.DAjustes;

namespace Gerente.Ventas
{
    public partial class ModificarDescuento : Form
    {
        public ModificarDescuento()
        {
            InitializeComponent();
        }
        AStock s = new AStock();
        DGenerarCompra gc = new DGenerarCompra();
        AGenerarCompra agc = new AGenerarCompra();
        private int id;
        private double precio;
        public int Id { get => id; set => id = value; }
        public double Precio { get => precio; set => precio = value; }

        public void mostrarStock()
        {
            dgStockDescuento.DataSource = s.MostrarStock();
        }
        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            mostrarStock();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            GenerarVentaAdmin ga = new GenerarVentaAdmin();
            agc._Descuento = Convert.ToDouble(txtDescuento.Text);
            gc.Editar_Descuento(agc);
        }

        private void dgStock_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgStockDescuento.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgStockDescuento.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = dgStockDescuento.CurrentRow.Cells[2].Value.ToString();
            txtDescuento.Text = dgStockDescuento.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
