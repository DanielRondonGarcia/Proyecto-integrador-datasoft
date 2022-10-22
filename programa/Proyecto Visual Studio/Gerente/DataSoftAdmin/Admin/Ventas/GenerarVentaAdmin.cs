using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerente.Ventas;
using Dominio.DAjustes;
using AccesoOracle.AjustesData;
using EnMemoria.Cache;

namespace Gerente
{
    public partial class GenerarVentaAdmin : Form
    {
        public string _Nombre { get; set; }
        public string _idCliente { get; set; }
        public string _Apellido { get; set; }
        public string _Cedula { get; set; }
        public static int bandera;
        public GenerarVentaAdmin()
        {
            InitializeComponent();
        }
        AgregarProductosFiltro pdf = new AgregarProductosFiltro();
        AGenerarVenta gv = new AGenerarVenta();
        DGenerarVenta ven = new DGenerarVenta();
        private void GenerarCompraAdmin_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblOperador.Text = CacheUsuarioLog.nombre + " " + CacheUsuarioLog.Apellido;
            lblRazonSocial.Text = CacheUsuarioLog.sucursal.ToString();
            if (bandera == 0)
            {
                txtNombreCliente.Text = CacheUsuarioLog.nombreC + " " + CacheUsuarioLog.apellidoC;
                lblCedula.Text = CacheUsuarioLog.cedulaC.ToString();
                lblID.Text = CacheUsuarioLog.idCliente.ToString();
                bandera = 1;
            }
            else
            {
                CacheUsuarioLog.cedulaC = 0;
                CacheUsuarioLog.nombreC = "";
                CacheUsuarioLog.apellidoC = "";
                CacheUsuarioLog.idCliente = 0;
                lblCedula.Text = "0";
                lblID.Text = "0";
                bandera = 0;
            }
            lblFactura.Text = ven.Mostrar_IDFactura().ToString();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClienteFiltro bc = new BuscarClienteFiltro();
            bc.ShowDialog();
            if (bc.DialogResult == DialogResult.OK)
            {
                lblCedula.Text = bc.dgCliente.CurrentRow.Cells[4].Value.ToString();
                _idCliente = bc.dgCliente.CurrentRow.Cells[0].Value.ToString();
                _Nombre = bc.dgCliente.CurrentRow.Cells[1].Value.ToString();
                _Apellido = bc.dgCliente.CurrentRow.Cells[2].Value.ToString();
                txtNombreCliente.Text = _Nombre + " " + _Apellido;
                lblID.Text = _idCliente;
            }
        }
        public void FOCO()
        {
            txtCantidad.Clear();
            txtCantidad.Focus();
        }
        string valor;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pdf.ShowDialog();
            if (pdf.DialogResult == DialogResult.OK)
            {
                txtID.Text = pdf.dgStock.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = pdf.dgStock.CurrentRow.Cells[1].Value.ToString();
                valor = pdf.dgStock.CurrentRow.Cells[3].Value.ToString();
                txtDescuento.Text = pdf.dgStock.CurrentRow.Cells[5].Value.ToString();

                FOCO();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }
        int total = 0, cantidad = 0;
        double importe = 0;
        private void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCantidad.Clear();
            txtDescuento.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgGenerarCompra.SelectedRows.Count > 0)
            {
                int pos = dgGenerarCompra.CurrentRow.Index;
                dgGenerarCompra.Rows.RemoveAt(pos);
                nuevafila = nuevafila - 1;
                cantidad = 0;
                total = 0;
                int contfilas, aumenta = 0;
                contfilas = dgGenerarCompra.RowCount;
                double valorImponible = 0, ivaP = 0, iva = 0, tempBP=0,descuento=0,acumdesc=0;
                ivaP = Convert.ToDouble(pdf.dgStock.CurrentRow.Cells[4].Value);
                while (contfilas != aumenta)
                {
                    total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[5].Value);
                    descuento = Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value) - (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value) * (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[4].Value) / 100));             
                    tempBP = descuento / (1 + ivaP / 100);
                    total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[4].Value);
                    valorImponible = valorImponible + (tempBP * Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[3].Value));
                    iva = (total - valorImponible);
                    acumdesc = acumdesc + (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value)) * (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[4].Value) / 100);
                    cantidad = cantidad + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[3].Value);
                    aumenta++;
                }
                lblIva.Text = iva.ToString("C");
                lblTotal.Text = total.ToString("C");
                lblSubtotal.Text = valorImponible.ToString("C");
                lblDescuento.Text = acumdesc.ToString("C");
                lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
                lblCantidadTotal.Text = cantidad.ToString();
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCantidad.Clear();
            txtDescuento.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            dgGenerarCompra.Rows.Clear();
            nuevafila = 0;
            cantidad = 0;
            total = 0;
            int contfilas, aumenta = 0;
            contfilas = dgGenerarCompra.RowCount;
            double valorImponible = 0, ivaP = 0, iva = 0, tempBP,acumdesc=0;
            ivaP = Convert.ToDouble(pdf.dgStock.CurrentRow.Cells[4].Value);
            while (contfilas != aumenta)
            {

                total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[5].Value);
                tempBP = Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value) / (1 + ivaP / 100);
                valorImponible = valorImponible + (tempBP * Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[3].Value));
                acumdesc = acumdesc + (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value)) * (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[4].Value) / 100);
                iva = (total - valorImponible);
                aumenta++;
            }
            lblIva.Text = iva.ToString("C");
            lblTotal.Text = total.ToString("C");
            lblSubtotal.Text = valorImponible.ToString("C");
            lblDescuento.Text = acumdesc.ToString("C");
            lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
            lblCantidadTotal.Text = cantidad.ToString();
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            ModificarDescuento modi = new ModificarDescuento();
            modi.ShowDialog();
        }
        int nuevafila = 0;
        DGenerarVenta venta = new DGenerarVenta();
        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (dgGenerarCompra.Rows.Count > 0)
            {
                if (txtNombreCliente.Text != "")
                {
                    try
                    {

                        gv._Facturaventa = Convert.ToInt32(lblFactura.Text);
                        gv._IdCliente = Convert.ToInt32(lblID.Text);
                        gv._Iduser = Convert.ToInt32(CacheUsuarioLog.id);
                        AGenerarVenta ca = new AGenerarVenta();
                        ca.InsertarEncabezadoVenta(gv);

                        int cantcolumna, contfilas, aumenta = 0;
                        cantcolumna = dgGenerarCompra.ColumnCount;
                        contfilas = dgGenerarCompra.RowCount;
                        string[] vecprod = new string[cantcolumna];
                        int i;
                        while (contfilas != aumenta)
                        {
                            for (i = 0; i < cantcolumna; i++)
                            {
                                vecprod[i] = dgGenerarCompra.Rows[aumenta].Cells[i].Value.ToString();
                            }
                            gv._Facturaventa = Convert.ToInt32(lblFactura.Text);
                            gv._Idproducto = Convert.ToInt32(vecprod[0]);
                            gv._Cantidad = Convert.ToInt32(vecprod[3]);
                            gv._Valor = DescuentoR(Convert.ToDouble(vecprod[2]), Convert.ToDouble(vecprod[4]));
                            venta.Insertar_DetalleVenta(gv);
                            aumenta++;
                        }
                        dgGenerarCompra.Rows.Clear();
                        lblCantidadTotal.Text = "0";
                        lblTotal.Text = "0";
                        lblDescuento.Text = "0";
                        lblCantidadProductos.Text = "0";
                        txtNombreCliente.Clear();
                        lblID.Text = "";
                        lblCedula.Text = "";
                        MessageBox.Show("Venta registrada con exito");
                        lblFactura.Text = ven.Mostrar_IDFactura().ToString();
                        this.Refresh();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se genero error " + ex);

                    }
                }
                else
                {
                    MessageBox.Show("Falta Ingresar el Cliente", "¡AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al generar venta");
            }
        }
        public double DescuentoR(double valor, double descuento)
        {
            double resultado = valor - (valor * (descuento / 100));
            return resultado;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteVentaF rv = new ReporteVentaF();
            rv.ShowDialog();
        }

        private void btnAgragaraStock_Click(object sender, EventArgs e)
        {
            bool existe = false;
            try
            {               
                    int cantidadStock = Convert.ToInt32(pdf.dgStock.CurrentRow.Cells[2].Value);
                    if (Convert.ToInt32(txtCantidad.Text) <= cantidadStock)
                    {
                        if (txtID.Text != "" && txtNombre.Text != "")
                        {
                            if (txtCantidad.Text != "" || txtCantidad.Text != "0")
                            {
                                try
                                {                                
                                int contfilas, aumenta = 0, cantidad = 0, numfila = 0;                                 
                                total = 0;
                                double valorImponible = 0, ivaP = 0, iva = 0, tempBP, descuento = 0, acumdesc = 0;
                                ivaP = Convert.ToDouble(pdf.dgStock.CurrentRow.Cells[4].Value);
                                foreach (DataGridViewRow fila in dgGenerarCompra.Rows)
                                {
                                    if (fila.Cells[0].Value.ToString() == txtID.Text && fila.Cells[2].Value.ToString() == valor)
                                    {
                                        existe = true;
                                        numfila = fila.Index;
                                    }
                                   
                                }
                                if (existe==true)
                                {
                                    dgGenerarCompra.Rows[numfila].Cells[3].Value = Convert.ToInt32(txtCantidad.Text) + Convert.ToInt32(dgGenerarCompra.Rows[numfila].Cells[3].Value);
                                    importe = (Convert.ToInt32(dgGenerarCompra.Rows[numfila].Cells[3].Value) * Convert.ToDouble(dgGenerarCompra.Rows[numfila].Cells[2].Value)) - (Convert.ToInt32(dgGenerarCompra.Rows[numfila].Cells[3].Value) * Convert.ToDouble(dgGenerarCompra.Rows[numfila].Cells[2].Value) * (Convert.ToDouble(dgGenerarCompra.Rows[numfila].Cells[4].Value) / 100));
                                    dgGenerarCompra.Rows[numfila].Cells[5].Value = importe;
                                }
                                else
                                {
                                    importe = (Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(valor)) - (Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(valor) * (Convert.ToDouble(txtDescuento.Text) / 100));
                                    dgGenerarCompra.Rows.Add(txtID.Text, txtNombre.Text, valor, txtCantidad.Text, txtDescuento.Text,importe);
                                    dgGenerarCompra.Rows[nuevafila].Cells[5].Value = importe;
                                    nuevafila = nuevafila + 1;                                 
                                }
                                lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
                               contfilas = dgGenerarCompra.RowCount;
                                while (contfilas != aumenta)
                                    {
                                    
                                    descuento = Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value) - (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value) * (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[4].Value) / 100));
                                        total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[5].Value);
                                        tempBP = descuento / (1 + ivaP / 100);
                                        valorImponible = valorImponible + (tempBP * Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[3].Value));
                                        iva = (total - valorImponible);
                                        cantidad = cantidad + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[3].Value);
                                        acumdesc = acumdesc + (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[2].Value)) * (Convert.ToDouble(dgGenerarCompra.Rows[aumenta].Cells[4].Value) / 100);
                                        aumenta++;
                                    }
                                    lblIva.Text = iva.ToString("C");
                                    lblTotal.Text = total.ToString("C");
                                    lblSubtotal.Text = valorImponible.ToString("C");
                                    lblDescuento.Text = acumdesc.ToString("C");
                                    lblCantidadTotal.Text = cantidad.ToString();
                                    
                                    limpiar();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Se generó errores " + ex);
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
                    else
                    {
                        MessageBox.Show("Cantidad de producto no disponible");
                        txtCantidad.Focus();
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        
        }
    }
}
