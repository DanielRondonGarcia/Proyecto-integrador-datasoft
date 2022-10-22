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
using AccesoOracle.AjustesData;
using Dominio.DAjustes;
using Validar;

namespace Operador
{
    public partial class InventarioAdmin : Form
    {
        DProducto con = new DProducto();
        public InventarioAdmin()
        {
            InitializeComponent();
        }
        public bool estado = false;
        private void Inventario_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            ListarMarca();
            ListarCategoria();
            ListarColor();
        }
        private void MostrarProductos()
        {
            dgProducto.RowTemplate.Height = 45;
            dgProducto.DataSource = con.MostrarProducto();
            DataGridViewImageColumn im = new DataGridViewImageColumn();
            im = (DataGridViewImageColumn)dgProducto.Columns[12];
            im.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgProducto.Refresh();
        }
        //--------------------insertar imagen-----------------------------------------------
        public Byte[] InsertarImagen(PictureBox pbProd)
        {
            MemoryStream me = new MemoryStream();
            pbProd.Image.Save(me, pbProd.Image.RawFormat);
            byte[] imagen = me.GetBuffer();
            return imagen;
        }
        //-----------------------------------------------------------------------------------------     
        private void EliminarProducto(AProductos pro)
        {
            con.Eliminar_Producto(pro);
        }
        private void ListarMarca()
        {
            cbMarca.DataSource = con.Listar_Marca();
            cbMarca.DisplayMember = "NOMMAR";
            cbMarca.ValueMember = "IDMAR";
        }
        private void ListarCategoria()
        {
            cbCategoria.DataSource = con.Listar_Categoria();
            cbCategoria.DisplayMember = "NOMCAT";
            cbCategoria.ValueMember = "IDCAT";
        }
        private void ListarColor()
        {
            cbColor.DataSource = con.Listar_Color();
            cbColor.DisplayMember = "NOMCOL";
            cbColor.ValueMember = "IDCOL";
        }
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void ReiniciarPB(PictureBox pb)
        {
            pb.Image = Properties.Resources.icons8_foto_filled_500__1_;
        }

        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtModelo.Clear();
            txtPrecio.Clear();
            txtAlmacenamiento.Clear();
            txtDetalle.Clear();
            ListarCategoria();
            ListarColor();
            ListarMarca();
            txtUtilidad.Clear();
            txtIVA.Clear();
            ReiniciarPB(pbProducto);
        }
        public bool ValidarCampos()
        {
            bool error = true;
            if (txtNombre.Text.Trim() == "")
            {
                ErrorP.SetError(txtNombre, "Introduce nombre");
                error = false;
            }
            if (txtCodigo.Text.Trim() == "")
            {
                ErrorP.SetError(txtCodigo, "Introduce código");
                error = false;
            }
            if (txtModelo.Text.Trim() == "")
            {
                ErrorP.SetError(txtModelo, "Introduce serial");
                error = false;
            }
            if (txtPrecio.Text.Trim() == "")
            {
                ErrorP.SetError(txtPrecio, "Introduce el precio");
                error = false;
            }
            return error;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AProductos prod = new AProductos();
            if (ValidarCampos())
            {
                ErrorP.Clear();
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            prod._Nombre = txtNombre.Text;
                            prod._Categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                            prod._Marca = Convert.ToInt32(cbMarca.SelectedValue);
                            prod._Color = Convert.ToInt32(cbColor.SelectedValue);
                            prod._Codigo = Convert.ToInt64(txtCodigo.Text);
                            prod._Modelo = txtModelo.Text;
                            prod._Detalle = txtDetalle.Text;
                            prod._Almacenamiento = txtAlmacenamiento.Text;
                            prod._Precio = Convert.ToDouble(txtPrecio.Text);
                            prod._Utilidad = Convert.ToDouble(txtUtilidad.Text);
                            prod._Iva = Convert.ToDouble(txtIVA.Text);
                            prod._Imagen = InsertarImagen(pbProducto);
                            con.Insert_Producto(prod);
                            MostrarProductos();
                            limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo guardar los datos   " + ex);
                        }
                    }
                }
                else
                {
                    //tus codigos
                }

                if (estado == true)
                {
                    if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            prod._Id = Convert.ToInt32(txtID.Text);
                            prod._Nombre = txtNombre.Text;
                            prod._Categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                            prod._Marca = Convert.ToInt32(cbMarca.SelectedValue);
                            prod._Color = Convert.ToInt32(cbColor.SelectedValue);
                            prod._Codigo = Convert.ToInt32(txtCodigo.Text);
                            prod._Modelo = txtModelo.Text;
                            prod._Detalle = txtDetalle.Text;
                            prod._Almacenamiento = txtAlmacenamiento.Text;
                            prod._Precio = Convert.ToDouble(txtPrecio.Text);
                            prod._Utilidad = Convert.ToDouble(txtUtilidad.Text);
                            prod._Iva = Convert.ToDouble(txtIVA.Text);
                            prod._Imagen = InsertarImagen(pbProducto);
                            con.Editar_Producto(prod);
                            limpiar();
                            MostrarProductos();
                            btnCancelarEdicion.Visible = false;
                            btnLimpiar.Visible = true;
                            estado = false;
                            txtID.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo editar los datos por error: " + ex.ToString());
                        }
                    }
                }
                else
                {
                    //tus codigos
                }
            }
            else
            {
                MessageBox.Show("Dejó datos obligatorios sin llenar");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProducto.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgProducto.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgProducto.CurrentRow.Cells[1].Value.ToString();
                    cbMarca.SelectedValue = dgProducto.CurrentRow.Cells[2].Value.ToString();
                    cbCategoria.SelectedValue = dgProducto.CurrentRow.Cells[3].Value.ToString();
                    cbColor.SelectedValue = dgProducto.CurrentRow.Cells[4].Value.ToString();
                    txtModelo.Text = dgProducto.CurrentRow.Cells[5].Value.ToString();
                    txtDetalle.Text = dgProducto.CurrentRow.Cells[6].Value.ToString();
                    txtAlmacenamiento.Text = dgProducto.CurrentRow.Cells[7].Value.ToString();
                    txtCodigo.Text = dgProducto.CurrentRow.Cells[8].Value.ToString();
                    txtPrecio.Text = dgProducto.CurrentRow.Cells[9].Value.ToString();
                    txtUtilidad.Text = dgProducto.CurrentRow.Cells[10].Value.ToString();
                    txtIVA.Text = dgProducto.CurrentRow.Cells[11].Value.ToString();
                    //-----------------------------------------imagen-------------------------------------------
                    byte[] img = (byte[])dgProducto.CurrentRow.Cells[12].Value;
                    MemoryStream ms = new MemoryStream(img);
                    pbProducto.Image = Image.FromStream(ms);
                    //------------------------------------------------------------------------------------------             

                    btnCancelarEdicion.Visible = true;
                    btnLimpiar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mientras editaba se genero error: " + ex.ToString());
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.InitialDirectory = "C:\\";
            buscar.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                pbProducto.ImageLocation = buscar.FileName;
            }
            else
            {
                MessageBox.Show("Seleccione una imagen", "No Selecciono una Imagen");
            }
        }
        private string EliminarAlerta()
        {
            string name = dgProducto.CurrentRow.Cells[1].Value.ToString();
            return name;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AProductos pro = new AProductos();
            if (dgProducto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto " + EliminarAlerta() + "?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pro._Id = Convert.ToInt32(dgProducto.CurrentRow.Cells[0].Value.ToString());
                    EliminarProducto(pro);
                    MostrarProductos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
            btnLimpiar.Visible = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            string dato = txtFiltro.Text;
            dgProducto.RowTemplate.Height = 45;
            dgProducto.DataSource = con.Filtrar_Producto(dato);
            DataGridViewImageColumn im = new DataGridViewImageColumn();
            im = (DataGridViewImageColumn)dgProducto.Columns[12];
            im.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgProducto.Refresh();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                ErrorP.SetError(txtNombre, "");
            }
            else
            {
                ErrorP.SetError(txtNombre, "Introduce nombre");
            }
        }

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                ErrorP.SetError(txtCodigo, "");
            }
            else
            {
                ErrorP.SetError(txtCodigo, "Introduce código");
            }
        }

        private void txtSerial_Validated(object sender, EventArgs e)
        {
            if (txtModelo.Text.Length > 0)
            {
                ErrorP.SetError(txtModelo, "");
            }
            else
            {
                ErrorP.SetError(txtModelo, "Introduce un serial");
            }
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            if (txtPrecio.Text.Length > 0)
            {
                ErrorP.SetError(txtPrecio, "");
            }
            else
            {
                ErrorP.SetError(txtPrecio, "Introduce el precio");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }
    }
}
