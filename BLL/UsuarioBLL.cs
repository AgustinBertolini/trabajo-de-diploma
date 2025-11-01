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
        
        public int AltaUsuario(Usuario usuario)
        {
            try
            {
                List<Usuario> usuariosExistentes = GetUsuarios();
                if (usuariosExistentes.Any(u => u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new Exception("Ya existe un usuario con el email elegido.");
                }
                if (usuariosExistentes.Any(u => u.DNI == usuario.DNI))
                {
                    throw new Exception("Ya existe un usuario con el DNI elegido.");
                }
                

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

        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                List<Usuario> usuariosExistentes = GetUsuarios();
                var tieneMismoEmail = usuariosExistentes.Any(u => u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase) && u.Id != usuario.Id);
                if (tieneMismoEmail)
                {
                    throw new Exception("Ya existe un usuario con el email elegido.");
                }
                if (usuariosExistentes.Any(u => u.DNI == usuario.DNI && u.Id != usuario.Id))
                {
                    throw new Exception("Ya existe un usuario con el DNI elegido.");
                }
             

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
