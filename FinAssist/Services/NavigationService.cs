using FinAssist.Model;
using FinAssist.ViewModel;

namespace FinAssist.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation navigation;

        public NavigationService(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public void NavigateToDemandCurve(FinData finData)
        {
            DemandCurvePage demandCurvePage = new DemandCurvePage();

            if (demandCurvePage.BindingContext is DemandCurveViewModel demandCurveViewModel)
            {
                demandCurveViewModel.FinData = finData;
            }

            navigation.PushAsync(demandCurvePage);
        }
    }
}
