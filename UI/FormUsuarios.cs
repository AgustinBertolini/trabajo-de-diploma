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
using Abstraccion;
using BLL;
using Entidades;
using Servicios;

namespace UI
{
    public partial class FormUsuarios : Form, IIdiomaObserver
    {
        public FormUsuarios()
        {
            InitializeComponent();
            Traducir();
            dataGridView1.ReadOnly = true;
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

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarUsuarios()
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            dataGridView1.DataSource = usuarioBLL.GetUsuarios().Select(x => new { 
                x.Id,
                x.Nombre,
                x.Apellido,
                x.DNI,
                x.Email,
                Rol = x.Rol.Nombre 
            }).ToList();

            dataGridView1.Columns["Id"].Visible = false;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            this.CargarUsuarios();
            SessionManager.GetInstance.SuscribirObservador(this);
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Usuarios") || SessionManager.TienePermiso("Crear Usuario")))
            {
                MessageBox.Show("No tenes permisos suficientes para crear un usuario");
                return;
            }

            FormAgregarUsuario formAgregarUsuario = new FormAgregarUsuario();
            formAgregarUsuario.Show();

            this.Hide();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Usuarios") || SessionManager.TienePermiso("Borrar Usuario")))
            {
                MessageBox.Show("No tenes permisos suficientes para borrar un usuario");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un usuario seleccionado");
                return;
            }  

            if(dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico usuario");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();

            Usuario usuario = usuarioBLL.GetUsuario(email);

            bool usuarioBorrado = usuarioBLL.BorrarUsuario(id);

            if (usuarioBorrado)
            {
                Bitacoras.AltaBitacora("El usuario " + email + " fue dado de baja", TipoEvento.Message, SessionManager.GetInstance.Usuario.Id);

                var usuariosObtenidos = usuarioBLL.GetUsuarios();

                string digitoVerificador = DigitoVerificador.CalcularDigitoVerificador(usuariosObtenidos.Cast<IVerificableEntity>().ToList(), true);

                DigitoVerificador.GuardarDigitoVerificador(digitoVerificador);
            }

            CargarUsuarios();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Usuarios") || SessionManager.TienePermiso("Editar Usuario")))
            {
                MessageBox.Show("No tenes permisos suficientes para editar un usuario");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un usuario seleccionado");
                return;
            }  

            if(dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico usuario");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();

            Usuario usuario = usuarioBLL.GetUsuario(email);

            FormEditarUsuario formEditarUsuario = new FormEditarUsuario(usuario);
            formEditarUsuario.Show();

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos formPermiso = new FormPermisos();
            formPermiso.Show();

            this.Hide();
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Permisos") || SessionManager.TienePermiso("Asignar Permiso")))
            {
                MessageBox.Show("No tenes permisos suficientes");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un usuario seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico usuario");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            Usuario usuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;


            FormAsignarPermiso form = new FormAsignarPermiso(usuario.Nombre + " " + usuario.Apellido, usuario.Id);
            form.Show();

            this.Hide();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

     


        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora form = new FormBitacora();
            form.Show();
            
            this.Hide();
        }

        private void btnDesasignarPermiso_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Permisos")))
            {
                MessageBox.Show("No tenes permisos suficientes");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un usuario seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico usuario");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            Usuario usuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;

            PermisoBLL permisoBLL = new PermisoBLL();
            permisoBLL.DesasignarPermisos(usuario.Id);
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
                { "label_bitacora", "Bitacora" }
            };

            foreach (var item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Tag != null)
                    {
                        var tag = menuItem.Tag.ToString();
                        if(tag == "label_sesion")
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
    }
}
