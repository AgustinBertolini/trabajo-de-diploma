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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormTraducciones : Form, IIdiomaObserver
    {
        public FormTraducciones()
        {
            InitializeComponent();
            Traducir();
            CargarIdiomas(true);
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

        private void CargarIdiomas(bool recargarIdiomas)
        {
            if (!(SessionManager.TienePermiso("Traducciones") || SessionManager.TienePermiso("Listar Idiomas")))
            {
                MessageBox.Show("No tenes permisos suficientes");
                return;
            }

            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;


            IdiomaBLL idiomaBLL = new IdiomaBLL();

            List<Idioma> idiomas = idiomaBLL.GetIdiomas();

            if(recargarIdiomas)
            {
                dataGridView1.DataSource = idiomas;

                dataGridView1.Columns["Id"].Visible = false;

                comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

                comboBox1.DataSource = idiomas;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.SelectedItem = idiomaSeleccionado;

                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            }

            dataGridView2.DataSource = Traductor.GetTraducciones(idiomaSeleccionado.Id);
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["idIdioma"].Visible = false;
            dataGridView2.Columns["Tag"].Width = 160;
            dataGridView2.Columns["Valor"].Width = 160;
        }

        private void FormTraducciones_Load(object sender, EventArgs e)
        {
            SessionManager.GetInstance.SuscribirObservador(this);
        }

        private void FormTraducciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();
            CargarIdiomas(false);

        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            usuarios.Show();

            this.Hide();
        }

        private void tag_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Traducciones") || SessionManager.TienePermiso("Agregar Idioma")))
            {
                MessageBox.Show("No tenes permisos suficientes");
                return;

            }
            FormAgregarIdioma form = new FormAgregarIdioma();

            form.Show();

            this.Hide();
        }

        private void borrarIdiomaBtn_Click(object senPermisosder, EventArgs e)
        {

            if (!(SessionManager.TienePermiso("Traducciones") || SessionManager.TienePermiso("Borrar Idioma")))
            {
                MessageBox.Show("No tenes permisos suficientes");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un idioma seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico idioma");
                return;
            }

            IdiomaBLL idiomaBLL = new IdiomaBLL();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            idiomaBLL.BorrarIdioma(id);

            CargarIdiomas(true);
        }

        private void editarIdiomaBtn_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Traducciones") || SessionManager.TienePermiso("Editar Idioma")))
            {
                MessageBox.Show("No tenes permisos suficientes para editar un producto");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un idioma seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico idioma");
                return;
            }


            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            IdiomaBLL idiomaBLL = new IdiomaBLL();

            Idioma idioma = idiomaBLL.GetIdioma(id);

            FormEditarIdioma form = new FormEditarIdioma(idioma);
            form.Show();

            this.Hide();
        }

        public void MarcarIdioma()
        {
            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;

            Idioma nuevoIdioma = Traductor.CambiarIdioma(idiomaSeleccionado.Id);

            SessionManager.CambiarIdioma(nuevoIdioma);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un idioma");
                return;
            }

            Idioma idioma = (Idioma)comboBox1.SelectedItem;

            SessionManager.CambiarIdioma(idioma);


        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos form = new FormPermisos();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditarTraduccion_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Traducciones") || SessionManager.TienePermiso("Editar Traduccion")))
            {
                MessageBox.Show("No tenes permisos suficientes para editar una traduccion");
                return;
            }

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay una traduccion seleccionada");
                return;
            }

            if (dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar una unica traduccion");
                return;
            }


            int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);

            

            Traduccion traduccion = Traductor.GetTraduccion(id);

            FormEditarTraduccion form = new FormEditarTraduccion(traduccion);
            form.Show();

            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            FormHistorico form = new FormHistorico();

            form.Show();

            this.Hide();
        }
    }
}
