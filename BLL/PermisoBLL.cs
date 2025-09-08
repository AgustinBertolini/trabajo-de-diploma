using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class PermisoBLL
    {

        public List<Container> GetArbol()
        {
            PermisoDAL permisoDAL = new PermisoDAL();
            return permisoDAL.GetAll(null);
        }

        public Permiso GetPermiso(int id)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();

                Permiso permiso = permisoDAL.GetPermiso(id);

                return permiso;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Permiso> GetPermisos()
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();

                List<Permiso> permisos = permisoDAL.GetPermisos();

                return permisos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AltaPermiso(string nombre, bool esPadre)
        {
            try
            {
                Permiso permiso = new Permiso();
                permiso.Id = 0;
                permiso.Nombre = nombre;
                permiso.EsPadre = esPadre;

                PermisoDAL permisoDAL = new PermisoDAL();

                int permisoId = permisoDAL.CrearPermiso(permiso);

                return permisoId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BorrarPermiso(int id)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();

                permisoDAL.BorrarPermiso(id);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EditarPermiso(int id, string nombre)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();
                Permiso permiso = new Permiso();

                Permiso permisoObtenido = permisoDAL.GetPermiso(id);

                permiso.Id = id;
                permiso.Nombre = nombre;
                permiso.EsPadre = permisoObtenido.EsPadre;

                permisoDAL.EditarPermiso(permiso);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool VincularPermisos(int idPadre, int idHijo)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();
                permisoDAL.VincularPermisos(idPadre,idHijo);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AsignarPermiso(int idUsuario, int idPermiso)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();
                permisoDAL.AsignarPermiso(idUsuario, idPermiso);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public bool DesasignarPermisos(int idUsuario)
        {
            try
            {
                PermisoDAL permisoDAL = new PermisoDAL();
                permisoDAL.DesasignarPermisos(idUsuario);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
