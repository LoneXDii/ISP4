using _253505Pavlovich.UI.Pages;

namespace _253505Pavlovich.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SaleAdvertisementDetailsPage), typeof(SaleAdvertisementDetailsPage));
        Routing.RegisterRoute(nameof(AddCarBrandPage), typeof(AddCarBrandPage));
    }
}
