namespace Poke
{
    public delegate bool FilterFunction(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle);
}