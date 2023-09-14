using Example.Domain.Entities.Persistence;
using Example.Domain.Interfaces.Aplication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Aplication.Implements
{
    public class PermisoBL : IPermisosBL
    {
        private readonly IPermisosBL _permisos;

        public PermisoBL(IPermisosBL permisos)
        {
            _permisos = permisos;
        }

        public Task<int> Create(Permiso entity)
        {
            return _permisos.Create(entity);
        }

        public Task<int> Delete(Permiso entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permiso>> Get()
        {
           return _permisos.Get();
        }

        public Task<Permiso> Get(int id)
        {
           return _permisos.Get(id);
        }

        public Task<int> Update(Permiso entity)
        {
            return _permisos.Update(entity);
        }
    }
}
