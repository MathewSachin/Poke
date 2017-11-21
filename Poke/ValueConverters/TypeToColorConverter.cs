using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class TypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Types t)
            {
                return t.GetColorHex();
            }
            
            return parameter ?? "#00000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}