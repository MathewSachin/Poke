using System.Windows;

namespace Poke
{
    public partial class MovesListPage
    {
        public MovesListPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }

        void GoToMove(object Sender, RoutedEventArgs E)
        {
            if (Sender is FrameworkElement element && element.DataContext is MoveInfo move)
            {
                NavigationService?.Navigate(new MovePage
                {
                    DataContext = move
                });
            }
        }
    }
}
