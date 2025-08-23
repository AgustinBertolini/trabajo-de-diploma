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
    public class TraduccionHistoricoDAL
    {
        public void CrearHistorico(TraduccionHistorico traduccionHistorico)
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
                        using (SqlCommand cmd = new SqlCommand("InsertTraduccionHistorico", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@ValorViejo", traduccionHistorico.ValorViejo);
                            cmd.Parameters.AddWithValue("@ValorNuevo", traduccionHistorico.ValorNuevo);
                            cmd.Parameters.AddWithValue("@IdTraduccion", traduccionHistorico.IdTraduccion);


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
      
        public List<TraduccionHistorico> GetHistoricos()
        {
            List<TraduccionHistorico> historico = new List<TraduccionHistorico>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetTraduccionesHistorico", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    historico.Add(new TraduccionHistorico
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        ValorViejo = reader["valorViejo"].ToString(),
                                        ValorNuevo = reader["valorNuevo"].ToString(),
                                        Fecha = Convert.ToDateTime(reader["fecha"].ToString()),
                                        IdTraduccion = Convert.ToInt32(reader["idTraduccion"].ToString())
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

                return historico;
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
