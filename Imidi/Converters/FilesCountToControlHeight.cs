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
            return count * 14.06 / 4.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
