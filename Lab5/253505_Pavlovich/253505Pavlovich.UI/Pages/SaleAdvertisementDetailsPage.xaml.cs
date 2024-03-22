using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class SaleAdvertisementDetailsPage : ContentPage
{
	public SaleAdvertisementDetailsPage(SaleAdvertisementDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}