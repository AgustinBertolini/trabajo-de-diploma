using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class BitacoraDAL
    {
        public List<Bitacora> GetBitacoras()
        {
            List<Bitacora> bitacoras = new List<Bitacora>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetBitacoras", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    bitacoras.Add(new Bitacora
                                    {
                                        Mensaje = reader["mensaje"].ToString(),
                                        Fecha = Convert.ToDateTime(reader["fecha"].ToString()),
                                        TipoEvento = Enum.TryParse(reader["tipoEvento"].ToString(), out TipoEvento tipoEvento) ? tipoEvento : TipoEvento.Message,
                                        IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString())
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

                return bitacoras;
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

        public void AltaBitacora(Bitacora bitacora)
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
                        using (SqlCommand cmd = new SqlCommand("InsertBitacora", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Mensaje", bitacora.Mensaje);
                            cmd.Parameters.AddWithValue("@TipoEvento", bitacora.TipoEvento);
                            cmd.Parameters.AddWithValue("@IdUsuario", bitacora.IdUsuario);


                            object result = cmd.ExecuteScalar();

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                }

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

       
    }
}
