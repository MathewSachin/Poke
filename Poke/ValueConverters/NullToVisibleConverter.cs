using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poke
{
    public class NullToVisibleConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}