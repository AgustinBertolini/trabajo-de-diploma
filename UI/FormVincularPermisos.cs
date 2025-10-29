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
    public partial class FormVincularPermisos : Form, IIdiomaObserver
    {
        public FormVincularPermisos()
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

        private void FormVincularPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPermisos form = new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void FormVincularPermisos_Load(object sender, EventArgs e)
        {
            List<Permiso> permisos = new List<Permiso> ();

            PermisoBLL permisoBLL = new PermisoBLL();

            permisos = permisoBLL.GetPermisos();

            comboPadre.DataSource = permisos.Where(permiso => permiso.EsPadre == true).ToList();
            comboPadre.DisplayMember = "Nombre";

            comboHijo.DataSource = permisos.ToList();
            comboHijo.DisplayMember = "Nombre";

            comboPadre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPadre.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPadre.DropDownStyle = ComboBoxStyle.DropDown;

            comboHijo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboHijo.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboHijo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();

            this.Hide();
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if(comboPadre.SelectedItem == null)
            {
                 MessageBox.Show("Debe seleccionar un padre");
                return;
            }

            if(comboHijo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un hijo");
            }
            
            Permiso permisoPadre = (Permiso)comboPadre.SelectedItem;
            Permiso permisoHijo = (Permiso)comboHijo.SelectedItem;

            PermisoBLL permisoBLL = new PermisoBLL();
            permisoBLL.VincularPermisos(permisoPadre.Id, permisoHijo.Id);

            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();

            this.Hide();


        }

       
        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();
        }

        private void comboHijo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
