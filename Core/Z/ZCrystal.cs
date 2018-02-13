namespace Poke
{
    public abstract class ZCrystal : HeldItem
    {
        public Types Type { get; }

        public string MoveName { get; }

        protected ZCrystal(string CrystalName, Types Type, string MoveName) : base(CrystalName)
        {
            this.Type = Type;
            this.MoveName = MoveName;
        }

        public abstract bool Supports(Pokemon Pokemon, Move Move);

        public abstract ZMove Upgrade(Move Move);
    }
}