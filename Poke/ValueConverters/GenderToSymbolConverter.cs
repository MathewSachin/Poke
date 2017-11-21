using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class GenderToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Gender.Male:
                    return "♂";

                case Gender.Female:
                    return "♀";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}