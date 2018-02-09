using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poke
{
    public static class Extensions
    {
        public static string SpaceAtCapitals(this object Obj)
        {
            var s = Obj.ToString();

            var sb = new StringBuilder();

            for (var i = 0; i < s.Length; ++i)
            {
                if (i != 0 && char.IsUpper(s[i]))
                    sb.Append(" ");

                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public static T Clip<T>(this T Value, T Minimum, T Maximum) where T : IComparable<T>
        {
            if (Minimum.CompareTo(Maximum) > 0)
                throw new ArgumentException($"{Minimum} value is greater than {Maximum}");

            if (Value.CompareTo(Minimum) < 0)
                return Minimum;

            if (Value.CompareTo(Maximum) > 0)
                return Maximum;

            return Value;
        }

        public static string GetColorHex(this Types Type)
        {
            switch (Type)
            {
                case Types.Normal:
                    return "#A8A77A";

                case Types.Fire:
                    return "#EE8130";

                case Types.Fighting:
                    return "#C22E28";

                case Types.Water:
                    return "#6390F0";

                case Types.Flying:
                    return "#A98FF3";

                case Types.Grass:
                    return "#7AC74C";

                case Types.Poison:
                    return "#A33EA1";

                case Types.Electric:
                    return "#F7D02C";

                case Types.Ground:
                    return "#E2BF65";

                case Types.Psychic:
                    return "#F95587";

                case Types.Rock:
                    return "#B6A136";

                case Types.Ice:
                    return "#96D9D6";

                case Types.Bug:
                    return "#A6B91A";

                case Types.Dragon:
                    return "#6F35FC";

                case Types.Ghost:
                    return "#735797";

                case Types.Dark:
                    return "#705746";

                case Types.Steel:
                    return "#B7B7CE";

                case Types.Fairy:
                    return "#D685AD";

                default:
                    return null;
            }
        }

        public static bool Is<T>(this T Obj, params T[] Candidates)
        {
            return Candidates != null && Candidates.Contains(Obj);
        }

        public static bool Is(this Pokemon Pokemon, params Types[] Types)
        {
            return Types.Any(Type => Pokemon.PrimaryType == Type || Pokemon.SecondaryType == Type);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> Enumerable)
        {
            return Enumerable.OrderBy(M => BattleViewModel.Random.Next());
        }

        public static T[] Shuffle<T>(this T[] Arr)
        {
            return Arr.OrderBy(S => BattleViewModel.Random.Next()).ToArray();
        }

        public static int GetEffectiveSpeed(this Pokemon Pokemon, BattleViewModel Battle)
        {
            double speed = Pokemon.Stats.GetValue(Stats.Speed);

            if (Battle.SuppressWeather == 0)
            {
                // Chlorophyll
                if (Pokemon.Ability == Ability.Chlorophyll && Battle.Weather.Is(Weather.HarshSunlight, Weather.ExtremelyHarshSunlight))
                    speed *= 2;

                // Swift Swim
                if (Pokemon.Ability == Ability.SwiftSwim && Battle.Weather.Is(Weather.Rain, Weather.HeavyRain))
                    speed *= 2;

                // Sand Rush
                if (Pokemon.Ability == Ability.SandRush && Battle.Weather == Weather.Sandstorm)
                    speed *= 2;
            }
            
            // Quick Feet
            if (Pokemon.Ability == Ability.QuickFeet && Pokemon.NonVolatileStatus != NonVolatileStatus.None)
                speed *= 1.5;
            
            // Paralysis
            else if (Pokemon.NonVolatileStatus == NonVolatileStatus.Paralysis)
                speed /= 2;

            return (int)speed;
        }

        public static double GetTypeEffectiveness(this Pokemon Pokemon, Types MoveType)
        {
            return TypeEffectiveness.Get(MoveType, Pokemon.PrimaryType, Pokemon.SecondaryType);
        }

        public static IEnumerable<Pokemon> GetAdjacentFoes(this Pokemon Pokemon)
        {
            var attackerPosition = -1;

            for (var i = 0; i < Pokemon.Side.Format; ++i)
            {
                if (Pokemon == Pokemon.Side.Battling[i])
                {
                    attackerPosition = i;

                    break;
                }
            }

            Pokemon opponent;

            // Left
            if (attackerPosition != 0)
            {
                opponent = Pokemon.Side.OpposingSide.Battling[attackerPosition - 1];

                if (opponent != null && !opponent.IsFainted)
                {
                    yield return opponent;
                }
            }

            // Facing
            opponent = Pokemon.Side.OpposingSide.Battling[attackerPosition];

            if (opponent != null && !opponent.IsFainted)
            {
                yield return opponent;
            }

            // Right
            if (attackerPosition != Pokemon.Side.Format - 1)
            {
                opponent = Pokemon.Side.OpposingSide.Battling[attackerPosition + 1];

                if (opponent != null && !opponent.IsFainted)
                {
                    yield return opponent;
                }
            }
        }

        public static IEnumerable<Pokemon> GetAdjacentAllies(this Pokemon Pokemon, bool ExcludeTelepathy = false)
        {
            var attackerPosition = -1;

            for (var i = 0; i < Pokemon.Side.Format; ++i)
            {
                if (Pokemon == Pokemon.Side.Battling[i])
                {
                    attackerPosition = i;

                    break;
                }
            }

            Pokemon ally;

            // Left
            if (attackerPosition != 0)
            {
                ally = Pokemon.Side.Battling[attackerPosition - 1];

                if (ally != null && !ally.IsFainted)
                {
                    if (!(ExcludeTelepathy && ally.Ability == Ability.Telepathy))
                        yield return ally;
                }
            }
            
            // Right
            if (attackerPosition != Pokemon.Side.Format - 1)
            {
                ally = Pokemon.Side.Battling[attackerPosition + 1];

                if (ally != null && !ally.IsFainted)
                {
                    if (!(ExcludeTelepathy && ally.Ability == Ability.Telepathy))
                        yield return ally;
                }
            }
        }

        public static IEnumerable<Pokemon> GetAdjacent(this Pokemon Pokemon, bool ExcludeTelepathy = false)
        {
            return Pokemon.GetAdjacentFoes().Concat(Pokemon.GetAdjacentAllies(ExcludeTelepathy));
        }

        public static T Random<T>(this IReadOnlyList<T> List)
        {
            return List[BattleViewModel.Random.Next(List.Count)];
        }
    }
}