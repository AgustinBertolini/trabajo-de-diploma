using BLL;
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

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarVentasAlDataGridView();
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            FormAgregarVenta form = new FormAgregarVenta();
            form.Show();

            this.Hide();
        }
    }
}
