using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace Entidades
{
    public class TraduccionHistorico : IEntidad
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string ValorViejo { get; set; }

        public string ValorNuevo { get; set; }

        public int IdTraduccion { get; set; }
    }
}
