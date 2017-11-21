namespace Poke
{
    class PokemonMovePair
    {
        public PokemonMovePair(Pokemon Attacker, Move Move)
        {
            this.Attacker = Attacker;
            this.Move = Move;
        }

        public Pokemon Attacker { get; }
        
        public Move Move { get; }

        public Pokemon Target { get; set; }
    }
}