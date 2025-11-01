using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mensaje
    {
        public int Id { get; set; }
        public int IdConversacion { get; set; }
        public int IdEmisor { get; set; }
        public string Texto { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
