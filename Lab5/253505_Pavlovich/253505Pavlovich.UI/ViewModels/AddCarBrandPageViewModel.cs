using _253505_Pavlovich.Application.CarBrandUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI.ViewModels;

public partial class AddCarBrandPageViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public AddCarBrandPageViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    string? name;

    [ObservableProperty]
    string? description;

    [RelayCommand]
    public async Task Add() => await AddCarModel();

    [RelayCommand]
    public async Task Cancel() => await AddCancel();

    public async Task AddCarModel()
    {
        if (name is null || description is null) return;
        var brand = await _mediator.Send(new AddCarBrandRequest(name, description));
        await Shell.Current.GoToAsync("..");
    }

    public async Task AddCancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}
