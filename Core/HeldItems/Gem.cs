using System.Collections.Generic;

namespace Poke
{
    public class Gem : HeldItem
    {
        Gem(Types Type) : base(Type + " Gem")
        {
            this.Type = Type;
            Description = $"When the holder uses a damaging {Type}-type move, the move has 1.5x power and this item is consumed.";
        }

        public Types Type { get; }

        static readonly Dictionary<Types, Gem> gems = new Dictionary<Types, Gem>();

        static Gem()
        {
            for (var type = Types.Normal; type <= Types.Fairy; ++type)
                gems.Add(type, new Gem(type));
        }

        public static IReadOnlyDictionary<Types, Gem> Gems => gems;
    }
}