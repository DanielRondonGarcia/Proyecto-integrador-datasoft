using AccesoOracle.AjustesData;
using EnMemoria.Cache;
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

namespace Admin
{
    public partial class AjusteCuenta : Form
    {
        public AjusteCuenta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AjusteCuenta_Load(object sender, EventArgs e)
        {
            mostrarImagenUser();
        }
        public void mostrarImagenUser()
        {
            try
            {
                byte[] img = CacheUsuarioLog.imagen;
                MemoryStream ms = new MemoryStream(img);
                pbUsuario.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                pbUsuario.Image = null;
            }

        }

        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.InitialDirectory = "C:\\";
            buscar.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                pbUsuario.ImageLocation = buscar.FileName;
            }
            else
            {

                MessageBox.Show("Seleccione una imagen", "No Selecciono una Imagen");
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            AUsuarios usu = new AUsuarios();
            FormAdmin fa = new FormAdmin();
            Encriptacion.Encriptar encriptar = new Encriptacion.Encriptar();
            if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    usu._Id = Convert.ToInt32(CacheUsuarioLog.id);
                    usu._Nombre = txtNombre.Text;
                    usu._Apellido = txtApellido.Text;
                    usu._Telefono = txtTelefono.Text;
                    usu._Contraseña = encriptar._Encriptar(txtContraseña.Text);
                    usu._Correo = txtCorreo.Text;
                    usu._Imagen = CacheUsuarioLog.imagen =InsertarImagen(pbUsuario);
                    usu.Modificarse(usu);
                    limpiar();
                    mostrarImagenUser();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos");
                }
            }
            
            
        }
        public void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtContraseña.Clear();
        }
        public Byte[] InsertarImagen(PictureBox pbUsu)
        {
            MemoryStream me = new MemoryStream();
            pbUsu.Image.Save(me, pbUsu.Image.RawFormat);
            byte[] imagen = me.GetBuffer();
            return imagen;
        }

        private void txtTelefono_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Validacion.SoloNumeros(e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
