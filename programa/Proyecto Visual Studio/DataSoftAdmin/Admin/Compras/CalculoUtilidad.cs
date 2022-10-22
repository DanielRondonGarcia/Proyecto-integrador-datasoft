using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin.Compras
{
    public partial class CalculoUtilidad : Form
    {
        public CalculoUtilidad()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void CalculoUtilidad_Load(object sender, EventArgs e)
        {
            lblUtilidad.Text = "0";
        }
        public void Calcular()
        {
            try
            {
                txtBImponible.Text = (Convert.ToDouble(txtValorVenta.Text) / (1 + Convert.ToDouble(txtIVA.Text) / 100)).ToString("N");
                txtIVAsinINC.Text = (Convert.ToDouble(txtValorVenta.Text) - Convert.ToDouble(txtBImponible.Text)).ToString("N");
                double temp = (Convert.ToDouble(txtCosto.Text) * 100) / Convert.ToDouble(txtBImponible.Text);
                lblUtilidad.Text = (100 - temp).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se generó un error");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtCosto.Text) < Convert.ToDouble(txtValorVenta.Text))
                {
                    Calcular();
                }
                else
                {
                    MessageBox.Show("No se generará ganancias");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se generó un error");
            }
            
            
        }
        //----------------------moneda--------------------------
        public static void moneda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length-1);
                v = Convert.ToDouble(n)/100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {

            }
        }
        //-----------------------------------------------------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBImponible.Clear();
            txtCosto.Clear();
            txtIVA.Clear();
            txtIVAsinINC.Clear();
            txtValorVenta.Clear();
            lblUtilidad.Text = "0";
        }


        private void txtValorVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Validacion.NumerosDecimales(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Validacion.NumerosDecimales(e);
        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Validacion.NumerosDecimales(e);
        }
    }
}
