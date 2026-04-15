using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.Collections.ObjectModel;

namespace FinAssist.Services
{
    public class LineCreature : ILineCreature
    {
        public XamlLineSeries BuildLineSeries(ObservableCollection<ObservablePoint> points)
        {
            return new XamlLineSeries
            {
                Values = points,
                Fill = null,
                GeometrySize = 5,
                YToolTipLabelFormatter = (chartPoint) => $" Цена: {Math.Round(chartPoint.Coordinate.PrimaryValue, 2)} Кол-во товара: {Math.Round(chartPoint.Coordinate.SecondaryValue)}",
            };
        }
    }
}
