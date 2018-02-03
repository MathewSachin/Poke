namespace Poke
{
    public class PinchAbility : Ability
    {
        public PinchAbility(string Name, Types Type) : base(Name)
        {
            this.Type = Type;

            Description = $"Strengthens {Type} moves to inflict 1.5x damage at 1/3 max HP or less.";
        }

        public Types Type { get; }
    }
}