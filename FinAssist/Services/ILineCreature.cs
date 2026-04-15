using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.Collections.ObjectModel;

namespace FinAssist.Services
{
    internal interface ILineCreature
    {
        XamlLineSeries BuildLineSeries(ObservableCollection<ObservablePoint> points);
    }
}
