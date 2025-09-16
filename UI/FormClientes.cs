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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
            MostrarItemsSegunPermisos();
        }

        private void MostrarItemsSegunPermisos()
        {
            var items = menuStrip1.Items;

            var permisosMap = new Dictionary<string, string>
            {
                { "label_usuarios", "Usuarios"},
                { "label_productos", "Productos"},
                { "label_permisos", "Permisos" },
                { "label_traducciones", "Traducciones" },
                { "label_bitacora", "Bitacora" },
                { "label_clientes", "Clientes" },
                { "label_presupuestos", "Presupuestos" }

            };

            foreach (var item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Tag != null)
                    {
                        var tag = menuItem.Tag.ToString();
                        if (tag == "label_sesion")
                        {
                            menuItem.Visible = true;
                            continue;
                        }
                        if (SessionManager.TienePermiso(permisosMap[tag]))
                        {
                            menuItem.Visible = true;
                        }
                        else
                        {
                            menuItem.Visible = false;
                        }
                    }
                }
            }
        }

        private void CargarClientes()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            List<Cliente> clientes = clienteBLL.GetClientes();
            dataGridView1.DataSource = clientes.Where(x=>x.UserId == SessionManager.GetInstance.Usuario.Id).ToList();

          
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

            if (!(SessionManager.TienePermiso("Clientes")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a la pantalla");
                return;
            }
            CargarClientes();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Editar Cliente")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a la pantalla");
                return;

            }
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cliente clienteSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Cliente;
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener la información del cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormEditarCliente formEditar = new FormEditarCliente(clienteSeleccionado);
            formEditar.Show();

            this.Hide();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Agregar Cliente")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a la pantalla");
                return;
            }

            FormAgregarCliente formAgregarCliente = new FormAgregarCliente();
            formAgregarCliente.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(SessionManager.TienePermiso("Borrar Cliente")))
            {
                MessageBox.Show("No tenes permisos suficientes para acceder a la pantalla");
                return;

            }

            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cliente clienteSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Cliente;
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener la información del cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClienteBLL clienteBLL = new ClienteBLL();
            clienteBLL.BorrarCliente(clienteSeleccionado.Id);
            MessageBox.Show("Cliente eliminado correctamente.");
            CargarClientes();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();

            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos form= new FormPermisos();
            form.Show();

            this.Hide();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora form = new FormBitacora(); 
            form.Show();

            this.Hide();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();

            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Logout();

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }
    }
}
