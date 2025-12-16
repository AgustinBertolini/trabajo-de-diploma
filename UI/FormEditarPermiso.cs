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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UI
{
    public partial class FormEditarPermiso : Form
    {
        public FormEditarPermiso(Permiso permiso)
        {
            InitializeComponent();
            Traducir();
            txtIdHidden.Text = permiso.Id.ToString();
            txtNombre.Text = permiso.Nombre;

            List<Permiso> permisos = new List<Permiso>();

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

        private void FormEditarPermiso_Load(object sender, EventArgs e)
        {
            txtIdHidden.Hide();
        }

        private void FormEditarPermiso_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("El campo nombre es obligatorio");
                    return;
                }

                PermisoBLL permisoBLL = new PermisoBLL();

                permisoBLL.EditarPermiso(Convert.ToInt32(txtIdHidden.Text), txtNombre.Text);

                FormPermisos permisos = new FormPermisos();
                permisos.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtIdHidden_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkEsPadre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
