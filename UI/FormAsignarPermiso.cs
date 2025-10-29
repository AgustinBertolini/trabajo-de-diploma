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
    public partial class FormAsignarPermiso : Form
    {
        int idUsuario = 0;
        public FormAsignarPermiso(string usuario,int idUsuario)
        {
            InitializeComponent();
            Traducir();
            labelTitulo.Text = "Asignar permiso a usuario " + usuario;
            PermisoBLL permisoBLL = new PermisoBLL();

            comboBox1.DataSource = permisoBLL.GetPermisos();
            comboBox1.DisplayMember = "Nombre";
            this.idUsuario = idUsuario;
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

        private void FormAsignarPermiso_Load(object sender, EventArgs e)
        {

        }

        private void FormAsignarPermiso_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            usuarios.Show();

            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un permiso");
                return;
            }

            Permiso permiso = (Permiso)comboBox1.SelectedItem;

            PermisoBLL permisoBLL = new PermisoBLL();
            permisoBLL.AsignarPermiso(idUsuario, permiso.Id);

            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }
    }
}
