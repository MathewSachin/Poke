using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poke
{
    public class TeamMemberViewModel : NotifyPropertyChanged
    {
        public IEnumerable<PokemonSpecies> AvailablePokemon => TeamBuilderViewModel.Filtered;

        public IEnumerable<MoveInfo> AvailableMoves => _species?.LearnSet.Count >= 4 ? _species.LearnSet : Lists.Moves;

        string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                
                OnPropertyChanged();
            }
        }

        PokemonSpecies _species;

        public PokemonSpecies Species
        {
            get => _species;
            set
            {
                if (_species == value)
                    return;

                _species = value;

                if (Species.MegaEvolutions.Count > 0)
                    HeldItem = Species.MegaEvolutions[0].MegaStone;

                OnPropertyChanged(nameof(AvailableMoves));
                
                var shuffle = AvailableMoves
                    .Where(M => M.Kind != MoveKind.Status)
                    .Shuffle()
                    .Take(4)
                    .ToArray();

                Move1 = shuffle[0];
                Move2 = shuffle[1];
                Move3 = shuffle[2];
                Move4 = shuffle[3];
                
                OnPropertyChanged();

                AvailableAbilities.Clear();

                if (Species.AbilitySlot1 != null)
                    AvailableAbilities.Add(Species.AbilitySlot1);

                if (Species.AbilitySlot2 != null)
                    AvailableAbilities.Add(Species.AbilitySlot2);

                if (Species.HiddenAbility != null)
                    AvailableAbilities.Add(Species.HiddenAbility);

                Ability = Species.GetAbility(out var _);
            }
        }

        HeldItem _heldItem;

        public HeldItem HeldItem
        {
            get => _heldItem;
            set
            {
                _heldItem = value;
                
                OnPropertyChanged();
            }
        }

        MoveInfo _move1, _move2, _move3, _move4;

        public MoveInfo Move1
        {
            get => _move1;
            set
            {
                _move1 = value;
                
                OnPropertyChanged();
            }
        }

        public MoveInfo Move2
        {
            get => _move2;
            set
            {
                _move2 = value;

                OnPropertyChanged();
            }
        }

        public MoveInfo Move3
        {
            get => _move3;
            set
            {
                _move3 = value;

                OnPropertyChanged();
            }
        }

        public MoveInfo Move4
        {
            get => _move4;
            set
            {
                _move4 = value;

                OnPropertyChanged();
            }
        }

        Nature _nature;

        public Nature Nature
        {
            get => _nature;
            set
            {
                _nature = value;
                
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ability> AvailableAbilities { get; } = new ObservableCollection<Ability>();

        Ability _ability;

        public Ability Ability
        {
            get => _ability;
            set
            {
                _ability = value;
                
                OnPropertyChanged();
            }
        }
    }
}