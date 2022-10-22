using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using Dominio;

namespace DataSoft1._0
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                lblError.Text = "";
            }
        }

        private void txtPWD_Enter(object sender, EventArgs e)
        {
            if (txtPWD.Text == "CONTRASEÑA")
            {
                txtPWD.Text = "";
                txtPWD.UseSystemPasswordChar = true;
            }
            
        }

        private void txtPWD_Leave(object sender, EventArgs e)
        {
            if (txtPWD.Text == "")
            {
                txtPWD.Text = "CONTRASEÑA";
                txtPWD.UseSystemPasswordChar = false;
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {        
            

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
