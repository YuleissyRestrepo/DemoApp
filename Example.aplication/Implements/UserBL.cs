using Example.Domain.Entities.Persistence;
using Example.Domain.Interfaces.Aplication;
using Example.Domain.Interfaces.Persistence.SQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Example.Aplication.Implements
{

    public class UserBL : IUserBL
    { 

        // Variable privada de solo lectura 
       // private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;

        // Constructor 
        public UserBL( IUserRepository userRepository)
        {
            //_userServices = userServices;
            _userRepository = userRepository;
        }

        public Task<int> Create(UserApp entity)
        {
            return _userRepository.Create(entity);
        }

        public Task<List<UserApp>> Get()
        {
           return _userRepository.Get(); 
        }

        public Task<int> Delete(UserApp entity)
        {
            throw new NotImplementedException(); // Mañana consultamos 
        }


        public Task<UserApp> Get(int id)
        {
          return _userRepository.Get(id);
        }

        public Task<int> Update(UserApp entity)
        {
            return _userRepository.Update(entity);
        }

        public Task<UserApp> GetByCedula(string cedula) => _userRepository.GetByCedula(cedula);

        public Task<UserLogin> UserLogin(UserLogin userLogin)
        {
            return _userRepository.UserLogin(userLogin);
        }
    }
}
