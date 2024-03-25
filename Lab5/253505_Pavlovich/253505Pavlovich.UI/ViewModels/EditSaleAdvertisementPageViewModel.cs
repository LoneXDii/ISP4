using _253505_Pavlovich.Application.CarBrandUseCases.Queries;
using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;
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

[QueryProperty ("SaleAdvertisement", "SaleAdvertisement")]
public partial class EditSaleAdvertisementPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public ObservableCollection<CarBrand> Brands { get; set; } = new();

    public EditSaleAdvertisementPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    SaleAdvertisement? saleAdvertisement;

    [ObservableProperty]
    CarBrand? selectedBrand;

    [ObservableProperty]
    int productionYear = 0;

    [RelayCommand]
    async Task SetPicker() => await UpdateBrandsList();

    [RelayCommand]
    async Task ChangeBrand(int id) => await UpdateCarBrand(id);

    [RelayCommand]
    async Task Edit() => await EditSaleAdvertisementAsync();

    [RelayCommand]
    async Task Cancel() => await CancelEditingAsync();

    private async Task UpdateBrandsList()
    {
        var brands = await _mediator.Send(new GetCarBrandsRequest());
        if (brands is null) return;
        foreach (var brand in brands)
        {
            Brands.Add(brand);
        }

        if (SaleAdvertisement is null) return;
        SelectedBrand = Brands.FirstOrDefault(b => b.Id == SaleAdvertisement.CarBrandId);
        if (ProductionYear == 0)
        {
            ProductionYear = SaleAdvertisement.CarInfo.ProductionYear;
        }
    }

    private async Task UpdateCarBrand(int id)
    {
        if(SelectedBrand is null || SaleAdvertisement is null) return;
        SelectedBrand = Brands.FirstOrDefault(b => b.Id == id);
        SaleAdvertisement.DeleteFromBrandAdvertisements();
        SaleAdvertisement.AddToBrandAdvertisements(id);
        await _mediator.Send(new UpdateSaleAdvertisementRequest(SaleAdvertisement));
    }

    public async Task EditSaleAdvertisementAsync()
    {
        if (SaleAdvertisement is null) return;
        try
        {
            SaleAdvertisement.CarInfo.ProductionYear = ProductionYear;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Something went wrong"
                            , $"Incrorrect production year (must be from 1970 to {DateTime.Now.Year})"
                            , "Ok");
            return;
        }
        await _mediator.Send(new UpdateSaleAdvertisementRequest(SaleAdvertisement));
        await Shell.Current.GoToAsync("..");
    }

    public async Task CancelEditingAsync()
    {
        if (SaleAdvertisement is null || SaleAdvertisement?.CarBrandId is null) return;
        var adverts = await _mediator.Send(new GetSaleAdvertisementsByBrandRequest((int)SaleAdvertisement.CarBrandId));
        SaleAdvertisement = adverts.FirstOrDefault(adv => adv.Id == SaleAdvertisement.Id);
        await Shell.Current.GoToAsync("..");
    }
}
