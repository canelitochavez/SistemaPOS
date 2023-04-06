using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Negocio
    {
        public Negocio ObtenerNegocio()
        {
            Negocio objNegocio = null;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select N.IdNegocio,N.Nombre,N.RUC,N.Direccion");
                    query.AppendLine("From dbo.Negocio N");
                    query.AppendLine("Where N.IdNegocio = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objNegocio = new Negocio()
                                {
                                    IdNegocio = (int)dr["IdNegocio"],
                                    Nombre = (string)dr["Nombre"],
                                    RUC = (string)dr["RUC"],
                                    Direccion = (string)dr["Direccion"]
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objNegocio = new Negocio();
                }
            }

            return objNegocio;
        }

        public bool GuardarDatos(Negocio oNegocio,out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Update Negocio");
                    query.AppendLine("Set Nombre = @Nombre,");
                    query.AppendLine("RUC = @RUC,");
                    query.AppendLine("Direccion = @Direccion");
                    query.AppendLine("Where IdNegocio = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oNegocio.Nombre);
                        cmd.Parameters.AddWithValue("@RUC", oNegocio.RUC);
                        cmd.Parameters.AddWithValue("@Direccion", oNegocio.Direccion);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        if (cmd.ExecuteNonQuery() < 1)
                        {
                            mensaje = "No fue posible guardar los datos.";
                            respuesta = false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }

            }

            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoBytes = new byte[0];

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select N.Logo");
                    query.AppendLine("From dbo.Negocio N");
                    query.AppendLine("Where N.IdNegocio = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                logoBytes = (byte[])dr["Logo"];
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    obtenido = false;
                    logoBytes = new byte[0];
                }
            }

            return logoBytes;
        }

        public bool ActualizarLogo(byte[] image,out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Update Negocio");
                    query.AppendLine("Set Logo = @Imagen");
                    query.AppendLine("Where IdNegocio = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Imagen", image);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();

                        if (cmd.ExecuteNonQuery() < 1)
                        {
                            mensaje = "No fue posible guardar el logo.";
                            respuesta = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}
