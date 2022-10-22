using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerente.Ventas;
namespace Gerente
{
    public partial class VentasAdmin : Form
    {
        public VentasAdmin()
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
        private void VentasAdmin_Load(object sender, EventArgs e)
        {
            AbrirForm(new VentasClientasAdmin());
            toggle(sender);
            Separator1.Visible = true;
        }
        void toggle(object sender)
        {
            Separator1.Visible = false;
            Separator2.Visible = false;
            Separator3.Visible = false;
            separador4.Visible = false;
        }
        private void btnClienteAdmin_Click(object sender, EventArgs e)
        {
            AbrirForm(new VentasClientasAdmin());
            toggle(sender);
            Separator1.Visible = true;
        }

        private void btnGenerarCompra_Click(object sender, EventArgs e)
        {
            AbrirForm(new GenerarVentaAdmin());
            toggle(sender);
            Separator2.Visible = true;
        }


        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            AbrirForm(new Devoluciones());
            toggle(sender);
            Separator3.Visible = true;

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Separator1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Separator3_Load(object sender, EventArgs e)
        {

        }

        private void Separator2_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearProdCliente_Click(object sender, EventArgs e)
        {
            AbrirForm(new GenerarVentaServicio());
            toggle(sender);
            separador4.Visible = true;
        }
    }
}
