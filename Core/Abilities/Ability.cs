namespace Poke
{
    public partial class Ability
    {
        protected Ability(string Name)
        {
            this.Name = Name;

            Lists.Abilities.Add(this);
        }

        public string Name { get; }

        public string Description { get; protected set; }
        
        public override string ToString() => Name;
    }
}
