namespace Poke
{
    public abstract class ZCrystal : HeldItem
    {
        protected ZCrystal(string Name) : base(Name)
        {
        }

        public MoveInfo Move { get; protected set; }
    }
}