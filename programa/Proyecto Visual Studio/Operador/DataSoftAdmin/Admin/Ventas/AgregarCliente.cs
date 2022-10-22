using AccesoOracle.AOModelos;
using Dominio.DAjustes;
using Dominio.Modelos;
using System;
using System.Windows.Forms;
using EnMemoria.Cache;
using Validar;
using AccesoOracle.AjustesData;
namespace Operador
{
    public partial class VentasClientasAdmin : Form
    {
        DClientes con = new DClientes();
        Clientes cli = new Clientes();
        bool estado = false;
        
        public VentasClientasAdmin()
        {
            InitializeComponent();
        }

        private void VentasClientasAdmin_Load(object sender, EventArgs e)
        {
            MostrarCliente();          
            ListarTipoDocumento();
            ListarSexo();
            ListarDepartamento();
            ContarClientes();
            
        }
        private void ContarClientes()
        {
            lblCantidadClientes.Text = con.Cantidad_Clientes();
        }
        private void MostrarCliente()
        {
            dgClientes.DataSource = con.Mostrar_Clientes();
        }
        private void ListarTipoDocumento()
        {
            cbTipoDoc.DataSource = con.Listar_TipoDocumento();
            cbTipoDoc.DisplayMember = "NOMTIPDOC";
            cbTipoDoc.ValueMember = "IDTIPDOC";
        }
        private void ListarSexo()
        {
            cbSexo.DataSource = con.Listar_Sexo();
            cbSexo.DisplayMember = "NOMSEX";
            cbSexo.ValueMember = "IDSEX";
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
        //inversa **********************************************************************
        public string Dato_Departamento(string id_mun)
        {
            return con.IListar_Departamento(id_mun);
        }
        public string Dato_municipio(string id_zona)
        {
            return con.IListar_Municipios(id_zona);
        }
        //inversa **********************************************************************
        //metodo que llama la lista de los combobox
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
        public void limpiarError()
        {

        }
        public bool validarCampos()
        {
            bool error = true;
            if (txtNombre.Text.Trim() == "")
            {
                errorMostrar.SetError(txtNombre, "Introduce nombre");
                error = false;
            }

            if (txtApellido.Text.Trim() == "")
            {
                errorMostrar.SetError(txtApellido, "Ingresar apellido");
                error = false;
            }

            if (txtTelefono.Text.Trim() == "")
            {
                errorMostrar.SetError(txtTelefono, "Ingrese Teléfono");
                error = false;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                errorMostrar.SetError(txtDireccion, "Ingrese Dirección");
                error = false;
            }


            if (txtNDocumento.Text.Trim() == "")
            {
                errorMostrar.SetError(txtNDocumento, "Ingrese número de documento");
                error = false;
            }

            return error;
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {           
            
            AOCliente cli = new AOCliente();
            ACliente c = new ACliente();
           

            if (validarCampos())
            {
                errorMostrar.Clear();
               
                try { 
                if (estado == false)
                {
                            if (MessageBox.Show("¡Se guardaran nuevos datos!", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    CacheUsuarioLog.idCliente = c.ConsultaIDCliente();
                                    cli._Nombre = CacheUsuarioLog.nombreC = txtNombre.Text;
                                    cli._Apellido = CacheUsuarioLog.apellidoC = txtApellido.Text;
                                    cli._TipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue);
                                    cli._NDocumento1 = CacheUsuarioLog.cedulaC = Convert.ToInt64(txtNDocumento.Text);
                                    cli._Telefono = Convert.ToInt64(txtTelefono.Text);
                                    cli._Correo = txtCorreo.Text;
                                    cli._Sexo = Convert.ToInt32(cbSexo.SelectedValue);
                                    cli._Direccion = txtDireccion.Text;
                                    cli._Zona = Convert.ToInt32(cbZona.SelectedValue);
                                    con.Insertar_Cliente(cli);
                                    MostrarCliente();
                                    limpiar();
                                    ContarClientes();
                                
                            }
                                catch (Exception ex)
                                {
                                }                           
                        }
                        else
                        {
                            MessageBox.Show("El número de documento ya se encuantra registrado", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar los datos");
                }



                if (estado == true)
                {
                    
                        if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            cli._ID1 = Convert.ToInt32(txtID.Text);
                            cli._Nombre = txtNombre.Text;
                            cli._Apellido = txtApellido.Text;
                            cli._TipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue);
                            cli._NDocumento1 = Convert.ToInt64(txtNDocumento.Text);
                            cli._Telefono = Convert.ToInt64(txtTelefono.Text);
                            cli._Correo = txtCorreo.Text;
                            cli._Sexo = Convert.ToInt32(cbSexo.SelectedValue);
                            cli._Direccion = txtDireccion.Text;
                            cli._Zona = Convert.ToInt32(cbZona.SelectedValue);
                            con.Editar_Cliente(cli);
                            limpiar();
                            MostrarCliente();
                            btnCancelarEdicion.Visible = false;
                            estado = false;
                            txtID.Enabled = true;
                                ListarDepartamento();
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
            else
            {
                MessageBox.Show("Dejó datos obligatorios sin llenar");
            }


        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dgClientes.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgClientes.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgClientes.CurrentRow.Cells[1].Value.ToString();
                    txtApellido.Text = dgClientes.CurrentRow.Cells[2].Value.ToString();
                    cbTipoDoc.SelectedValue = dgClientes.CurrentRow.Cells[3].Value.ToString();
                    txtNDocumento.Text = dgClientes.CurrentRow.Cells[4].Value.ToString();
                    txtTelefono.Text = dgClientes.CurrentRow.Cells[5].Value.ToString();
                    txtCorreo.Text = dgClientes.CurrentRow.Cells[6].Value.ToString();
                    cbSexo.SelectedValue = dgClientes.CurrentRow.Cells[7].Value.ToString();
                    txtDireccion.Text = dgClientes.CurrentRow.Cells[8].Value.ToString();

                    ListarDepartamento();
                    cbDepartamento.SelectedValue = Dato_Departamento(Dato_municipio(dgClientes.CurrentRow.Cells[9].Value.ToString()));

                    ListarMunicipio(Dato_Departamento(Dato_municipio(dgClientes.CurrentRow.Cells[9].Value.ToString())));
                    cbCiudad.SelectedValue = Dato_municipio(dgClientes.CurrentRow.Cells[9].Value.ToString());

                    ListarZona(Dato_municipio(dgClientes.CurrentRow.Cells[9].Value.ToString()));
                    cbZona.SelectedValue = dgClientes.CurrentRow.Cells[9].Value.ToString();
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
        //Hasta acá.
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtNDocumento.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
        }
        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
            ListarDepartamento();
        }

        private void txtFiltroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            string dato = txtFiltroDocumento.Text;
            dgClientes.DataSource = con.Filtrar_Cliente(dato);
        }
        private void EliminarCliente(string da)
        {
            con.Eliminar_Cliente(da);
            ContarClientes();
        }
        private string clientealerta()
        {
            string name = dgClientes.CurrentRow.Cells[1].Value.ToString();
            string lastname = dgClientes.CurrentRow.Cells[2].Value.ToString();
            string fullname = name + " " + lastname;
            return fullname;
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente " + clientealerta() + "?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string dato = dgClientes.CurrentRow.Cells[0].Value.ToString();
                    EliminarCliente(dato);
                    MostrarCliente();
                }
            }
            else
            {
            MessageBox.Show("Seleccione una fila");
            }
            }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);          
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtNDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void txtFiltroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }


