using FreshMvvm;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Example.PageModels
{
    public class WorldPageModel : FreshBasePageModel
    {
        public string cmam { get; set; } = "Conversor Cm a m";
        private string _Centimeters;
        public string Centimeters
        {
            set
            {
                _Centimeters = value;
                RaisePropertyChanged();
            }
            get
            {
                return _Centimeters;
            }
        }

        private double _Meters;
        public double Meters
        {
            set
            {
                _Meters = value;
                RaisePropertyChanged();
            }
            get
            {
                return _Meters;
            }
        }



        public ICommand Calculate => new Command(Convertc);


        public async void Convertc()
        
        {
            // Si es difretente de vacio hace la opracion, si no muestra la alerta 
            if (!string.IsNullOrEmpty(Centimeters))
            {
                double aux = Convert.ToDouble(Centimeters);
                Meters = aux / 100;
            }
            else
            {
                await CoreMethods.DisplayAlert("Alerta", "Ingrse un valor para convertir", "Vale!");
            }
           
        }



        public ICommand ComeToLogin
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PopPageModel(modal: true, animate: true);

                });
            }
        }

    }
}
