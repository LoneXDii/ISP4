using _253505Pavlovich.UI.Pages;
using Microsoft.Maui.Controls;

namespace _253505Pavlovich.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SaleAdvertisementDetailsPage), typeof(SaleAdvertisementDetailsPage));
        Routing.RegisterRoute(nameof(AddCarBrandPage), typeof(AddCarBrandPage));
        Routing.RegisterRoute(nameof(AddSaleAdvertisementPage), typeof(AddSaleAdvertisementPage));
        Routing.RegisterRoute(nameof(EditSaleAdvertisementPage), typeof(EditSaleAdvertisementPage));
    }
}
