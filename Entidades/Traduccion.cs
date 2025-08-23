using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Traduccion
    {
        public int Id {  get; set; }
        public int IdIdioma { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
