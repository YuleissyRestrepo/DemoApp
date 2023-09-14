using Example.Domain.DTO;
using Example.Domain.Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Interfaces.Aplication
{
    public interface ISecurityBL : IGeneral<UserApp>
    {
        Task<UserApp> Login(LoginDTO login);
        Task<PermisoRol> GetPermisoByRol(string IdRol,string Permiso);
        Task<UserLogin> UserLogin(UserLogin userLogin);
    }
}
