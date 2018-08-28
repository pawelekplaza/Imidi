using System;
using System.Globalization;
using System.Windows.Data;

namespace Imidi.Converters
{
    public class FilesCountToControlHeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            return 14.06 * (count / 4 + 1) + 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
