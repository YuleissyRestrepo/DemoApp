using Example.Domain.Entities.Persistence;
using Example.Domain.Interfaces.Aplication;
using Example.Domain.Interfaces.Persistence.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Aplication.Implements
{
    public class PermisoRolBL : IPermisosRolBL
    {
        private readonly IPermisoRolRepository _permisosRolBL;

        public PermisoRolBL(IPermisoRolRepository permisosRolBL)
        {
            _permisosRolBL = permisosRolBL;
        }
        public Task<int> Create(PermisoRol entity)
        {
            return _permisosRolBL.Create(entity);
        }

        public Task<int> Delete(PermisoRol entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PermisoRol>> Get()
        {
            return _permisosRolBL.Get();
        }

        public Task<PermisoRol> Get(int id)
        {
            return _permisosRolBL.Get(id);
        }

        public Task<PermisoRol> GetPermisoByRol(string IdRol, string Permiso)
        {
           return _permisosRolBL.GetPermisoByRol(IdRol, Permiso);
        }

        public Task<int> Update(PermisoRol entity)
        {
            return _permisosRolBL.Update(entity);
        }
    }
}
