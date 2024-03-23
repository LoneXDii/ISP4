using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class CarBrandsPage : ContentPage
{
	public CarBrandsPage(CarBrandsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        foreach (var item in MenuBarItems)
        {
            item.BindingContext = BindingContext;
        }
    }
}