using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace Entidades
{
    public class ProductoPrecio : IEntidad
    {
        public int Id { get; set; }

        public string Precio { get; set; }
        
        public DateTime FechaCreacion { get; set; }
    }
}
