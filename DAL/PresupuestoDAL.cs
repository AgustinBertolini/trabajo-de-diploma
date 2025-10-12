using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class PresupuestoDAL
    {
        private readonly string connectionString;

        public PresupuestoDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Presupuesto> GetPresupuestos()
        {
            var presupuestos = new List<Presupuesto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetPresupuestos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            presupuestos.Add(new Presupuesto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdCliente = Convert.ToInt32(reader["idCliente"]),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"])
                            });
                        }
                    }
                }
            }

            return presupuestos;
        }

        public Presupuesto GetPresupuestoById(int id)
        {
            Presupuesto presupuesto = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("GetPresupuestoById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            presupuesto = new Presupuesto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdCliente = Convert.ToInt32(reader["idCliente"]),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"])
                            };
                        }
                    }
                }

                if (presupuesto != null)
                {
                    presupuesto.Items = new List<PresupuestoItem>();

                    using (SqlCommand cmd = new SqlCommand("GetPresupuestoItemsByPresupuestoId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPresupuesto", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                presupuesto.Items.Add(new PresupuestoItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]),
                                    IdProducto = Convert.ToInt32(reader["idProducto"]),
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    PrecioUnitario = Convert.ToDecimal(reader["precioUnitario"])
                                });
                            }
                        }
                    }
                }
            }

            return presupuesto;
        }

        public int AltaPresupuesto(Presupuesto presupuesto, List<PresupuestoItem> items)
        {
            int idPresupuestoGenerado = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertPresupuesto", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", presupuesto.IdCliente);
                        cmd.Parameters.AddWithValue("@FechaCreacion", presupuesto.FechaCreacion);

                        object result = cmd.ExecuteScalar();
                        idPresupuestoGenerado = Convert.ToInt32(result);
                    }

                    foreach (var item in items)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertPresupuestoItem", conn, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuestoGenerado);
                            cmd.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                            cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                            cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }

            return idPresupuestoGenerado;
        }

        public bool BorrarPresupuesto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DeletePresupuesto", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
