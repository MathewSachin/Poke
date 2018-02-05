using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class TransformSpriteConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value)
            {
                case MegaStone _:
                    return "/Images/Mega.png";

                case ZCrystal zCrystal when zCrystal == ExclusiveZCrystal.Ultranecrozium:
                    return "/Images/UltraBurst.png";

                case ZCrystal _:
                    return "/Images/Z.png";

                case HeldItem heldItem when heldItem == HeldItem.BlueOrb:
                    return "/Images/Alpha.png";

                case HeldItem heldItem when heldItem == HeldItem.RedOrb:
                    return "/Images/Omega.png";
            }
            
            return null;
        }

        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}