using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace DivisasXamarin.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private decimal pesos;
        private decimal dollars;
        private decimal euros;
        private decimal pounds;
        public decimal Pesos { get => pesos; set => pesos = value; }
        public decimal Dollars
        {
            get => dollars;
            set
            {
                if (dollars != value)
                {
                    dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
        }
        public decimal Euros
        {
            get => euros;
            set
            {
                if (euros != value)
                {
                    euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
        }
        public decimal Pounds
        {
            get => pounds;
            set
            {
                if (pounds != value)
                {
                    pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } } 
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        private async void ConvertMoney()
        {
            if(Pesos <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un valor mayor a cero en pesos", "Aceptar");
                return;
            }
            Dollars = Pesos / 19.05M;
            Euros = Pesos / 22.14M;
            Pounds = Pesos / 24.85M;
        }
    }
}