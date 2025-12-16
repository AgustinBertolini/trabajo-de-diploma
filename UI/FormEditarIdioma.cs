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
    public partial class FormEditarIdioma : Form
    {
        public FormEditarIdioma(Idioma idioma)
        {
            InitializeComponent();
            Traducir();
            txtIdHidden.Text = idioma.Id.ToString();
            txtNombre.Text = idioma.Nombre;

            List<Idioma> permisos = new List<Idioma>();
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

        private void FormEditarIdioma_Load(object sender, EventArgs e)
        {
            txtIdHidden.Hide();

        }

        private void FormEditarIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormTraducciones form = new FormTraducciones();
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

                IdiomaBLL idiomaBLL = new IdiomaBLL();

                idiomaBLL.EditarIdioma(Convert.ToInt32(txtIdHidden.Text), txtNombre.Text);
                Bitacoras.AltaBitacora("ATENCION --> El idioma: " + txtNombre.Text + " fue modificado", TipoEvento.Warning, SessionManager.GetInstance.Usuario.Id);

                FormTraducciones traducciones = new FormTraducciones();
                traducciones.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
