using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL dal;

        public VentaBLL()
        {
            dal = new VentaDAL();
        }

        public List<Venta> GetVentas()
        {
            return dal.GetVentas();
        }

        public Venta GetVentaById(int id)
        {
            return dal.GetVentaById(id);
        }

        public int AltaVenta(Venta venta, List<VentaItem> items)
        {

            venta.FechaCreacion = DateTime.Now;

            var clienteBLL = new ClienteBLL();
            Cliente cliente = clienteBLL.GetClientes().FirstOrDefault(c => c.Id == venta.IdCliente);

            var productoBLL = new ProductoBLL();
            List<Producto> productos = productoBLL.GetProductos();

            foreach (var item in items)
            {
                var producto = productos.FirstOrDefault(p => p.Id == item.IdProducto);

                if (producto.Stock < item.Cantidad)
                {
                    throw new Exception($"El producto '{producto.Nombre}' no tiene stock suficiente. " +
                                        $"Stock disponible: {producto.Stock}, cantidad solicitada: {item.Cantidad}.");
                }
            }

            if (cliente != null && !string.IsNullOrEmpty(cliente.Email))
            {
                EnviarNotificacionCliente(
                    cliente.Email,
                    $"{cliente.Nombre} {cliente.Apellido}",
                    items.ConvertAll(i => (
                        productos.FirstOrDefault(x => x.Id == i.IdProducto)?.Nombre ?? "Producto desconocido",
                        i.PrecioUnitario,
                        i.Cantidad
                    )),
                    items.Sum(i => i.PrecioUnitario * i.Cantidad)
                );
            }

            return dal.AltaVenta(venta, items);
        }

        public bool BorrarVenta(int id)
        {
            return dal.BorrarVenta(id);
        }

        public void ActualizarEstadoEnvio(int id, string estadoEnvio)
        {
            dal.ActualizarEstadoEnvio(id, estadoEnvio);
        }

        private async void EnviarNotificacionCliente(
            string email,
            string nombreCliente,
            List<(string Producto, decimal Precio, int Cantidad)> productos,
            decimal total)
        {
            try
            {
                var emailSender = new EmailSender();
                await emailSender.EnviarComprobanteVentaAsync(email, nombreCliente, productos, total);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo al cliente {nombreCliente}: {ex.Message}");
            }
        }
    }
}
