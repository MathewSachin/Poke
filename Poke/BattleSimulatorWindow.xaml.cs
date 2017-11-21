namespace Poke
{
    public partial class BattleSimulatorWindow
    {
        public BattleSimulatorWindow(int Format)
        {
            InitializeComponent();

            if (DataContext is BattleViewModel battle)
            {
                switch (Format)
                {
                    case 2:
                        Width = 600;
                        Title += " (Doubles)";
                        break;

                    case 3:
                        Width = 1000;
                        Title += " (Triples)";
                        break;
                }

                battle.Format = Format;
            }
        }
    }
}
