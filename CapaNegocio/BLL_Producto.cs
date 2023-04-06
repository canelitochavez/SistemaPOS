using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Producto
    {
        private DAL_Producto objProducto = new DAL_Producto();

        public List<Producto> Listar()
        {
            return objProducto.Listar();
        }

        public int Registrar(Producto oProducto, out string mensaje)
        {
            mensaje = string.Empty;

            if (oProducto.Codigo == "")
            {
                mensaje += "El valor del campo Codigo no puede ser vacío.\n";
            }

            if (oProducto.Nombre == "")
            {
                mensaje += "El valor del campo Nombre no puede ser vacío.\n";
            }

            if (oProducto.Descripcion == "")
            {
                mensaje += "El valor del campo Descripcion no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objProducto.Registrar(oProducto, out mensaje);
            }

        }


        public bool Editar(Producto oProducto, out string mensaje)
        {
            mensaje = string.Empty;

            if (oProducto.Codigo == "")
            {
                mensaje += "El valor del campo Codigo no puede ser vacío.\n";
            }

            if (oProducto.Nombre == "")
            {
                mensaje += "El valor del campo Nombre no puede ser vacío.\n";
            }

            if (oProducto.Descripcion == "")
            {
                mensaje += "El valor del campo Descripcion no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objProducto.Editar(oProducto, out mensaje);
            }

        }

        public bool Eliminar(Producto oProducto, out string mensaje)
        {
            return objProducto.Eliminar(oProducto, out mensaje);
        }

        public bool CheckProducto(string idProducto, out string mensaje, string precioCompra = "0", string precioVenta = "0",string stock = "0",string cantidad = "0")
        {
            mensaje = string.Empty;

            if (int.Parse(idProducto) == 0)
            {
                mensaje += "Debe seleccionar un Producto.\n";
            }

            decimal _precioCompra = 0;

            if (!decimal.TryParse(precioCompra, out _precioCompra))
            {
                mensaje += "El valor del campo Precio de Compra no tiene el Formato Correcto.\n";
            }

            decimal _precioVenta = 0;

            if (!decimal.TryParse(precioVenta, out _precioVenta))
            {
                mensaje += "El valor del campo Precio de Venta no tiene el Formato Correcto.\n";
            }

            if(Convert.ToInt32(stock) < Convert.ToInt32(cantidad))
            {
                mensaje += "La cantidad de productos supera el stock disponible.\n";
            }


            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
