namespace Poke
{
    // Halves the damage on type-specific super-effective attack
    public class DamageReductionBerry : Berry
    {
        public Types Type { get; }

        DamageReductionBerry(string Name, Types Type) : base(Name + " Berry")
        {
            this.Type = Type;

            Description = $"Consumed when struck by a super-effective {Type}-type attack to halve the damage.";
        }

        public static DamageReductionBerry Babiri { get; } = new DamageReductionBerry(nameof(Babiri), Types.Steel);

        public static DamageReductionBerry Charti { get; } = new DamageReductionBerry(nameof(Charti), Types.Rock);

        public static DamageReductionBerry Chilan { get; } = new DamageReductionBerry(nameof(Chilan), Types.Normal);

        public static DamageReductionBerry Chople { get; } = new DamageReductionBerry(nameof(Chople), Types.Fighting);

        public static DamageReductionBerry Coba { get; } = new DamageReductionBerry(nameof(Coba), Types.Flying);

        public static DamageReductionBerry Colbur { get; } = new DamageReductionBerry(nameof(Colbur), Types.Dark);

        public static DamageReductionBerry Haban { get; } = new DamageReductionBerry(nameof(Haban), Types.Dragon);

        public static DamageReductionBerry Kasib { get; } = new DamageReductionBerry(nameof(Kasib), Types.Ghost);

        public static DamageReductionBerry Kebia { get; } = new DamageReductionBerry(nameof(Kebia), Types.Poison);

        public static DamageReductionBerry Occa { get; } = new DamageReductionBerry(nameof(Occa), Types.Fire);

        public static DamageReductionBerry Passho { get; } = new DamageReductionBerry(nameof(Passho), Types.Water);

        public static DamageReductionBerry Payapa { get; } = new DamageReductionBerry(nameof(Payapa), Types.Psychic);

        public static DamageReductionBerry Rindo { get; } = new DamageReductionBerry(nameof(Rindo), Types.Grass);

        public static DamageReductionBerry Roseli { get; } = new DamageReductionBerry(nameof(Roseli), Types.Fairy);

        public static DamageReductionBerry Shuca { get; } = new DamageReductionBerry(nameof(Shuca), Types.Ground);

        public static DamageReductionBerry Tanga { get; } = new DamageReductionBerry(nameof(Tanga), Types.Bug);

        public static DamageReductionBerry Wacan { get; } = new DamageReductionBerry(nameof(Wacan), Types.Electric);

        public static DamageReductionBerry Yache { get; } = new DamageReductionBerry(nameof(Yache), Types.Ice);
    }
}