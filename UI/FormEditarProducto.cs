using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Servicios;

namespace UI
{
    public partial class FormEditarProducto : Form
    {
        public FormEditarProducto(int id)
        {
            InitializeComponent();
            Traducir();
            txtId.Hide();
            txtId.Text = id.ToString();
            CargarVendedores();
            numericUpDown1.Maximum = 9999999;
            numericStock.Maximum = 9999999;

            ProductoBLL productoBLL = new ProductoBLL();
            var producto = productoBLL.GetProducto(id);
            inputNombre.Text = producto.Nombre;
            numericUpDown1.Value = producto.Precio;
            numericStock.Value = producto.Stock;

            if (!SessionManager.TienePermiso("Editar Producto"))
            {
                MessageBox.Show("No tienes permisos suficientes para editar un producto.");
                FormProductos form = new FormProductos();
                form.Show();
                this.Hide();
                return;
            }
        }

        public void CargarVendedores()
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            var usuarios = usuarioBLL.GetUsuarios();

            comboUsuarios.SelectedItem = null;

            ProductoBLL productoBLL = new ProductoBLL();

            var vendedoresAsignados = productoBLL.GetProductoVendedores(Convert.ToInt32(txtId.Text));

            var vendedoresAsignadosIds = vendedoresAsignados.Select(v => v.IdUsuario).ToList();

            comboUsuarios.DataSource = usuarios.Where(u => u.Rol.Nombre == "VENDEDOR" && !vendedoresAsignadosIds.Contains(u.Id)).Select(u => new { u.Id, NombreCompleto = u.Nombre + " " + u.Apellido }).ToList();

            comboUsuarios.DisplayMember = "NombreCompleto";
            comboUsuarios.ValueMember = "Id";

            dataGridView1.DataSource = null;

            if (vendedoresAsignados.Count > 0)
            {

                dataGridView1.DataSource = vendedoresAsignados.Select(v => new { v.IdUsuario, NombreCompleto = v.Nombre + " " + v.Apellido }).ToList();

                dataGridView1.Columns["IdUsuario"].Visible = false;
            }
        }

        public void Traducir()
        {
            var idioma = SessionManager.GetInstance.Usuario.Idioma;

            var traducciones = Traductor.GetTraducciones(idioma.Id);

            foreach (Control control in this.Controls)
            {
                if (control.Tag != null)
                {
                    var tag = control.Tag.ToString();
                    var traduccion = traducciones.FirstOrDefault(x => x.Tag == tag);
                    if (traduccion != null)
                        control.Text = traduccion.Valor;
                }
            }
        }

        private void FormEditarProducto_Load(object sender, EventArgs e)
        {
            numericStock.Maximum = 9999999;
            numericUpDown1.Maximum = 9999999;

            comboUsuarios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboUsuarios.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void FormEditarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputNombre.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
                return;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("El campo precio es obligatorio");
                return;
            }
            
            if (numericStock.Value <= 0)
            {
                MessageBox.Show("El campo stock es obligatorio");
                return;
            }

            ProductoBLL productoBLL = new ProductoBLL();

            productoBLL.EditarProducto(Convert.ToInt32(txtId.Text), inputNombre.Text, (int)numericUpDown1.Value, (int)numericStock.Value);

            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void comboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAsignarUsuario_Click(object sender, EventArgs e)
        {
            if (comboUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un vendedor para asignar.");
                return;
            }

            var selected = comboUsuarios.SelectedItem;
            int userId = (int)comboUsuarios.SelectedValue;
            int productId = Convert.ToInt32(txtId.Text);

            ProductoBLL productoBLL = new ProductoBLL();
            bool resultado = productoBLL.AsignarProducto(userId, productId);

            if (resultado)
                MessageBox.Show("Usuario asignado correctamente al producto.");
            else
                MessageBox.Show("No se pudo asignar el usuario al producto.");

            CargarVendedores();

        }

        private void btnDesasignarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un vendedor en la lista para desasignar.");
                return;
            }

            int userId = (int)dataGridView1.SelectedRows[0].Cells["IdUsuario"].Value;
            int productId = Convert.ToInt32(txtId.Text);

            ProductoBLL productoBLL = new ProductoBLL();
            bool resultado = productoBLL.DesasignarProducto(userId, productId);

            if (resultado)
                MessageBox.Show("Usuario desasignado correctamente del producto.");
            else
                MessageBox.Show("No se pudo desasignar el usuario del producto.");

            CargarVendedores();
        }
    }
}
