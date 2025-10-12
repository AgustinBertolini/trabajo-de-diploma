using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormAgregarVenta : Form
    {
        public FormAgregarVenta()
        {
            InitializeComponent();
        }

        private void CargarProductosEnComboBox()
        {
            ProductoBLL productoBLL = new ProductoBLL();
            var productos = productoBLL.GetProductos();
            comboProductos.DataSource = productos;
            comboProductos.DisplayMember = "Nombre";
            comboProductos.ValueMember = "Id";
        }

        private void CargarClientesEnComboBox()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes();
            comboClientes.DataSource = clientes;
            comboClientes.DisplayMember = "Nombre";
            comboClientes.ValueMember = "Id";
        }

        private void CalcularSubTotal()
        {
            if (comboProductos.SelectedItem is Entidades.Producto producto)
            {
                int cantidad = (int)numericCantidad.Value;
                int subTotal = producto.Precio * cantidad;
                numericSubTotal.Value = subTotal;
            }
        }

        private void AgregarProductoAlDataGridView()
        {
            if (comboProductos.SelectedItem is Entidades.Producto producto)
            {
                int cantidad = (int)numericCantidad.Value;
                int subTotal = producto.Precio * cantidad;
                dataGridView1.Rows.Add(producto.Id, producto.Nombre, producto.Precio, cantidad, subTotal);
            }
            else
            {
                MessageBox.Show("Seleccione un producto válido.");
            }
        }

        private void CalcularLabelTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colSubTotal"].Value != null)
                {
                    total += Convert.ToInt32(row.Cells["colSubTotal"].Value);
                }
            }
            CultureInfo culturaArgentina = new CultureInfo("es-AR");

            labelTotal.Text = total.ToString("C", culturaArgentina);
        }

        private void LimpiarSelecciones()
        {
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;
            numericSubTotal.Value = 0;
        }

        private void FormAgregarPresupuesto_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns["colProductoId"].Visible = false;


            CargarProductosEnComboBox();
            CargarClientesEnComboBox();
        }

        private void FormAgregarVenta_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns["colProductoId"].Visible = false;


            CargarProductosEnComboBox();
            CargarClientesEnComboBox();
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            AgregarProductoAlDataGridView();
            CalcularLabelTotal();
            LimpiarSelecciones();
        }

        private void numericCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

            this.Hide();
        }

        private void btnCrearPresupuesto_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VentaBLL ventaBLL = new VentaBLL();
            List<VentaItem> items = new List<VentaItem>();


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colProductoId"].Value != null)
                {
                    int idProducto = Convert.ToInt32(row.Cells["colProductoId"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value);
                    items.Add(new VentaItem
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidad,
                        PrecioUnitario = precioUnitario
                    });
                }
            }

            Venta venta = new Venta
            {
                FechaCreacion = DateTime.Now,
                IdCliente = (comboClientes.SelectedItem as Cliente)?.Id ?? 0,
                Items = items
            };

            ventaBLL.AltaVenta(venta, items);


            MessageBox.Show("Venta creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormVentas form = new FormVentas();
            form.Show();
            this.Hide();
        }
    }
}
