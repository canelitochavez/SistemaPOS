using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;
using System.Globalization;

namespace CapaDatos
{
    public class DAL_Reporte
    {
        public List<ReporteCompra> Compra(string fechaInicio,string fechaFin,int idProveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteCompras", oConexion))
                    {

                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                        cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ReporteCompra objReporteCompra = new ReporteCompra()
                                {
                                    FechaCreacion = dr["FechaCreacion"].ToString(),
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoTotal = dr["MontoTotal"].ToString(),
                                    UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                    DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    CodigoProducto = dr["CodigoProducto"].ToString(),
                                    NombreProducto = dr["NombreProducto"].ToString(),
                                    Categoria = dr["Categoria"].ToString(),
                                    PrecioCompra = dr["PrecioCompra"].ToString(),
                                    PrecioVenta = dr["PrecioVenta"].ToString(),
                                    Cantidad = dr["Cantidad"].ToString(),
                                    SubTotal = dr["SubTotal"].ToString()
                                };

                                lista.Add(objReporteCompra);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteCompra>();
                }
            }

            return lista;
        }

        public List<ReporteVenta> Venta(string fechaInicio, string fechaFin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ReporteVenta objReporteVenta = new ReporteVenta()
                                {
                                    FechaCreacion = dr["FechaCreacion"].ToString(),
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoTotal = dr["MontoTotal"].ToString(),
                                    UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                    DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                    NombreCliente = dr["NombreCliente"].ToString(),
                                    CodigoProducto = dr["CodigoProducto"].ToString(),
                                    NombreProducto = dr["NombreProducto"].ToString(),
                                    Categoria = dr["Categoria"].ToString(),
                                    PrecioVenta = dr["PrecioVenta"].ToString(),
                                    Cantidad = dr["Cantidad"].ToString(),
                                    SubTotal = dr["SubTotal"].ToString()
                                };

                                lista.Add(objReporteVenta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }
            
            return lista;
        }
    }
}
