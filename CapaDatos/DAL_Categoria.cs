using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select C.IdCategoria,C.Descripcion,C.Estado From dbo.Categoria C");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Categoria oCategoria = new Categoria()
                                {
                                    IdCategoria = (int)dr["IdCategoria"],
                                    Descripcion = (string)dr["Descripcion"],
                                    Estado = (bool)dr["Estado"]
                                };

                                listaCategorias.Add(oCategoria);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaCategorias = new List<Categoria>();
                }
            }

            return listaCategorias;
        }

        public int Registrar(Categoria oCategoria, out string mensaje)
        {
            int idCategoriaNueva = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", oCategoria.Descripcion);
                        cmd.Parameters.AddWithValue("@Estado", oCategoria.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        idCategoriaNueva = (int)cmd.Parameters["@Resultado"].Value;
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                idCategoriaNueva = 0;
                mensaje = ex.Message;
            }

            return idCategoriaNueva;
        }

        public bool Editar(Categoria oCategoria, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EditarCategoria", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdCategoria", oCategoria.IdCategoria);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoria.Descripcion);
                        cmd.Parameters.AddWithValue("@Estado", oCategoria.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Categoria oCategoria,out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdCategoria", oCategoria.IdCategoria);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
