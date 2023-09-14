using Example.Domain.DTO;
using Example.Domain.Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Interfaces.Aplication
{
    public interface IPermisosRolBL : IGeneral<PermisoRol>
    {
        Task<PermisoRol>GetPermisoByRol(string IdRol, string Permiso);
    }
}
