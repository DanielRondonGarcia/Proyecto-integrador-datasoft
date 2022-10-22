using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin.Ventas;
using Dominio.DAjustes;
using AccesoOracle.AjustesData;
using EnMemoria.Cache;

namespace Admin
{
    public partial class GenerarVentaServicio : Form
    {
        public string _Nombre { get; set; }
        public string _idCliente { get; set; }
        public string _Apellido { get; set; }
        public string _Cedula { get; set; }
        public static int bandera;
        public GenerarVentaServicio()
        {
            InitializeComponent();
        }
        AgregarServicio pdf = new AgregarServicio();
        AGenerarVentaServicio gv = new AGenerarVentaServicio();
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
            lblFactura.Text = gv.MostrarIDFactura().ToString();
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
            txtDetalle.Clear();
            txtDetalle.Focus();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pdf.ShowDialog();
            if (pdf.DialogResult == DialogResult.OK)
            {
                txtID.Text = pdf.dgStock.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = pdf.dgStock.CurrentRow.Cells[1].Value.ToString();
                txtCosto.Text = pdf.dgStock.CurrentRow.Cells[2].Value.ToString();
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
            txtDetalle.Clear();
            txtCosto.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgGenerarCompra.SelectedRows.Count > 0)
            {
                int pos = dgGenerarCompra.CurrentRow.Index;
                dgGenerarCompra.Rows.RemoveAt(pos);
                cantidad = 0;
                total = 0;
                int contfilas, aumenta = 0;
                contfilas = dgGenerarCompra.RowCount;
                while (contfilas != aumenta)
                {
                    total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[5].Value);               
                    aumenta++;
                }
                lblTotal.Text = total.ToString("C");
                lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDetalle.Clear();

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
            while (contfilas != aumenta)
            {

                total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[4].Value);
                aumenta++;
            }
            lblTotal.Text = total.ToString("C");
            lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
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
                        gv.InsertarEncabezadoVenta(gv);

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
                            gv._IdServicio = Convert.ToInt32(vecprod[0]);
                            gv._Detalle = vecprod[2];
                            gv._Valor = Convert.ToDouble(vecprod[3]);
                            gv.InsertarDetalleVenta(gv);
                            aumenta++;
                        }
                        dgGenerarCompra.Rows.Clear();
                        lblTotal.Text = "0";
                        lblCantidadProductos.Text = "0";
                        txtNombreCliente.Clear();
                        lblID.Text = "";
                        lblCedula.Text = "";
                        MessageBox.Show("Venta registrada con exito");
                        lblFactura.Text = gv.MostrarIDFactura().ToString();
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

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ReporteVentaServicio rp = new ReporteVentaServicio();
            rp.ShowDialog();
        }

        private void btnAgragaraStock_Click(object sender, EventArgs e)
        {
            bool existe = false;
            try
            {                                 
                        if (txtID.Text != "" && txtNombre.Text != "")
                        {
                            if (txtDetalle.Text != "" || txtDetalle.Text != "0")
                            {
                                try
                                {                                
                                int contfilas, aumenta = 0, cantidad = 0, numfila = 0;                                 
                                total = 0;

                                    importe = Convert.ToDouble(txtCosto.Text);
                                    dgGenerarCompra.Rows.Add(txtID.Text, txtNombre.Text, txtDetalle.Text, txtCosto.Text, importe);                                                     
                                    lblCantidadProductos.Text = dgGenerarCompra.RowCount.ToString();
                                    contfilas = dgGenerarCompra.RowCount;
                                while (contfilas != aumenta)
                                    {
                                        total = total + Convert.ToInt32(dgGenerarCompra.Rows[aumenta].Cells[4].Value);                               
                                        aumenta++;
                                    }
                                    lblTotal.Text = total.ToString("C");
                                    
                                    limpiar();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Se generó errores " + ex);
                                }
                            }
                            else
                            {
                                txtDetalle.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay producto que agregar");
                        }                  
                }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        
        }
    }
}
