using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505Pavlovich.UI.ValueConverters;

internal class IdToImageValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) return ImageSource.FromFile("no_image.jpg");

        var dirPath = FileSystem.Current.AppDataDirectory;
        var pathToImageDir = Path.Combine(dirPath, "Images");
        var pathToImage = Path.Combine(pathToImageDir, $"{(int)value}.png");

        if (!File.Exists(pathToImage))
        {
            pathToImage = Path.Combine(pathToImageDir, $"{(int)value}.jpg");
        }

        if (File.Exists(pathToImage))
        {
            return ImageSource.FromFile(pathToImage);
        }
        return ImageSource.FromFile("no_image.jpg");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
