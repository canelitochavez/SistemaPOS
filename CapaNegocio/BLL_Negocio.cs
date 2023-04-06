using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Negocio
    {
        private DAL_Negocio objNegocio = new DAL_Negocio();

        public Negocio ObtenerNegocio()
        {
            return objNegocio.ObtenerNegocio();
        }

        public bool GuardarDatos(Negocio oNegocio, out string mensaje)
        {
            mensaje = string.Empty;

            if (oNegocio.Nombre == "")
            {
                mensaje += "El valor del campo Nombre no puede ser vacío.\n";
            }

            if (oNegocio.RUC == "")
            {
                mensaje += "El valor del campo RUC no puede ser vacío.\n";
            }

            if (oNegocio.Direccion == "")
            {
                mensaje += "El valor del campo Direccion no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objNegocio.GuardarDatos(oNegocio, out mensaje);
            }
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objNegocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen,out string mensaje)
        {
            return objNegocio.ActualizarLogo(imagen,out mensaje);
        }

    }
}
