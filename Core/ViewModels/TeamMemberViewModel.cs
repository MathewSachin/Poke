using System.Collections.ObjectModel;
using System.Linq;

namespace Poke
{
    public class TeamMemberViewModel : NotifyPropertyChanged
    {
        static readonly ObservableCollection<PokemonSpecies> Filtered = new ObservableCollection<PokemonSpecies>(Lists.PokemonSpecies.Where(M => !M.Name.StartsWith("Mega ")));

        public ObservableCollection<PokemonSpecies> AvailablePokemon => Filtered;
        
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
                _species = value;

                if (Species.MegaEvolutions.Count > 0)
                    HeldItem = Species.MegaEvolutions[0].MegaStone;
                
                OnPropertyChanged();
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
    }
}