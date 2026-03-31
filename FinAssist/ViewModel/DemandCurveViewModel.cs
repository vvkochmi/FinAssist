using FinAssist.Model;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FinAssist.ViewModel
{
    public class DemandCurveViewModel : INotifyPropertyChanged
    {
        private readonly IDemandCurve demandCurve;
        private ObservablePoint point;
        private SeriesCollection demandData;

        public ICommand BuildDemandCommand { get; set; }

        public DemandCurveViewModel()
        {
            demandCurve = new DemandCurve();
            point = new ObservablePoint(0, 0);
            demandData = new SeriesCollection();
            BuildDemandCommand = new Command(BuildDemandCurve);
        }

        public string X
        {
            get => point.X.ToString();
            set
            {
                point.X = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }

        public string Y
        {
            get => point.Y.ToString();
            set
            {
                point.Y = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }

        public SeriesCollection DemandData
        {
            get => demandData;
            set
            {
                demandData = value;
                OnPropertyChanged();
            }
        }

        private void BuildDemandCurve()
        {
            demandData.Clear();
            DemandData.Add(demandCurve.BuidDemandCurve(point));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
