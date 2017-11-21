namespace Poke
{
    public class Drive : HeldItem
    {
        public Types Type { get; }

        Drive(string Name, Types Type) : base(Name)
        {
            this.Type = Type;

            Description = $"Makes the holder's Techno Blast a {Type}-type move.";
        }

        public static Drive BurnDrive { get; } = new Drive("Burn Drive", Types.Fire);

        public static Drive ChillDrive { get; } = new Drive("Chill Drive", Types.Ice);

        public static Drive DouseDrive { get; } = new Drive("Douse Drive", Types.Water);

        public static Drive ShockDrive { get; } = new Drive("Shock Drive", Types.Electric);
    }
}