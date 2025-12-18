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

namespace UI
{
    public partial class FormInicioVendedor : Form, Entidades.IIdiomaObserver
    {
        public FormInicioVendedor()
        {
            InitializeComponent();
        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir();

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
                formExistente.Show();
                formExistente.Focus();
                formExistente.WindowState = FormWindowState.Normal;
            }
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

        private void FormInicioVendedor_Load(object sender, EventArgs e)
        {
            SessionManager.GetInstance.SuscribirObservador(this);

            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Click += (s, ev) => panel1_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel2.Controls)
            {
                ctrl.Click += (s, ev) => panel2_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel3.Controls)
            {
                ctrl.Click += (s, ev) => panel3_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel4.Controls)
            {
                ctrl.Click += (s, ev) => panel4_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel5.Controls)
            {
                ctrl.Click += (s, ev) => panel5_Click(panel5, EventArgs.Empty);
            }

            
        }

        private void FormInicioVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.GetInstance.DesuscribirObservador(this);
        }
        

        private void label3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormClientes>();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
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

        private void panel5_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Ventas")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a las ventas");
                return;
            }

            AbrirFormulario<FormVentas>();

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Presupuestos")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a los presupuestos");
                return;
            }

            AbrirFormulario<FormPresupuesto>();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormClientes>();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            ConversacionBLL conversacionBLL = new ConversacionBLL();

            Conversacion conversacion = conversacionBLL.GetConversacionesByUsuario(SessionManager.GetInstance.Usuario.Id).FirstOrDefault();
            int? id = null;

            if (conversacion != null)
            {
                id = conversacion.Id;
            }
            ;

            if (id != null)
            {
                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
            else
            {
                id = conversacionBLL.CrearConversacion();

                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            ConversacionBLL conversacionBLL = new ConversacionBLL();

            Conversacion conversacion = conversacionBLL.GetConversacionesByUsuario(SessionManager.GetInstance.Usuario.Id).FirstOrDefault();
            int? id = null;
            
            if(conversacion != null)
            {
                id = conversacion.Id;
            }
            ;

            if(id != null)
            {
                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
            else
            {
                if (!(SessionManager.TienePermiso("Presupuestos")))
                {
                    MessageBox.Show("No tenes permisos suficientes para acceder a los presupuestos");
                    return;
                }

                id = conversacionBLL.CrearConversacion();

                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormClientes>();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Presupuestos")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a los presupuestos");
                return;
            }

            AbrirFormulario<FormPresupuesto>();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Ventas")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a las ventas");
                return;
            }

            AbrirFormulario<FormVentas>();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Presupuestos")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a los presupuestos");
                return;
            }

            AbrirFormulario<FormPresupuesto>();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Ventas")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a las ventas");
                return;
            }

            AbrirFormulario<FormVentas>();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            ConversacionBLL conversacionBLL = new ConversacionBLL();

            Conversacion conversacion = conversacionBLL.GetConversacionesByUsuario(SessionManager.GetInstance.Usuario.Id).FirstOrDefault();
            int? id = null;

            if (conversacion != null)
            {
                id = conversacion.Id;
            }
            ;

            if (id != null)
            {
                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
            else
            {
                id = conversacionBLL.CrearConversacion();

                FormConversacion form = new FormConversacion(id);
                form.Show();
            }
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

        private void label15_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
        }

       
    }
}
