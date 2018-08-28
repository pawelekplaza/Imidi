using Imidi.Helpers;
using Imidi.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Imidi.Converters
{
    public class WidthToColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (double)value;
            var columns = SettingsHelper.NumberOfColumns;
            return (number / columns) - (MainWindowViewModel.FileEntryMargin.Left + MainWindowViewModel.FileEntryMargin.Right);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("WidthToColumnWidthConverter.ConvertBack");
        }
    }
}
