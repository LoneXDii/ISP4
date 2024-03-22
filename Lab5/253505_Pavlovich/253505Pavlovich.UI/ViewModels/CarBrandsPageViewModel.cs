using _253505_Pavlovich.Application.CarBrandUseCases.Queries;
using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Queries;
using _253505Pavlovich.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI.ViewModels;

public partial class CarBrandsPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public CarBrandsPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ObservableCollection<CarBrand> CarBrands { get; set; } = new();
    public ObservableCollection<SaleAdvertisement> SaleAdvertisements { get; set; } = new();

    [ObservableProperty]
    CarBrand? selectedBrand;

    [RelayCommand]
    async Task UpdateGroupList() => await GetCarBrands();

    [RelayCommand]
    async Task UpdateMemberList() => await GetSaleAdvertisements();

    [RelayCommand]
    async Task ShowDetails(SaleAdvertisement saleAdvertisement) => await GotoDetailsPage(saleAdvertisement);

    [RelayCommand]
    async Task AddBrand() => await GotoAddBrandPage();

    public async Task GetCarBrands()
    {
        var brands = await _mediator.Send(new GetCarBrandsRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            CarBrands.Clear();
            foreach (var brand in brands)
            {
                CarBrands.Add(brand);
            }
        });
    }

    public async Task GetSaleAdvertisements()
    {
        if (SelectedBrand is null) return;
        var adverts = await _mediator.Send(new GetSaleAdvertisementsByBrandRequest(SelectedBrand.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            SaleAdvertisements.Clear();
            foreach (var advert in adverts)
            {
                SaleAdvertisements.Add(advert);
            }
        });
    }

    private async Task GotoDetailsPage(SaleAdvertisement saleAdvertisement) {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "SaleAdvertisement", saleAdvertisement }
        };
        await Shell.Current.GoToAsync(nameof(SaleAdvertisementDetailsPage), parameters);
    }

    private async Task GotoAddBrandPage()
    {
        await Shell.Current.GoToAsync(nameof(AddCarBrandPage));
    }
}
