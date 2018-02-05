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

        void OpenDex(object Sender, RoutedEventArgs E)
        {
            new DexWindow().Show();
        }

        void OpenTripleSimulator(object Sender, RoutedEventArgs E)
        {
            new BattleSimulatorWindow(3).Show();
        }
    }
}
