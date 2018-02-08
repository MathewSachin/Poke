namespace Poke
{
    public class PokemonViewModel
    {
        public PokemonViewModel(PokemonSpecies Species)
        {
            this.Species = Species;

            TypeEffectiveness.PrimaryType = Species.PrimaryType;
            TypeEffectiveness.SecondaryType = Species.SecondaryType;

            foreach (var pair in Species.BaseStats)
            {
                BaseStatTotal += pair.Value;
            }
        }

        public PokemonSpecies Species { get; }

        public int BaseStatTotal { get; }

        public TypeEffectivenessViewModel TypeEffectiveness { get; } = new TypeEffectivenessViewModel();
    }
}