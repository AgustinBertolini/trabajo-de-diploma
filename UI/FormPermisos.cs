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
using Entidades;
using Servicios;

namespace UI
{
    public partial class FormPermisos : Form, IIdiomaObserver
    {
        public FormPermisos()
        {
            InitializeComponent();
            Traducir();
            MostrarItemsSegunPermisos();
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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Logout();

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
    }

        private void CargarPermisos()
        {
            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Listar Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes para listar permisos");
                return;
            }

            treeView1.Nodes.Clear();

            PermisoBLL permisoBLL = new PermisoBLL();
            var permisos = permisoBLL.GetPermisos();

            var arbol = permisoBLL.GetArbol();

            foreach (var raiz in arbol)
            {
                var nodo = CrearNodo(raiz);
                treeView1.Nodes.Add(nodo);
            }

        }

        private TreeNode CrearNodo(Entidades.Container container)
        {
            TreeNode nodo = new TreeNode(container.Nombre);
            nodo.Tag = container;

            if (container.Hijos != null)
            {
                foreach (var hijo in container.Hijos)
                {
                    nodo.Nodes.Add(CrearNodo(hijo));
                }
            }

            return nodo;
        }

        public int ObtenerIdDesdeNodo(TreeNode nodoSeleccionado)
        {
            if (nodoSeleccionado.Tag is Permiso permiso)
            {
                return permiso.Id;
            }
            else if (nodoSeleccionado.Tag is Familia familia)
            {
                return familia.Id;
            }

            return 0;
        }


        private void btnEditUser_Click(object sender, EventArgs e)
        {
            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Editar Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes para editar el permiso");
                return;
            }

            if (nodoSeleccionado == null)
            {
                MessageBox.Show("No hay un permiso seleccionado");
                return;
            }

            PermisoBLL permisoBLL = new PermisoBLL();

            int id = ObtenerIdDesdeNodo(nodoSeleccionado);

            Permiso permiso = permisoBLL.GetPermiso(id);

            FormEditarPermiso formEditarPermiso = new FormEditarPermiso(permiso);
            formEditarPermiso.Show();

            this.Hide();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Crear Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes para agregar un permiso");
                return;
            }

            FormAgregarPermiso formAgregarPermiso = new FormAgregarPermiso();
            formAgregarPermiso.Show();

            this.Hide();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Borrar Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes para borrar un permiso");
                return;
            }

            if (nodoSeleccionado == null)
            {
                MessageBox.Show("No hay un permiso seleccionado");
                return;
            }

            PermisoBLL permisoBLL = new PermisoBLL();

            int id = ObtenerIdDesdeNodo(nodoSeleccionado);

            permisoBLL.BorrarPermiso(id);

            CargarPermisos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuario = new FormUsuarios();
            formUsuario.Show();

            this.Hide();
        }

        private void btnVincularPermisos_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Vincular Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes para vincular permisos");
                return;
            }

            FormVincularPermisos form = new FormVincularPermisos();

            form.Show();

            this.Hide();
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            CargarPermisos();
            SessionManager.GetInstance.SuscribirObservador(this);
        }

        private void sesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        public void MarcarIdioma()
        {
            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;

            Idioma nuevoIdioma = Traductor.CambiarIdioma(idiomaSeleccionado.Id);

            SessionManager.CambiarIdioma(nuevoIdioma);
        }


        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarcarIdioma();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();
        }

        private void cambiarIdiomaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones = new FormTraducciones();
            formTraducciones.Show();

            this.Hide();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
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
                { "label_clientes", "Clientes" }
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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
