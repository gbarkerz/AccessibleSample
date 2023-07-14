using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AccessibleSampleUWP
{
    public class NotAvailableToText : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            var notAvailable = (bool)value;

            // Show a No Entry icon for unavailable items.
            return notAvailable ? "\u26D4" : "";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
