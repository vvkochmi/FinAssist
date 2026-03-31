using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.Collections.ObjectModel;

namespace FinAssist.Model
{
    public class DemandCurve : IDemandCurve
    {
        public XamlLineSeries BuidDemandCurve(ObservablePoint point)
        {
            ObservableCollection<ObservablePoint> values = new ObservableCollection<ObservablePoint>();
            
            double? step = (point.X - point.X / 2) / 5;
            double? x = point.X / 2;
            double? y = 0;

            for (int i = 0; i <= 10; i++, x += step)
            {
                if (i == 5)
                {
                    values.Add(new ObservablePoint(point.X, point.Y));
                    x = point.X;
                }

                y = point.X * point.Y / x;
                values.Add(new ObservablePoint(x, y));
            }

            return new XamlLineSeries
            {
                Values = values,
                Fill = null,
                GeometrySize = 0,

            };
        }
    }
}
