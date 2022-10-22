using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.DAjustes;
namespace Admin
{
    public partial class BuscarClienteFiltro : Form
    {
        DClientes cli = new DClientes();
        public BuscarClienteFiltro()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void MostrarCliente()
        {
            dgCliente.DataSource = cli.Mostrar_Clientes();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BuscarClienteFiltro_Load(object sender, EventArgs e)
        {
            MostrarCliente();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbCedula.Checked == true) {
                string dato = txtFiltrar.Text;
                dgCliente.DataSource = cli.Filtrar_Cliente(dato);
            }
            if (rbIDCliente.Checked == true)
            {
                string dato = txtFiltrar.Text;
                dgCliente.DataSource = cli.Filtrar_ClienteID(dato);
            }

            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila");
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
