namespace Poke
{
    public class HeldItem
    {
        protected HeldItem(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; }

        public string Description { get; protected set; }

        public override string ToString() => Name;

        public static HeldItem BlueOrb { get; } = new HeldItem("Blue Orb");
        public static HeldItem RedOrb { get; } = new HeldItem("Red Orb");

        public static HeldItem BrightPowder { get; } = new HeldItem("Bright Powder")
        {
            Description = "Moves targetting the holder have 0.9x chance to hit."
        };
        
        public static HeldItem CellBattery { get; } = new HeldItem("Cell Battery")
        {
            Description = "When the holder takes electric-type from a move, its Attack by one stage and this item is consumed."
        };
        
        public static HeldItem DampRock { get; } = new HeldItem("Damp Rock")
        {
            Description = "Increases the duration of rain created by holder using the move Rain Dance or the Drizzle Ability to 8 turns rather than 5."
        };

        public static HeldItem HeatRock { get; } = new HeldItem("Heat Rock")
        {
            Description = "Increases the duration of harsh sunlight created by holder using the move Sunny Day or the Drought Ability to 8 turns rather than 5."
        };
        
        public static HeldItem IcyRock { get; } = new HeldItem("Icy Rock")
        {
            Description = "Increases the duration of hail created by holder using the move Hail or the Snow Warning Ability to 8 turns rather than 5."
        };

        public static HeldItem LightBall { get; } = new HeldItem("Light Ball")
        {
            Description = "Doubles holding Pikachu's Attack and Special Attack."
        };

        public static HeldItem SmoothRock { get; } = new HeldItem("Smooth Rock")
        {
            Description = "Increases the duration of sandstorm created by holder using the move Sandstorm or the Sand Stream Ability to 8 turns rather than 5."
        };
    }
}