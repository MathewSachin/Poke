using System.Collections.Generic;

namespace Poke
{
    public static class Lists
    {
        static Lists()
        {
            // ReSharper disable once NotAccessedVariable
            object a = MoveInfo.AerialAce;
            // ReSharper disable RedundantAssignment
            a = Ability.Overgrow;
            a = Poke.PokemonSpecies.Arcanine;
            a = MegaStone.Blastoisinite;
            a = Nature.Brave;
            // ReSharper restore RedundantAssignment
        }

        public static List<MoveInfo> Moves { get; } = new List<MoveInfo>();

        public static List<Ability> Abilities { get; } = new List<Ability>();

        public static List<PokemonSpecies> PokemonSpecies { get; } = new List<PokemonSpecies>();

        public static List<MegaStone> MegaStones { get; } = new List<MegaStone>();

        public static List<Nature> Natures { get; } = new List<Nature>();
    }
}