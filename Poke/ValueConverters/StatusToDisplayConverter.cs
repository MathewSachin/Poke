using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class StatusToDisplayConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value)
            {
                case NonVolatileStatus.BadPoison:
                case NonVolatileStatus.Poison:
                    return "PSN";

                case NonVolatileStatus.Burn:
                    return "BRN";

                case NonVolatileStatus.Freeze:
                    return "FRZ";

                case NonVolatileStatus.Paralysis:
                    return "PAR";

                case NonVolatileStatus.Sleep:
                    return "SLP";

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