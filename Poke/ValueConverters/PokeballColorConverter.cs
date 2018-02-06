﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Poke
{
    public class PokeballColorConverter : IMultiValueConverter
    {
        static Brush GetBrush(string Hex)
        {
            if (ColorConverter.ConvertFromString(Hex) is Color color)
                return new SolidColorBrush(color);

            return new SolidColorBrush();
        }

        static readonly Brush FullHealthBrush = GetBrush("#B7FF0000");
        static readonly Brush FaintedBrush = GetBrush("#B7000000");
        static readonly Brush StatusConditionBrush = GetBrush("#B7FF7700");

        public object Convert(object[] Values, Type TargetType, object Parameter, CultureInfo Culture)
        {
            if (Values[0] is Pokemon pokemon)
            {
                if (pokemon.Stats.CurrentHP == 0)
                    return FaintedBrush;

                if (pokemon.NonVolatileStatus != NonVolatileStatus.None || pokemon.ConfusionCounter > 0)
                    return StatusConditionBrush;

                return FullHealthBrush;
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object Value, Type[] TargetTypes, object Parameter, CultureInfo Culture)
        {
            throw new NotImplementedException();
        }
    }
}