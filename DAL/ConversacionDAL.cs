using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ConversacionDAL
    {
            private readonly string connectionString;

            public ConversacionDAL()
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }

            public int CrearConversacion(int idUsuario)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CrearConversacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
        }   

            public List<Conversacion> GetConversacionesByUsuario(int idUsuario)
            {
                var conversaciones = new List<Conversacion>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetConversacionesByUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                conversaciones.Add(new Conversacion
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                                });
                            }
                        }
                    }
                }

                return conversaciones;
            }

            public List<Conversacion> GetConversaciones()
            {
                var conversaciones = new List<Conversacion>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetConversaciones", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                conversaciones.Add(new Conversacion
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                                });
                            }
                        }
                    }
                }

                return conversaciones;
            }

            public List<Mensaje> GetMensajesByConversacion(int idConversacion)
            {
                var mensajes = new List<Mensaje>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetMensajesByConversacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@IdConversacion", idConversacion);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mensajes.Add(new Mensaje
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdConversacion = Convert.ToInt32(reader["idConversacion"]),
                                    IdEmisor = Convert.ToInt32(reader["idEmisor"]),
                                    Texto = reader["mensaje"].ToString(),
                                    FechaEnvio = Convert.ToDateTime(reader["fechaEnvio"])
                                });
                            }
                        }
                    }
                }

                return mensajes;
            }

            public int InsertarMensaje(Mensaje mensaje)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertMensaje", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@IdConversacion", mensaje.IdConversacion);
                        cmd.Parameters.AddWithValue("@IdEmisor", mensaje.IdEmisor);
                        cmd.Parameters.AddWithValue("@Mensaje", mensaje.Texto);

                        object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
    }
}
