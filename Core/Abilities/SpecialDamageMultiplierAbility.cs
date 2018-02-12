namespace Poke
{
    public class AttackMultiplierAbility : Ability
    {
        readonly FilterFunction _filter;

        public AttackMultiplierAbility(string Name, FilterFunction Filter, double Multiplier, bool Physical, bool Special) : base(Name)
        {
            _filter = Filter;
            this.Multiplier = Multiplier;
            this.Physical = Physical;
            this.Special = Special;
        }

        public bool Check(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            return _filter(Attacker, Move, Opponent, Battle);
        }

        public double Multiplier { get; }

        public bool Physical { get; }

        public bool Special { get; }
    }
}