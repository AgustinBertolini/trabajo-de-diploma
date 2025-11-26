using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class ProductoBLL
    {
       
        public Producto GetProducto(int id)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                Producto producto = productoDAL.GetProducto(id);

                return producto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Producto> GetProductos()
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                List<Producto> productos = productoDAL.GetProductos();

                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Producto> GetProductosByUserId(int id)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                List<Producto> productos = productoDAL.GetProductosByUserId(id);

                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Producto> GetProductosSinFiltros()
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                List<Producto> productos = productoDAL.GetProductosSinFiltros();

                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Producto> GetProductosSinFiltrosByUserId(int id)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                List<Producto> productos = productoDAL.GetProductosSinFiltrosByUserId(id);

                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AltaProducto(string nombre, decimal precio, int stock)
        {
            try
            {
                Producto producto = new Producto();
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Stock = stock;

                ProductoDAL productoDAL = new ProductoDAL();

                int productoId = productoDAL.AltaProducto(producto);

                return productoId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BorrarProducto(int id)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                productoDAL.BorrarProducto(id);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ActivarProducto(int id)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();

                productoDAL.ActivarProducto(id);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EditarProducto(int id, string nombre, decimal precio, int stock)
        {
            try
            {
                Producto producto = new Producto();
                producto.Id = id;
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Stock = stock;

                ProductoDAL productoDAL= new ProductoDAL();
                productoDAL.EditarProducto(producto);
                productoDAL.GuardarPrecioHistorico(id, precio);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AsignarProducto(int userId, int productId)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();
                productoDAL.AsignarProducto(userId, productId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DesasignarProducto(int userId, int productId)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();
                productoDAL.DesasignarProducto(userId, productId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto_Usuario> GetProductoVendedores(int productId)
        {
            try
            {
                ProductoDAL productoDAL = new ProductoDAL();
                return productoDAL.GetProductoVendedores(productId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}