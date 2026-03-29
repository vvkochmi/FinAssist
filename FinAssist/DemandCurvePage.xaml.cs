namespace FinAssist;

public partial class DemandCurvePage : ContentPage
{
    public DemandCurvePage()
    {
        InitializeComponent();

        /*double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        
        Plot1.Plot.Add.Scatter(dataX, dataY);

        Plot1.Refresh();*/
    }

    private void PriceCountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        //OxyPlot
        Plot1.Plot.Clear();
        if (PriceEntry.Text != null && CountEntry.Text != null)
        {
            double[] dataX = new double[5];
            double[] dataY = new double[5];

            dataX[0] = Convert.ToDouble(PriceEntry.Text) / 4;
            dataY[0] = Convert.ToDouble(PriceEntry.Text) * Convert.ToDouble(CountEntry.Text) / dataX[0];

            dataX[1] = Convert.ToDouble(PriceEntry.Text) / 2;
            dataY[1] = Convert.ToDouble(PriceEntry.Text) * Convert.ToDouble(CountEntry.Text) / dataX[1];

            dataX[2] = Convert.ToDouble(PriceEntry.Text);
            dataY[2] = Convert.ToDouble(CountEntry.Text);

            dataX[3] = Convert.ToDouble(PriceEntry.Text) * 2;
            dataY[3] = Convert.ToDouble(PriceEntry.Text) * Convert.ToDouble(CountEntry.Text) / dataX[3];

            dataX[4] = Convert.ToDouble(PriceEntry.Text) * 4;
            dataY[4] = Convert.ToDouble(PriceEntry.Text) * Convert.ToDouble(CountEntry.Text) / dataX[4];

            Plot1.Plot.Add.Scatter(dataX, dataY);
            Plot1.Plot.HideGrid();
            Plot1.Refresh();
        }
    }
}