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

namespace Gerente.Ventas
{
    public partial class AgregarServicio : Form
    {
        public AgregarServicio()
        {
            InitializeComponent();
        }
        ACrearServicios s = new ACrearServicios();
        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            dgStock.DataSource = s.MostrarServicios();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        double valor = 0, ivat;

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgStock.SelectedCells.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}
