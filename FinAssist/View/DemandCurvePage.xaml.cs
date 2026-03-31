using FinAssist.ViewModel;

namespace FinAssist;

public partial class DemandCurvePage : ContentPage
{
    public DemandCurvePage()
    {
        InitializeComponent();
        BindingContext = new DemandCurveViewModel();
    }
}