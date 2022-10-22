using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoOracle.AjustesData;
using Dominio.DAjustes;

namespace Gerente.Compras
{
    public partial class AgregarProducto : Form
    {
        DGenerarCompra con = new DGenerarCompra();
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void MostrarProductos()
        {
            
        }
        private void btnCrearNuevoProducto_Click(object sender, EventArgs e)
        {
            CrearProducto cp = new CrearProducto();
            cp.ShowDialog();
        }

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            dgGenerarCompra.DataSource = con.Mostrar_Productos();
        }
        
        private void dgGenerarCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgGenerarCompra.SelectedCells.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dgGenerarCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
