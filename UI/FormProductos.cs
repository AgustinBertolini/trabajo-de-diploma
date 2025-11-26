using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using Servicios;

namespace UI
{
    public partial class FormProductos : Form, IIdiomaObserver
    {
        public FormProductos()
        {
            InitializeComponent();
            CargarProducto();
            Traducir();
            dataGridView1.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();
        }

        private void CargarProducto()
        {
            ProductoBLL productoBLL = new ProductoBLL();
            if (SessionManager.GetInstance.Usuario.Rol.Nombre == "VENDEDOR")
            {
                dataGridView1.DataSource = productoBLL.GetProductosSinFiltrosByUserId(SessionManager.GetInstance.Usuario.Id);
                dataGridView1.Columns["Activo"].Visible = false;
            }
            else
            {
                dataGridView1.DataSource = productoBLL.GetProductosSinFiltros();
            }

            dataGridView1.Columns["Id"].Visible = false;
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Productos") || SessionManager.TienePermiso("Borrar Producto")))
            {
                MessageBox.Show("No tenes permisos suficientes para borrar un producto");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un producto seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico producto");
                return;
            }

            ProductoBLL productoBLL = new ProductoBLL();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            productoBLL.BorrarProducto(id);

            CargarProducto();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Productos") || SessionManager.TienePermiso("Crear Producto")))
            {
                MessageBox.Show("No tenes permisos suficientes para crear un producto");
                return;
            }

            FormAgregarProducto form = new FormAgregarProducto();
            form.Show();

            this.Hide();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Productos") || SessionManager.TienePermiso("Editar Producto")))
            {
                MessageBox.Show("No tenes permisos suficientes para editar un producto");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un producto seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico producto");
                return;
            }


            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            FormEditarProducto form = new FormEditarProducto(id);
            form.Show(); 
            
            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Logout();

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            SessionManager.GetInstance.SuscribirObservador(this);
            
            if(SessionManager.GetInstance.Usuario.Rol.Nombre == "VENDEDOR")
            {
                btnActivarProducto.Visible = false;
            }
        }

        private void FormProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
        }

        public void MarcarIdioma()
        {
            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;

            Idioma nuevoIdioma = Traductor.CambiarIdioma(idiomaSeleccionado.Id);

            SessionManager.CambiarIdioma(nuevoIdioma);
        }


        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones = new FormTraducciones();
            formTraducciones.Show();

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora form = new FormBitacora();
            form.Show();

            this.Hide();
        }

       

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

            this.Hide();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPresupuesto formPresupuesto = new FormPresupuesto();

            formPresupuesto.Show();

            this.Hide();
        }

        private void btnActivarProducto_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Productos") || SessionManager.TienePermiso("Activar Producto")))
            {
                MessageBox.Show("No tenes permisos suficientes para borrar un producto");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un producto seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico producto");
                return;
            }

            ProductoBLL productoBLL = new ProductoBLL();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool activo = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Activo"].Value);

            if(activo == true)
            {
                MessageBox.Show("El producto ya esta activo");
                return;
            }

            productoBLL.ActivarProducto(id);

            CargarProducto();
        }
    }
}
