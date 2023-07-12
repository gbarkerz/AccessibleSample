
using System.Globalization;

namespace AccessibleSample;

public class NotAvailableToText : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var notAvailable = (bool)value;

        return notAvailable ? "\u274C" : "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
