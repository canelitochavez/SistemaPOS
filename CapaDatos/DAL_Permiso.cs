using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {

            List<Permiso> listaPermisos = new List<Permiso>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select P.IdRol,P.NombreMenu");
                    query.AppendLine("From dbo.Permiso P");
                    query.AppendLine("Inner Join dbo.Rol R ON P.IdRol = R.IdRol");
                    query.AppendLine("Inner Join dbo.Usuario U ON U.IdRol = R.IdRol");
                    query.AppendLine("WHERE U.IdUsuario = @idUsuario");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        oConexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Permiso oPermiso = new Permiso()
                                {
                                    oRol = new Rol() { IdRol = (int)dr["IdRol"] },
                                    NombreMenu = (string)dr["NombreMenu"],
                                };

                                listaPermisos.Add(oPermiso);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaPermisos = new List<Permiso>();
                }
            }

            return listaPermisos;
        }
    }
}
