using FinAssist.Model;
using FinAssist.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FinAssist.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        FinData data;

        public ICommand NavigateCommand { get; }

        public MainPageViewModel(INavigation navigation)
        {
            data = new FinData();

            NavigateCommand = new Command(() => new NavigationService(navigation).NavigateToDemandCurve(data));
        }

        public string Price
        {
            get => data.Price.ToString();
            set
            {
                data.Price = Convert.ToDouble(value == "" ? 0 : value);
                OnPropertyChanged();
            }
        }

        public string ProductCount
        {
            get => data.ProductCount.ToString();
            set
            {
                data.ProductCount = Convert.ToInt32(value == "" ? 0 : value);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
