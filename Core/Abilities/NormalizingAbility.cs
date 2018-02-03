namespace Poke
{
    public class NormalizingAbility : Ability
    {
        public NormalizingAbility(string Name, Types Type) : base(Name)
        {
            this.Type = Type;

            Description = $"Turns the bearer's normal moves into {Type} moves and strengthens them to 1.2x their power.";
        }

        public Types Type { get; }
    }
}