﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Imidi.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception)
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (Visibility)value == Visibility.Visible;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
