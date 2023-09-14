using Example.Domain.Common;
using Example.Domain.Entities.Persistence;
using FreshMvvm;
using SQLite;
using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Const = Example.Persistence.SQL.Settings.Constants;

namespace Example.PageModels
{
    public class RegistroPageModel : FreshBasePageModel
    {
        static SQLiteConnection Database;
        public string Registro { get; set; } = "Registro";
        public string Name { get; set; } = "";
        public string Document{ get; set; } = "";
        public string Password { get; set; } = "";
        public string Rol { get; set; } = "";

        public async void Registrar()
        {
            if (Name != "" && Document != "" && Password != "" && Rol != "")
            {
                UserApp app = new UserApp
                {
                    Name = Name,
                    Document = Int32.Parse(Document),
                    Password = Encryption.GenerarHash(Password),
                    Rol = Rol,
                    Id = Guid.NewGuid()
                };
                var aux = await App.SecurityBusinessLogic.Create(app);

                if (aux != 0)
                {
                    await CoreMethods.DisplayAlert("Registro Exitoso", "Su usuario fue creado correctamente", "Vale");
                }
                else
                {
                    await CoreMethods.DisplayAlert("Registro Fallido", "No fue posible Crear el usuario, intente de nuevo", "Vale");
                }
                
            }
        }
        public ICommand RegistrarUser => new Command(Registrar);

        public ICommand ComeToLoginR => new Command(GoLoginAsync);
        
        private async void GoLoginAsync()
        {
            await CoreMethods.PopPageModel();
        }
    }
}
