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
            var productos = productoBLL.GetProductos();

            var cliente = clientes.Find(c => c.Id == presupuesto.IdCliente);

            labelCliente.Text = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Desconocido";
            labelCorreo.Text = cliente.Email;
            labelDireccion.Text = cliente.Direccion;
            labelFecha.Text = presupuesto.FechaCreacion.ToString("g");

            dataGridView1.DataSource = productos
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
            var presupuesto = presupuestoBLL.GetPresupuestoById(PresupuestoId);

            if (presupuesto == null)
            {
                MessageBox.Show("No se encontró el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(presupuesto.FechaCreacion < DateTime.Now.AddDays(-2))
            {
                MessageBox.Show("No se puede convertir este presupuesto en venta porque ya pasaron más de 48 horas desde su creación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Venta nuevaVenta = new Venta
            {
                IdCliente = presupuesto.IdCliente,
                FechaCreacion = DateTime.Now,
                EstadoEnvio = "En preparación",
                Items = presupuesto.Items.Select(i => new VentaItem
                {
                    IdProducto = i.IdProducto,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario
                }).ToList()
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
                MessageBox.Show($"Error al convertir presupuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

    }
}
}
