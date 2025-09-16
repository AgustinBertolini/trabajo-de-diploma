using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            // Cargar productos
            ProductoBLL productoBLL = new ProductoBLL();
            var productos = productoBLL.GetProductos();
            this.dgvProductos.DataSource = productos;

            // Cargar usuarios
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            var usuarios = usuarioBLL.GetUsuarios();
            this.dgvUsuarios.DataSource = usuarios;

            // Ocultar columnas sensibles
            if (this.dgvUsuarios.Columns["Contraseña"] != null)
                this.dgvUsuarios.Columns["Contraseña"].Visible = false;
            if (this.dgvUsuarios.Columns["DV"] != null)
                this.dgvUsuarios.Columns["DV"].Visible = false;
        }
    }
}
