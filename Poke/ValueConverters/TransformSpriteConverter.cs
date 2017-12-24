using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class TransformSpriteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case MegaStone _:
                    return "mega.png";

                case ZCrystal zCrystal when zCrystal == ExclusiveZCrystal.Ultranecrozium:
                    return "UltraBurst.png";

                case ZCrystal _:
                    return "Z.png";
            }
            
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}