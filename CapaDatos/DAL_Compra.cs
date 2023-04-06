using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Compra
    {
        public int GenerarNuevoIdCompra()
        {
            int nuevoIdCompra = 0;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select COUNT(*) + 1 AS IdCompra");
                    query.AppendLine("From dbo.Compra C");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        nuevoIdCompra = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    nuevoIdCompra = 0;
                }
            }

            return nuevoIdCompra;
        }

        public bool Registrar(Compra oCompra,DataTable dt,out string mensaje)
        {
            bool laCompraFueExitosa = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", oCompra.oUsuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@IdProveedor", oCompra.oProveedor.IdProveedor);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oCompra.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", oCompra.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@MontoTotal", oCompra.MontoTotal);
                        cmd.Parameters.AddWithValue("@DetalleCompra", dt);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        laCompraFueExitosa = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                laCompraFueExitosa = false;
                mensaje = ex.Message;
            }

            return laCompraFueExitosa;
        }


        public Compra ObtenerCompra(string numeroDocumento)
        {
            Compra objCompra = null;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select C.IdCompra,U.NombreCompleto,P.Documento,P.RazonSocial,C.TipoDocumento,");
                    query.AppendLine("C.NumeroDocumento,C.MontoTotal,CONVERT(CHAR(10),C.FechaCreacion,103) AS FechaCreacion");
                    query.AppendLine("From dbo.Compra C");
                    query.AppendLine("INNER JOIN dbo.Usuario U");
                    query.AppendLine("ON C.IdUsuario = U.IdUsuario");
                    query.AppendLine("INNER JOIN dbo.Proveedor P");
                    query.AppendLine("ON C.IdProveedor = P.IdProveedor");
                    query.AppendLine("WHERE C.NumeroDocumento = @numero");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@numero", numeroDocumento);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objCompra = new Compra()
                                {
                                    IdCompra = (int)dr["IdCompra"],
                                    oUsuario = new Usuario() { NombreCompleto = (string)dr["NombreCompleto"] },
                                    oProveedor = new Proveedor() { Documento = (string)dr["Documento"], RazonSocial = (string)dr["RazonSocial"] },
                                    TipoDocumento = (string)dr["TipoDocumento"],
                                    NumeroDocumento = (string)dr["NumeroDocumento"],
                                    MontoTotal = (decimal)dr["MontoTotal"],
                                    FechaCreacion = (string)dr["FechaCreacion"]
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objCompra = new Compra();
                }
            }

            return objCompra; 
        }


        public List<DetalleCompra> ObtenerDetalleCompra(int idCompra)
        {

            List<DetalleCompra> listaDetalleCompra = new List<DetalleCompra>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select P.Nombre,DC.PrecioCompra,DC.Cantidad,DC.MontoTotal");
                    query.AppendLine("From dbo.DetalleCompra DC");
                    query.AppendLine("INNER JOIN dbo.Producto P");
                    query.AppendLine("ON P.IdProducto = DC.IdProducto");
                    query.AppendLine("WHERE DC.IdCompra = @idCompra");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idCompra", idCompra);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DetalleCompra oDetalleCompra = new DetalleCompra()
                                {
                                    oProducto = new Producto() { Nombre = (string)dr["Nombre"] },
                                    PrecioCompra = (decimal)dr["PrecioCompra"],
                                    Cantidad = (int)dr["Cantidad"],
                                    MontoTotal = (decimal)dr["MontoTotal"]
                                };

                                listaDetalleCompra.Add(oDetalleCompra);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaDetalleCompra = new List<DetalleCompra>();
                }
            }

            return listaDetalleCompra;
        }

    }
}
