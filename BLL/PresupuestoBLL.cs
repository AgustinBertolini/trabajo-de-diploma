using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class PresupuestoBLL
    {
        private readonly PresupuestoDAL dal;

        public PresupuestoBLL()
        {
            dal = new PresupuestoDAL();
        }

        public List<Presupuesto> GetPresupuestos()
        {
            return dal.GetPresupuestos();
        }

        public Presupuesto GetPresupuestoById(int id)
        {
            return dal.GetPresupuestoById(id);
        }

        public int AltaPresupuesto(Presupuesto presupuesto, List<PresupuestoItem> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("Debe incluir al menos un item en el presupuesto.");

            List<Cliente> clientes = new ClienteDAL().GetClientes();

            Cliente cliente = clientes.Find(c => c.Id == presupuesto.IdCliente);

            List<Producto> productos = new ProductoDAL().GetProductos();

            this.EnviarNotificacionCliente(cliente.Email, cliente.Nombre + " " + cliente.Apellido, 
                items.ConvertAll(i => (productos.FirstOrDefault(x=>x.Id == i.IdProducto).Nombre, i.PrecioUnitario, i.Cantidad)), 
                items.Sum(i => i.PrecioUnitario * i.Cantidad));

            return dal.AltaPresupuesto(presupuesto, items);
        }

        public bool BorrarPresupuesto(int id)
        {
            return dal.BorrarPresupuesto(id);
        }

        private async void EnviarNotificacionCliente(string email, string nombreCliente, List<(string Producto, decimal Precio, int Cantidad)> productos, decimal total)
        {
            var emailSender = new EmailSender();
            await emailSender.EnviarPresupuestoAsync(email, nombreCliente, productos,total);
        }
    }
}
