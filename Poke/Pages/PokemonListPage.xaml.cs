using System.Windows;

namespace Poke
{
    public partial class PokemonListPage
    {
        public PokemonListPage()
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
                    DataContext = new PokemonViewModel(species)
                });
            }
        }
    }
}
