using System.Windows;

namespace Poke
{
    public partial class TeamBuilderWindow
    {
        public TeamBuilderWindow()
        {
            InitializeComponent();
        }

        void OkClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = true;

            Close();
        }
    }
}
