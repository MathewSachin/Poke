using System.Windows;

namespace Poke
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void OpenBattleSimulator(object Sender, RoutedEventArgs E)
        {
            new BattleSimulatorWindow(1).Show();
        }

        void OpenDoubleSimulator(object Sender, RoutedEventArgs E)
        {
            new BattleSimulatorWindow(2).Show();
        }

        void OpenTypeEffectiveness(object Sender, RoutedEventArgs E)
        {
            new TypeEffectivenessWindow().Show();
        }

        void OpenNatures(object Sender, RoutedEventArgs E)
        {
            new NaturesWindow().Show();
        }

        void OpenTripleSimulator(object Sender, RoutedEventArgs E)
        {
            new BattleSimulatorWindow(3).Show();
        }

        void OpenAbilities(object Sender, RoutedEventArgs E)
        {
            new AbilitiesWindow().Show();
        }
    }
}
