using System.Windows;

namespace Poke
{
    public partial class TypeEffectivenessPage
    {
        public TypeEffectivenessPage()
        {
            InitializeComponent();
        }

        void GoBack(object Sender, RoutedEventArgs E)
        {
            NavigationService?.GoBack();
        }
    }
}
