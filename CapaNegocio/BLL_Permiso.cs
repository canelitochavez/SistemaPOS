using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLL_Permiso
    {
        private DAL_Permiso objPermiso = new DAL_Permiso();

        public List<Permiso> Listar(int IdUsuario)
        {
            return objPermiso.Listar(IdUsuario);
        }
    }
}
