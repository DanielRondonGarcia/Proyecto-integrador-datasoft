using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerente.Compras;
using Gerente.Menu;
using EnMemoria.Cache;
using Dominio.DAjustes;
namespace Gerente
{
    public partial class FormGerente : Form
    {
        public FormGerente()
        {
            InitializeComponent();
            mostrarImagenUser();
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

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirForm(new InicioAdmin());
            lbInfo.Text = "Inicio";
            toggle(sender);
            bunifuSeparator1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirForm(new InicioAdmin());
            lbInfo.Text = "Inicio";
            toggle(sender);
        }
        void toggle(object sender)
        {
            ButtonStart.selected = false;
            ButtonVentas.selected = false;
            ButtonStock.selected = false;
            ButtonBought.selected = false;
            ButtonReportes.selected = false;
            ButtonReportes.selected = false;
            Button7.selected = false;
            btnServicios.selected = false;
            btnCerrarSesion.selected = false;
            panelUsuario.BackColor = Color.FromArgb(32, 36, 48);
            //Separadores
            bunifuSeparator1.Visible = false;
            bunifuSeparator2.Visible = false;
            bunifuSeparator3.Visible = false;
            bunifuSeparator4.Visible = false;
            bunifuSeparator6.Visible = false;
            bunifuSeparator7.Visible = false;
            bunifuSeparator8.Visible = false;
            bunifuSeparator9.Visible = false;
            bunifuSeparator10.Visible = false;
            separadorS.Visible = false;

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            AbrirForm(new InicioAdmin());
            lbInfo.Text = "Inicio";
            toggle(sender);
            bunifuSeparator1.Visible = true;
        }

        private void ButtonVentas_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Ventas";
            AbrirForm(new VentasAdmin());
            toggle(sender);
            bunifuSeparator2.Visible = true;
        }

        private void ButtonStock_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Inventario";
            AbrirForm(new Gestor());
            toggle(sender);
            bunifuSeparator3.Visible = true;
        }

        private void ButtonBought_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Compras";
            AbrirForm(new ComprasAdmin());
            toggle(sender);
            bunifuSeparator4.Visible = true;
        }

        private void ButtonAsistencia_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Reportes";
            AbrirForm(new ReportesAdmin());
            toggle(sender);
            bunifuSeparator6.Visible = true;
        }

        private void ButtonCounts_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Cuentas";
            AbrirForm(new Cuentas());
            toggle(sender);
            bunifuSeparator7.Visible = true;
        }


        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Ajuste de Cuenta";
            AbrirForm(new AjusteCuenta());
            toggle(sender);
            panelUsuario.BackColor = Color.FromArgb(20, 32, 44);
            bunifuSeparator10.Visible = true;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            DReportes r = new DReportes();
            if (MessageBox.Show("seguro de cerrar?", "alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //tus codigos
                r.Cerrar_Asistencia();
                r.Borra_Temp();
                Application.Exit();
            }
            else
            {
                //tus codigos
            }
        }
        int LX, LY, SW, SH;

        private void Button7_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Ajustes";
            toggle(sender);
            AbrirForm(new AjustesAdmin());
            bunifuSeparator8.Visible = true;
        }

        private void ButtonStart_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro de cerrar la sesión?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DReportes r = new DReportes();
                btnCerrarSesion.Enabled = false;
                r.Borra_Temp();
                r.Cerrar_Asistencia();
                this.Close();
            }

        }
        private void cargarDatosUsuarioForm()
        {
            lblNombreUser.Text = CacheUsuarioLog.nombre +" "+ CacheUsuarioLog.Apellido;
            switch (CacheUsuarioLog.Rol)
            {
                case 1:
                    lblRol.Text = "ADMININISTRADOR";
                    break;
                case 2:
                    lblRol.Text = "GERENTE";
                    break;
                case 3:
                    lblRol.Text = "OPERADOR";
                    break;
            }

        }

        private void sidepanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FormAdmin_Load_1(object sender, EventArgs e)
        {
            cargarDatosUsuarioForm();
            MostrarFecha();
            mostrarImagenUser();
        }
        public void mostrarImagenUser()
        {
            try
            {
                byte[] img = CacheUsuarioLog.imagen;
                MemoryStream ms = new MemoryStream(img);
                pbUsuarioInicio.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                pbUsuarioInicio.Image = null;
            }
            
        }
        public void MostrarFecha()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void bunifuSeparator6_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator7_Load(object sender, EventArgs e)
        {

        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            lbInfo.Text = "Servicios";
            AbrirForm(new Servicios.GestorServicios());
            toggle(sender);
            separadorS.Visible = true;
        }

        private void panelUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(SW, SH);
            this.Location = new Point(LX, LY);
            iconmaximizar.Visible = true;
            iconrestaurar.Visible = false;
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X;
            LY = this.Location.Y;
            SW = this.Size.Width;
            SH = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconmaximizar.Visible = false;
            iconrestaurar.Visible = true;
        }
    }
}
