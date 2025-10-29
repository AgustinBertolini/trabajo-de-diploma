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
using Servicios;

namespace UI
{
    public partial class FormAgregarIdioma : Form
    {
        public FormAgregarIdioma()
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
                return;
            }

            IdiomaBLL idiomaBll = new IdiomaBLL();

            idiomaBll.AltaIdioma(txtNombre.Text);

            FormTraducciones traducciones = new FormTraducciones();
            traducciones.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormTraducciones traducciones = new FormTraducciones();
            traducciones.Show();

            this.Hide();
        }

        private void FormAgregarIdioma_Load(object sender, EventArgs e)
        {

        }

        private void FormAgregarIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormTraducciones form= new FormTraducciones();
            form.Show();

            this.Hide();
        }
    }
}
