using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;

namespace FinAssist.Model
{
    internal interface IDemandCurve
    {
        XamlLineSeries BuidDemandCurve(ObservablePoint point);
    }
}
