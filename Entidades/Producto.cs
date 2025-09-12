using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace Entidades
{
    public class Producto : IEntidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Precio { get; set; }

        public int Stock { get; set; }

        public DateTime FechaCreacion { get; set; }
        
        public DateTime FechaActualizacion{ get; set; }

        public List<Usuario> Usuarios { get; set; }
        
        public List<ProductoPrecio> Precios { get; set; }

    }
}
