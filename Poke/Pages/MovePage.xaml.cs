using System.Windows;

namespace Poke
{
    public partial class MovePage
    {
        public MovePage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }
    }
}
