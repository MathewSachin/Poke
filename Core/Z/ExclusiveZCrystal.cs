using System;
using System.Linq;

namespace Poke
{
    public class ExclusiveZCrystal : ZCrystal
    {
        readonly PokemonSpecies[] _supportedSpecies;
        readonly Func<Move, MoveInfo> _upgrader;

        public ExclusiveZCrystal(string Name, MoveInfo BaseMove, Func<Move, MoveInfo> Upgrader, params PokemonSpecies[] SupportedSpecies) : base(Name)
        {
            this.BaseMove = BaseMove;
            _upgrader = Upgrader;
            _supportedSpecies = SupportedSpecies;
        }

        public override bool Supports(Pokemon Pokemon, Move Move)
        {
            return _supportedSpecies.Contains(Pokemon.Species) && Move.Info == BaseMove;
        }

        public override MoveInfo Upgrade(Move Move)
        {
            return _upgrader(Move);
        }

        public MoveInfo BaseMove { get; }
    }
}