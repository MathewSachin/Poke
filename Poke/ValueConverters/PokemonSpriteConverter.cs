﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class PokemonSpriteConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] is Pokemon pokemon && parameter is string s)
            {
                try
                {
                    return SpriteManager.GetSpriteLink(pokemon, s == "Back");
                }
                catch
                {
                    return "unknown.png";
                }
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}