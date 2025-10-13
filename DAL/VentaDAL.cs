using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class VentaDAL
    {
        private readonly string connectionString;

        public VentaDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Venta> GetVentas()
        {
            var ventas = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Obtener todas las ventas
                using (SqlCommand cmd = new SqlCommand("GetVentas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdCliente = Convert.ToInt32(reader["idCliente"]),
                                EstadoEnvio = Convert.ToString(reader["estadoEnvio"]),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"]),
                            });
                        }
                    }
                }

                // 2️⃣ Cargar los ítems de cada venta
                foreach (var venta in ventas)
                {
                    if (venta != null)
                    {
                        venta.Items = new List<VentaItem>();

                        using (SqlCommand cmd = new SqlCommand("GetVentaItemsByVentaId", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdVenta", venta.Id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    venta.Items.Add(new VentaItem
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        IdVenta = Convert.ToInt32(reader["idVenta"]),
                                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                                        Cantidad = Convert.ToInt32(reader["cantidad"]),
                                        PrecioUnitario = Convert.ToDecimal(reader["precioUnitario"])
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return ventas;
        }


        public Venta GetVentaById(int id)
        {
            Venta venta = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("GetVentaById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venta = new Venta
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdCliente = Convert.ToInt32(reader["idCliente"]),
                                EstadoEnvio = Convert.ToString(reader["estadoEnvio"]),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"])
                            };
                        }
                    }
                }

                if (venta != null)
                {
                    venta.Items = new List<VentaItem>();

                    using (SqlCommand cmd = new SqlCommand("GetVentaItemsByVentaId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVenta", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                venta.Items.Add(new VentaItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdVenta = Convert.ToInt32(reader["idVenta"]),
                                    IdProducto = Convert.ToInt32(reader["idProducto"]),
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    PrecioUnitario = Convert.ToDecimal(reader["precioUnitario"])
                                });
                            }
                        }
                    }
                }
            }

            return venta;
        }

        public int AltaVenta(Venta venta, List<VentaItem> items)
        {
            int idVentaGenerada = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertVenta", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                        cmd.Parameters.AddWithValue("@FechaCreacion", venta.FechaCreacion);

                        object result = cmd.ExecuteScalar();
                        idVentaGenerada = Convert.ToInt32(result);
                    }

                    foreach (var item in items)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertVentaItem", conn, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdVenta", idVentaGenerada);
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

            return idVentaGenerada;
        }

        public bool BorrarVenta(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteVenta", conn, tran))
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

        public void ActualizarEstadoEnvio(int id, string estadoEnvio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("ActualizarEstadoEnvio", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@EstadoEnvio", estadoEnvio);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
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
