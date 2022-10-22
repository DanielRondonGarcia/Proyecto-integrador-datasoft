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
    public partial class Marca : Form
    {
        public Marca()
        {
            InitializeComponent();
        }
        bool estado = false;
        private DMarca con = new DMarca();
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Marca_Load(object sender, EventArgs e)
        {
            MostrarMarca();
        }
        public void MostrarMarca()
        {
            dgMarca.DataSource = con.Mostrar_Marca();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AMarca m = new AMarca();
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            m._Nombre = txtNombre.Text;
                            con.Insertar_Marca(m);
                            MostrarMarca();
                            limpiar();
                            MessageBox.Show("Agregado Correctamente");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo guardar los datos");
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
                MessageBox.Show("Ingrese Nombre de Marca");
            }

            if (estado == true)
            {
                if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        m._Id = int.Parse(txtId.Text);
                        m._Nombre = txtNombre.Text;
                        con.Editar_Marca(m);
                        MostrarMarca();
                        limpiar();
                        btnCancelarEdicion.Visible = false;
                        estado = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMarca.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtId.Text = dgMarca.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgMarca.CurrentRow.Cells[1].Value.ToString();

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
    }
}
