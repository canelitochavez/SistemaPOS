using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Usuario
    {
        public  List<Usuario> Listar()
        {

            List<Usuario> listaUsuarios = new List<Usuario>();

            using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select U.IdUsuario,U.Documento,U.NombreCompleto,U.Correo,U.Clave,U.Estado,R.IdRol,R.Descripcion");
                    query.AppendLine("From dbo.Usuario U");
                    query.AppendLine("Inner Join dbo.Rol R ON U.IdRol = R.IdRol");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(),oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using(SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                Usuario oUsuario = new Usuario()
                                { 
                                    IdUsuario = (int)dr["IdUsuario"],
                                    Documento = (string)dr["Documento"],
                                    NombreCompleto = (string)dr["NombreCompleto"],
                                    Correo = (string)dr["Correo"],
                                    Clave = (string)dr["Clave"],
                                    Estado = (bool)dr["Estado"],
                                    oRol = new Rol() { IdRol = (int)dr["IdRol"], Descripcion = (string)dr["Descripcion"] }
                                };

                                listaUsuarios.Add(oUsuario);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    listaUsuarios = new List<Usuario>();
                }
            }

            return listaUsuarios;
        }
        public int Registrar(Usuario oUsuario, out string mensaje)
        {
            int idUsuarioNuevo = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                        cmd.Parameters.AddWithValue("@nombreCompleto", oUsuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);
                        cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
                        cmd.Parameters.AddWithValue("@idRol", oUsuario.oRol.IdRol);
                        cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                        cmd.Parameters.Add("@idUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@menaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        idUsuarioNuevo = (int)cmd.Parameters["@idUsuarioResultado"].Value;
                        mensaje = (string)cmd.Parameters["@menaje"].Value;
                    }
                        
                }
            }
            catch(Exception ex)
            {
                idUsuarioNuevo = 0;
                mensaje = ex.Message;
            }

            return idUsuarioNuevo;
        }

        public bool Editar(Usuario oUsuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", oUsuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                        cmd.Parameters.AddWithValue("@nombreCompleto", oUsuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);
                        cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
                        cmd.Parameters.AddWithValue("@idRol", oUsuario.oRol.IdRol);
                        cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                        cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@menaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(cmd.Parameters["@respuesta"].Value);
                        mensaje = (string)cmd.Parameters["@menaje"].Value;
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

        public bool Eliminar(Usuario oUsuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", oUsuario.IdUsuario);
                        cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@menaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        cmd.ExecuteNonQuery();

                        respuesta = (bool)cmd.Parameters["@respuesta"].Value;
                        mensaje = (string)cmd.Parameters["@menaje"].Value;
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
