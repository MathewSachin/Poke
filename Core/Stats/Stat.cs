using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    
    public class PokemonStats : NotifyPropertyChanged
    {
        readonly Pokemon _pokemon;

        public PokemonStats(Pokemon Pokemon)
        {
            _pokemon = Pokemon;

            CurrentHP = MaxHP;
        }

        public void OnMegaEvolve(PokemonStats Previous)
        {
            CurrentHP = Previous.CurrentHP;

            foreach (var key in _stages.Keys.ToArray())
            {
                _stages[key] = Previous.GetStage(key);
            }
        }

        static int GenerateIV() => BattleViewModel.Random.Next(32);

        public IReadOnlyDictionary<Stats, int> IV { get; } = new Dictionary<Stats, int>
        {
            [Stats.HP] = GenerateIV(),
            [Stats.Attack] = GenerateIV(),
            [Stats.Defense] = GenerateIV(),
            [Stats.SpecialAttack] = GenerateIV(),
            [Stats.SpecialDefense] = GenerateIV(),
            [Stats.Speed] = GenerateIV()
        };

        public EV EV { get; } = new EV();

        readonly Dictionary<Stats, int> _stages = new Dictionary<Stats, int>
        {
            [Stats.Attack] = 0,
            [Stats.Defense] = 0,
            [Stats.SpecialAttack] = 0,
            [Stats.SpecialDefense] = 0,
            [Stats.Speed] = 0,
            [Stats.Accuracy] = 0,
            [Stats.Evasiveness] = 0
        };

        public int GetStage(Stats Stat) => _stages[Stat];

        public int GetBase(Stats Stat)
        {
            return _pokemon.Species.BaseStats[Stat];
        }

        public int ChangeStage(Stats Stat, int Stages)
        {
            var initialValue = _stages[Stat];

            _stages[Stat] += Stages;

            _stages[Stat] = _stages[Stat].Clip(-6, 6);

            return _stages[Stat] - initialValue;
        }

        double GetNatureMultiplier(Stats Stat)
        {
            if (_pokemon.Nature.IncreasedStat == Stat)
                return 1.1;

            if (_pokemon.Nature.DecreasedStat == Stat)
                return 0.9;

            return 1;
        }

        double GetStageMultiplier(Stats Stat)
        {
            var stage = _stages[Stat];

            // Simple
            if (_pokemon.Ability == Ability.Simple)
            {
                stage = (stage * 2).Clip(-6, 6);
            }

            if (stage > 0)
                return (stage + 2) / 2.0;

            if (stage < 0)
                return 2.0 / (-stage + 2);

            return 1;
        }

        public int GetValue(Stats Stat, bool CriticalHit = false)
        {
            var stageMultiplier = GetStageMultiplier(Stat);

            switch (Stat)
            {
                // Critical hit ignores negative Attack stages
                case Stats.Attack:
                case Stats.SpecialAttack:
                    if (CriticalHit && GetStage(Stat) < 0)
                        stageMultiplier = 1;

                    break;

                // Critical hit ignores possitive Defense stages
                case Stats.Defense:
                case Stats.SpecialDefense:
                    if (CriticalHit && GetStage(Stat) > 0)
                        stageMultiplier = 1;

                    break;
            }

            switch (Stat)
            {
                case Stats.Attack:
                case Stats.Defense:
                case Stats.SpecialAttack:
                case Stats.SpecialDefense:
                case Stats.Speed:
                    var nature = GetNatureMultiplier(Stat);
                    var level = _pokemon.Level;

                    var value = (int)(((2 * GetBase(Stat) + IV[Stat] + EV[Stat] / 4) * level / 100 + 5) * nature);

                    return (int)(value * stageMultiplier);

                default:
                    throw new NotSupportedException();
            }
        }

        public int MaxHP
        {
            get
            {
                var level = _pokemon.Level;

                return (2 * GetBase(Stats.HP) + IV[Stats.HP] + EV[Stats.HP] / 4) * level / 100 + level + 10;
            }
        }

        int _currentHP;

        public int CurrentHP
        {
            get => _currentHP;
            private set
            {
                _currentHP = value.Clip(0, MaxHP);

                OnPropertyChanged();
            }
        }

        public async Task Damage(int Amount, BattleViewModel Battle)
        {
            // Sturdy
            if (_pokemon.Ability == Ability.Sturdy && _pokemon.AbilityData == 0 && CurrentHP == MaxHP)
            {
                await Battle.ShowAbility(_pokemon);

                CurrentHP = 1;

                await Battle.WriteStatus($"{Battle.GetStatusName(_pokemon)} endured the hit.");

                _pokemon.AbilityData = 1;
            }
            else CurrentHP -= Amount;
        }

        public bool Heal(int Amount)
        {
            if (CurrentHP == MaxHP)
                return false;

            // TODO: Handle Heal Block

            CurrentHP += Amount;

            return true;
        }
    }
}