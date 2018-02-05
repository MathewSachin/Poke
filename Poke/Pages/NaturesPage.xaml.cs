using System.Windows;

namespace Poke
{
    public partial class NaturesPage
    {
        public NaturesPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }
    }
}
