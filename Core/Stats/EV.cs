using System.Collections.Generic;

namespace Poke
{
    public class EV : NotifyPropertyChanged
    {
        readonly Dictionary<Stats, int> _stats = new Dictionary<Stats, int>
        {
            [Stats.HP] = 0,
            [Stats.Attack] = 0,
            [Stats.Defense] = 0,
            [Stats.SpecialAttack] = 0,
            [Stats.SpecialDefense] = 0,
            [Stats.Speed] = 0
        };

        const int MaxTotal = 510;
        const int MaxIndividual = 252;

        int _total;

        public int this[Stats Stat]
        {
            get => _stats[Stat];
            set
            {
                value = value.Clip(0, MaxIndividual);

                var newTotal = _total - _stats[Stat] + value;

                if (newTotal <= MaxTotal)
                {
                    _stats[Stat] = value;

                    _total = newTotal;
                }

                OnPropertyChanged();
            }
        }
    }
}