using System.Threading.Tasks;

namespace Poke
{
    public partial class BattleViewModel
    {
        public int WeatherDuration { get; set; }

        public int SuppressWeather { get; set; }

        Weather _weather;

        public Weather Weather
        {
            get => _weather;
            set
            {
                _weather = value;

                OnPropertyChanged();
            }
        }

        async Task EndWeather()
        {
            if (WeatherDuration > 0)
                --WeatherDuration;

            if (WeatherDuration == 0)
            {
                switch (Weather)
                {
                    case Weather.HarshSunlight:
                    case Weather.ExtremelyHarshSunlight:
                        await WriteStatus("The sunlight faded");
                        break;

                    case Weather.Rain:
                    case Weather.HeavyRain:
                        await WriteStatus("The rain stopped");
                        break;

                    case Weather.Sandstorm:
                        await WriteStatus("The sandstorm subsided");
                        break;

                    case Weather.Hail:
                        await WriteStatus("The hailed stopped");
                        break;

                    case Weather.MysteriousAirCurrent:
                        break;
                }

                Weather = Weather.None;
            }
        }

        async Task PostTurnWeatherEffects(Pokemon Pokemon)
        {
            if (SuppressWeather != 0)
                return;

            switch (Weather)
            {
                case Weather.Rain:
                case Weather.HeavyRain:
                    // Rain Dish
                    if (Pokemon.Ability == Ability.RainDish)
                    {
                        if (Pokemon.Stats.Heal(Pokemon.Stats.MaxHP / 16))
                        {
                            await WriteStatus($"{GetStatusName(Pokemon)} had it's HP restored");
                        }
                    }

                    // Hydration
                    else if (Pokemon.Ability == Ability.Hydration && Pokemon.NonVolatileStatus != NonVolatileStatus.None)
                    {
                        await ShowAbility(Pokemon);

                        await WriteStatus($"{GetStatusName(Pokemon)}'s {Pokemon.NonVolatileStatus.SpaceAtCapitals()} was cured.");

                        Pokemon.NonVolatileStatus = NonVolatileStatus.None;
                    }

                    // Dry Skin
                    else if (Pokemon.Ability == Ability.DrySkin)
                    {
                        if (Pokemon.Stats.Heal(Pokemon.Stats.MaxHP / 8))
                        {
                            await WriteStatus($"{GetStatusName(Pokemon)} had it's HP restored");
                        }
                    }

                    break;

                case Weather.Sandstorm:
                    if (Pokemon.Is(Types.Rock, Types.Steel, Types.Ground))
                        return;

                    // Sand Force, Sand Rush, Overcoat
                    if (Pokemon.Ability.Is(Ability.SandForce, Ability.SandRush, Ability.Overcoat))
                        return;

                    await Pokemon.Stats.Damage(Pokemon.Stats.MaxHP / 16, this);

                    await WriteStatus($"{GetStatusName(Pokemon)} is buffeted by the sandstorm");

                    break;

                case Weather.Hail:
                    if (Pokemon.Is(Types.Ice))
                        return;

                    // Snow Cloak, Overcoat
                    if (Pokemon.Ability.Is(Ability.SnowCloak, Ability.Overcoat))
                        return;

                    // Ice Body
                    if (Pokemon.Ability == Ability.IceBody)
                    {
                        if (Pokemon.Stats.Heal(Pokemon.Stats.MaxHP / 16))
                        {
                            await WriteStatus($"{GetStatusName(Pokemon)} had it's HP restored");
                        }

                        return;
                    }

                    await Pokemon.Stats.Damage(Pokemon.Stats.MaxHP / 16, this);

                    await WriteStatus($"{GetStatusName(Pokemon)} is buffeted by the hail");

                    break;

                case Weather.HarshSunlight:
                case Weather.ExtremelyHarshSunlight:
                    // Solar Power, Dry Skin
                    if (Pokemon.Ability.Is(Ability.SolarPower, Ability.DrySkin))
                    {
                        await Pokemon.Stats.Damage(Pokemon.Stats.MaxHP / 8, this);

                        await WriteStatus($"{GetStatusName(Pokemon)} suffered damage due to {Pokemon.Ability}.");
                    }

                    break;
            }
        }

        async Task WeatherAbility(Pokemon Pokemon)
        {
            if (!Weather.Is(Weather.ExtremelyHarshSunlight, Weather.HeavyRain, Weather.MysteriousAirCurrent))
            {
                // Drizzle
                if (Pokemon.Ability == Ability.Drizzle)
                {
                    await ShowAbility(Pokemon);

                    Weather = Weather.Rain;
                    WeatherDuration = Pokemon.HeldItem == HeldItem.DampRock ? 8 : 5;

                    await WriteStatus("It started to rain");
                }

                // Drought
                else if (Pokemon.Ability == Ability.Drought)
                {
                    await ShowAbility(Pokemon);

                    Weather = Weather.HarshSunlight;
                    WeatherDuration = Pokemon.HeldItem == HeldItem.HeatRock ? 8 : 5;

                    await WriteStatus("The sunlight turned harsh");
                }

                // Sand Stream
                else if (Pokemon.Ability == Ability.SandStream)
                {
                    await ShowAbility(Pokemon);

                    Weather = Weather.Sandstorm;
                    WeatherDuration = Pokemon.HeldItem == HeldItem.SmoothRock ? 8 : 5;

                    await WriteStatus("A sandstorm kicked in");
                }

                // Snow Warning
                else if (Pokemon.Ability == Ability.SnowWarning)
                {
                    await ShowAbility(Pokemon);

                    Weather = Weather.Hail;
                    WeatherDuration = Pokemon.HeldItem == HeldItem.IcyRock ? 8 : 5;

                    await WriteStatus("It started to hail");
                }
            }

            // Desolate Land
            if (Pokemon.Ability == Ability.DesolateLand)
            {
                await ShowAbility(Pokemon);

                Weather = Weather.ExtremelyHarshSunlight;
                WeatherDuration = -1;

                await WriteStatus("The sunlight turned extremely harsh");
            }

            // Primordial Sea
            else if (Pokemon.Ability == Ability.PrimordialSea)
            {
                await ShowAbility(Pokemon);

                Weather = Weather.HeavyRain;
                WeatherDuration = -1;

                await WriteStatus("It started to rain heavily");
            }
        }
    }
}