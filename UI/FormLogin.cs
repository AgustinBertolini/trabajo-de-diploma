using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abstraccion;
using BLL;
using Entidades;
using Servicios;

namespace UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private Point initialPosition;


        private void D_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();

                string emailValue = txtEmail.Text;
                string contraseñaValue = txtContraseña.Text;

                if (string.IsNullOrEmpty(emailValue))
                {
                    MessageBox.Show("El campo email es obligatorio");
                    return;
                }

                if (!emailValue.Contains("@") && !emailValue.Contains("."))
                {
                    MessageBox.Show("El campo email tiene un valor invalido");
                    return;
                }

                if (string.IsNullOrEmpty(contraseñaValue))
                {
                    MessageBox.Show("El campo contraseña es obligatorio");
                    return;
                }

                bool login = usuarioBLL.Login(emailValue, contraseñaValue);

                if (login)
                {
                    Bitacoras.AltaBitacora("Nuevo inicio de sesión", TipoEvento.Message, SessionManager.GetInstance.Usuario.Id);

                    if (SessionManager.GetInstance.Usuario.Rol.Nombre == "VENDEDOR")
                    {
                        FormInicioVendedor form = new FormInicioVendedor();
                        form.Show();
                    }
                    else
                    {
                        FormInicioAdmin form = new FormInicioAdmin();
                        form.Show();
                    }


                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña invalida");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location != initialPosition)
                this.Location = initialPosition;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            initialPosition = this.Location;

            this.LocationChanged += Form1_LocationChanged;

            this.AcceptButton = btnIniciarSesion;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            var usuarios = usuarioBLL.GetUsuarios();

            string digitoVerificador = DigitoVerificador.CalcularDigitoVerificador(usuarios.Cast<IVerificableEntity>().ToList(), false);

            string digitoVerificadorHistorico = DigitoVerificador.ObtenerDigitoGuardado();

            if (digitoVerificador != digitoVerificadorHistorico)
            {
                DialogResult result = MessageBox.Show(
                    "Los datos fueron manipulados, por favor corrije las incosistencias.",
                    "Error de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
