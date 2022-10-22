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
using Dominio.Modelos;
using Dominio.DAjustes;
using AccesoOracle.AjustesData;

namespace Admin.Ajustes
{
    public partial class Sucursal : Form
    {
        DSucursal con = new DSucursal();
        public Sucursal()
        {
            InitializeComponent();
        }
        bool estado = false;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void MostrarSucursal()
        {
            dgSuc.DataSource = con.Mostrar_Sucursal();
        }
        private void ListarDepartamento()
        {
            cbDepartamento.DataSource = con.Listar_Departamento();
            cbDepartamento.DisplayMember = "NOMDEP";
            cbDepartamento.ValueMember = "IDDEP";
        }
        private void ListarMunicipio(string idedep)
        {
            cbCiudad.DataSource = con.Listar_Municipios(idedep);
            cbCiudad.DisplayMember = "NOMMUN";
            cbCiudad.ValueMember = "IDMUN";
        }
        private void ListarZona(string idemun)
        {
            cbZona.DataSource = con.Listar_Zona(idemun);
            cbZona.DisplayMember = "NOMZONA";
            cbZona.ValueMember = "IDZONA";
        }
        private void Sucursal_Load(object sender, EventArgs e)
        {
            MostrarSucursal();
            ListarDepartamento();
        }

        private void cbDepartamento_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDepartamento.SelectedValue.ToString() != null)
                {
                    string dato = cbDepartamento.SelectedValue.ToString();
                    ListarMunicipio(dato);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cbCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCiudad.SelectedValue.ToString() != null)
                {
                    string dato = cbCiudad.SelectedValue.ToString();
                    ListarZona(dato);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ASucursal suc = new ASucursal();   
            if (txtNumeroContacto.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            suc._Contacto = txtNumeroContacto.Text;
                            suc._Direccion = txtDireccion.Text;
                            suc._Zona = Convert.ToInt32(cbZona.SelectedValue);
                            suc._Nombre = txtNombre.Text;
                            con.Insertar_Sucursal(suc);
                            MostrarSucursal();
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
                            suc._Id = Convert.ToInt32(txtID.Text);
                            suc._Contacto = txtNumeroContacto.Text;
                            suc._Direccion = txtDireccion.Text;
                            suc._Zona = Convert.ToInt32(cbZona.SelectedValue);
                            suc._Nombre = txtNombre.Text;
                            con.Editar_Sucursal(suc);
                            limpiar();
                            MostrarSucursal();
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
        }
        public void limpiar()
        {
            txtID.Clear();
            txtDireccion.Clear();
            txtNumeroContacto.Clear();           
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgSuc.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgSuc.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgSuc.CurrentRow.Cells[1].Value.ToString();
                    txtNumeroContacto.Text = dgSuc.CurrentRow.Cells[2].Value.ToString();
                    txtDireccion.Text = dgSuc.CurrentRow.Cells[3].Value.ToString();
                    cbZona.SelectedValue = dgSuc.CurrentRow.Cells[4].Value.ToString();
                    //PARA QUE SIRVA EL BARRIO SE TIENE QUE TENER EN LA BASE DE DATOS EL DEPARTAMENTO Y CIUDAD                  
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
        private void EliminarCliente(ASucursal s)
        {
            con.Eliminar_Cliente(s);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
             ASucursal suc = new ASucursal();  
            if (dgSuc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente ", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string dato = dgSuc.CurrentRow.Cells[0].Value.ToString();
                    suc._Id = Convert.ToInt32(dato);
                    EliminarCliente(suc);
                    MostrarSucursal();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
