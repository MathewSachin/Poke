using System.Windows;

namespace Poke
{
    public partial class AbilitiesPage
    {
        public AbilitiesPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }
    }
}
