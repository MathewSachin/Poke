using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class FaintedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int i && i == 0 ? Types.Fire.GetColorHex() : "#00000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}