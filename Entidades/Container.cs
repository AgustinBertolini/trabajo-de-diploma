using System;
using System.Collections.Generic;

namespace Entidades
{
    public abstract class Container
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool EsPadre { get; set; }
        public abstract List<Container> Hijos { get; }
        public abstract void AgregarHijo(Container c);
        public abstract bool TienePermiso(string nombrePermiso);
    }
}
