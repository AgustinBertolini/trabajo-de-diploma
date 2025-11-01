using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Conversacion
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public List<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
    }
}
