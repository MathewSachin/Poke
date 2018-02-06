using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class GenderToSymbolConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value)
            {
                case Gender.Male:
                    return "♂";

                case Gender.Female:
                    return "♀";

                default:
                    return "";
            }
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}