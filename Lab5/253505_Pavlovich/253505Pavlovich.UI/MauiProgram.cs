using _253505_Pavlovich.Application;
using _253505_Pavlovich.Persistence;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace _253505Pavlovich.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services
            .AddApplication()
            .AddPersistence()
            .RegisterPages()
            .RegisterViewModels();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
