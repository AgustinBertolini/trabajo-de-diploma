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

            ProductoBLL productoBLL = new ProductoBLL();

            productoBLL.EditarProducto(Convert.ToInt32(txtId.Text), inputNombre.Text, (int)numericUpDown1.Value);

            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }
    }
}
