using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Maui;
using System.Collections.ObjectModel;

namespace FinAssist.Model
{
    public class DemandCurve
    {
        readonly ObservablePoint pointCenter;
        readonly ObservableCollection<ObservablePoint> Points;

        public DemandCurve() 
        { 
            Points = new ObservableCollection<ObservablePoint>();
            pointCenter = new ObservablePoint();
            for (int i = 0; i < 10; i++)
            {
                Points.Add(new ObservablePoint());
                if (i == 5)
                {
                    Points.Add(pointCenter);
                }
            }
        }

        public DemandCurve(ObservablePoint point)
            : this()
        {
            pointCenter = point;
            PlottGraph(point.X, point.Y);
        }

        /// <summary>
        /// Строит график "Кривой спроса" по координатам середины
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<ObservablePoint> PlottGraph(double? x, double? y)
        {
            double? step = (x - x / 2) / 5;
            double? xNew = x / 2;
            double? yNew = 0;

            for (int i = 0; i <= 10; i++, xNew += step)
            {
                if (i == 5)
                {
                    Points[i].X = x;
                    Points[i].Y = y;
                    xNew = x;
                }

                yNew = x * y / xNew;
                Points[i].X = xNew;
                Points[i].Y = yNew;
            }

            return Points;
        }

        public ObservableCollection<ObservablePoint> PlottGraph(ObservablePoint point)
        {
            return PlottGraph(point.X, point.Y);
        }
    }
}
