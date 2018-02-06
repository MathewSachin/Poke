using System.Windows;

namespace Poke
{
    public partial class AbilityPage
    {
        public AbilityPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }

        void GoToPokemon(object Sender, RoutedEventArgs E)
        {
            if (Sender is FrameworkElement element && element.DataContext is PokemonSpecies species)
            {
                NavigationService?.Navigate(new PokemonPage
                {
                    DataContext = species
                });
            }
        }
    }
}
