using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class SpaceAtCaptitalsConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Value == null ? Parameter : Value.ToString().SpaceAtCapitals();
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}