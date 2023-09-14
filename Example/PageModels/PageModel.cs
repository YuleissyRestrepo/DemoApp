using Example.Domain.DTO;
using Example.Domain.Entities.Persistence;
using FreshMvvm;
using SQLite;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Const = Example.Persistence.SQL.Settings.Constants;

namespace Example.PageModels
{
    // Capa de precentacion de un proyecto 
    public class PageModel : FreshBasePageModel
    {

        public string Title { get; set; } = "Conversor";

        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        //static SQLiteConnection Database;

        public ICommand Login => new Command(GoToConvert);

        public async void GoToConvert()
        {

            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                LoginDTO user = new LoginDTO() { Cedula = UserName, PassWord = Password };
                var aux = await App.SecurityBusinessLogic.Login(user);
                if (aux != null)
                {
                    //helpers.Settings.GeneralSettings = aux.IdRol.ToString();
                    UserLogin userLogin = new UserLogin()
                    {
                        Document= aux.Document,
                        IdRol = aux.IdRol
                    };
                    await App.SecurityBusinessLogic.UserLogin(userLogin);
                    await CoreMethods.PushPageModel<MenuPageModel>(null, true);
                }
                else
                {
                    await CoreMethods.DisplayAlert("Alerta", "Usuario no encontrado", "Vale!");
                }
            }
            else
            {
                await CoreMethods.DisplayAlert("Alerta", "Digite algo por favor", "Vale!");
            }
        }

        public ICommand GoToRegistro
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<RegistroPageModel>();
                });
            }
        }
    }
}

