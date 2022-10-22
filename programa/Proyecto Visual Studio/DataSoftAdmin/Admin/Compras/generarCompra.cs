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
using EnMemoria.Cache;
using Admin.Compras;
using Validar;

namespace Admin.Compras
{
    public partial class generarCompra : Form
    {
        DGenerarCompra con = new DGenerarCompra();
        AGenerarCompra c = new AGenerarCompra();
        AgregarProducto prod = new AgregarProducto();
        public generarCompra()
        {
            InitializeComponent();
        }

        private void generarCompra_Load(object sender, EventArgs e)
        {
            total = 0;
            ListarProveedor();
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblOperador.Text = CacheUsuarioLog.nombre + " " + CacheUsuarioLog.Apellido;
            lblRazonSocial.Text = CacheUsuarioLog.sucursal.ToString();
            dgCompraPrincipal.Refresh();
            lblFactura.Text = MostrarIDFactura().ToString();
            lblCantidadProductos.Text = "0";
            lblTotal.Text = total.ToString("C");

        }
        public int MostrarIDFactura()
        {
            return con.Mostrar_IDFactura();
        }
        public void ListarProveedor()
        {
            cbProveedor.DataSource = con.Listar_Proveedor();
            cbProveedor.ValueMember = "IDPRO";
            cbProveedor.DisplayMember = "NOMPRO";
        }
        int importe;
        public void FOCO()
        {
            txtCantidad.Clear();
            txtCantidad.Focus();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            prod.ShowDialog();
            if (prod.DialogResult == DialogResult.OK)
            {
                txtID.Text = prod.dgGenerarCompra.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = prod.dgGenerarCompra.CurrentRow.Cells[1].Value.ToString();
                txtNuevoPrecio.Text = prod.dgGenerarCompra.CurrentRow.Cells[9].Value.ToString();
                txtUtilidad.Text = prod.dgGenerarCompra.CurrentRow.Cells[10].Value.ToString();
                FOCO();
            }

        }
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCantidad.Clear();
            txtNuevoPrecio.Clear();
            txtUtilidad.Clear();
        }
        int total = 0, cantidad = 0;
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtNombre.Text != "")
            {
                if (txtCantidad.Text != "")
                {
                    try
                    {
                        double iva = Convert.ToDouble(prod.dgGenerarCompra.CurrentRow.Cells[11].Value);
                        importe = Convert.ToInt32(txtNuevoPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
                        dgCompraPrincipal.Rows.Add(txtID.Text, txtNombre.Text, txtNuevoPrecio.Text, txtCantidad.Text,importe,txtUtilidad.Text,iva, "ELIMINAR");
                        lblCantidadProductos.Text = dgCompraPrincipal.RowCount.ToString();
                        if (dgCompraPrincipal.Rows.Count > 0)
                        {
                            cbProveedor.Visible = false;
                            lblProveedor.Visible = false;
                        }
                        else
                        {
                            cbProveedor.Visible = true;
                            lblProveedor.Visible = true;
                        }
                        cantidad = cantidad + int.Parse(txtCantidad.Text);
                        lblCantidadTotal.Text = cantidad.ToString();
                        int contfilas, aumenta = 0;
                        contfilas = dgCompraPrincipal.RowCount;
                        total = 0;
                        while (contfilas != aumenta)
                        {
                            total = total + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[4].Value);
                            aumenta++;
                        }
                        lblTotal.Text = total.ToString("C");
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se genero errores "+ex);
                    }
                }
                else
                {
                    txtCantidad.Focus();
                }

            }
            else
            {
                MessageBox.Show("No hay producto que agregar");
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            bunifuFlatButton4_Click(sender, e);
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }
        bool estado = false;
        int pos;
        private void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCompraPrincipal.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtNuevoPrecio.Text = dgCompraPrincipal.CurrentRow.Cells[2].Value.ToString();
                    txtUtilidad.Text = dgCompraPrincipal.CurrentRow.Cells[5].Value.ToString();
                    btnAceptarEd.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mientras edita");
            }
        }
        public double Valor_Venta(double precio, double porcentaje)
        {
            //double porcentaje = Convert.ToDouble(prod.dgGenerarCompra.CurrentRow.Cells[10].Value);
            double pIva = Convert.ToDouble(prod.dgGenerarCompra.CurrentRow.Cells[11].Value);
            double vIva = pIva / 100;
            double utilidad = (porcentaje / 100);
            double valor = precio / (1-utilidad);
            double valorVenta = valor * (1+vIva);
            return valorVenta;
        }
        private void btnAceptarEd_Click(object sender, EventArgs e)
        {
            pos = dgCompraPrincipal.CurrentRow.Index;
            DataGridViewRow actualizar = dgCompraPrincipal.Rows[pos];
            importe = Convert.ToInt32(txtNuevoPrecio.Text) * Convert.ToInt32(dgCompraPrincipal.CurrentRow.Cells[3].Value);
            actualizar.Cells[2].Value = txtNuevoPrecio.Text;
            actualizar.Cells[5].Value = txtUtilidad.Text;
            actualizar.Cells[4].Value = importe.ToString();
            int contfilas, aumenta = 0;
            contfilas = dgCompraPrincipal.RowCount;
            total = 0;
            while (contfilas != aumenta)
            {
                total = total + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[4].Value);
                aumenta++;
            }
            lblTotal.Text =total.ToString("C");
            limpiar();
            btnAceptarEd.Visible = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void txtNuevoPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NumerosDecimales(e);
        }

        private void Click_Eliminar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==7)
            {              
                dgCompraPrincipal.Rows.RemoveAt(e.RowIndex);
                cantidad = 0;
                total = 0;
                int contfilas, aumenta = 0;
                contfilas = dgCompraPrincipal.RowCount;
                while (contfilas != aumenta)
                {
                    cantidad = cantidad + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[3].Value);
                    total = total + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[4].Value);
                    aumenta++;
                }
                lblCantidadProductos.Text = dgCompraPrincipal.RowCount.ToString();
                lblCantidadTotal.Text = cantidad.ToString();
                lblTotal.Text =total.ToString("C");
                if (dgCompraPrincipal.Rows.Count ==0)
                {
                    cbProveedor.Visible = true;
                }
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            limpiar();
            ListarProveedor();
            dgCompraPrincipal.Rows.Clear();
            cantidad = 0;
            total = 0;
            int contfilas, aumenta = 0;
            contfilas = dgCompraPrincipal.RowCount;
            while (contfilas != aumenta)
            {
                cantidad = cantidad + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[3].Value);
                total = total + Convert.ToInt32(dgCompraPrincipal.Rows[aumenta].Cells[4].Value);
                aumenta++;
            }
            lblCantidadProductos.Text = dgCompraPrincipal.RowCount.ToString();
            lblCantidadTotal.Text = cantidad.ToString();
            lblTotal.Text = total.ToString("C");
            if (dgCompraPrincipal.Rows.Count == 0)
            {
                cbProveedor.Visible = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            InvetarioStock stock = new InvetarioStock();
            stock.ShowDialog();
        }

        private void btnUtilidad_Click(object sender, EventArgs e)
        {
            CalculoUtilidad calculo = new CalculoUtilidad();
            calculo.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
             
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteCompra rc = new ReporteCompra();
            rc.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if(dgCompraPrincipal.Rows.Count > 0)
            {
                try
                {
                    c._Idfactura = Convert.ToInt32(lblFactura.Text);
                    c._Idproveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                    c._Idusuario = Convert.ToInt32(CacheUsuarioLog.id);
                    con.Insertar_Encabezado(c);

                    int cantcolumna, contfilas, aumenta = 0;
                    cantcolumna = dgCompraPrincipal.ColumnCount;
                    contfilas = dgCompraPrincipal.RowCount;
                    string[] vecprod = new string[cantcolumna];
                    int i;
                    while (contfilas != aumenta)
                    {
                        for (i = 0; i < cantcolumna; i++)
                        {
                            vecprod[i] = dgCompraPrincipal.Rows[aumenta].Cells[i].Value.ToString();
                        }

                        c._Idfactura = Convert.ToInt32(lblFactura.Text);
                        c._Idproducto = Convert.ToInt32(vecprod[0]);
                        c._Cantidad = Convert.ToInt32(vecprod[3]);
                        c._Valor = Valor_Venta(Convert.ToDouble(vecprod[2]), Convert.ToDouble(vecprod[5]));
                        c._Iva = Convert.ToDouble(vecprod[6]);
                        con.Insertar_Detalle(c);
                        aumenta++;
                    }
                    dgCompraPrincipal.Rows.Clear();
                    lblCantidadTotal.Text = "0";
                    lblTotal.Text = "0";
                    lblCantidadProductos.Text = "0";
                    MessageBox.Show("Compra registrada con exito");
                    lblFactura.Text = MostrarIDFactura().ToString();
                    cbProveedor.Visible = true;
                    this.Refresh();
                }catch(Exception ex)
                {
                    MessageBox.Show("Se genero error "+ex);
                }
            }            
            else
            {
                MessageBox.Show("Error al generar compra");
            }
            
        }
    }
}
