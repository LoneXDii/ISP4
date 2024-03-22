using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class AddSaleAdvertisementPage : ContentPage
{
	public AddSaleAdvertisementPage(AddSaleAdvertisementPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}