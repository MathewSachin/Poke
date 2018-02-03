using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

                battle.DoAnimation += BattleOnDoAnimation;
            }
        }

        async Task BattleOnDoAnimation(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            if (Move.Info.Flags.HasFlag(MoveFlags.Contact) && Move.Info.Target == MoveTarget.Normal)
            {
                var playerAttacking = Battle.PlayerSide.IndexOf(Attacker) != -1;

                var playerIndex = Battle.PlayerSide.IndexOf(playerAttacking ? Attacker : Opponent);
                var opponentIndex = Battle.OpponentSide.IndexOf(playerAttacking ? Opponent : Attacker);

                var playerItem = PlayerSideControl.ItemContainerGenerator.ContainerFromIndex(playerIndex) as UIElement;
                var opponentItem = OpponentSideControl.ItemContainerGenerator.ContainerFromIndex(opponentIndex) as UIElement;

                var translater = new TranslateTransform();

                if (playerAttacking)
                    playerItem.RenderTransform = translater;
                else opponentItem.RenderTransform = translater;

                var pokemonWidth = Width / Battle.Format / 2;

                double targetX, targetY;

                if (playerAttacking)
                {
                    targetX = (Battle.Format - playerIndex) * pokemonWidth + opponentIndex * pokemonWidth;
                    targetY = -220;
                }
                else
                {
                    targetX = - playerIndex * pokemonWidth - (Battle.Format - opponentIndex) * pokemonWidth;
                    targetY = 220;
                }

                var xEvent = new ManualResetEvent(false);
                var yEvent = new ManualResetEvent(false);

                var xAnimation = new DoubleAnimation(0, targetX, new Duration(TimeSpan.FromMilliseconds(200)))
                {
                    AutoReverse = true
                };

                xAnimation.Completed += (S, E) => xEvent.Set();

                var yAnimation = new DoubleAnimation(0, targetY, new Duration(TimeSpan.FromMilliseconds(200)))
                {
                    AutoReverse = true
                };

                yAnimation.Completed += (S, E) => yEvent.Set();

                translater.BeginAnimation(TranslateTransform.XProperty, xAnimation);
                translater.BeginAnimation(TranslateTransform.YProperty, yAnimation);

                await Task.Run(() => WaitHandle.WaitAll(new WaitHandle[] {xEvent, yEvent}));

                xEvent.Dispose();
                yEvent.Dispose();
            }
        }
    }
}
