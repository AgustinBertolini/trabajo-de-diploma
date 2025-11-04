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
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class FormReportes : Form
    {
        private VentaBLL ventaBLL = new VentaBLL();
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private ProductoBLL productoBLL = new ProductoBLL();
        private ClienteBLL clienteBLL = new ClienteBLL();

        public FormReportes()
        {
            InitializeComponent();

            CargarInformacionParaCharts();
        }

        private void CargarInformacionParaCharts()
        {
            var ventas = ventaBLL.GetVentas();
            var clientes = clienteBLL.GetClientes();
            var usuarios = usuarioBLL.GetUsuarios();
            var productos = productoBLL.GetProductosSinFiltros();

            var ticketPromedio = ventas.Select(x => x.Items.Sum(i => i.PrecioUnitario * i.Cantidad)).DefaultIfEmpty(0).Average();
            labelTicketPromedio.Text = $"${ticketPromedio:F2}";

            var recaudacionTotal = ventas.Sum(x => x.Items.Sum(i => i.PrecioUnitario * i.Cantidad));
            labelRecaudacionTotal.Text = $"${recaudacionTotal:F2}";

            var ventasTotales = ventas.Count;
            labelVentasTotales.Text = ventasTotales.ToString();

            CargarVentasPorVendedor(ventas,clientes,usuarios);
            CargarRecaudacionPorVendedor(ventas,clientes,usuarios);
            CargarProductosMasVendidosEnPieChart(ventas,productos);
            CargarRecaudacionPorProductoDonutChart(ventas,productos);
        }

        private void CargarVentasPorVendedor(List<Venta> ventas, List<Cliente> clientes, List<Usuario> usuarios)
        {

            ventas = (from venta in ventas
                                         join cliente in clientes
                                         on venta.IdCliente equals cliente.Id
                                         select new Venta
                                         {
                                             Id = venta.Id,
                                             IdCliente = venta.IdCliente,
                                             EstadoEnvio = venta.EstadoEnvio,
                                             FechaCreacion = venta.FechaCreacion,
                                             Cliente = cliente,
                                             Items = venta.Items
                                         }).ToList();

            var ventasPorVendedorChartData = ventas
                 .GroupBy(v => v.Cliente.UserId)
                 .Select(g => new
                 {
                     VendedorId = g.Key,
                     CantidadVentas = g.Count()
                 })
                 .ToList();

            var chartData = (from venta in ventasPorVendedorChartData
                                            join usuario in usuarios
                                            on venta.VendedorId equals usuario.Id
                                            select new
                                            {
                                                VendedorId = usuario.Nombre + ' ' + usuario.Apellido,
                                                CantidadVentas = venta.CantidadVentas
                                            }).ToList();

            chartVentasPorVendedor.Titles.Add("");

            Series serie = new Series("Vendedores");
            serie.ChartType = SeriesChartType.Column;
            serie.Color = System.Drawing.Color.CornflowerBlue;
            serie.IsValueShownAsLabel = true;

            foreach (var item in chartData)
            {
                serie.Points.AddXY(item.VendedorId, item.CantidadVentas);
            }

            chartVentasPorVendedor.Series.Clear();
            chartVentasPorVendedor.Series.Add(serie);

            chartVentasPorVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false; 
            chartVentasPorVendedor.ChartAreas[0].AxisX.Title = "Vendedores";
            chartVentasPorVendedor.ChartAreas[0].AxisY.Title = "Cantidades";
        }

        private void CargarRecaudacionPorVendedor(List<Venta> ventas, List<Cliente> clientes, List<Usuario> usuarios)
        {
            ventas = (from venta in ventas
                      join cliente in clientes
                      on venta.IdCliente equals cliente.Id
                      select new Venta
                      {
                          Id = venta.Id,
                          IdCliente = venta.IdCliente,
                          EstadoEnvio = venta.EstadoEnvio,
                          FechaCreacion = venta.FechaCreacion,
                          Cliente = cliente,
                          Items = venta.Items
                      }).ToList();

            var recaudacionPorVendedor = ventas
                .GroupBy(v => v.Cliente.UserId)
                .Select(g => new
                {
                    VendedorId = g.Key,
                    RecaudacionTotal = g.Sum(v => v.Items.Sum(i => i.PrecioUnitario * i.Cantidad))
                })
                .ToList();

            var chartData = (from venta in recaudacionPorVendedor
                             join usuario in usuarios
                             on venta.VendedorId equals usuario.Id
                             select new
                             {
                                 VendedorNombre = usuario.Nombre + " " + usuario.Apellido,
                                 RecaudacionTotal = venta.RecaudacionTotal
                             })
                             .OrderByDescending(x => x.RecaudacionTotal)
                             .ToList();

            chartRecaudacionPorVendedor.Series.Clear();
            chartRecaudacionPorVendedor.Titles.Clear();

            Series serie = new Series("Recaudación");
            serie.ChartType = SeriesChartType.Bar;
            serie.Color = System.Drawing.Color.SeaGreen;
            serie.IsValueShownAsLabel = true;

            foreach (var item in chartData)
            {
                serie.Points.AddXY(item.VendedorNombre, item.RecaudacionTotal);
            }

            chartRecaudacionPorVendedor.Series.Add(serie);

            chartRecaudacionPorVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false; 
            chartRecaudacionPorVendedor.ChartAreas[0].AxisY.Title = "Recaudación ($)";
            chartRecaudacionPorVendedor.ChartAreas[0].AxisX.Title = "Vendedores";
        }

        private void CargarProductosMasVendidosEnPieChart(List<Venta> ventas, List<Producto> productos)
        {
            var productosMasVendidos = ventas
                .SelectMany(v => v.Items)
                .GroupBy(i => i.IdProducto)
                .Select(g => new
                {
                    ProductoId = g.Key,
                    CantidadVendida = g.Sum(i => i.Cantidad)
                })
                .OrderByDescending(x => x.CantidadVendida)
                .Take(5)
                .ToList();
            var chartData = (from producto in productosMasVendidos
                             join prod in productos
                             on producto.ProductoId equals prod.Id
                             select new
                             {
                                 NombreProducto = prod.Nombre,
                                 CantidadVendida = producto.CantidadVendida
                             }).ToList();
            chartProductosMasVendidos.Series.Clear();
            chartProductosMasVendidos.Titles.Clear();
            Series serie = new Series("Productos");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            foreach (var item in chartData)
            {
                serie.Points.AddXY(item.NombreProducto, item.CantidadVendida);
            }
            chartProductosMasVendidos.Series.Add(serie);
        }

        private void CargarRecaudacionPorProductoDonutChart(List<Venta> ventas, List<Producto> productos)
        {
            ventas = ventas.Where(v => v.Items != null && v.Items.Any()).ToList();

            var recaudacionPorProducto = ventas
                .SelectMany(v => v.Items)
                .GroupBy(i => i.IdProducto)
                .Select(g => new
                {
                    ProductoId = g.Key,
                    RecaudacionTotal = g.Sum(i => i.PrecioUnitario * i.Cantidad)
                })
                .OrderByDescending(x => x.RecaudacionTotal)
                .ToList();

            var chartData = (from producto in recaudacionPorProducto
                             join prod in productos on producto.ProductoId equals prod.Id into gj
                             from subProd in gj.DefaultIfEmpty()
                             select new
                             {
                                 NombreProducto = subProd != null ? subProd.Nombre : $"ID {producto.ProductoId}",
                                 RecaudacionTotal = producto.RecaudacionTotal
                             })
                             .ToList();

            chartRecaudacionPorProducto.Series.Clear();
            chartRecaudacionPorProducto.Titles.Clear();

            Series serie = new Series("Productos")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
            };

            foreach (var item in chartData)
            {
                serie.Points.AddXY(item.NombreProducto, item.RecaudacionTotal);
            }

            chartRecaudacionPorProducto.Series.Add(serie);

            chartRecaudacionPorProducto.ChartAreas[0].BackColor = Color.White;
            chartRecaudacionPorProducto.BackColor = Color.Transparent;
            chartRecaudacionPorProducto.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRecaudacionPorProducto.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FormReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
