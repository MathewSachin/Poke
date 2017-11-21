using System.Collections.Generic;

namespace Poke
{
    class PokemonMovePairComparer : IComparer<PokemonMovePair>
    {
        readonly BattleViewModel _battle;

        public PokemonMovePairComparer(BattleViewModel Battle)
        {
            _battle = Battle;
        }

        static int GetEffectivePriority(Pokemon Attacker, Move Move)
        {
            var priority = Move.Info.Priority;

            if (Attacker.Ability == Ability.GaleWings && Move.Type == Types.Flying)
                ++priority;

            return priority;
        }

        public int Compare(PokemonMovePair X, PokemonMovePair Y)
        {
            if (X.Move != null && Y.Move != null)
            {
                var xPriority = GetEffectivePriority(X.Attacker, X.Move);
                var yPriority = GetEffectivePriority(Y.Attacker, Y.Move);

                if (xPriority != yPriority)
                    return yPriority - xPriority;
            }

            // TODO: Implement Trick Room here
            return Y.Attacker.GetEffectiveSpeed(_battle) - X.Attacker.GetEffectiveSpeed(_battle);
        }
    }
}