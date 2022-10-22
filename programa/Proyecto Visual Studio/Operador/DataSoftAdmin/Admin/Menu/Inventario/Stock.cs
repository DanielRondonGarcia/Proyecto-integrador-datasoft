using AccesoOracle.AjustesData;
using Dominio.DAjustes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Validar;
using Dominio.DAjustes;
namespace Operador
{
    public partial class Stock : Form
    {
        AGenerarCompra ag = new AGenerarCompra();
       
        public Stock()
        {
            InitializeComponent();
        }
        public bool estado = false;
        
        private void Cuentas_Load(object sender, EventArgs e)
        {
            MostrarStock();
            ContarProductos();
        }

        private void ContarProductos()
        {
            lblCantidad.Text = dgStock.RowCount.ToString();
        }
        AStock s = new AStock();
        private void MostrarStock()
        {
            dgStock.DataSource = s.MostrarStock();
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
            DGenerarCompra g = new DGenerarCompra();
                if (estado == true)
                {
                    if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                        if (txtDescuento.Text !="")
                        {
                            ag._Descuento = Convert.ToInt32(txtDescuento.Text);
                            ag._Valor = Convert.ToDouble(txtPrecioVenta.Text);
                            ag._Idproducto = Convert.ToInt32(txtID.Text);
                        }
                        else
                        {
                            ag._Descuento = 0;
                        }
                        
                        g.Editar_Descuento(ag);
                        limpiar();
                        MostrarStock();
                        btnCancelarEdicion.Visible = false;
                        btnLimpiar.Visible = true;
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
                    txtCantidad.Text = dgStock.CurrentRow.Cells[2].Value.ToString();
                    txtPrecioVenta.Text = dgStock.CurrentRow.Cells[3].Value.ToString();
                    txtIVA.Text = dgStock.CurrentRow.Cells[4].Value.ToString();
                    txtDescuento.Text = dgStock.CurrentRow.Cells[5].Value.ToString();
                     
                    

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
            txtIVA.Clear();
            txtPrecioVenta.Clear();
            txtCantidad.Clear();
            txtDescuento.Clear();           
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
//-------------------------validar que ingresen datos para ejecutar----------------------------------
       
        //----------------------------------------validacion por tamaño---------------------------------------------------
        private void txtNombre_Validated(object sender, EventArgs e)
        {
            if (txtDescuento.Text.Length > 0)
            {
                ErrorP.SetError(txtDescuento, "");
            }
            else
            {
                ErrorP.SetError(txtDescuento, "Introduce nombre");
            }
        }
        //-----------------------------valida los datos de entrada(tipo de dato)-----------------------------------
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtFiltroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void txtFiltroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
           /* string dato = txtFiltroDocumento.Text;            
            dgUsuarios.RowTemplate.Height = 45;
            dgUsuarios.DataSource = obUsuario.Filtrar_Cliente(dato);
            DataGridViewImageColumn im = new DataGridViewImageColumn();
            im = (DataGridViewImageColumn)dgUsuarios.Columns[13];
            im.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgUsuarios.Refresh();*/
        }

        private void dgStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgStock.Columns[e.ColumnIndex].Name == "Cantidad")
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
                catch (NullReferenceException ex)
                {

                }
            }

            //--------------------------------------------------------------------------------------------------
        }
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }
    }
}
