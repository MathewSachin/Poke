using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class TypeToColorConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            if (Value is Types t)
            {
                return t.GetColorHex();
            }
            
            return Parameter ?? "#00000000";
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}