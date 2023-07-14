
using System.Globalization;

namespace AccessibleSample;

public class NotAvailableToText : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var notAvailable = (bool)value;

        // Show a red 'X' icon for unavailable items.
        return notAvailable ? "\u274C" : "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
