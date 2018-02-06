using System.Collections.ObjectModel;
using System.Linq;

namespace Poke
{
    public class AbilityViewModel
    {
        public AbilityViewModel(Ability Ability)
        {
            this.Ability = Ability;

            Pokemon = new ObservableCollection<PokemonSpecies>(Lists.PokemonSpecies
                .Where(M => M.AbilitySlot1 == Ability || M.AbilitySlot2 == Ability || M.HiddenAbility == Ability));
        }

        public Ability Ability { get; }

        public ObservableCollection<PokemonSpecies> Pokemon { get; }
    }
}