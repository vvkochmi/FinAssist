using FinAssist.Model;
using FinAssist.Services;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FinAssist.ViewModel
{
    public class DemandCurveViewModel : INotifyPropertyChanged
    {
        readonly ILineCreature lineCreature;
        readonly DemandCurve demandCurve;
        readonly DemandCurve demandCurveCoeff;
        readonly ObservablePoint point = new();
        FinData finData;
        SeriesCollection demandData = new();
        double koefPref, koefInc;

        public DemandCurveViewModel()
        {
            lineCreature = new LineCreature();
            demandCurve = new DemandCurve(point);
            demandCurveCoeff = new DemandCurve(point);
            demandData = new SeriesCollection();
            finData = new FinData();
            koefPref = koefInc = 1;
        }

        public FinData FinData
        {
            get => finData;
            set
            {
                finData = value;
                point.X = finData.ProductCount;
                point.Y = finData.Price;
                AddDemandCurves();
                OnPropertyChanged();
            }
        }

        public string X
        {
            get => point.X.ToString();
            set
            {
                if (double.TryParse(value, out double x))
                {
                    point.X = x;
                    OnPropertyChanged();
                    ChangeDemandCurve();
                }
            }
        }

        public string Y
        {
            get => point.Y.ToString();
            set
            {
                if (double.TryParse(value, out double y))
                {
                    point.Y = y;
                    OnPropertyChanged();
                    ChangeDemandCurve();
                }
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

        public double SliderPrefValue
        {
            get => koefPref;
            set
            {
                if (koefPref != value)
                {
                    koefPref = value;
                    OnPropertyChanged();
                    SliderValueChanged();
                }
            }
        }

        public double SliderIncValue
        {
            get => koefInc;
            set
            {
                if (koefInc != value)
                {
                    koefInc = value;
                    OnPropertyChanged();
                    SliderValueChanged();
                }
            }
        }

        void AddDemandCurves()
        {
            demandData.Clear();
            demandData.Add(lineCreature.BuildLineSeries(demandCurve.PlottGraph(point)));
            demandData.Add(lineCreature.BuildLineSeries(demandCurveCoeff.PlottGraph(point)));
        }

        void ChangeDemandCurve()
        {
            demandCurve.PlottGraph(point);
        }

        void SliderValueChanged()
        {
            demandCurveCoeff.PlottGraph(point.X * koefPref * koefInc, point.Y * koefPref * koefInc);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
