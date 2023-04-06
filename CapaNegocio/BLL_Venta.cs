using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Venta
    {
        private DAL_Venta objVenta = new DAL_Venta();
        public int GenerarNuevoIdVenta()
        {
            return objVenta.GenerarNuevoIdVenta();
        }

        public bool Registrar(string documentoCliente,string nombreCliente, int numeroDeVentas, Venta oVenta, DataTable dt, out string mensaje)
        {
            mensaje = string.Empty;

            if (documentoCliente == "")
            {
                mensaje += "El valor del campo Documento Cliente no puede ser vacío.\n";
            }

            if (nombreCliente == "")
            {
                mensaje += "El valor del campo Nombre Cliente no puede ser vacío.\n";
            }

            if (numeroDeVentas < 1)
            {
                mensaje += "Debe ingresar Productos en la Venta.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objVenta.Registrar(oVenta, dt, out mensaje);
            }
        }

        public bool RestarStock(int IdProducto, int Cantidad)
        {
            return objVenta.RestarStock(IdProducto, Cantidad);
        }

        public bool SumarStock(int IdProducto, int Cantidad)
        {
            return objVenta.SumarStock(IdProducto, Cantidad);
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = objVenta.ObtenerVenta(numero);

            if (oVenta.IdVenta != 0)
            {
                List<DetalleVenta> oDetalleVenta = objVenta.ObtenerDetalleVenta(oVenta.IdVenta);

                oVenta.oDetalleVenta = oDetalleVenta;
            }

            return oVenta;
        }

    }
}
