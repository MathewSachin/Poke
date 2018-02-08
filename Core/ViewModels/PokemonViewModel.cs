namespace Poke
{
    public class PokemonViewModel
    {
        public PokemonViewModel(PokemonSpecies Species)
        {
            this.Species = Species;

            TypeEffectiveness.PrimaryType = Species.PrimaryType;
            TypeEffectiveness.SecondaryType = Species.SecondaryType;
        }

        public PokemonSpecies Species { get; }

        public TypeEffectivenessViewModel TypeEffectiveness { get; } = new TypeEffectivenessViewModel();
    }
}