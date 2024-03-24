using _253505_Pavlovich.Application.CarBrandUseCases.Queries;
using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;
using _253505_Pavlovich.Application.SaleAdvertisementUseCases.Queries;
using _253505Pavlovich.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

    [RelayCommand]
    async Task SetImage() => await SelectImageFromDevice();

    [RelayCommand]
    void Refresh() => RefreshPage();

    private async Task GotoEditPage()
    {
        if (SaleAdvertisement is null) return;
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "SaleAdvertisement", SaleAdvertisement }
        };
        await Shell.Current.GoToAsync(nameof(EditSaleAdvertisementPage), parameters);
    }

    private async Task SelectImageFromDevice()
    {
        var pickedImg = await FilePicker.Default.PickAsync(PickOptions.Images);
        if (pickedImg is null) return;

        var fileType = pickedImg.ContentType.Split('/')[1];

        if (fileType is null || SaleAdvertisement is null) return;


        var dirPath = "D:\\labs\\Sem 4\\ISP\\Lab5\\253505_Pavlovich\\253505Pavlovich.UI\\Images\\";
        var pathToImage = Path.Combine(dirPath, $"{(int)SaleAdvertisement.Id}.{fileType}");
        pathToImage = Path.Combine(FileSystem.Current.AppDataDirectory, pathToImage);

        using Stream inputStream = await pickedImg.OpenReadAsync();

        if (File.Exists(pathToImage))
        {
            File.Delete(pathToImage);
        }

        using Stream outputStream = File.Create(pathToImage);

        await inputStream.CopyToAsync(outputStream);
        this.OnPropertyChanged(nameof(SaleAdvertisement));
    }

    private void RefreshPage()
    {
        this.OnPropertyChanged(nameof(SaleAdvertisement));
    }
}
