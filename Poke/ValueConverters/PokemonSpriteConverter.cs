using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Poke
{
    public class PokemonSpriteConverter : IMultiValueConverter
    {
        static ImageSource GetImageSource(string Link)
        {
            var image = new BitmapImage();
            
            image.BeginInit();
            
            image.StreamSource = SpriteManager.GetStream(Link);

            image.EndInit();

            return image;
        }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] is Pokemon pokemon && parameter is string s)
            {
                return GetImageSource(SpriteManager.GetSpriteLink(pokemon, s == "Back"));
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}