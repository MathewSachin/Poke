using System.Linq;

namespace Poke
{
    public partial class ExclusiveZCrystal : ZCrystal
    {
        readonly PokemonSpecies[] _supportedSpecies;

        public ExclusiveZCrystal(string CrystalName, MoveInfo BaseMove, string MoveName, MoveInfo ZMove, params PokemonSpecies[] SupportedSpecies) : base(CrystalName, BaseMove.Type, MoveName)
        {
            this.BaseMove = BaseMove;
            this.ZMove = ZMove;
            _supportedSpecies = SupportedSpecies;
        }

        public override bool Supports(Pokemon Pokemon, Move Move)
        {
            return _supportedSpecies.Contains(Pokemon.Species) && Move.Info == BaseMove;
        }

        public override MoveInfo Upgrade(Move Move) => ZMove;

        static ExclusiveZCrystal MakeCrystal(string CrystalName, MoveInfo BaseMove, string MoveName, int Power, params PokemonSpecies[] SupportedSpecies)
        {
            return new ExclusiveZCrystal(CrystalName + " Z", BaseMove, MoveName,
                new MoveInfo(MoveName, BaseMove.Type, BaseMove.Kind, Power, null, 1, null, true), SupportedSpecies);
        }

        public MoveInfo BaseMove { get; }

        public MoveInfo ZMove { get; }
    }
}