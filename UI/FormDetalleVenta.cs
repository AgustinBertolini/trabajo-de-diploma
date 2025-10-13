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
    public partial class FormDetalleVenta : Form
    {
        private int VentaId = 0;

        public FormDetalleVenta(int id)
        {
            InitializeComponent();
            CargarDatosVenta(id);
            VentaId = id;
        }

        private void CheckearRadioButtonSegunEstadoEnvio(string estadoEnvio)
        {
             radioBtnPreparacion.Checked = estadoEnvio == "En preparación";
             radioBtnCamino.Checked = estadoEnvio == "En camino";
             radioBtnEntregado.Checked = estadoEnvio == "Entregado";
        }

        private void CargarDatosVenta(int id)
        {
            VentaBLL ventaBLL = new VentaBLL();
            var venta = ventaBLL.GetVentaById(id);

            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes();

            ProductoBLL productoBLL = new ProductoBLL();
            var productos = productoBLL.GetProductos();

            var cliente = clientes.Find(c => c.Id == venta.IdCliente);

            labelCliente.Text = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Desconocido";
            labelCorreo.Text = cliente.Email;
            labelDireccion.Text = venta.EstadoEnvio;
            labelFecha.Text = venta.FechaCreacion.ToString("g");

            dataGridView1.DataSource = productos
              .Select(x =>
              {
                  var item = venta.Items.FirstOrDefault(i => i.IdProducto == x.Id);

                  return new
                  {
                      Producto = x.Nombre,
                      Precio = item?.PrecioUnitario ?? 0,
                      Cantidad = item?.Cantidad ?? 0,
                      SubTotal = (item?.PrecioUnitario ?? 0) * (item?.Cantidad ?? 0)
                  };
              })
              .ToList();


            CalcularLabelTotal(venta.Items);
            CheckearRadioButtonSegunEstadoEnvio(venta.EstadoEnvio);
        }

        private void CalcularLabelTotal(List<VentaItem> items)
        {
            decimal total = items.Sum(i => i.PrecioUnitario * i.Cantidad);
            CultureInfo culturaArgentina = new CultureInfo("es-AR");

            labelTotal.Text = total.ToString("C", culturaArgentina);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormDetalleVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

            this.Hide();
        }

        private void radioBtnEntregado_CheckedChanged(object sender, EventArgs e)
        {
            VentaBLL ventaBLL = new VentaBLL();
            ventaBLL.ActualizarEstadoEnvio(VentaId, "Entregado");
        }

        private void radioBtnCamino_CheckedChanged(object sender, EventArgs e)
        {
            VentaBLL ventaBLL = new VentaBLL();
            ventaBLL.ActualizarEstadoEnvio(VentaId, "En camino");
        }

        private void radioBtnPreparacion_CheckedChanged(object sender, EventArgs e)
        {
            VentaBLL ventaBLL = new VentaBLL();
            ventaBLL.ActualizarEstadoEnvio(VentaId, "En preparación");
        }
    }
}
