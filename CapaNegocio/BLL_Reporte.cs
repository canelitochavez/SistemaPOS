using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Reporte
    {
        private DAL_Reporte objReporte = new DAL_Reporte();

        public List<ReporteCompra> Compra(string fechaInicio,string fechaFin,int idProveedor)
        {
            return objReporte.Compra(fechaInicio, fechaFin, idProveedor);
        }
        public List<ReporteVenta> Venta(string fechaInicio, string fechaFin)
        {
            return objReporte.Venta(fechaInicio, fechaFin);
        }
    }
}
