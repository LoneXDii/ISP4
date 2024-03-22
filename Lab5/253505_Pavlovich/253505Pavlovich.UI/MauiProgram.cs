using _253505_Pavlovich.Application;
using _253505_Pavlovich.Persistence;
using _253505_Pavlovich.Persistence.Data;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace _253505Pavlovich.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "_253505Pavlovich.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("icofont.ttf", "IcoFont");
                fonts.AddFont("FontAwesome.ttf", "fontawesome");
            });

        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;

        builder.Services
            .AddApplication()
            .AddPersistence(options)
            .RegisterPages()
            .RegisterViewModels();  

        DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
