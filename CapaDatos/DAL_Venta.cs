using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Venta
    {
        public int GenerarNuevoIdVenta()
        {
            int nuevoIdVenta = 0;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select COUNT(*) + 1 AS IdVenta");
                    query.AppendLine("From dbo.Venta C");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        nuevoIdVenta = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    nuevoIdVenta = 0;
                }
            }

            return nuevoIdVenta;
        }

        public bool RestarStock(int IdProducto,int Cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool SumarStock(int IdProducto, int Cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock + @Cantidad WHERE IdProducto = @IdProducto");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Registrar(Venta oVenta, DataTable dt, out string mensaje)
        {
            bool laVentaFueExitosa = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", oVenta.oUsuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oVenta.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", oVenta.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@DocumentoCliente", oVenta.DocumentoCliente);
                        cmd.Parameters.AddWithValue("@NombreCliente", oVenta.NombreCliente);
                        cmd.Parameters.AddWithValue("@Efectivo", oVenta.MontoPago);
                        cmd.Parameters.AddWithValue("@Cambio", oVenta.MontoCambio);
                        cmd.Parameters.AddWithValue("@Total", oVenta.MontoTotal);
                        cmd.Parameters.AddWithValue("@DetalleVenta", dt);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        laVentaFueExitosa = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                laVentaFueExitosa = false;
                mensaje = ex.Message;
            }

            return laVentaFueExitosa;
        }


        public Venta ObtenerVenta(string numeroDocumento)
        {
            Venta objVenta = null;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select V.IdVenta,U.NombreCompleto,V.DocumentoCliente,V.NombreCliente,");
                    query.AppendLine("V.TipoDocumento,V.NumeroDocumento,V.MontoPago,V.MontoCambio,V.MontoTotal,");
                    query.AppendLine("CONVERT(CHAR(10),V.FechaCreacion,103) AS FechaCreacion");
                    query.AppendLine("From dbo.Venta V");
                    query.AppendLine("INNER JOIN dbo.Usuario U");
                    query.AppendLine("ON V.IdUsuario = U.IdUsuario");
                    query.AppendLine("WHERE V.NumeroDocumento = @numero");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@numero", numeroDocumento);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objVenta = new Venta()
                                {
                                    IdVenta = (int)dr["IdVenta"],
                                    oUsuario = new Usuario() { NombreCompleto = (string)dr["NombreCompleto"] },
                                    DocumentoCliente = (string)dr["DocumentoCliente"],
                                    NombreCliente = (string)dr["NombreCliente"],
                                    TipoDocumento = (string)dr["TipoDocumento"],
                                    NumeroDocumento = (string)dr["NumeroDocumento"],
                                    MontoPago = (decimal)dr["MontoPago"],
                                    MontoCambio = (decimal)dr["MontoCambio"],
                                    MontoTotal = (decimal)dr["MontoTotal"],
                                    FechaCreacion = (string)dr["FechaCreacion"]
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objVenta = new Venta();
                }
            }

            return objVenta;
        }


        public List<DetalleVenta> ObtenerDetalleVenta(int idVenta)
        {

            List<DetalleVenta> listaDetalleVenta = new List<DetalleVenta>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select P.Nombre,DV.PrecioVenta,DV.Cantidad,DV.SubTotal");
                    query.AppendLine("From dbo.DetalleVenta DV");
                    query.AppendLine("INNER JOIN dbo.Producto P");
                    query.AppendLine("ON P.IdProducto = DV.IdProducto");
                    query.AppendLine("WHERE DV.IdVenta = @idVenta");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DetalleVenta oDetalleVenta = new DetalleVenta()
                                {
                                    oProducto = new Producto() { Nombre = (string)dr["Nombre"] },
                                    PrecioVenta = (decimal)dr["PrecioVenta"],
                                    Cantidad = (int)dr["Cantidad"],
                                    SubTotal = (decimal)dr["SubTotal"]
                                };

                                listaDetalleVenta.Add(oDetalleVenta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaDetalleVenta = new List<DetalleVenta>();
                }
            }

            return listaDetalleVenta;
        }
    }
}
