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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void CargarVentasAlDataGridView()
        {
            VentaBLL ventaBLL = new VentaBLL();

            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes();

            var datos = (from venta in ventaBLL.GetVentas()
                        join cliente in clientes on venta.IdCliente equals cliente.Id
                        select new
                        {
                            venta.Id,
                            Cliente = $"{cliente.Nombre} {cliente.Apellido}",
                            Total = venta.Items != null ? venta.Items.Sum(i => i.Cantidad * i.PrecioUnitario) : 0,
                            venta.EstadoEnvio,
                            venta.FechaCreacion
                        }).ToList();

            dataGridView1.DataSource = datos;

            dataGridView1.Columns["Id"].Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarVentasAlDataGridView();
            MostrarItemsSegunPermisos();
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            FormAgregarVenta form = new FormAgregarVenta();
            form.Show();

            this.Hide();
        }

        private void btnVerVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay una venta seleccionada");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar una unica venta");
                return;
            }


            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            FormDetalleVenta form = new FormDetalleVenta(id);
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

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            usuarios.Show();

            this.Hide();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();

            this.Hide();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones = new FormTraducciones();
            formTraducciones.Show();

            this.Hide();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora formBitacora = new FormBitacora();
            formBitacora.Show();

            this.Hide();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();

            this.Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();

            this.Hide();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPresupuesto formPresupuesto = new FormPresupuesto();
            formPresupuesto.Show();

            this.Hide();
        }
    }
}
