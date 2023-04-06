using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Usuario
    {
        private DAL_Usuario objUsuario = new DAL_Usuario();

        public  List<Usuario> Listar()
        {
            return objUsuario.Listar();
        }

        public int Registrar(Usuario oUsuario,out string mensaje)
        {
            mensaje = string.Empty;

            if (oUsuario.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oUsuario.NombreCompleto == "")
            {
                mensaje += "El valor del campo Nombre completo no puede ser vacío.\n";
            }

            if (oUsuario.Clave == "")
            {
                mensaje += "El valor del campo Clave no puede ser vacío.\n";
            }

            if(mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objUsuario.Registrar(oUsuario, out mensaje);
            }
            
        }

        public bool Editar(Usuario oUsuario,out string mensaje)
        {
            mensaje = string.Empty;

            if (oUsuario.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oUsuario.NombreCompleto == "")
            {
                mensaje += "El valor del campo Nombre completo no puede ser vacío.\n";
            }

            if (oUsuario.Clave == "")
            {
                mensaje += "El valor del campo Clave no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objUsuario.Editar(oUsuario, out mensaje);
            }
            
        }

        public bool Eliminar(Usuario oUsuario,out string mensaje)
        {
            return objUsuario.Eliminar(oUsuario, out mensaje);
        }
    }
}
