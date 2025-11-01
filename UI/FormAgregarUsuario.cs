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
    public partial class FormAgregarUsuario : Form
    {
        public FormAgregarUsuario()
        {
            InitializeComponent();
            Traducir();
            CargarRoles();
        }

        public void CargarRoles()
        {
            RolBLL rolBLL = new RolBLL();

            var roles = rolBLL.GetRoles();

            comboRoles.DataSource = roles;
            comboRoles.DisplayMember = "Nombre";
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
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
            
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void FormAgregarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

                if (string.IsNullOrEmpty(txtApellido.Text))
                {
                    MessageBox.Show("El campo apellido es obligatorio");
                    return;
                }

                if (numericDni.Value <= 0)
                {
                    MessageBox.Show("El campo DNI es obligatorio");
                    return;
                }

                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("El campo email es obligatorio");
                    return;
                }

                if (string.IsNullOrEmpty(txtContraseña.Text))
                {
                    MessageBox.Show("El campo contraseña es obligatorio");
                    return;
                }

                if (comboRoles.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un rol");
                    return;
                }

                UsuarioBLL usuarioBLL = new UsuarioBLL();

                Rol rolSeleccionado = (Rol)comboRoles.SelectedItem;


                Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Email = txtEmail.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.DNI = Convert.ToInt64(numericDni.Value);
                usuario.Rol = rolSeleccionado;



                int userId = usuarioBLL.AltaUsuario(usuario);

                if (userId != 0)
                {
                    Bitacoras.AltaBitacora("El usuario " + txtEmail.Text + " fue dado de alta", TipoEvento.Message, SessionManager.GetInstance.Usuario.Id);

                    var usuariosObtenidos = usuarioBLL.GetUsuarios();

                    string digitoVerificador = DigitoVerificador.CalcularDigitoVerificador(usuariosObtenidos.Cast<IVerificableEntity>().ToList(), true);

                    DigitoVerificador.GuardarDigitoVerificador(digitoVerificador);

                    FormUsuarios usuarios = new FormUsuarios();
                    usuarios.Show();

                    this.Hide();
                }
                else
                {
                    Bitacoras.AltaBitacora("Error al crear usuario: Ya existe un usuario con el mismo email", TipoEvento.Error, SessionManager.GetInstance.Usuario.Id);

                    MessageBox.Show("Ya existe un usuario con el mismo email");

                }
            } catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al crear el usuario: " + ex.Message);
                return;
            }
           

        }

        private void numberDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