        private void txtNombre_Validated_1(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length > 0)
            {
                errorMostrar.SetError(txtNombre,"");
            }
            else
            {
                errorMostrar.SetError(txtNombre,"Ingrese Nombre");
            }
        }

        private void txtApellido_Validated_1(object sender, EventArgs e)
        {
            if (txtApellido.Text.Length > 0)
            {
                errorMostrar.SetError(txtApellido, "");
            }
            else
            {
                errorMostrar.SetError(txtApellido, "Ingrese Apellido");
            }
        }

        private void txtNDocumento_Validated_1(object sender, EventArgs e)
        {
            if (txtNDocumento.Text.Length > 0)
            {
                errorMostrar.SetError(txtNDocumento, "");
            }
            else
            {
                errorMostrar.SetError(txtNDocumento, "Ingrese Número de documento");
            }
        }

        private void txtTelefono_Validated_1(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 0)
            {
                errorMostrar.SetError(txtTelefono, "");
            }
            else
            {
                errorMostrar.SetError(txtTelefono, "Ingrese télefono");
            }
        }

        private void txtDireccion_Validated_1(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Length > 0)
            {
                errorMostrar.SetError(txtDireccion, "");
            }
            else
            {
                errorMostrar.SetError(txtDireccion, "Ingrese Dirección");
            }
        }
    }      
    }

