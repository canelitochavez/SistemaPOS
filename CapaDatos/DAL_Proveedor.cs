using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Proveedor
    {
        public List<Proveedor> Listar()
        {

            List<Proveedor> listaProveedores = new List<Proveedor>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select P.IdProveedor,P.Documento,P.RazonSocial,P.Correo,P.Telefono,P.Estado");
                    query.AppendLine("From dbo.Proveedor P");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Proveedor oProveedor = new Proveedor()
                                {
                                    IdProveedor = (int)dr["IdProveedor"],
                                    Documento = (string)dr["Documento"],
                                    RazonSocial = (string)dr["RazonSocial"],
                                    Correo = (string)dr["Correo"],
                                    Telefono = (string)dr["Telefono"],
                                    Estado = (bool)dr["Estado"]
                                };

                                listaProveedores.Add(oProveedor);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaProveedores = new List<Proveedor>();
                }
            }

            return listaProveedores;
        }


        public int Registrar(Proveedor oProveedor, out string mensaje)
        {
            int idProveedorNuevo = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@documento", oProveedor.Documento);
                        cmd.Parameters.AddWithValue("@RazonSocial", oProveedor.RazonSocial);
                        cmd.Parameters.AddWithValue("@Correo", oProveedor.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oProveedor.Telefono);
                        cmd.Parameters.AddWithValue("@Estado", oProveedor.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        idProveedorNuevo = (int)cmd.Parameters["@Resultado"].Value;
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                idProveedorNuevo = 0;
                mensaje = ex.Message;
            }

            return idProveedorNuevo;
        }

        public bool Editar(Proveedor oProveedor, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProveedor", oProveedor.IdProveedor);
                        cmd.Parameters.AddWithValue("@Documento", oProveedor.Documento);
                        cmd.Parameters.AddWithValue("@RazonSocial", oProveedor.RazonSocial);
                        cmd.Parameters.AddWithValue("@Correo", oProveedor.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oProveedor.Telefono);
                        cmd.Parameters.AddWithValue("@Estado", oProveedor.Estado);
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

        public bool Eliminar(Proveedor oProveedor, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProveedor", oProveedor.IdProveedor);
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
