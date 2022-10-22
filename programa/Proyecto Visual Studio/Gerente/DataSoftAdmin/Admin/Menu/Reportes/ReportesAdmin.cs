using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerente.Menu.Reportes;
namespace Gerente
{
    public partial class ReportesAdmin : Form
    {
        public ReportesAdmin()
        {
            InitializeComponent();
        }
        public void AbrirForm(object formhija)
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
            Separator3.Visible = false;
            Separator4.Visible = false;
        }

        private void btnClienteAdmin_Click(object sender, EventArgs e)
        {
            AbrirForm(new FacturaVenta());
            toggle(sender);
            Separator1.Visible = true;
            

        }

        private void btnGenerarCompra_Click(object sender, EventArgs e)
        {
            AbrirForm(new FacturaCompra());
            toggle(sender);
            Separator2.Visible = true;
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirForm(new FacturaDevoluciones());
            toggle(sender);
            Separator3.Visible = true;
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AbrirForm(new Asistencia());
            toggle(sender);
            Separator4.Visible = true;
        }

        private void ReportesAdmin_Load(object sender, EventArgs e)
        {
            AbrirForm(new FacturaVenta());
            toggle(sender);
            Separator1.Visible = true;
        }

        private void Separator1_Load(object sender, EventArgs e)
        {

        }


    }
}
