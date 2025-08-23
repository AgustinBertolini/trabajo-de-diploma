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
    public partial class FormUsuarios : Form, IIdiomaObserver
    {
        public FormUsuarios()
        {
            InitializeComponent();
            Traducir();
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
            if (!(SessionManager.TienePermiso("Usuarios") || SessionManager.TienePermiso("Listar Usuario")))
            {
                MessageBox.Show("No tenes permisos suficientes para listar usuarios");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();   
            dataGridView1.DataSource = usuarioBLL.GetUsuarios();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Contraseña"].Visible = false;
            dataGridView1.Columns["IsActive"].Visible = false;
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

            usuarioBLL.BorrarUsuario(id);

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
    }
}
