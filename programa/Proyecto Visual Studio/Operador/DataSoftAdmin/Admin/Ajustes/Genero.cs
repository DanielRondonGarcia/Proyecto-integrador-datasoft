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

namespace Operador.Ajustes
{
    public partial class Genero : Form
    {
        public Genero()
        {
            InitializeComponent();
        }

        bool estado = false;
        private DGenero con = new DGenero();
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void MostrarGenero()
        {
           dgGenero.DataSource = con.Mostrar_Genero();
        }
        private void Genero_Load(object sender, EventArgs e)
        {
            MostrarGenero();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AGenero g = new AGenero();
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            g._Nombre = txtNombre.Text;
                            con.Insertar_Genero(g);
                            MostrarGenero();
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
                MessageBox.Show("Ingrese Nombre del genero");
            }

            if (estado == true)
            {
                if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        g._Id = int.Parse(txtId.Text);
                        g._Nombre = txtNombre.Text;
                        con.Editar_Genero(g);
                        MostrarGenero();
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
                if (dgGenero.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtId.Text = dgGenero.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgGenero.CurrentRow.Cells[1].Value.ToString();

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
        public void EliminarGenero(AGenero g)
        {
            con.Eliminar_Genero(g);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AGenero g = new AGenero();
            if (dgGenero.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente ", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string dato = dgGenero.CurrentRow.Cells[0].Value.ToString();
                    g._Id = Convert.ToInt32(dato);
                    EliminarGenero(g);
                    MostrarGenero();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
