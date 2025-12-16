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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormAgregarPermiso : Form
    {
        public FormAgregarPermiso()
        {
            InitializeComponent();
            Traducir();
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

                permisoBLL.AltaPermiso(txtNombre.Text, true);

                FormPermisos permisos = new FormPermisos();
                permisos.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void checkEsPadre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboHijo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAgregarPermiso_Load(object sender, EventArgs e)
        {

        }

        private void FormAgregarPermiso_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }
    }
}
