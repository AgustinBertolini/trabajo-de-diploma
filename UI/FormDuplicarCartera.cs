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

namespace UI
{
    public partial class FormDuplicarCartera : Form
    {
        private int idUsuarioDestino;
        public FormDuplicarCartera(int idUsuarioDestino)
        {
            InitializeComponent();

            this.idUsuarioDestino = idUsuarioDestino;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarComboUsuarios()
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            List<Usuario> usuarios = usuarioBLL.GetUsuarios().Where(x => x.Rol.Nombre == "VENDEDOR").ToList();
            labelVendedor.Text = usuarios.FirstOrDefault(u => u.Id == idUsuarioDestino)?.Email ?? "Usuario no encontrado";

            usuarios = usuarios.Where(u => u.Id != idUsuarioDestino).ToList();
            comboBox1.DataSource = usuarios;
            comboBox1.DisplayMember = "Email";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedItem = null;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try 
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un usuario origen.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuarioOrigen = ((Usuario)comboBox1.SelectedItem).Id;

                ClienteBLL clienteBLL = new ClienteBLL();

                bool exito = clienteBLL.DuplicarCartera(idUsuarioOrigen, idUsuarioDestino);

                if (exito)
                {
                    MessageBox.Show("Cartera duplicada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al duplicar la cartera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

        private void FormDuplicarCartera_Load(object sender, EventArgs e)
        {
            CargarComboUsuarios();
        }
    }
}
