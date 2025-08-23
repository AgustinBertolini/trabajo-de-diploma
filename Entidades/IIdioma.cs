using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace Entidades
{
    public interface IIdioma : IEntidad
    {
        string Nombre { get; set; }
    }
}
