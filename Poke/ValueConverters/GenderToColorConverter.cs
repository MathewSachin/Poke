using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class GenderToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Gender.Male:
                    return Types.Water.GetColorHex();

                case Gender.Female:
                    return Types.Fairy.GetColorHex();

                default:
                    return "#00000000";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}