namespace Poke
{
    public abstract class ZCrystal : HeldItem
    {
        protected ZCrystal(string Name) : base(Name)
        {
        }

        public abstract bool Supports(Pokemon Pokemon, Move Move);

        public abstract MoveInfo Upgrade(Move Move);
    }
}