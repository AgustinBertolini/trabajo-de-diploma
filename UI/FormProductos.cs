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
            MostrarItemsSegunPermisos();
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

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item.Tag != null)
                {
                    var tag = item.Tag.ToString();
                    var traduccion = traducciones.FirstOrDefault(x => x.Tag == tag);
                    if (traduccion != null)
                        item.Text = traduccion.Valor;
                }

                if (item is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
                {
                    foreach (ToolStripItem subItem in menuItem.DropDownItems)
                    {
                        var tag = item.Tag.ToString();
                        var traduccion = traducciones.FirstOrDefault(x => x.Tag == tag);
                        if (traduccion != null)
                            item.Text = traduccion.Valor;
                    }
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
            dataGridView1.DataSource = productoBLL.GetProductos();

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

        private void MostrarItemsSegunPermisos()
        {
            var items = menuStrip1.Items;

            var permisosMap = new Dictionary<string, string>
            {
                { "label_usuarios", "Usuarios"},
                { "label_productos", "Productos"},
                { "label_permisos", "Permisos" },
                { "label_traducciones", "Traducciones" },
                { "label_bitacora", "Bitacora" },
                { "label_clientes", "Clientes" },
                { "label_presupuestos", "Presupuestos" },
                { "label_ventas", "Ventas" }
            };

            foreach (var item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Tag != null)
                    {
                        var tag = menuItem.Tag.ToString();
                        if (tag == "label_sesion")
                        {
                            menuItem.Visible = true;
                            continue;
                        }
                        if (SessionManager.TienePermiso(permisosMap[tag]))
                        {
                            menuItem.Visible = true;
                        }
                        else
                        {
                            menuItem.Visible = false;
                        }
                    }
                }
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

            this.Hide();
        }
    }
}
