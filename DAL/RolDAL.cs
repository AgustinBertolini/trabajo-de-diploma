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
    public class RolDAL
    {
        public List<Rol> GetRoles()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetRoles", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    roles.Add(new Rol
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nombre = reader["nombre"].ToString(),
                                      
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

                return roles;
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
