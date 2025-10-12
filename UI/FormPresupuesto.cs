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
    public partial class FormPresupuesto : Form
    {
        public FormPresupuesto()
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
                { "label_presupuestos", "Presupuestos" },
                { "label_ventas", "Ventas" }
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

        private void CargarPresupuestosAlDataGrid()
        {
            PresupuestoBLL presupuestoBLL = new PresupuestoBLL();
            var presupuestos = presupuestoBLL.GetPresupuestos();

            ClienteBLL clienteBLL = new ClienteBLL();
            List<Cliente> clientes = clienteBLL.GetClientes();

            foreach (var p in presupuestos)
            {
                var cliente = clientes.FirstOrDefault(c => c.Id == p.IdCliente);
                if (cliente != null)
                {
                    p.NombreCliente = $"{cliente.Nombre} {cliente.Apellido}";
                }
                else
                {
                    p.NombreCliente = "Cliente desconocido";
                }
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = presupuestos;

            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns.Add("NombreCliente", "Cliente");
            dataGridView1.Columns["NombreCliente"].DataPropertyName = "NombreCliente";

            dataGridView1.Columns.Add("FechaCreacion", "Fecha de creación");
            dataGridView1.Columns["FechaCreacion"].DataPropertyName = "FechaCreacion";

            dataGridView1.Columns.Add("IdCliente", "Id Cliente");
            dataGridView1.Columns["IdCliente"].Visible = false;
        }



        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            CargarPresupuestosAlDataGrid();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos form = new FormPermisos();
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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes();
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

        private void btnCrearPresupuesto_Click(object sender, EventArgs e)
        {
            FormAgregarPresupuesto form = new FormAgregarPresupuesto();
            form.Show();

            this.Hide();
        }

        private void btnVerPresupuesto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un presupuesto seleccionado");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar un unico presupuesto");
                return;
            }


            var presupuesto = (Presupuesto)dataGridView1.SelectedRows[0].DataBoundItem;
            int id = presupuesto.Id;
            FormDetallePresupuesto form = new FormDetallePresupuesto(id);
            form.Show();
            this.Hide();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

            this.Hide();
        }
    }
}
