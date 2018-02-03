namespace Poke
{
    public class WeatherEffectNegatorAbility : Ability
    {
        public WeatherEffectNegatorAbility(string Name) : base(Name)
        {
            Description = "Negates all effects of weather, but does not prevent the weather itself.";
        }
    }
}