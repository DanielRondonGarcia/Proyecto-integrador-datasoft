using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.DAjustes;
using AccesoOracle.AjustesData;

namespace Gerente.Ajustes
{
    public partial class TipoDocumento : Form
    {
        public TipoDocumento()
        {
            InitializeComponent();
        }
        bool estado = false;
        private DTipoDocumento con = new DTipoDocumento();
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void MostrarTipoDocumento()
        {
            dgTipoDoc.DataSource = con.Mostrar_TipoDocumento();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ATipoDocumento td = new ATipoDocumento();
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            td._Nombre = txtNombre.Text;
                            con.Insertar_TipoDocumento(td);
                            MostrarTipoDocumento();
                            limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error "+ex.ToString());
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
                //poner validacion
                MessageBox.Show("Ingrese Nombre de Documento");
            }

            if (estado == true)
            {
                if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        td._Id = int.Parse(txtId.Text);
                        td._Nombre = txtNombre.Text;
                        con.Editar_TipoDocumento(td);
                        MostrarTipoDocumento();
                        limpiar();
                        btnCancelarEdicion.Visible = false;
                        estado = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error editar "+ex.ToString());
                    }
                }
            }
            else
            {
                //tus codigos
            }
        }
        private void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
        }

        private void TipoDocumento_Load(object sender, EventArgs e)
        {
            MostrarTipoDocumento();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgTipoDoc.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtId.Text = dgTipoDoc.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgTipoDoc.CurrentRow.Cells[1].Value.ToString();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea eliminar el tipo de documento?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }
    }
}
