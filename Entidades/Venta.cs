using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Venta
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string EstadoEnvio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Cliente Cliente { get; set; }
        

        public List<VentaItem> Items { get; set; }
    }
}
