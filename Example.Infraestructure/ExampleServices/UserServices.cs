using Example.Domain.Entities.Infraestructure;
using Example.Domain.Interfaces.InfraStructure.ExampleServices;
using Example.Domain.Resources.Environment;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace Example.Infraestructure.ExampleServices
//{
//    // Todas las capas que no sean dominio ni test van a tener interface 
//    public class UserServices : ServiceBase, IUserServices
//    {
//        public async Task<List<SecurityUser>> GetAllUsers()
//        {
//            List<SecurityUser> securityUsers = new List<SecurityUser>();

//            try
//            {
//                HttpResponse<List<SecurityUser>> result = await GetAsync<List<SecurityUser>>(ServiceSettings.GET_ALL_USER_PATH, AppSettings.HEADER_CODENAME_SECURITYID, AppSettings.SECURITY_ID);
//                securityUsers = result.Response;
//            }
//            catch (Exception ex)
//            {
//               Console.WriteLine(ex.Message);
//            }
//            return securityUsers;
//        }
//    }
//}
