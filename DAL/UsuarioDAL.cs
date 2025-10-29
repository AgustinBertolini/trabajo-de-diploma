using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;
using System.Net;

namespace DAL
{
    public class UsuarioDAL
    {
        public Usuario GetUsuario(string email)
        {
            Usuario usuario = new Usuario();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetUsuario", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Email", email);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    usuario = new Usuario
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nombre = reader["nombre"].ToString(),
                                        Apellido = reader["apellido"].ToString(),
                                        DNI = Convert.ToInt64(reader["dni"]),
                                        Email = reader["email"].ToString(),
                                        Contraseña = reader["contraseña"].ToString(),
                                        IsActive = Convert.ToBoolean(reader["isActive"]),
                                        Rol = new Rol
                                        {
                                            Id = Convert.ToInt32(reader["rolId"]),
                                            Nombre = reader["rolNombre"].ToString()
                                        }
                                    };
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                }

                return usuario;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetUsuarios", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    usuarios.Add(new Usuario
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nombre = reader["nombre"].ToString(),
                                        Apellido = reader["apellido"].ToString(),
                                        DNI = Convert.ToInt64(reader["dni"]),
                                        Email = reader["email"].ToString(),
                                        Contraseña = reader["contraseña"].ToString(),
                                        IsActive = Convert.ToBoolean(reader["isActive"]),
                                        Rol = new Rol
                                        {
                                            Id = Convert.ToInt32(reader["rolId"]),
                                            Nombre = reader["rolNombre"].ToString()
                                        }
                                    });
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                   
                }

                return usuarios;
            }
            catch (SqlException ex)
            {
                throw ex;
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
                int userId = 0;

                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertUsuario", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                            cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                            cmd.Parameters.AddWithValue("@Email", usuario.Email);
                            cmd.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
                            cmd.Parameters.AddWithValue("@RolId", usuario.Rol.Id);


                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                userId = Convert.ToInt32(result);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    
                }

                return userId;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    return 0;
                }
                throw ex;
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
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteUsuario", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", id);


                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    
                }

                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
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
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("EditUsuario", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", usuario.Id);
                            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                            cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                            cmd.Parameters.AddWithValue("@Email", usuario.Email);


                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    
                }

                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    return false;

                }
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

       
    }
}
