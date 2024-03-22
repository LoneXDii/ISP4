using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class AddCarBrandPage : ContentPage
{
	public AddCarBrandPage(AddCarBrandPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}