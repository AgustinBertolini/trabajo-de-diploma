using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using BLL;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
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

            var tipoClienteSeleccionado = comboTipoCliente.SelectedItem as TipoCliente;
            int tipoClienteId = tipoClienteSeleccionado != null ? tipoClienteSeleccionado.Id : 0;

            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Cuit = txtCuit.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                TipoClienteId = tipoClienteId
            };

            ClienteBLL clienteBLL = new ClienteBLL();
            clienteBLL.AltaCliente(cliente);
            MessageBox.Show("Cliente agregado correctamente.");
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
    }
}
