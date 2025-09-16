using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int TipoClienteId { get; set; }
        public int UserId { get; set; }
    }
}
