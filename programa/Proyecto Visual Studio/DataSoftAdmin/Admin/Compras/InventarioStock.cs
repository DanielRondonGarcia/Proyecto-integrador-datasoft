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

namespace Admin.Compras
{
    public partial class InvetarioStock : Form
    {
        public InvetarioStock()
        {
            InitializeComponent();
        }
        AStock s = new AStock();
        public void mostrarStock()
        {
            dgStock.DataSource = s.MostrarStock();
        }
        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            mostrarStock();
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgStock.Columns[e.ColumnIndex].Name =="Cantidad")
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {


                        if (Convert.ToInt32(e.Value) <= 60)
                        {
                            e.CellStyle.ForeColor = Color.Cyan;
                        }
                        if (Convert.ToInt32(e.Value) <= 30)
                        {
                            e.CellStyle.ForeColor = Color.Orange;
                        }
                        if (Convert.ToInt32(e.Value) <= 15)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }
                    }
                }
                catch(NullReferenceException ex)
                {
                    
                }
                
            }
        }
    }
}
