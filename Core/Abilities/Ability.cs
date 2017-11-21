namespace Poke
{
    public partial class Ability
    {
        Ability(string Name)
        {
            this.Name = Name;

            Lists.Abilities.Add(this);
        }

        public string Name { get; }

        public string Description { get; private set; }
        
        public override string ToString() => Name;
    }
}
