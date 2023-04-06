using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Producto
    {
        public List<Producto> Listar()
        {

            List<Producto> listaProductos = new List<Producto>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select P.IdProducto,P.Codigo,P.Nombre,P.Descripcion,C.IdCategoria,C.Descripcion AS DescripcionCategoria,P.Stock,P.PrecioCompra,P.PrecioVenta,P.Estado");
                    query.AppendLine("From dbo.Producto P");
                    query.AppendLine("Inner Join dbo.Categoria C ON P.IdCategoria = C.IdCategoria");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto oProducto = new Producto()
                                {
                                    IdProducto = (int)dr["IdProducto"],
                                    Codigo = (string)dr["Codigo"],
                                    Nombre = (string)dr["Nombre"],
                                    Descripcion = (string)dr["Descripcion"],
                                    oCategoria = new Categoria() { IdCategoria = (int)dr["IdCategoria"], Descripcion = (string)dr["DescripcionCategoria"] },
                                    Stock = (int)dr["Stock"],
                                    PrecioCompra =  Convert.ToDecimal(dr["PrecioCompra"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                };

                                listaProductos.Add(oProducto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaProductos = new List<Producto>();
                }
            }

            return listaProductos;
        }
        public int Registrar(Producto oProducto, out string mensaje)
        {
            int idProductoNuevo = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", oProducto.Codigo);
                        cmd.Parameters.AddWithValue("@Nombre", oProducto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                        cmd.Parameters.AddWithValue("@IdCategoria", oProducto.oCategoria.IdCategoria);
                        cmd.Parameters.AddWithValue("@Estado", oProducto.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        idProductoNuevo = (int)cmd.Parameters["@Resultado"].Value;
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                idProductoNuevo = 0;
                mensaje = ex.Message;
            }

            return idProductoNuevo;
        }


        public bool Editar(Producto oProducto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", oProducto.IdProducto);
                        cmd.Parameters.AddWithValue("@Nombre", oProducto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                        cmd.Parameters.AddWithValue("@IdCategoria", oProducto.oCategoria.IdCategoria);
                        cmd.Parameters.AddWithValue("@Estado", oProducto.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
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


        public bool Eliminar(Producto oProducto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarProducto", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", oProducto.IdProducto);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = (bool)cmd.Parameters["@Resultado"].Value;
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
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
