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
            CargarBitacora(null,null);
            UsuarioBLL usuario = new UsuarioBLL();
            comboBox1.DataSource = usuario.GetUsuarios();
            comboBox1.DisplayMember = "Email";
            dataGridView1.ReadOnly = true;
            MostrarItemsSegunPermisos();
        }

        public void CargarBitacora(int? idUsuario,DateTime? date)
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

            if (date != null)
            {
                data = data.Where(bitacora => bitacora.Fecha.Date == date.Value.Date).OrderByDescending(b => b.Fecha).ToList();
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

            if (usuario != null)
            {
                CargarBitacora(usuario.Id, null);
            }
            else
            {
                CargarBitacora(null, null);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            CargarBitacora(null,date);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Now;

            CargarBitacora(null, null);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }
    }
}
