using System.Collections.ObjectModel;
using System.Linq;

namespace Poke
{
    public class MoveViewModel
    {
        public MoveViewModel(MoveInfo MoveInfo)
        {
            this.Move = MoveInfo;

            Pokemon = new ObservableCollection<PokemonSpecies>(Lists.PokemonSpecies
                .Where(M => M.LearnSet.Contains(MoveInfo)));
        }

        public MoveInfo Move { get; }

        public ObservableCollection<PokemonSpecies> Pokemon { get; }
    }
}