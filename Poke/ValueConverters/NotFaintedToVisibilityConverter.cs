using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poke
{
    public class NotFaintedToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hide = parameter?.ToString() == "Collapse" ? Visibility.Collapsed : Visibility.Hidden;

            if (value is int hp)
                return hp == 0 ? hide : Visibility.Visible;

            return hide;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}