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
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
        }
        bool estado = false;
        private DColor con = new DColor();
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Color_Load(object sender, EventArgs e)
        {
            MostrarColor();
        }
        public void MostrarColor()
        {
            dgColor.DataSource = con.Mostrar_Color();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AColor c = new AColor();
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            c._Nombre = txtNombre.Text;
                            con.Insertar_Color(c);
                            MostrarColor();
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
                MessageBox.Show("Ingrese Nombre del Color");
            }

            if (estado == true)
            {
                if (MessageBox.Show("¿Guardar cambios?", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        c._Id = int.Parse(txtID.Text);
                        c._Nombre = txtNombre.Text;
                        con.Editar_color(c);
                        MostrarColor();
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
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgColor.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgColor.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgColor.CurrentRow.Cells[1].Value.ToString();

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
        public void EliminarColor(AColor c)
        {
            con.Eliminar_Color(c);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AColor col = new AColor();
            if (dgColor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el color? ", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string dato = dgColor.CurrentRow.Cells[0].Value.ToString();
                    col._Id = Convert.ToInt32(dato);
                    EliminarColor(col);
                    MostrarColor();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
