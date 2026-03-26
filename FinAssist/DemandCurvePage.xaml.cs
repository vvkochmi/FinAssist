namespace FinAssist;

public partial class DemandCurvePage : ContentPage
{
    public DemandCurvePage()
    {
        InitializeComponent();

        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };


        Plot1.Plot.Add.Scatter(dataX, dataY);

        Plot1.Refresh();

    }
}