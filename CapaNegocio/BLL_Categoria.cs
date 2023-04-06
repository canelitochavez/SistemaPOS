using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Categoria
    {
        private DAL_Categoria objCategoria = new DAL_Categoria();

        public List<Categoria> Listar()
        {
            return objCategoria.Listar();
        }

        public int Registrar(Categoria oCategoria,out string mensaje)
        {
            mensaje = string.Empty;

            if (oCategoria.Descripcion == "")
            {
                mensaje += "El valor del campo Descripcion no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCategoria.Registrar(oCategoria, out mensaje);
            }
        }

        public bool Editar(Categoria oCategoria,out string mensaje)
        {
            mensaje = string.Empty;

            if (oCategoria.Descripcion == "")
            {
                mensaje += "El valor del campo Descripcion no puede ser vacío.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCategoria.Editar(oCategoria, out mensaje);
            }
        }

        public bool Eliminar(Categoria oCategoria, out string mensaje)
        {
            return objCategoria.Eliminar(oCategoria,out mensaje);
        }
    }
}
