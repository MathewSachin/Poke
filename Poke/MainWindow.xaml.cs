using System;
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
            var format = FormatBox.SelectedIndex + 1;

            Func<Side> sideGen = null;

            if (TeamTypeBox.SelectedIndex == 1)
            {
                var win = new TeamBuilderWindow();
                
                var result = win.ShowDialog();

                if (!result.GetValueOrDefault())
                    return;

                if (win.DataContext is TeamBuilderViewModel vm)
                {
                    try
                    {
                        sideGen = () => vm.GetSide(format);
                    }
                    catch
                    {
                        // Ignore errors
                    }
                }
            }

            new BattleSimulatorWindow(format, sideGen).Show();
        }
        
        void OpenDex(object Sender, RoutedEventArgs E)
        {
            new DexWindow().Show();
        }
    }
}
