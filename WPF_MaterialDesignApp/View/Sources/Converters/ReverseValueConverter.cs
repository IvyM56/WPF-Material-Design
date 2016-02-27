using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_MaterialDesignApp.View.Sources.Converters
{
    /// <summary>
    /// Converts the value into the opposite one.
    /// </summary>
    public sealed class ReverseValueConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
