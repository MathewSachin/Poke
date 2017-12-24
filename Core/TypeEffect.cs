using System;

namespace Poke
{
    public class TypeEffect
    {
        public TypeEffect(Types Type, double Effect)
        {
            this.Type = Type;

            if (Math.Abs(Effect - 0.5) < 0.01)
                Effectiveness = "½";
            else if (Math.Abs(Effect - 0.25) < 0.01)
                Effectiveness = "¼";
            else Effectiveness = ((int)Effect).ToString();
        }

        public Types Type { get; }

        public string Effectiveness { get; }

        public override string ToString() => $"{Type}: {Effectiveness}";
    }
}