using System.Windows;
using System.Windows.Controls;

namespace Poke
{
    public partial class AbilitiesListPage
    {
        public AbilitiesListPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }

        void GoToAbility(object Sender, RoutedEventArgs E)
        {
            if (Sender is Button b && b.CommandParameter is Ability ability)
            {
                NavigationService?.Navigate(new AbilityPage
                {
                    DataContext = new AbilityViewModel(ability)
                });
            }
        }
    }
}
