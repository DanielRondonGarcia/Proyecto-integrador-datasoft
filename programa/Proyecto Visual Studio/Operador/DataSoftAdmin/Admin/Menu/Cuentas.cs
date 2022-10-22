using AccesoOracle.AjustesData;
using Dominio.DAjustes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Validar;
namespace Operador
{
    public partial class Cuentas : Form
    {
        DUsuarios obUsuario= new DUsuarios();
       
        public Cuentas()
        {
            InitializeComponent();
        }
        public bool estado = false;
        private void pictureBoxInventario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void Cuentas_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            ListarSexo();
            ListarTipoDocumento();
            ListarRoles();
            ListarDepartamento();
            ListarSucursal();
            ContarUsuario();
        }
        private void ListarTipoDocumento()
        {
            cbTipoDoc.DataSource = obUsuario.Listar_TipoDocumento();
            cbTipoDoc.DisplayMember = "NOMTIPDOC";
            cbTipoDoc.ValueMember = "IDTIPDOC";
        }
        private void ListarSucursal()
        {
            cbSucursal.DataSource = obUsuario.Listar_Sucursal();
            cbSucursal.DisplayMember = "IDSUC";
            cbSucursal.ValueMember = "IDSUC";
        }
        private void ListarSexo()
        {
            cbGenero.DataSource = obUsuario.Listar_Sexo();
            cbGenero.DisplayMember = "NOMSEX";
            cbGenero.ValueMember = "IDSEX";
        }
        private void ListarRoles()
        {
            cbRol.DataSource = obUsuario.Listar_Roles();
            cbRol.DisplayMember = "NOMROL";
            cbRol.ValueMember = "IDROL";
        }
        private void ListarDepartamento()
        {
            cbDepartamento.DataSource = obUsuario.Listar_Departamento();
            cbDepartamento.DisplayMember = "NOMDEP";
            cbDepartamento.ValueMember = "IDDEP";
        }
        private void ListarMunicipio(string idedep)
        {
            cbCiudad.DataSource = obUsuario.Listar_Municipios(idedep);
            cbCiudad.DisplayMember = "NOMMUN";
            cbCiudad.ValueMember = "IDMUN";
        }
        private void ListarZona(string idemun)
        {
            cbZona.DataSource = obUsuario.Listar_Zona(idemun);
            cbZona.DisplayMember = "NOMZONA";
            cbZona.ValueMember = "IDZONA";
        }
        private void ContarUsuario()
        {
            lblCantidad.Text = obUsuario.Cantidad_Usuario();
        }
        //inversa **********************************************************************
        public string Dato_Departamento(string id_mun)
        {
           return obUsuario.IListar_Departamento(id_mun);         
        }
        public string Dato_municipio(string id_zona)
        {
           return obUsuario.IListar_Municipios(id_zona);
        }
        // *****************************************************************************
        private void MostrarUsuarios()
        {
            dgUsuarios.RowTemplate.Height = 45;
            dgUsuarios.DataSource =obUsuario.Mostrar_Usuarios();
            DataGridViewImageColumn im = new DataGridViewImageColumn();
            im = (DataGridViewImageColumn)dgUsuarios.Columns[13];
            im.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgUsuarios.Refresh();
        }
        //--------------------insertar imagen-----------------------------------------------
        public Byte[] InsertarImagen(PictureBox pbUsu)
        {
            MemoryStream me = new MemoryStream();
            pbUsu.Image.Save(me, pbUsu.Image.RawFormat);
            byte[] imagen = me.GetBuffer();
            return imagen;
        }
 //-----------------------------------------------------------------------------------------       
        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxInventario_Click_1(object sender, EventArgs e)
        {

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
            AUsuarios usu = new AUsuarios();
            Encriptacion.Encriptar encriptar = new Encriptacion.Encriptar();
            if (ValidarCampos())
            {
                ErrorP.Clear();
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            usu._Nombre = txtNombre.Text;
                            usu._Apellido = txtApellido.Text;
                            usu._IdSucursal = Convert.ToInt32(cbSucursal.SelectedValue);
                            usu._Contraseña = encriptar._Encriptar(txtContraseña.Text);
                            usu._IdTipDoc = Convert.ToInt32(cbTipoDoc.SelectedValue);
                            usu._Documento = Convert.ToInt64(txtDocumento.Text);
                            usu._Telefono = txtTelefono.Text;
                            usu._IdRol = Convert.ToInt32(cbRol.SelectedValue);
                            usu._Correo = txtCorreo.Text;
                            usu._Genero = Convert.ToInt32(cbGenero.SelectedValue);
                            usu._Direccion = txtDireccion.Text;
                            usu._IdZona = Convert.ToInt32(cbZona.SelectedValue);
                            usu._Imagen = InsertarImagen(pbUsuario);
                            obUsuario.Insert_Usuario(usu);
                            MostrarUsuarios();
                            limpiar();
                            ContarUsuario();
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
                            usu._Id = Convert.ToInt32(txtID.Text);
                            usu._Nombre = txtNombre.Text;
                            usu._Apellido = txtApellido.Text;
                            usu._IdSucursal = Convert.ToInt32(cbSucursal.SelectedValue);
                            usu._Contraseña = encriptar._Encriptar(txtContraseña.Text);
                            usu._IdTipDoc = Convert.ToInt32(cbTipoDoc.SelectedValue);
                            usu._Documento = Convert.ToInt64(txtDocumento.Text);
                            usu._Telefono = txtTelefono.Text;
                            usu._IdRol = Convert.ToInt32(cbRol.SelectedValue);
                            usu._Correo = txtCorreo.Text;
                            usu._Genero = Convert.ToInt32(cbGenero.SelectedValue);
                            usu._Direccion = txtDireccion.Text;
                            usu._IdZona = Convert.ToInt32(cbZona.SelectedValue);
                            usu._Imagen = InsertarImagen(pbUsuario);
                            obUsuario.Editar_Usuario(usu);
                            limpiar();
                            MostrarUsuarios();
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
            else
            {
                MessageBox.Show("Dejó datos obligatorios sin llenar");
            }


        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Encriptacion.Encriptar en = new Encriptacion.Encriptar();
            try
            {
                if (dgUsuarios.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
                    txtApellido.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
                    cbSucursal.SelectedValue = dgUsuarios.CurrentRow.Cells[3].Value.ToString();
                    txtContraseña.Text =en._Desencriptar(dgUsuarios.CurrentRow.Cells[4].Value.ToString());
                    cbTipoDoc.SelectedValue = dgUsuarios.CurrentRow.Cells[5].Value.ToString();
                    txtDocumento.Text = dgUsuarios.CurrentRow.Cells[6].Value.ToString();
                    txtTelefono.Text = dgUsuarios.CurrentRow.Cells[7].Value.ToString();
                    cbRol.SelectedValue = dgUsuarios.CurrentRow.Cells[8].Value.ToString();
                    txtCorreo.Text = dgUsuarios.CurrentRow.Cells[9].Value.ToString();
                    cbGenero.SelectedValue = dgUsuarios.CurrentRow.Cells[10].Value.ToString();
                    txtDireccion.Text = dgUsuarios.CurrentRow.Cells[11].Value.ToString();
//-----------------------------------------imagen-------------------------------------------
                    byte[] img = (byte[])dgUsuarios.CurrentRow.Cells[13].Value;
                    MemoryStream ms = new MemoryStream(img);
                    pbUsuario.Image = Image.FromStream(ms);
//------------------------------------------------------------------------------------------             
                    ListarDepartamento();
                    cbDepartamento.SelectedValue = Dato_Departamento(Dato_municipio(dgUsuarios.CurrentRow.Cells[12].Value.ToString()));
                    
                    ListarMunicipio(Dato_Departamento(Dato_municipio(dgUsuarios.CurrentRow.Cells[12].Value.ToString())));
                    cbCiudad.SelectedValue = Dato_municipio(dgUsuarios.CurrentRow.Cells[12].Value.ToString());
                    
                    ListarZona(Dato_municipio(dgUsuarios.CurrentRow.Cells[12].Value.ToString()));
                    cbZona.SelectedValue = dgUsuarios.CurrentRow.Cells[12].Value.ToString();                 

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
            txtApellido.Clear();
            txtTelefono.Clear();
            txtContraseña.Clear();
            txtDocumento.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            ListarDepartamento();
            ListarRoles();
            ListarSucursal();
            ListarTipoDocumento();
            ListarSexo();
            ReiniciarPB(pbUsuario);
        }
        public void ReiniciarPB(PictureBox pb)
        {
            pb.Image = Properties.Resources.icons8_administrador_del_hombre_480;
        }
        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.InitialDirectory = "C:\\";
            buscar.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            if(buscar.ShowDialog() == DialogResult.OK)
            {
                pbUsuario.ImageLocation = buscar.FileName;
            }
            else
            {
                 
                MessageBox.Show("Seleccione una imagen", "No Selecciono una Imagen");
            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void EliminarUsuario(AUsuarios da)
        {
            obUsuario.Eliminar_Usuario(da);
            ContarUsuario();
        }
        private string clientealerta()
        {
            string name = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            string lastname = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
            string fullname = name + " " + lastname;
            return fullname;
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            AUsuarios usu = new AUsuarios();
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente " + clientealerta() + "?", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    usu._Id = Convert.ToInt32(dgUsuarios.CurrentRow.Cells[0].Value.ToString());
                    EliminarUsuario(usu);
                    MostrarUsuarios();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
        //----------------------------validar que ingresen datos para ejecutar----------------------------------
        public bool ValidarCampos()
        {
            bool error = true;
            if (txtNombre.Text.Trim() == "")
            {
                ErrorP.SetError(txtNombre, "Introduce nombre");
                error = false;
            }
            if (txtApellido.Text.Trim() == "")
            {
                ErrorP.SetError(txtApellido, "Introduce apellido");
                error = false;
            }
            if (txtDocumento.Text.Trim() == "")
            {
                ErrorP.SetError(txtDocumento, "Ingrese número de documento");
                error = false;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                ErrorP.SetError(txtTelefono, "Ingrese número de contacto");
                error = false;
            }
            if (txtCorreo.Text.Trim() == "")
            {
                ErrorP.SetError(txtCorreo, "Ingrese un correo");
                error = false;
            }
            if (txtContraseña.Text.Trim() == "")
            {
                ErrorP.SetError(txtContraseña, "Ingrese una contraseña");
                error = false;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                ErrorP.SetError(txtDireccion, "Ingrese dirección");
                error = false;
            }
            return error;
        }
        //----------------------------------------validacion por tamaño---------------------------------------------------
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

        private void txtApellido_Validated(object sender, EventArgs e)
        {
            if (txtApellido.Text.Length > 0)
            {
                ErrorP.SetError(txtApellido, "");
            }
            else
            {
                ErrorP.SetError(txtNombre, "Introduce apellido");
            }
        }

        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Length > 0)
            {
                ErrorP.SetError(txtDocumento, "");
            }
            else
            {
                ErrorP.SetError(txtDocumento, "Ingrese número de documento");
            }
        }

        private void txtTelefono_Validated(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 0)
            {
                ErrorP.SetError(txtTelefono, "");
            }
            else
            {
                ErrorP.SetError(txtDocumento, "Ingrese número de contacto");
            }
        }

        private void txtCorreo_Validated(object sender, EventArgs e)
        {
            if (txtCorreo.Text.Length > 0)
            {
                ErrorP.SetError(txtCorreo, "");
            }
            else
            {
                ErrorP.SetError(txtCorreo, "Ingrese un correo");
            }
        }

        private void txtContraseña_Validated(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length > 0)
            {
                ErrorP.SetError(txtContraseña, "");
            }
            else
            {
                ErrorP.SetError(txtContraseña, "Ingrese una contraseña");
            }
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Length > 0)
            {
                ErrorP.SetError(txtDireccion, "");
            }
            else
            {
                ErrorP.SetError(txtDireccion, "Ingrese una dirección");
            }
        }
        //-----------------------------valida los datos de entrada(tipo de dato)-----------------------------------
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFiltroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            string dato = txtFiltroDocumento.Text;            
            dgUsuarios.RowTemplate.Height = 45;
            dgUsuarios.DataSource = obUsuario.Filtrar_Cliente(dato);
            DataGridViewImageColumn im = new DataGridViewImageColumn();
            im = (DataGridViewImageColumn)dgUsuarios.Columns[13];
            im.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgUsuarios.Refresh();
        }

        //--------------------------------------------------------------------------------------------------

    }
}
