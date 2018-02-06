using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poke
{
    public class EqualityToVisibilityConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Value?.ToString() == Parameter?.ToString() ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}