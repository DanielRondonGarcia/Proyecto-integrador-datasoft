using AccesoOracle.AjustesData;
using Dominio.DAjustes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Validar;
using Dominio.DAjustes;
namespace Gerente
{
    public partial class CrearServicio : Form
    {
        AGenerarCompra ag = new AGenerarCompra();
        ACrearServicios s = new ACrearServicios();
        public CrearServicio()
        {
            InitializeComponent();
        }
        public bool estado = false;
        
        private void Cuentas_Load(object sender, EventArgs e)
        {
            MostrarServicios();
            ContarProductos();
            listarCategoria();
        }
        private void listarCategoria()
        {
            cbCategoria.DataSource = s.ListarCategoriaServicio();
            cbCategoria.DisplayMember = "nomcat";
            cbCategoria.ValueMember = "idcatser";
        }
        private void ContarProductos()
        {
            lblCantidad.Text = dgStock.RowCount.ToString();
        }

        private void MostrarServicios()
        {
            dgStock.DataSource = s.MostrarServicios();
        }    

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
            btnLimpiar.Visible = true;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
           
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                        s._Nombre = txtNombre.Text;
                        s._Costo = Convert.ToDouble(txtCosto.Text);
                        s._Idcategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                        s.InsertarServicios(s);
                            limpiar();
                        MostrarServicios();
                        ContarProductos();
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
                        s._Id = Convert.ToInt32(txtID.Text);
                        s._Nombre = txtNombre.Text;
                        s._Costo = Convert.ToDouble(txtCosto.Text);
                        s._Idcategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                        s.EditarServicio(s);
                        limpiar();
                            MostrarServicios();
                        ContarProductos();
                            btnCancelarEdicion.Visible = false;
                            estado = false;
                            txtID.Enabled = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo editar los datos");
                        }
                    }
                }
                else
                {
                    //tus codigos
                }
            


        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Encriptacion.Encriptar en = new Encriptacion.Encriptar();
            try
            {
                if (dgStock.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgStock.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgStock.CurrentRow.Cells[1].Value.ToString();
                    txtCosto.Text = dgStock.CurrentRow.Cells[2].Value.ToString();
                    cbCategoria.SelectedValue = dgStock.CurrentRow.Cells[3].Value.ToString();
                     
                  
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
                MessageBox.Show("No debe dejar campos vacios mientras edita");
            }
        }
        //Hasta acá.
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCosto.Clear();
            listarCategoria();           
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
//-------------------------validar que ingresen datos para ejecutar----------------------------------
       
        //----------------------------------------validacion por tamaño---------------------------------------------------
        //-----------------------------valida los datos de entrada(tipo de dato)-----------------------------------
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtFiltroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void dgStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //--------------------------------------------------------------------------------------------------
        }
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dgStock.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el servicio?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    s._Id = Convert.ToInt32(dgStock.CurrentRow.Cells[0].Value.ToString());
                    s.EliminarServicios(s);
                    ContarProductos();
                    MostrarServicios();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
