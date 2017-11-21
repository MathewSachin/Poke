namespace Poke
{
    public class TypeZCrystal : ZCrystal
    {
        public Types Type { get; }

        TypeZCrystal(string Name, Types Type) : base(Name)
        {
            this.Type = Type;
        }
    }
}