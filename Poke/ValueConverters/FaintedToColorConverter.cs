using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class FaintedToColorConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Value is int i && i == 0 ? Types.Fire.GetColorHex() : "#00000000";
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}