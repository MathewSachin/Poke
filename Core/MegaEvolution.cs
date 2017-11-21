namespace Poke
{
    public class MegaEvolution
    {
        public MegaEvolution(PokemonSpecies Species, MegaStone MegaStone)
        {
            this.Species = Species;
            this.MegaStone = MegaStone;
        }

        public PokemonSpecies Species { get; }

        public MegaStone MegaStone { get; }
    }
}