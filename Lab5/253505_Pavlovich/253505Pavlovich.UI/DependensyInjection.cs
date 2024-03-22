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
        services.AddTransient<CarBrandsPage>();
        return services;
    }

    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<CarBrandsPageViewModel>();
        return services;
    }
}
