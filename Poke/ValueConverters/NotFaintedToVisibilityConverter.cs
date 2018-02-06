using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poke
{
    public class NotFaintedToVisibilityConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            var hide = Parameter?.ToString() == "Collapse" ? Visibility.Collapsed : Visibility.Hidden;

            if (Value is int hp)
                return hp == 0 ? hide : Visibility.Visible;

            return hide;
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}