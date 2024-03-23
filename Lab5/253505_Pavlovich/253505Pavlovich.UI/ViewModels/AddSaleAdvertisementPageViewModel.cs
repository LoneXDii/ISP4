﻿using _253505_Pavlovich.Application.CarBrandUseCases.Commands;
using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI.ViewModels;

[QueryProperty("SelectedBrand", "SelectedBrand")]
public partial class AddSaleAdvertisementPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public AddSaleAdvertisementPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    CarBrand? selectedBrand;

    [ObservableProperty]
    string? name;

    [ObservableProperty]
    string? carModel;

    [ObservableProperty]
    int carProductionYear;

    [ObservableProperty]
    string? salesmanName;

    [ObservableProperty]
    string? salesmanPhoneNumber;

    [ObservableProperty]
    double price;

    [RelayCommand]
    public async Task Add() => await AddSaleAdvertisement();

    [RelayCommand]
    public async Task Cancel() => await AddCanceled();

    public async Task AddSaleAdvertisement()
    {
        if (Name is null || CarModel is null || SalesmanName is null 
            || SalesmanPhoneNumber is null || SelectedBrand is null) return;
        
        var brand = await _mediator.Send(new AddSaleAdvertisementRequest(Name, CarModel, CarProductionYear
                                                                         , SalesmanName, SalesmanPhoneNumber, Price
                                                                         , SelectedBrand.Id));
        await Shell.Current.GoToAsync("..");
    }

    public async Task AddCanceled()
    {
        await Shell.Current.GoToAsync("..");
    }
}
