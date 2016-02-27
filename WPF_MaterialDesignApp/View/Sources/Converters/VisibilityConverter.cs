using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_MaterialDesignApp.View.Sources.Converters
{
    /// <summary>
    /// Converts passed value into visual state (shown or hidden)
    /// </summary>
    public sealed class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}