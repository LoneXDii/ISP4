using _253505Pavlovich.UI.ViewModels;

namespace _253505Pavlovich.UI.Pages;

public partial class SaleAdvertisementDetailsPage : ContentPage
{
	public SaleAdvertisementDetailsPage(SaleAdvertisementDetailsPageViewModel viewModel)
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

    private void OnSetImageClicked(object sender, EventArgs e)
    {
        //AdvertImage.Source = ImageSource.FromFile("no_image.jpg");
    }
}