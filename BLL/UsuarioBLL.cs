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
    public class UsuarioBLL
    {
        public bool ValidarContraseña(string contraseña, string contraseñaGuardada)
        {
            try
            {
                string hashedPassword = Encriptador.CreateHash(contraseña);

                return hashedPassword == contraseñaGuardada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Usuario GetUsuario(string email)
        {
            try
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                Usuario usuario = usuarioDAL.GetUsuario(email);

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                List<Usuario> usuarios = usuarioDAL.GetUsuarios();

                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public int AltaUsuario(string nombre, string apellido, string email, string contraseña, long dni, int rolId)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Email = email;
                usuario.Contraseña = contraseña;
                usuario.DNI = dni;
                usuario.Rol = new Rol { Id = rolId };

                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuarioWithPass = new Usuario();

                string hashedPassword = Encriptador.CreateHash(usuario.Contraseña);

                usuarioWithPass = usuario;
                usuarioWithPass.Contraseña = hashedPassword;

                int usuarioId = usuarioDAL.AltaUsuario(usuarioWithPass);

                return usuarioId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BorrarUsuario(int id)
        {
            try
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                usuarioDAL.BorrarUsuario(id);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EditarUsuario(int id, string nombre, string apellido, string email, long dni)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id = id;
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Email = email;
                usuario.Contraseña = "";
                usuario.DNI = dni;

                UsuarioDAL usuarioDAL = new UsuarioDAL();
                return usuarioDAL.EditarUsuario(usuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Login(string email, string contraseña)
        {
            Usuario usuario = GetUsuario(email);

            if (!ValidarContraseña(contraseña, usuario.Contraseña))
            {
                return false;
            }

            PermisoDAL permisoDAL = new PermisoDAL();

            var permisos = permisoDAL.GetPermisosDeUsuario(usuario.Id);

            usuario.Idioma = (Idioma)Traductor.GetIdiomas()[0];

            SessionManager.Login(usuario);

            SessionManager.AsignarPermisos(permisos);

            return true;
        }

        public void Logout()
        {
            try
            {
                SessionManager.Logout();

            }
            catch (Exception ex)
            {
 
                throw ex;
            }
        }
    }
}
