using System.Linq;

namespace Poke
{
    public class ExclusiveZCrystal : ZCrystal
    {
        readonly PokemonSpecies[] _supportedSpecies;

        public ExclusiveZCrystal(string Name, MoveInfo BaseMove, params PokemonSpecies[] SupportedSpecies) : base(Name)
        {
            this.BaseMove = BaseMove;
            _supportedSpecies = SupportedSpecies;
        }

        public bool Supports(Pokemon Pokemon)
        {
            return _supportedSpecies.Contains(Pokemon.Species);
        }

        public MoveInfo BaseMove { get; }
    }
}