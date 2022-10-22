using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerente.Compras;

namespace Gerente.Compras
{
    public partial class ComprasAdmin : Form
    {
        public ComprasAdmin()
        {
            InitializeComponent();
        }
        private void AbrirForm(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        void toggle(object sender)
        {
            Separator1.Visible = false;
            Separator2.Visible = false;
        }
        private void ComprasAdmin_Load(object sender, EventArgs e)
        {
            AbrirForm(new ProveedoresAdmin());
            toggle(sender);
            Separator1.Visible = true;          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClienteAdmin_Click(object sender, EventArgs e)
        {
            AbrirForm(new ProveedoresAdmin());
            toggle(sender);
            Separator1.Visible = true;
            
        }

        private void btnGenerarCompra_Click(object sender, EventArgs e)
        {
            AbrirForm(new generarCompra());
            toggle(sender);
            Separator2.Visible = true;            
        }
    }
}
