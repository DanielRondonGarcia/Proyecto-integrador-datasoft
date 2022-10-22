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
    public partial class AjustesAdmin : Form
    {
        public AjustesAdmin()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Inicio I = new Inicio();

            //if (comboBox1=1)
            //{

            //}
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Ajustes.TipoDocumento td = new Ajustes.TipoDocumento();
            td.ShowDialog();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Ajustes.Color color = new Ajustes.Color();
            color.ShowDialog();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Ajustes.CategoriaServicio cs = new Ajustes.CategoriaServicio();
            cs.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Ajustes.Genero gen = new Ajustes.Genero();
            gen.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Ajustes.Categoria cat = new Ajustes.Categoria();
            cat.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Ajustes.Marca mar = new Ajustes.Marca();
            mar.ShowDialog();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Ajustes.Sucursal suc = new Ajustes.Sucursal();
            suc.ShowDialog();
        }
    }
}
