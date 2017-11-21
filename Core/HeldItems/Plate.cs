using System.Collections.Generic;

namespace Poke
{
    public class Plate : TypeEnhancement
    {
        Plate(string Name, Types Type) : base(Name, Type)
        {
            Description += $" Makes Arceus a {Type}-type Pokemon and makes Judgement a {Type}-type move.";
        }

        public static IReadOnlyDictionary<Types, Plate> Plates { get; } = new Dictionary<Types, Plate>
        {
            [Types.Dragon] = new Plate("Draco Plate", Types.Dragon),
            [Types.Dark] = new Plate("Dread Plate", Types.Dark),
            [Types.Ground] = new Plate("Earth Plate", Types.Ground),
            [Types.Fighting] = new Plate("Fist Plate", Types.Fighting),
            [Types.Fire] = new Plate("Flame Plate", Types.Fire),
            [Types.Ice] = new Plate("Icicle Plate", Types.Ice),
            [Types.Bug] = new Plate("Insect Plate", Types.Bug),
            [Types.Steel] = new Plate("Iron Plate", Types.Steel),
            [Types.Grass] = new Plate("Meadow Plate", Types.Grass),
            [Types.Psychic] = new Plate("Mind Plate", Types.Psychic),
            [Types.Fairy] = new Plate("Pixie Plate", Types.Fairy),
            [Types.Flying] = new Plate("Sky Plate", Types.Flying),
            [Types.Water] = new Plate("Splash Plate", Types.Water),
            [Types.Ghost] = new Plate("Spooky Plate", Types.Ghost),
            [Types.Rock] = new Plate("Stone Plate", Types.Rock),
            [Types.Poison] = new Plate("Toxic Plate", Types.Poison),
            [Types.Electric] = new Plate("Zap Plate", Types.Electric)
        };
    }
}