using System.Collections.Generic;

namespace Poke
{
    public class Memory : HeldItem
    {
        Memory(Types Type) : base(Type + " Memory")
        {
            this.Type = Type;

            Description = $"Makes Silvally a {Type}-type Pokémon and makes Multi-Attack a {Type}-type move.";
        }

        public Types Type { get; }

        static readonly Dictionary<Types, Memory> memories = new Dictionary<Types, Memory>();

        static Memory()
        {
            for (var type = Types.Normal + 1; type <= Types.Fairy; ++type)
                memories.Add(type, new Memory(type));
        }

        public static IReadOnlyDictionary<Types, Memory> Memories => memories;
    }
}