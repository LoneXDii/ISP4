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

[QueryProperty("SaleAdvertisement", "SaleAdvertisement")]
public partial class SaleAdvertisementDetailsPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public SaleAdvertisementDetailsPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    SaleAdvertisement? saleAdvertisement;

    [RelayCommand]
    async Task Edit() => await GotoEditPage();

    private async Task GotoEditPage()
    {
        if (SaleAdvertisement is null) return;
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "SaleAdvertisement", SaleAdvertisement }
        };
        await Shell.Current.GoToAsync(nameof(EditSaleAdvertisementPage), parameters);
    }
}
