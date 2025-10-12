using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Presupuesto
    {
        public int Id { get; set; }           
        public int IdCliente { get; set; }        
        public DateTime FechaCreacion { get; set; }

        public string NombreCliente { get; set; }

        public Cliente Cliente { get; set; }

        public List<PresupuestoItem> Items { get; set; }
    }
}
