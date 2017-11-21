using System;
using System.Globalization;
using System.Windows.Data;

namespace Poke
{
    public class WeatherToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Weather.Rain:
                case Weather.HeavyRain:
                    return Types.Water.GetColorHex();

                case Weather.HarshSunlight:
                case Weather.ExtremelyHarshSunlight:
                    return Types.Fire.GetColorHex();

                case Weather.Hail:
                    return Types.Ice.GetColorHex();

                case Weather.Sandstorm:
                    return Types.Ground.GetColorHex();

                default:
                    return "#FFFFFF";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}