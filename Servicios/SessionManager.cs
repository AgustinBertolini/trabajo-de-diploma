using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{

    public class SessionManager : IObservador
    {

        private static SessionManager session;

        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();


        public List<Container> Permisos { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (session == null) throw new Exception("Sesión no iniciada");

                return session;
            }
        }

        public static void Login(Usuario usuario)
        {

                if (session == null)
                {
                    session = new SessionManager();
                    session.Usuario = usuario;
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }

        public static void AsignarPermisos(List<Container> permisos)
        {
            GetInstance.Permisos = permisos;
        }

        public static bool TienePermiso(string permiso)
        {
            return GetInstance.Permisos.Any(p => p.TienePermiso(permiso));
        }

        public static void Logout()
        {
                if (session != null)
                {
                    session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }

        }

        public void SuscribirObservador(IIdiomaObserver o)
        {
            _observers.Add(o);
        }
        public void DesuscribirObservador(IIdiomaObserver o)
        {
            _observers.Remove(o);
        }

        private static void Notificar(IIdioma idioma)
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
            }
        }
        public static void CambiarIdioma(Idioma idioma)
        {
            if (session != null)
            {
                session.Usuario.Idioma = idioma;
                Notificar(idioma);
            }
        }

        private SessionManager()
        {

        }


    }

}
