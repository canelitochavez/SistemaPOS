using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class DAL_Rol
    {
        public List<Rol> Listar()
        {

            List<Rol> listaDeRoles = new List<Rol>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "Select IdRol,Descripcion From dbo.Rol";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Rol oRol = new Rol()
                                {
                                    IdRol =(int)dr["IdRol"],
                                    Descripcion = (string)dr["Descripcion"],
                                };

                                listaDeRoles.Add(oRol);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaDeRoles = new List<Rol>();
                }
            }

            return listaDeRoles;
        }
    }
}
