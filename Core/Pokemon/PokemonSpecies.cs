using System;
using System.Collections.Generic;

namespace Poke
{
    public partial class PokemonSpecies
    {
        public string Name { get; }
        public Types PrimaryType { get; }
        public Types? SecondaryType { get; }

        public int Number { get; }

        PokemonSpecies(int Number, string Name, Types PrimaryType, Types? SecondaryType,
            int HP, int Attack, int Defense, int SpecialAttack, int SpecialDefense, int Speed,
            Ability AbilitySlot1, Ability AbilitySlot2 = null, Ability HiddenAbility = null)
        {
            this.Number = Number;
            this.Name = Name;
            this.PrimaryType = PrimaryType;
            this.SecondaryType = SecondaryType;

            _baseStats = new Dictionary<Stats, int>
            {
                [Stats.HP] = HP,
                [Stats.Attack] = Attack,
                [Stats.Defense] = Defense,
                [Stats.SpecialAttack] = SpecialAttack,
                [Stats.SpecialDefense] = SpecialDefense,
                [Stats.Speed] = Speed
            };

            this.AbilitySlot1 = AbilitySlot1;
            this.AbilitySlot2 = AbilitySlot2;
            this.HiddenAbility = HiddenAbility;

            Lists.PokemonSpecies.Add(this);
        }

        readonly Dictionary<Stats, int> _baseStats;

        public IReadOnlyDictionary<Stats, int> BaseStats => _baseStats;
        
        public List<MegaEvolution> MegaEvolutions { get; } = new List<MegaEvolution>();

        public GenderRatio GenderRatio { get; private set; } = GenderRatio.Balanced;

        public Ability AbilitySlot1 { get; }

        public Ability AbilitySlot2 { get; }

        public Ability HiddenAbility { get; }
        
        public Ability GetAbility(int Slot)
        {
            switch (Slot)
            {
                case 1:
                    return AbilitySlot1;

                case 2:
                    return AbilitySlot2;

                case 3:
                    return HiddenAbility;

                default:
                    return null;
            }
        }

        public Ability GetAbility(out int Slot)
        {
            var available = new List<KeyValuePair<int, Ability>>();

            if (AbilitySlot1 != null)
            {
                available.Add(new KeyValuePair<int, Ability>(1, AbilitySlot1));
            }

            if (AbilitySlot2 != null)
            {
                available.Add(new KeyValuePair<int, Ability>(2, AbilitySlot2));
            }

            if (HiddenAbility != null)
            {
                available.Add(new KeyValuePair<int, Ability>(3, HiddenAbility));
            }

            if (available.Count == 0)
            {
                Slot = 1;

                return null;
            }

            var selected = available.Random();

            Slot = selected.Key;

            return selected.Value;
        }

        public List<MoveInfo> LearnSet { get; } = new List<MoveInfo>();
    }
}