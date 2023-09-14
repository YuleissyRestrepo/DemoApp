using Example.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Example.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page : ContentPage
    {
        public Page()
        {
            InitializeComponent();
        }
        

        protected override async void OnAppearing()
        {
            // es necesario escribir esta linea potqeue le dice a la funcion que se va a sobre escribir 
            base.OnAppearing();
           
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            
        }


        //async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        //{
        //    // Evalua la coneccion y  avalua la coneccion a internet
        //    if (e.NetworkAccess == NetworkAccess.Internet)
        //    {
        //        //se encarga de tarer los usuarios y si se descragan es true y si no es false );
        //        if (await App.userBusnessLogic.GetAllUsersFromAPI())
        //        {
        //            await DisplayAlert("Descarga Exitosa", "Los usuarios an sido descargados", "Ko");
        //        }
        //        else
        //        {
        //            await DisplayAlert("Descarga Fallida", "Los usuariso no pudieron ser descargados, por favor revice su coneccion", "Ko");
        //        }
        //    }
        //}
    }
}