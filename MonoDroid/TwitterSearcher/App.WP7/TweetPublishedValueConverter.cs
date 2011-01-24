using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace App.WP7
{
    public class TweetPublishedValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("f");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime converted;

            if (DateTime.TryParse(value.ToString(), out converted))
            {
                return converted;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
