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
    }
}
