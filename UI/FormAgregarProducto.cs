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
    public partial class FormAgregarProducto : Form
    {
        public FormAgregarProducto()
        {
            InitializeComponent();
            Traducir();

            if (!SessionManager.TienePermiso("Editar Producto"))
            {
                MessageBox.Show("No tienes permisos suficientes para agregar un producto.");
                FormProductos form = new FormProductos();
                form.Show();
                this.Hide();
                return;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
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

            int userId = productoBLL.AltaProducto(inputNombre.Text, (int)numericUpDown1.Value, (int)numericStock.Value);

            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            numericStock.Maximum = 9999999;
            numericUpDown1.Maximum = 9999999;
        }

        private void FormAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }
    }
}
