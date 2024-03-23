using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class EditSaleAdvertisementPage : ContentPage
{
	public EditSaleAdvertisementPage(EditSaleAdvertisementPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}