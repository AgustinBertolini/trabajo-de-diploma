using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FormEditarCliente : Form
    {
        private List<TipoCliente> tiposCliente;
        private Cliente clienteEditar;

        public FormEditarCliente(Cliente cliente)
        {
            InitializeComponent();
            clienteEditar = cliente;
            this.Load += FormEditarCliente_Load;
        }

        private void FormEditarCliente_Load(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            tiposCliente = clienteBLL.GetTiposCliente();
            comboTipoCliente.DataSource = tiposCliente;
            comboTipoCliente.DisplayMember = "Nombre";
            comboTipoCliente.ValueMember = "Id";

            txtNombre.Text = clienteEditar.Nombre;
            txtApellido.Text = clienteEditar.Apellido;
            txtCuit.Text = clienteEditar.Cuit;
            txtEmail.Text = clienteEditar.Email;
            txtDireccion.Text = clienteEditar.Direccion;
            comboTipoCliente.SelectedValue = clienteEditar.TipoClienteId;
        }

        private bool ValidarCuit(string cuit)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes();

            if (clientes.Any(c => c.Cuit == cuit && c.UserId == SessionManager.GetInstance.Usuario.Id))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(cuit))
                return false;


            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
                return false;

            string[] prefijos = { "20", "23", "24", "27", "30", "33", "34" };
            string prefijo = cuit.Substring(0, 2);

            return prefijos.Contains(prefijo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCuit.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                comboTipoCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidarCuit(txtCuit.Text) == false)
                {
                    MessageBox.Show("El CUIT ingresado no es válido.", "CUIT inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tipoClienteSeleccionado = comboTipoCliente.SelectedItem as TipoCliente;
                int tipoClienteId = tipoClienteSeleccionado != null ? tipoClienteSeleccionado.Id : 0;

                clienteEditar.Nombre = txtNombre.Text;
                clienteEditar.Apellido = txtApellido.Text;
                clienteEditar.Cuit = txtCuit.Text;
                clienteEditar.Email = txtEmail.Text;
                clienteEditar.Direccion = txtDireccion.Text;
                clienteEditar.TipoClienteId = tipoClienteId;

                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.EditarCliente(clienteEditar);
                MessageBox.Show("Cliente editado correctamente.");

                FormClientes clientes = new FormClientes();
                clientes.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormClientes clientes = new FormClientes();
            clientes.Show();

            this.Hide();
        }

        private void FormEditarCliente_Load_1(object sender, EventArgs e)
        {

        }

        private void FormEditarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClientes form = new FormClientes();
            form.Show();

            this.Hide();
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}
