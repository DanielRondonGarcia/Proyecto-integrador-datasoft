﻿using System;
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
    public partial class Categoria : Form
    {
        DCategoria con = new DCategoria();
        public Categoria()
        {
            InitializeComponent();
        }
        bool estado = false;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MostrarCategoria()
        {
            dgCategoria.DataSource = con.Mostrar_Categoria();
        }
        private void Categoria_Load(object sender, EventArgs e)
        {
            MostrarCategoria();
        }
        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ACategoria c = new ACategoria();
            if (txtNombre.Text != "")
            {
                if (estado == false)
                {
                    if (MessageBox.Show("¡Se guardaran nuevos datos!", "CUIDADO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            c._Nombre = txtNombre.Text;
                            con.Insertar_Categoria(c);
                            MostrarCategoria();
                            limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Se genero error al agregar: " + ex.ToString());
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
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
                        con.Editar_Categoria(c);
                        MostrarCategoria();
                        limpiar();
                        btnCancelarEdicion.Visible = false;
                        estado = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se genero error guardaba edición: " + ex.ToString());
                    }
                }
            }
            else
            {
                //tus codigos
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCategoria.SelectedRows.Count > 0)
                {
                    estado = true;
                    txtID.Text = dgCategoria.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgCategoria.CurrentRow.Cells[1].Value.ToString();

                    btnCancelarEdicion.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se genero error al editar: " + ex.ToString());
            }
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiar();
            estado = false;
            btnCancelarEdicion.Visible = false;
        }
        public void EliminarCategoria(ACategoria c)
        {
            con.Eliminar_Categoria(c);
        }
        public string AlertaEliminar()
        {
            string cat = dgCategoria.CurrentRow.Cells[1].Value.ToString();
            return cat;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ACategoria c = new ACategoria();
            if (dgCategoria.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar esta categoria " + AlertaEliminar() + "? ", "¡ALERTA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string dato = dgCategoria.CurrentRow.Cells[0].Value.ToString();
                    c._Id = Convert.ToInt32(dato);
                    EliminarCategoria(c);
                    MostrarCategoria();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
