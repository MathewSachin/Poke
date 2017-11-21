using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class NotFaintedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int hp)
                return hp == 0 ? "#B7000000" : "#B7FF0000";

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}