using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FormAgregarCliente : Form
    {
        private List<TipoCliente> tiposCliente;

        public FormAgregarCliente()
        {
            InitializeComponent();
            this.Load += FormAgregarCliente_Load;
        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            tiposCliente = clienteBLL.GetTiposCliente();
            comboTipoCliente.DataSource = tiposCliente;
            comboTipoCliente.DisplayMember = "Nombre";
            comboTipoCliente.ValueMember = "Id";
        }

        private bool ValidarCuit(string cuit)
        {
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

            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Cuit = txtCuit.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                TipoClienteId = tipoClienteId,
                UserId = SessionManager.GetInstance.Usuario.Id
            };

            ClienteBLL clienteBLL = new ClienteBLL();
            clienteBLL.AltaCliente(cliente);
            MessageBox.Show("Cliente agregado correctamente.");

            FormClientes formClientes = new FormClientes();
            formClientes.Show();

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();

            this.Hide();
        }

        private void FormAgregarCliente_Load_1(object sender, EventArgs e)
        {
        }

        private void FormAgregarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();

            this.Hide();
        }
    }
}
