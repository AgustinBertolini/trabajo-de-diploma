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
    public partial class FormDetallePresupuesto : Form
    {
        private int PresupuestoId = 0;
        public FormDetallePresupuesto(int id)
        {
            InitializeComponent();
            CargarDatosPresupuesto(id);
            PresupuestoId = id;
        }

        private void CargarDatosPresupuesto(int id)
        {
            PresupuestoBLL presupuestoBLL = new PresupuestoBLL();
            var presupuesto = presupuestoBLL.GetPresupuestoById(id);

            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes();

            ProductoBLL productoBLL = new ProductoBLL();
            var productos = productoBLL.GetProductosSinFiltros();

            var cliente = clientes.Find(c => c.Id == presupuesto.IdCliente);

            labelCliente.Text = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Desconocido";
            labelCorreo.Text = cliente.Email;
            labelDireccion.Text = cliente.Direccion;
            labelFecha.Text = presupuesto.FechaCreacion.ToString("g");

            dataGridView1.DataSource = productos
              .Where(p => presupuesto.Items.Any(i => i.IdProducto == p.Id))
              .Select(x =>
              {
                  var item = presupuesto.Items.FirstOrDefault(i => i.IdProducto == x.Id);

                  return new
                  {
                      Producto = x.Nombre, 
                      Precio = item?.PrecioUnitario ?? 0,
                      Cantidad = item?.Cantidad ?? 0,
                      SubTotal = (item?.PrecioUnitario ?? 0) * (item?.Cantidad ?? 0)
                  };
              })
              .ToList();


            CalcularLabelTotal(presupuesto.Items);
        }

        private void CalcularLabelTotal(List<Entidades.PresupuestoItem> items)
        {
            decimal total = items.Sum(i => i.PrecioUnitario * i.Cantidad);
            CultureInfo culturaArgentina = new CultureInfo("es-AR");

            labelTotal.Text = total.ToString("C", culturaArgentina);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormDetallePresupuesto_Load(object sender, EventArgs e)
        {

        }

        private void FormDetallePresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PresupuestoBLL presupuestoBLL = new PresupuestoBLL();
            ProductoBLL productoBLL = new ProductoBLL();

            var presupuesto = presupuestoBLL.GetPresupuestoById(PresupuestoId);

            if (presupuesto == null)
            {
                MessageBox.Show("No se encontró el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (presupuesto.FechaCreacion < DateTime.Now.AddDays(-2))
            {
                MessageBox.Show("No se puede convertir este presupuesto en venta porque ya pasaron más de 48 horas desde su creación.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var productosSinStock = new List<string>();
            var itemsConStock = new List<VentaItem>();

            foreach (var item in presupuesto.Items)
            {
                var producto = productoBLL.GetProducto(item.IdProducto);
                if (producto == null)
                    continue;

                if ((producto.Stock - item.Cantidad) <= 0)
                {
                    productosSinStock.Add(producto.Nombre);
                }
                else
                {
                    itemsConStock.Add(new VentaItem
                    {
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.PrecioUnitario
                    });
                }
            }

            if (productosSinStock.Any())
            {
                string lista = string.Join("\n• ", productosSinStock);
                MessageBox.Show(
                    "Algunos productos no tienen stock y no serán incluidos en la venta:\n\n• " + lista,
                    "Productos sin stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            if (!itemsConStock.Any())
            {
                MessageBox.Show("No se puede generar la venta porque ninguno de los productos tiene stock disponible.",
                    "Sin productos disponibles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Crear la venta solo con productos con stock
            Venta nuevaVenta = new Venta
            {
                IdCliente = presupuesto.IdCliente,
                FechaCreacion = DateTime.Now,
                EstadoEnvio = "En preparación",
                Items = itemsConStock
            };

            try
            {
                VentaBLL ventaBLL = new VentaBLL();
                int idVentaGenerada = ventaBLL.AltaVenta(nuevaVenta, nuevaVenta.Items);

                MessageBox.Show($"Presupuesto convertido correctamente en Venta Nº {idVentaGenerada}.",
                    "Conversión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir presupuesto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
