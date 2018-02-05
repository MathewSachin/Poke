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
    }
}
