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
    public class PermisoDAL
    {
        public List<Container> GetAll(int? idFamilia)
        {


            var where = " NOT IN (SELECT idHijo FROM permisos_permisos)";

            if (idFamilia != null)
            {
                where = " = " + idFamilia + " ";
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var cnn = new SqlConnection(connectionString);
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"
                        WITH recursivo AS (
                            SELECT 
                                NULL AS idPadre,
                                p.id AS idHijo,
                                1 AS Nivel
                            FROM permisos p
                            WHERE p.id {where}
                        
                            UNION ALL 
                        
                            SELECT 
                                sp.idPadre, 
                                sp.idHijo,
                                r.Nivel + 1
                            FROM permisos_permisos sp
                            INNER JOIN recursivo r ON r.idHijo = sp.idPadre
                            WHERE r.Nivel < 4
                        )
                        SELECT 
                            r.idPadre,
                            r.idHijo,
                            p.id,
                            p.nombre,
                            p.es_padre
                        FROM recursivo r
                        INNER JOIN permisos p ON r.idHijo = p.id;
                        ";


            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<Container>();
            
            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["idPadre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("idPadre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                var esPadre = reader.GetBoolean(reader.GetOrdinal("es_padre"));


                Container c;

                if (esPadre)
                    c = new Familia();
                else
                    c = new Permiso();

                c.Id = id;
                c.Nombre = nombre;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }



            }
            reader.Close();
            cnn.Close();


            return lista;
        }


        public bool IsInRole(int id)
        {
            var lista = GetAll(null);

            var c = GetComponent(id, lista);

            return c != null;
        }


        private Container GetComponent(int id, List<Container> lista)
        {
            try
            {
                Container component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

                if (component == null && lista != null)
                {
                    foreach (var c in lista)
                    {

                        var l = GetComponent(id, c.Hijos);
                        if (l != null && l.Id == id) return l;
                        else
                        if (l != null)
                            return GetComponent(id, l.Hijos);

                    }
                }

                return component;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CrearPermiso(Permiso permiso)
        {
            try
            {
                int permisoId = 0;

                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertPermiso", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Nombre", permiso.Nombre);
                            cmd.Parameters.AddWithValue("@EsPadre", permiso.EsPadre);


                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                permisoId = Convert.ToInt32(result);
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

                return permisoId;
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
    

        public Permiso GetPermiso(int id)
        {
            Permiso permiso = new Permiso();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetPermiso", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    permiso = new Permiso
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nombre = reader["nombre"].ToString(),
                                        EsPadre = Convert.ToBoolean(reader["es_padre"])
                                    };
                                }
                            }

                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                }

                return permiso;
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

        public void BorrarPermiso(int id)
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
                        using (SqlCommand cmd = new SqlCommand("DeletePermiso", conn, transaction))
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

        public void EditarPermiso(Permiso permiso)
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
                        using (SqlCommand cmd = new SqlCommand("EditPermiso", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", permiso.Id);
                            cmd.Parameters.AddWithValue("@Nombre", permiso.Nombre);
                            cmd.Parameters.AddWithValue("@EsPadre", permiso.EsPadre);


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

        public List<Permiso> GetPermisos()
        {
            List<Permiso> permisos = new List<Permiso>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetPermisos", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    permisos.Add(new Permiso
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nombre = reader["nombre"].ToString(),
                                        EsPadre= Convert.ToBoolean(reader["es_padre"])
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

                return permisos;
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

        public void VincularPermisos(int idPadre, int idHijo)
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
                        using (SqlCommand cmd = new SqlCommand("VincularPermisos", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@IdPadre", idPadre);
                            cmd.Parameters.AddWithValue("@IdHijo", idHijo);


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

        public void AsignarPermiso(int idUsuario, int idPermiso)
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
                        using (SqlCommand cmd = new SqlCommand("AsignarPermiso", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);


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
        
        public void DesasignarPermisos(int idUsuario)
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
                        using (SqlCommand cmd = new SqlCommand("DesasignarPermisos", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);


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

        public List<Container> GetPermisosDeUsuario(int idUsuario)
        {
            List<Container> permisos = new List<Container>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("GetUsuarioPermisos", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", idUsuario);

                            var ids = new List<int>();

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    ids.Add(reader.GetInt32(0));
                                }
                            }



                            foreach (var idPermiso in ids)
                            {
                                var permisosHilo = GetAll(idPermiso);
                                permisos.AddRange(permisosHilo);
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

                return permisos;
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

