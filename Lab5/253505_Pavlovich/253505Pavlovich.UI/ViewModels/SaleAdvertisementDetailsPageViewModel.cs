using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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
}
