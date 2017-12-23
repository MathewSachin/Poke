using System.Threading;

namespace Poke
{
    public partial class BattleViewModel
    {
        readonly ManualResetEvent _continueEvent = new ManualResetEvent(true);
        readonly ManualResetEvent _cancelEvent = new ManualResetEvent(false);
        readonly ManualResetEvent _battleEvent = new ManualResetEvent(false);

        public DelegateCommand MoveCommand { get; }

        public DelegateCommand ZMoveCommand { get; }

        public DelegateCommand SwitchCommand { get; }

        public DelegateCommand ContinueCommand { get; }

        public DelegateCommand TargetCommand { get; }

        public DelegateCommand CancelCommand { get; }
        
        void OnTargetExecute(object M)
        {
            if (M is Pokemon target)
            {
                _target = target;

                _battleEvent.Set();
            }
        }

        bool OnSwitchCanExecute(object M)
        {
            if (!BattleState.Is(BattleState.Move, BattleState.Switch))
                return false;

            if (M is int index || M is string s && int.TryParse(s, out index))
            {
                if (index >= 0 && index < PlayerSide.Party.Count)
                {
                    return !PlayerSide.Party[index].IsFainted;
                }
            }

            return false;
        }

        async void OnSwitchExecute(object M)
        {
            if (M is int index || M is string s && int.TryParse(s, out index))
            {
                if (PlayerSide.Battling.Contains(PlayerSide.Party[index]))
                {
                    await WriteStatus($"{PlayerSide.Party[index]} is already in battle.", false);

                    return;
                }

                _toSwitch = PlayerSide.Party[index];

                _battleEvent.Set();
            }
        }

        void OnMoveExecute(object Parameter)
        {
            if (Parameter is int index || Parameter is string s && int.TryParse(s, out index))
            {
                _toMove = index;

                _battleEvent.Set();
            }
        }

        bool OnZMoveCanExecute(object Parameter)
        {
            if (Parameter is int index || Parameter is string s && int.TryParse(s, out index))
            {
                return ZSelector?.Available[index] ?? false;
            }

            return false;
        }
    }
}