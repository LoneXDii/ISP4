using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class CarBrandsPage : ContentPage
{
	public CarBrandsPage(CarBrandsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}