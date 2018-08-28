using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Imidi.Converters
{
    public class IsSelectedEntryBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return (bool)value ? new SolidColorBrush(Color.FromRgb(0x30, 0x30, 0x30)) : null;            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
