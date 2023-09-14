using Example.Domain.Entities.Persistence;
using System.Threading.Tasks;

namespace Example.Domain.Interfaces.Aplication
{
    // Optiene los usuariuos del cervidor y los guarda en el dispocitivo 
    public interface IUserBL : IGeneral<UserApp>
    {
        Task<UserApp> GetByCedula(string cedula);
        Task<UserLogin> UserLogin(UserLogin userLogin);
    }
}
