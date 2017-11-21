using System.Threading.Tasks;

namespace Poke
{
    public delegate Task DamageFunction(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle);
}