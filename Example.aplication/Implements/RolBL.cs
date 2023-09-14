using Example.Domain.Entities.Persistence;
using Example.Domain.Interfaces.Aplication;
using Example.Domain.Interfaces.Persistence.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Aplication.Implements
{
    public class RolBL : IRolBL
    {

        private readonly IRolRepository _RolRepository;

        public RolBL(IRolRepository rolRepository)
        {
            _RolRepository = rolRepository;
        }
      

        public Task<int> Create(Rol entity)
        {
            return _RolRepository.Create(entity);
        }

        public Task<int> Delete(Rol entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rol>> Get()
        {
            return _RolRepository.Get();
        }

        public Task<Rol> Get(int id)
        {
            return (_RolRepository.Get(id));
        }

        public Task<int> Update(Rol entity)
        {
           return _RolRepository.Update(entity);
        }
    }
}
