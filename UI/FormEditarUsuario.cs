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
    public partial class FormEditarUsuario : Form
    {
        public FormEditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            Traducir();
            txtIdHidden.Text = usuario.Id.ToString();
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            numericDni.Value = usuario.DNI;
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

        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {
            txtIdHidden.Hide();

            numericDni.Maximum = 999999999;
        }

        private void FormEditarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
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

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            bool editado = usuarioBLL.EditarUsuario(Convert.ToInt32(txtIdHidden.Text), txtNombre.Text, txtApellido.Text, txtEmail.Text, Convert.ToInt64(numericDni.Value));

            if (editado)
            {
                var usuariosObtenidos = usuarioBLL.GetUsuarios();

                string digitoVerificador = DigitoVerificador.CalcularDigitoVerificador(usuariosObtenidos.Cast<IVerificableEntity>().ToList(),true);

                DigitoVerificador.GuardarDigitoVerificador(digitoVerificador);

                FormUsuarios usuarios = new FormUsuarios();
                usuarios.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Ya existe un usuario con el mismo email");

            }

            
        }

        private void txtIdHidden_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
