using Example.Domain.Entities.Persistence;
using FreshMvvm;
using SQLite;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Example.PageModels
{
    public class MenuPageModel: FreshBasePageModel
    {
        public string Menu { get; set; } = "Menu";

        public ICommand GoToConvert
        {
            get
            {
                return new Command(async () =>
                {
                    //string idRol = helpers.Settings.GeneralSettings;
                    var userLogin = App.SecurityBusinessLogic.UserLogin(null);
                    string idRol = userLogin.Result.IdRol.ToString();
                    var aux = App.SecurityBusinessLogic.GetPermisoByRol(idRol, "Distancia");
                    if (aux.Result != null) await CoreMethods.PushPageModel<WorldPageModel>(null, true);
                    else await CoreMethods.DisplayAlert("Alerta", "No tienes permisos para entrar", "Vale!");                    
                });
            }
        }

        public ICommand GoToTemperature
        {
            get
            {
                return new Command(async () =>
                {
                    //string idRol = helpers.Settings.GeneralSettings;
                    var userLogin = App.SecurityBusinessLogic.UserLogin(null);
                    string idRol = userLogin.Result.IdRol.ToString();
                    var aux = App.SecurityBusinessLogic.GetPermisoByRol(idRol, "Temperatura");
                    if (aux.Result != null) await CoreMethods.PushPageModel<ConTemperaturaPageModel>(null, true);
                    else await CoreMethods.DisplayAlert("Alerta", "No tienes permisos para entrar", "Vale!");
                });
            }
        }

        public ICommand Logout
        {
            get
            {
                return new Command(async () =>
                {
                    UserLogin userLogin = new UserLogin() { Document = 0, IdRol = Guid.Empty };
                    await App.SecurityBusinessLogic.UserLogin(userLogin);
                    await CoreMethods.PushPageModel<PageModel>(null, true);
                });
            }
        }

        public ICommand GoToExcel
        {
            get
            {
                return new Command(async async =>
                {
                    try
                    {
                        await CoreMethods.PushPageModel<ImportExcelPageModel>(null, true);
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                        throw;
                    }
                });
            }
        }
    }
}

