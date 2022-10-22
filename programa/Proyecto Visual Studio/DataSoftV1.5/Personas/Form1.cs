using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using System.Configuration;
using System.Runtime.InteropServices;
using EnMemoria.Cache;
using Admin;
using Encriptacion;
using Gerente;
using Operador;
namespace Personas
{
    public partial class Form1 : Form
    {
        //public OpenFileDialog op = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "CORREO")
            {
                txtCorreo.Text = "";
                
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "CORREO";
                lblError.Text = "";
            }
        }

        private void txtPWD_Enter(object sender, EventArgs e)
        {
            if (txtPWD.Text == "CONTRASEÑA")
            {
                txtPWD.Text = "";
                if (pbVisible.Visible.Equals(true)) {
                    txtPWD.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPWD.UseSystemPasswordChar = true;
                }              
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
            Encriptar en = new Encriptar();
           string pwd = en._Encriptar(txtPWD.Text);
            if (txtCorreo.Text != "CORREO"){
                if (txtPWD.Text != "CONTRASEÑA"){
                    ModeloUsuario mod = new ModeloUsuario();

                    var verificarLog = mod.LoginUser(txtCorreo.Text, pwd);
                    if (verificarLog== true)
                    {
                        //forma a la cual se va abrir
                        lblError.Visible = false;
                        switch (CacheUsuarioLog.IdUser)
                        {
                            case 1:
                                FormAdmin admin = new FormAdmin();
                                admin.Show();                              
                                admin.FormClosed += CerrarSesion;
                                this.Hide();
                                break;
                            case 2:
                                FormGerente gerente = new FormGerente();
                                
                                gerente.Show();
                                gerente.FormClosed += CerrarSesion;
                                this.Hide();
                                break;
                            case 3:
                                FormOperador operador = new FormOperador();
                                operador.Show();
                                operador.FormClosed += CerrarSesion;
                                this.Hide();
                                break;
                        }                  
                    }
                    else
                    {
                        mensajeError("¡Correo y/o contraseña incorrecta!");
                        txtPWD.Clear();
                        txtPWD.Focus();

                    }
                }
                else
                {
                    mensajeError("Por favor ingrese contraseña");
                }
            }
            else
            {
                mensajeError("Por favor ingrese correo");

            }
        }
        private void CerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtCorreo.Text = "CORREO";
            txtPWD.UseSystemPasswordChar = false;
            txtPWD.Text = "CONTRASEÑA";
            lblError.Visible = false;
            pbVisible.Visible = false;
            pbOculto.Visible = true;                          
            this.Show();
        }
        private void mensajeError(string mensaje)
        {
            lblError.Text = "    "+mensaje;
            lblError.Visible = true;

        }
        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pbOculto.Visible = false;
            pbVisible.Visible = true;
            txtPWD.UseSystemPasswordChar = false;

        }

        private void pbVisible_Click(object sender, EventArgs e)
        {
            pbOculto.Visible = true;
            pbVisible.Visible = false;
            
            if(txtPWD.Text == "CONTRASEÑA")
            {
                txtPWD.UseSystemPasswordChar = false;
            }
            else
            {
                txtPWD.UseSystemPasswordChar = true;
            }

        }
    }
}
