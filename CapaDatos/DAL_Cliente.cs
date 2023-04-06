using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;


namespace CapaDatos
{
    public class DAL_Cliente
    {
        public List<Cliente> Listar()
        {

            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select C.IdCliente,C.Documento,C.NombreCompleto,C.Correo,C.Telefono,C.Estado");
                    query.AppendLine("From dbo.Cliente C");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Cliente oCliente = new Cliente()
                                {
                                    IdCliente = (int)dr["IdCliente"],
                                    Documento = (string)dr["Documento"],
                                    NombreCompleto = (string)dr["NombreCompleto"],
                                    Correo = (string)dr["Correo"],
                                    Telefono = (string)dr["Telefono"],
                                    Estado = (bool)dr["Estado"]
                                };

                                listaClientes.Add(oCliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaClientes = new List<Cliente>();
                }
            }

            return listaClientes;
        }

        public int Registrar(Cliente oCliente, out string mensaje)
        {
            int idClienteNuevo = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@nombreCompleto", oCliente.NombreCompleto);
                        cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@Estado", oCliente.Estado);
                        cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        idClienteNuevo = (int)cmd.Parameters["@Resultado"].Value;
                        mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                idClienteNuevo = 0;
                mensaje = ex.Message;
            }

            return idClienteNuevo;
        }


        public bool Editar(Cliente oCliente, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ModificarCliente", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", oCliente.IdCliente);
                        cmd.Parameters.AddWithValue("@documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@nombreCompleto", oCliente.NombreCompleto);
                        cmd.Parameters.AddWithValue("@Correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@Estado", oCliente.Estado);
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


        public bool Eliminar(Cliente oCliente, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("Delete From dbo.Cliente Where IdCliente = @IdCliente", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", oCliente.IdCliente);
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                        if (!respuesta)
                        {
                            mensaje = "No fue posible Eliminar el Cliente.";
                        }
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
