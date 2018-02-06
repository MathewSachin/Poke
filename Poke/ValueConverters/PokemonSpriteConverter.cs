using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Poke
{
    public class PokemonSpriteConverter : IMultiValueConverter
    {
        const string Default = "/Images/Unknown.png";

        public object Convert(object[] Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            switch (Value[0])
            {
                case Pokemon pokemon when Parameter is string s:
                    return new AsyncTask(Default, async () =>
                    {
                        try
                        {
                            return await SpriteManager.GetSpriteLink(pokemon, s == "Back");
                        }
                        catch
                        {
                            return Default;
                        }
                    });

                case PokemonSpecies species when Parameter is string s:
                    return new AsyncTask(Default, async () =>
                    {
                        try
                        {
                            return await SpriteManager.GetSpriteLink(new Pokemon(species, 55), s == "Back");
                        }
                        catch
                        {
                            return Default;
                        }
                    });
            }

            return Default;
        }

        public object[] ConvertBack(object Value, Type[] TargetType, object Parameter, CultureInfo Culture)
        {
            return null;
        }

        class AsyncTask : NotifyPropertyChanged
        {
            public AsyncTask(object Default, Func<Task<object>> ValueFunc)
            {
                AsyncValue = Default;

                Task.Run(ValueFunc).ContinueWith(Task =>
                {
                    AsyncValue = Task.Result;
                });
            }

            object _value;

            public object AsyncValue
            {
                get => _value;
                set
                {
                    _value = value;

                    OnPropertyChanged();
                }
            }
        }
    }
}