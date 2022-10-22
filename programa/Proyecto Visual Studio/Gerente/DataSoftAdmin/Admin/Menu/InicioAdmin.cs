using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerente
{
    public partial class InicioAdmin : Form
    {

        private int flag;
        public int Flag { get => flag; set => flag = value; }
        public InicioAdmin()
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
 
        private void Inicio_Load(object sender, EventArgs e)
        {
            //switch (hora)
            //{
            //    case 1:

            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    default:
            //        Console.WriteLine("No válido. Escoja 1, 2, o 3.");
            //        break;
            //}
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            LbHora.Text = DateTime.Now.ToLongTimeString();
            LbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void LbFecha_Click(object sender, EventArgs e)
        {

        }

        private void LbHora_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
