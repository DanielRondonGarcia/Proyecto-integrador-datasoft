using AccesoOracle.AOModelos;
using Dominio.DAjustes;
using Dominio.Modelos;
using System;
using System.Windows.Forms;
using AccesoOracle.AjustesData;
using EnMemoria.Cache;

namespace Operador
{
    public partial class ProveedoresAdmin : Form
    {
        DProveedor con = new DProveedor();
        AProveedor pro = new AProveedor();
        bool estado = false;
        public ProveedoresAdmin()
        {
            InitializeComponent();
        }
        private void MostrarProveedor()
        {
            dgProveedor.DataSource = con.Mostrar_Proveedor();
        }
        private void ListarTipoDocumento()
        {
            cbTipoDoc.DataSource = con.Listar_TipoDocumento();
            cbTipoDoc.DisplayMember = "NOMTIPDOC";
            cbTipoDoc.ValueMember = "IDTIPDOC";
        }
        private void ContarProveedor()
        {
            lblCantidadProveedor.Text = con.Cantidad_Proveedor();
        }
        private void ProveedoresAdmin_Load(object sender, EventArgs e)
        {
            MostrarProveedor();
            ListarTipoDocumento();
            ContarProveedor();
        }
        private void EliminarCliente(AProveedor p)
        {
            con.Eliminar_Proveedor(p);
            ContarProveedor();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    pro._Documento = Convert.ToInt64(txtNDocumento.Text);
                        if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                pro._Nombre = txtNombre.Text;
                                pro._TipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue);
                                pro._Documento = Convert.ToInt64(txtNDocumento.Text);
                                pro._Correo = txtCorreo.Text;
                                pro._Telefono = Convert.ToInt64(txtTelefono.Text);
                                pro._Url = txtURL.Text;
                                con.Insertar_Proveedor(pro);
                                MostrarProveedor();
                                limpiar();
                                ContarProveedor();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo guardar los datos   " + ex);
                            }
                        }
                    }
                    else
                    {
                    }


                if (estado == true)
                {
                    if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            pro._Id = Convert.ToInt32(txtID.Text);
                            pro._Nombre = txtNombre.Text;
                            pro._TipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue);
                            pro._Documento = Convert.ToInt64(txtNDocumento.Text);
                            pro._Correo = txtCorreo.Text;
                            pro._Telefono = Convert.ToInt64(txtTelefono.Text);
                            pro._Url = txtURL.Text;
                            con.Editar_Proveedor(pro);
                            limpiar();
                            MostrarProveedor();
                            btnCancelarEdicion.Visible = false;
                            estado = false;
                            txtID.Enabled = true;
                            MessageBox.Show("Editado Correctamente");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo editar los datos");
                        }
                    }
                }
                else
                {
                }
            }
        }
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtNDocumento.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtURL.Clear();
            ListarTipoDocumento();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProveedor.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgProveedor.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgProveedor.CurrentRow.Cells[1].Value.ToString();
                    cbTipoDoc.SelectedValue = dgProveedor.CurrentRow.Cells[2].Value.ToString();
                    txtNDocumento.Text = dgProveedor.CurrentRow.Cells[3].Value.ToString();
                    txtCorreo.Text = dgProveedor.CurrentRow.Cells[4].Value.ToString();
                    txtTelefono.Text = dgProveedor.CurrentRow.Cells[5].Value.ToString();
                    txtURL.Text = dgProveedor.CurrentRow.Cells[6].Value.ToString();
                    btnCancelarEdicion.Visible = true;
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

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
        }
        private string alerta()
        {
            string name = dgProveedor.CurrentRow.Cells[1].Value.ToString();
            string doc = dgProveedor.CurrentRow.Cells[3].Value.ToString();
            string fullname = name + " " + doc;
            return fullname;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgProveedor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente " + alerta() + "?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pro._Id = Convert.ToInt32(dgProveedor.CurrentRow.Cells[0].Value.ToString());
                    EliminarCliente(pro);
                    MostrarProveedor();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }


        private void txtFiltroDocumento_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                pro._Filtro =txtFiltroDocumento.Text;
                dgProveedor.DataSource = con.Filtrar_Proveedor(pro);
            }
            catch (Exception ex)
            {
            }
        }
    }
    
}
