using System;
using System.Globalization;
using System.Windows.Data;

namespace Imidi.Converters
{
    public class DivideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var number = (double)value;
                var dividend = double.Parse(parameter?.ToString());
                return number / dividend;
            }
            catch (Exception)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("DivideConverter.ConvertBack");
        }
    }
}
