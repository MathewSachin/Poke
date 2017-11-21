using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class MoveKindToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case MoveKind.Physical:
                    return Types.Fighting.GetColorHex();

                case MoveKind.Special:
                    return Types.Ghost.GetColorHex();

                case MoveKind.Status:
                    return Types.Steel.GetColorHex();
                    
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