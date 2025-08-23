using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Bitacora
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public int IdUsuario { get; set; }
    }


    public enum TipoEvento
    {
        Warning,
        Error,
        Message
    }
}
