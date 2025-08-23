using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidades
{
    public class Permiso : Container
    {
        public override List<Container> Hijos 
        {
            get
            {
                return null;
            }
        }

        public override void AgregarHijo(Container c)
        {

        }

        public override bool TienePermiso(string nombrePermiso)
        {
            return this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }

    }

    public class Familia : Container
    {
        private List<Container> _hijos;
        public Familia()
        {
            _hijos = new List<Container>();
        }

        public override List<Container> Hijos
        {
            get
            {
                return _hijos;
            }

        }

        public override void AgregarHijo(Container c)
        {
            _hijos.Add(c);
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            if (this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return Hijos.Any(h => h.TienePermiso(nombrePermiso));
        }
    }
}
