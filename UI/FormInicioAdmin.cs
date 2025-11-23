using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormInicioAdmin : Form, IIdiomaObserver
    {
        public FormInicioAdmin()
        {
            InitializeComponent();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            var formExistente = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (formExistente == null)
            {
                T form = new T();
                form.Show();
            }
            else
            {
                formExistente.Focus();
                formExistente.WindowState = FormWindowState.Normal;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormUsuarios>();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormUsuarios>();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormUsuarios>();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormTraducciones>();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormTraducciones>();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormTraducciones>();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVentas>();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVentas>();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVentas>();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBitacora>();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBitacora>();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBitacora>();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormConversaciones>();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormConversaciones>();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormConversaciones>();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormPermisos>();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormPermisos>();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormPermisos>();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
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

        private void FormInicioAdmin_Load(object sender, EventArgs e)
        {
            SessionManager.GetInstance.SuscribirObservador(this);

            Idioma idiomaSeleccionado = SessionManager.GetInstance.Usuario.Idioma;

            IdiomaBLL idiomaBLL = new IdiomaBLL();

            List<Idioma> idiomas = idiomaBLL.GetIdiomas();

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            comboBox1.DataSource = idiomas;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.SelectedItem = idiomaSeleccionado;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void FormInicioAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
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
    }
}
