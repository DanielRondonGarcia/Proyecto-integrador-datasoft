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

namespace Operador.Servicios
{
    public partial class GestorServicios : Form
    {
        public GestorServicios()
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

        private void ComprasAdmin_Load(object sender, EventArgs e)
        {
            AbrirForm(new CrearServicio());

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
