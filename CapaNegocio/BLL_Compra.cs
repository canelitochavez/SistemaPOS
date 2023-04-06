using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Compra
    {
        private DAL_Compra objCompra = new DAL_Compra();

        public int GenerarNuevoIdCompra()
        {
            return objCompra.GenerarNuevoIdCompra();
        }
        public bool Registrar(string idProveddor,int numeroDeCompras,Compra oCompra,DataTable dt, out string mensaje)
        {
            mensaje = string.Empty;

            if (Convert.ToInt32(idProveddor) == 0)
            {
                mensaje += "El valor del campo Proveedor no puede ser vacío.\n";
            }

            if(numeroDeCompras < 1)
            {
                mensaje += "Debe ingresar Productos en la Compra.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCompra.Registrar(oCompra, dt, out mensaje);
            } 
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objCompra.ObtenerCompra(numero);

            if(oCompra.IdCompra != 0)
            {
                List<DetalleCompra> oDetalleCompra = objCompra.ObtenerDetalleCompra(oCompra.IdCompra);

                oCompra.oDetalleCompra = oDetalleCompra;
            }

            return oCompra;
        }
    }
}
