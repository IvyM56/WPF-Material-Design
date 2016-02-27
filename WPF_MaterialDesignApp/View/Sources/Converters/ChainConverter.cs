using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_MaterialDesignApp.View.Sources.Converters
{
    /// <summary>
    /// Converts passed value with several converters.
    /// </summary>
    public sealed class ChainConverter : IValueConverter
    {
        public IValueConverter FirstConverter
        {
            get;
            set;
        }

        public IValueConverter SecondConverter
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object converterValue = this.FirstConverter.Convert(value, targetType, parameter, culture);
            return this.SecondConverter.Convert(converterValue, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
