using System.Collections.Generic;
using System.Linq;

namespace Poke
{
    public class TeamBuilderViewModel : NotifyPropertyChanged
    {
        public IEnumerable<TeamMemberViewModel> Members { get; } = new[]
        {
            new TeamMemberViewModel(),
            new TeamMemberViewModel(),
            new TeamMemberViewModel(),
            new TeamMemberViewModel(),
            new TeamMemberViewModel(),
            new TeamMemberViewModel(),
        };

        public Side GetSide(int Format)
        {
            return new Side(Format, Members
                .Where(M => M.Species != null && M.Move1 != null && M.Move2 != null && M.Move3 != null && M.Move4 != null)
                .Select(M =>
                {
                    var pokemon = new Pokemon(M.Species, 55, M.Name)
                    {
                        HeldItem = M.HeldItem
                    };

                    pokemon.Moves.Assign(M.Move1, M.Move2, M.Move3, M.Move4);

                    return pokemon;
                }).ToArray());
        }
    }
}