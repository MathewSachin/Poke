namespace Poke
{
    public class TypeEnhancement : HeldItem
    {
        protected TypeEnhancement(string Name, Types Type, double Multiplier = 1.2) : base(Name)
        {
            this.Type = Type;
            this.Multiplier = Multiplier;

            Description = $"Increases the power of the holder's {Type} moves by {(int)((Multiplier - 1) * 100)}%.";
        }

        public Types Type { get; }

        public double Multiplier { get; }

        public static TypeEnhancement BlackBelt { get; } = new TypeEnhancement("Black Belt", Types.Fighting);

        public static TypeEnhancement BlackGlasses { get; } = new TypeEnhancement("Black Glasses", Types.Dark);

        public static TypeEnhancement Charcoal { get; } = new TypeEnhancement(nameof(Charcoal), Types.Fire);

        public static TypeEnhancement DragonFang { get; } = new TypeEnhancement("Dragon Fang", Types.Dragon);

        public static TypeEnhancement HardStone { get; } = new TypeEnhancement("Hard Stone", Types.Rock);

        public static TypeEnhancement Magnet { get; } = new TypeEnhancement(nameof(Magnet), Types.Electric);

        public static TypeEnhancement MetalCoat { get; } = new TypeEnhancement("Metal Coat", Types.Steel);

        public static TypeEnhancement MiracleSeed { get; } = new TypeEnhancement("Miracle Seed", Types.Grass);

        public static TypeEnhancement MysticWater { get; } = new TypeEnhancement("Mystic Water", Types.Water);

        public static TypeEnhancement NeverMeltIce { get; } = new TypeEnhancement("Never-Melt Ice", Types.Ice);

        public static TypeEnhancement PinkBow { get; } = new TypeEnhancement("Pink Bow", Types.Normal, 1.1);

        public static TypeEnhancement PoisonBarb { get; } = new TypeEnhancement("Poison Barb", Types.Poison);

        public static TypeEnhancement PolkadotBow { get; } = new TypeEnhancement("Polkadot Bow", Types.Normal, 1.1);

        public static TypeEnhancement SharpBeak { get; } = new TypeEnhancement("Sharp Beak", Types.Flying);

        public static TypeEnhancement SilkScarf { get; } = new TypeEnhancement("Silk Scarf", Types.Normal);

        public static TypeEnhancement SilverPowder { get; } = new TypeEnhancement("Silver Powder", Types.Bug);

        public static TypeEnhancement SoftSand { get; } = new TypeEnhancement("Soft Sand", Types.Ground);

        public static TypeEnhancement SpellTag { get; } = new TypeEnhancement("Spell Tag", Types.Ghost);

        public static TypeEnhancement TwistedSpoon { get; } = new TypeEnhancement("Twisted Spoon", Types.Psychic);

        #region Incenses
        public static TypeEnhancement OddIncense { get; } = new TypeEnhancement("Odd Incense", Types.Psychic);

        public static TypeEnhancement RockIncense { get; } = new TypeEnhancement("Rock Incense", Types.Rock);

        public static TypeEnhancement RoseIncense { get; } = new TypeEnhancement("Rose Incense", Types.Grass);

        public static TypeEnhancement SeaIncense { get; } = new TypeEnhancement("Sea Incense", Types.Water);

        public static TypeEnhancement WaveIncense { get; } = new TypeEnhancement("Wave Incense", Types.Water);
        #endregion
    }
}