using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Example.PageModels
{
    public class ConTemperaturaPageModel : FreshBasePageModel
    {
        public string caf { get; set; } = "Conversor C° a F";
        private string _Centigrade;
        public string  Centigrade
        {
            set
            {
                _Centigrade = value;
                RaisePropertyChanged();
            }
            get
            {
                return _Centigrade;
            }
        }

        private double _Fahrenheit;
        public double Fahrenheit
        {
            set
            {
                _Fahrenheit = value;
                RaisePropertyChanged();
            }
            get
            {
                return _Fahrenheit;
            }
        }


        public ICommand Calculat => new Command(ConvertT);


        public async void ConvertT()
        {

            // Si es difretente de vacio hace la opracion, si no muestra la alerta 
            if (!string.IsNullOrEmpty(Centigrade))
            {
                double aux = Convert.ToDouble(Centigrade);
                Fahrenheit = (aux * 9 / 5) + 32;
            }
            else
            {
                await CoreMethods.DisplayAlert("Alerta", "Ingresa el valor a convertir", "Vale!");
            }

            
        }

        public ICommand ComeToLoginT
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
