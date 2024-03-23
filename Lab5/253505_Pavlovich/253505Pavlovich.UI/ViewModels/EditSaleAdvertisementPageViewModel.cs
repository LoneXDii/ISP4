using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI.ViewModels;

[QueryProperty ("SaleAdvertisement", "SaleAdvertisement")]
public partial class EditSaleAdvertisementPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    private SaleAdvertisement? notChangedAdvert;

    public EditSaleAdvertisementPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    SaleAdvertisement? saleAdvertisement;

    [RelayCommand]
    async Task Edit() => await EditSaleAdvertisementAsync();

    [RelayCommand]
    async Task Cancel() => await CancelEditingAsync();

    public async Task EditSaleAdvertisementAsync()
    {
        if (SaleAdvertisement is null) return;
        await _mediator.Send(new UpdateSaleAdvertisementRequest(SaleAdvertisement));
        await Shell.Current.GoToAsync("..");
    }

    public async Task CancelEditingAsync()
    {
        SaleAdvertisement = notChangedAdvert;
        await Shell.Current.GoToAsync("..");
    }
}
