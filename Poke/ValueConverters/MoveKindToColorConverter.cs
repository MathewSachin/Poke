using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class MoveKindToColorConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value)
            {
                case MoveKind.Physical:
                    return Types.Fighting.GetColorHex();

                case MoveKind.Special:
                    return Types.Ghost.GetColorHex();

                case MoveKind.Status:
                    return Types.Steel.GetColorHex();
                    
                default:
                    return Parameter ?? "#00000000";
            }
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}