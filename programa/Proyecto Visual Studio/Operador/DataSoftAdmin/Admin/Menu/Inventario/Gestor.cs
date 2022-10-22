using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operador.Compras;

namespace Operador.Compras
{
    public partial class Gestor : Form
    {
        public Gestor()
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
            AbrirForm(new Stock());
            toggle(sender);
            Separator1.Visible = true;          
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            AbrirForm(new Stock());
            toggle(sender);
            Separator1.Visible = true;
        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            AbrirForm(new InventarioAdmin());
            toggle(sender);
            Separator2.Visible = true;
        }
    }
}
