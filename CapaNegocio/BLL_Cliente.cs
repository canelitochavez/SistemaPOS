using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class BLL_Cliente
    {
        private DAL_Cliente objCliente = new DAL_Cliente();

        public List<Cliente> Listar()
        {
            return objCliente.Listar();
        }

        public int Registrar(Cliente oCliente, out string mensaje)
        {
            mensaje = string.Empty;

            if (oCliente.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oCliente.NombreCompleto == "")
            {
                mensaje += "El valor del campo Nombre completo no puede ser vacío.\n";
            }

            if (oCliente.Correo == "")
            {
                mensaje += "El valor del campo Correo no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCliente.Registrar(oCliente, out mensaje);
            }

        }

        public bool Editar(Cliente oCliente, out string mensaje)
        {
            mensaje = string.Empty;

            if (oCliente.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oCliente.NombreCompleto == "")
            {
                mensaje += "El valor del campo Nombre completo no puede ser vacío.\n";
            }

            if (oCliente.Correo == "")
            {
                mensaje += "El valor del campo cOOREO no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCliente.Editar(oCliente, out mensaje);
            }

        }

        public bool Eliminar(Cliente oCliente, out string mensaje)
        {
            return objCliente.Eliminar(oCliente, out mensaje);
        }
    }
}
