using System.Collections.Generic;
using System.Linq;

namespace Poke
{
    public class TeamBuilderViewModel : NotifyPropertyChanged
    {
        public static readonly IReadOnlyList<PokemonSpecies> Filtered = new List<PokemonSpecies>(Lists.PokemonSpecies.Where(M => !M.Name.StartsWith("Mega ")));

        public IEnumerable<TeamMemberViewModel> Members { get; } = Filtered
            .Shuffle()
            .Take(6)
            .Select(M => new TeamMemberViewModel
            {
                Species = M,
                Nature = Lists.Natures.Random()
            }).ToArray();

        public Side GetSide(int Format)
        {
            return new Side(Format, Members
                .Where(M => M.Species != null && M.Move1 != null && M.Move2 != null && M.Move3 != null && M.Move4 != null)
                .Select(M =>
                {
                    var pokemon = new Pokemon(M.Species, 55, M.Name, M.Nature)
                    {
                        HeldItem = M.HeldItem
                    };

                    pokemon.Moves.Assign(M.Move1, M.Move2, M.Move3, M.Move4);

                    return pokemon;
                }).ToArray());
        }
    }
}