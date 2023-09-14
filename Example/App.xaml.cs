using Example.Aplication.Implements;
using Example.Domain.Interfaces.Aplication;
using Example.Domain.Interfaces.Persistence.SQL;
using Example.PageModels;
using Example.Persistence.SQL;
using FreshMvvm;
using Xamarin.Forms;

namespace Example
{
    public partial class App : Application
    {

        #region Business Logic
        public static IUserBL UserBusnessLogic { get; set; }
        public static IPermisosRolBL PermisosRolBL { get; set; }
        public static ISecurityBL SecurityBusinessLogic { get; set; }
        #endregion
        public App()
        {
            #region Repositories
            IUserRepository _userRepository = new UserRepository();
            IPermisoRolRepository _permisoRolRepository = new PermisoRolRepository();
            #endregion
            #region Services
            //IUserServices _userServices = new UserServices();
            #endregion

            #region Business logic Initialized 
            UserBusnessLogic = new UserBL(_userRepository);
            PermisosRolBL = new PermisoRolBL(_permisoRolRepository);
            SecurityBusinessLogic = new SecurityBL(UserBusnessLogic, PermisosRolBL);
            #endregion


            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<PageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;

           // MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
