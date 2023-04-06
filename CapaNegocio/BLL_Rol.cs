using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Rol
    {
        private DAL_Rol objRol = new DAL_Rol();

        public List<Rol> Listar()
        {
            return objRol.Listar();
        }
    }
}
