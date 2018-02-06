using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class GenderToColorConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value)
            {
                case Gender.Male:
                    return Types.Water.GetColorHex();

                case Gender.Female:
                    return Types.Fairy.GetColorHex();

                default:
                    return "#00000000";
            }
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}