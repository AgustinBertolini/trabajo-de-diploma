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
    public partial class FormEditarTraduccion : Form
    {
        public FormEditarTraduccion(Traduccion traduccion)
        {
            InitializeComponent();
            txtIdHidden.Hide();
            txtIdHidden.Text = traduccion.Id.ToString();
            txtNombre.Text = traduccion.Valor;
            txtTag.Text = traduccion.Tag;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEditarTraduccion_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormTraducciones form = new FormTraducciones();

            form.Show();

            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
                return;
            }

            var traduccionHistorica = Traductor.GetTraduccion(Convert.ToInt32(txtIdHidden.Text));
            TraduccionHistoricoBLL traduccionHistoricoBLL = new TraduccionHistoricoBLL();

            traduccionHistoricoBLL.CrearHistorico(traduccionHistorica.Valor, txtNombre.Text, traduccionHistorica.Id);

            Traductor.EditarTraduccion(Convert.ToInt32(txtIdHidden.Text), txtNombre.Text);

            var traduccion = Traductor.GetTraduccion(Convert.ToInt32(txtIdHidden.Text));
            var idIdioma = traduccion.IdIdioma;

            var idiomas = Traductor.GetIdiomas();
            var idioma = idiomas.FirstOrDefault(t => t.Id == idIdioma);

            if(idioma != null)
            {
                Bitacoras.AltaBitacora("Traducción modificada: '" + txtNombre.Text + "' para el idioma " + idioma.Nombre, TipoEvento.Warning, SessionManager.GetInstance.Usuario.Id);
            }



        


            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();
        }

        private void txtIdIdiomaHidden_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
