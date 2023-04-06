using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Proveedor
    {
        private DAL_Proveedor objProveedor = new DAL_Proveedor();

        public List<Proveedor> Listar()
        {
            return objProveedor.Listar();
        }

        public int Registrar(Proveedor oProveedor, out string mensaje)
        {
            mensaje = string.Empty;

            if (oProveedor.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oProveedor.RazonSocial == "")
            {
                mensaje += "El valor del campo Razon Social no puede ser vacío.\n";
            }

            if (oProveedor.Correo == "")
            {
                mensaje += "El valor del campo Correo no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objProveedor.Registrar(oProveedor, out mensaje);
            }

        }

        public bool Editar(Proveedor oProveedor, out string mensaje)
        {
            mensaje = string.Empty;

            if (oProveedor.Documento == "")
            {
                mensaje += "El valor del campo Documento no puede ser vacío.\n";
            }

            if (oProveedor.RazonSocial == "")
            {
                mensaje += "El valor del campo Razon Social no puede ser vacío.\n";
            }

            if (oProveedor.Correo == "")
            {
                mensaje += "El valor del campo Correo no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objProveedor.Editar(oProveedor, out mensaje);
            }

        }

        public bool Eliminar(Proveedor oProveedor, out string mensaje)
        {
            return objProveedor.Eliminar(oProveedor, out mensaje);
        }

    }
}
