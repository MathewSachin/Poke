using System.Windows;

namespace Poke
{
    public partial class MovesPage
    {
        public MovesPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }
    }
}
