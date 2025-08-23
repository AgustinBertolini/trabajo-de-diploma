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
    public partial class FormBitacora : Form, IIdiomaObserver
    {
        public FormBitacora()
        {
            InitializeComponent();
            Traducir();
            CargarBitacora(null);
            UsuarioBLL usuario = new UsuarioBLL();
            comboBox1.DataSource = usuario.GetUsuarios();
            comboBox1.DisplayMember = "Email";
        }

        public void CargarBitacora(int? idUsuario)
        {
            if (!(SessionManager.TienePermiso("Bitacora") || SessionManager.TienePermiso("Listar Bitacora")))
            {
                MessageBox.Show("No tenes permisos suficientes para ver la bitacora");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            List<Usuario> usuarios = usuarioBLL.GetUsuarios();

            var data = Bitacoras.GetBitacoras().Select(bitacora => new
            {
                Fecha = bitacora.Fecha,
                TipoEvento = bitacora.TipoEvento,
                Mensaje = bitacora.Mensaje,
                IdUsuario = bitacora.IdUsuario,
                Usuario = usuarios.FirstOrDefault(u => u.Id == bitacora.IdUsuario).Email
            }).OrderByDescending(b => b.Fecha).ToList();

            if(idUsuario != null)
            {
                data = data.Where(bitacora => bitacora.IdUsuario == idUsuario).OrderByDescending(b => b.Fecha).ToList();
            }

            var dataSource = data;

            dataGridView1.DataSource = dataSource;
            dataGridView1.Columns["Mensaje"].Width = 300;
            dataGridView1.Columns["IdUsuario"].Visible = false;
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

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            SessionManager.GetInstance.SuscribirObservador(this);
        }
        
        private void FormBitacora_FormClosing(object sender, EventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
        }

        public void MarcarIdioma()
        {
            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;

            Idioma nuevoIdioma = Traductor.CambiarIdioma(idiomaSeleccionado.Id);

            SessionManager.CambiarIdioma(nuevoIdioma);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            usuarios.Show();

            this.Hide();
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Logout();

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }

        private void traduccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)comboBox1.SelectedItem;
            
            CargarBitacora(usuario.Id);
        }
    }
}
