using _253505Pavlovich.UI.Pages;
using _253505Pavlovich.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI;

public static class DependensyInjection
{
    public static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>()
                .AddSingleton<CarBrandsPage>()
                .AddTransient<SaleAdvertisementDetailsPage>()
                .AddTransient<AddCarBrandPage>()
                .AddTransient<AddSaleAdvertisementPage>()
                .AddTransient<EditSaleAdvertisementPage>();
        return services;
    }

    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<CarBrandsPageViewModel>()
                .AddTransient<SaleAdvertisementDetailsPageViewModel>()
                .AddTransient<AddCarBrandPageViewModel>()
                .AddTransient<AddSaleAdvertisementPageViewModel>()
                .AddTransient<EditSaleAdvertisementPageViewModel>();
        return services;
    }
}
