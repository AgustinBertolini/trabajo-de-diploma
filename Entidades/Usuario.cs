using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace Entidades
{
    public class Usuario: IVerificableEntity, IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public long DNI { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Idioma Idioma { get; set; }
        public string DV { get; set; }
        public Rol Rol { get; set; }
    }
}
