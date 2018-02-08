using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Poke
{
    public class SpaceAtCaptitalsConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            if (Value == null)
                return Parameter;

            var toString = Value.ToString();

            return toString.All(char.IsUpper) ? toString : toString.SpaceAtCapitals();
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}