namespace Poke
{
    public class StatFallPreventionAbility : Ability
    {
        public StatFallPreventionAbility(string Name, Stats Stat) : base(Name)
        {
            this.Stat = Stat;

            Description = $"Prevents {Stat.SpaceAtCapitals()} from being lowered by other Pokemon.";
        }

        public Stats Stat { get; }
    }
}