using Example.Domain.Common;
using Example.Domain.DTO;
using Example.Domain.Entities.Persistence;
using Example.Domain.Interfaces.Aplication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Aplication.Implements
{
    public class SecurityBL : ISecurityBL
    {
        public readonly IPermisosRolBL _permisosRolBL;
        private readonly IUserBL _userBL;
        public SecurityBL(IUserBL userBL, IPermisosRolBL permisosRolBL)
        {
            _userBL = userBL;
            _permisosRolBL = permisosRolBL;
        }
        public Task<int> Create(UserApp entity) => _userBL.Create(entity);
        public Task<int> Delete(UserApp entity)
        {
            throw new NotImplementedException();
        }
        public Task<List<UserApp>> Get()
        {
            throw new NotImplementedException();
        }
        public Task<UserApp> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PermisoRol> GetPermisoByRol(string IdRol, string Permiso)
        {
            PermisoRol permisoRol = await _permisosRolBL.GetPermisoByRol(IdRol, Permiso);
            if (permisoRol != null)
            {
                return permisoRol;
            }
            return null;
        }
        
        public async Task<UserApp> Login(LoginDTO login)
        {
            UserApp user = await _userBL.GetByCedula(login.Cedula);
            if (user != null) {
                bool aux = Encryption.ValidateEncodedPassword(login.PassWord, user.Password);
                if (aux) return user;
            }
            return null;
        }
        public Task<int> Update(UserApp entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLogin> UserLogin(UserLogin userLogin)
        {
            return await _userBL.UserLogin(userLogin);
        }
    }
}
