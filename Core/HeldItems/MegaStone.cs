namespace Poke
{
    public class MegaStone : HeldItem
    {
        MegaStone(string Name) : base(Name)
        {
            Lists.MegaStones.Add(this);

            Description = "Allows a specific Pokemon to Mega Evolve during battle.";
        }

        public static MegaStone Abomasite { get; } = new MegaStone(nameof(Abomasite));

        public static MegaStone Absolite { get; } = new MegaStone(nameof(Absolite));

        public static MegaStone Aerodactylite { get; } = new MegaStone(nameof(Aerodactylite));

        public static MegaStone Aggronite { get; } = new MegaStone(nameof(Aggronite));

        public static MegaStone Alakazite { get; } = new MegaStone(nameof(Alakazite));

        public static MegaStone Altarianite { get; } = new MegaStone(nameof(Altarianite));

        public static MegaStone Ampharosite { get; } = new MegaStone(nameof(Ampharosite));

        public static MegaStone Audinite { get; } = new MegaStone(nameof(Audinite));

        public static MegaStone Banettite { get; } = new MegaStone(nameof(Banettite));
        
        public static MegaStone Beedrillite { get; } = new MegaStone(nameof(Beedrillite));

        public static MegaStone Blastoisinite { get; } = new MegaStone(nameof(Blastoisinite));

        public static MegaStone Blazikenite { get; } = new MegaStone(nameof(Blazikenite));

        public static MegaStone Cameruptite { get; } = new MegaStone(nameof(Cameruptite));

        public static MegaStone CharizarditeX { get; } = new MegaStone("Charizardite X");

        public static MegaStone CharizarditeY { get; } = new MegaStone("Charizardite Y");

        public static MegaStone Diancite { get; } = new MegaStone(nameof(Diancite));

        public static MegaStone Galladite { get; } = new MegaStone(nameof(Galladite));

        public static MegaStone Garchompite { get; } = new MegaStone(nameof(Gardevoirite));

        public static MegaStone Gardevoirite { get; } = new MegaStone(nameof(Gardevoirite));

        public static MegaStone Gengarite { get; } = new MegaStone(nameof(Gengarite));

        public static MegaStone Glalitite { get; } = new MegaStone(nameof(Glalitite));

        public static MegaStone Gyaradosite { get; } = new MegaStone(nameof(Gyaradosite));

        public static MegaStone Heracronite { get; } = new MegaStone(nameof(Heracronite));

        public static MegaStone Houndoominite { get; } = new MegaStone(nameof(Houndoominite));

        public static MegaStone Kangaskhanite { get; } = new MegaStone(nameof(Kangaskhanite));

        public static MegaStone Latiasite { get; } = new MegaStone(nameof(Latiasite));

        public static MegaStone Latiosite { get; } = new MegaStone(nameof(Latiosite));

        public static MegaStone Lopunnite { get; } = new MegaStone(nameof(Lopunnite));

        public static MegaStone Lucarionite { get; } = new MegaStone(nameof(Lucarionite));

        public static MegaStone Manectite { get; } = new MegaStone(nameof(Manectite));

        public static MegaStone Mawilite { get; } = new MegaStone(nameof(Mawilite));

        public static MegaStone Medichampite { get; } = new MegaStone(nameof(Medichampite));

        public static MegaStone Metagrossite { get; } = new MegaStone(nameof(Metagrossite));

        public static MegaStone MewtwoniteX { get; } = new MegaStone("Mewtwonite X");

        public static MegaStone MewtwoniteY { get; } = new MegaStone("Mewtwonite Y");

        public static MegaStone Pidgeotite { get; } = new MegaStone(nameof(Pidgeotite));

        public static MegaStone Pinsirite { get; } = new MegaStone(nameof(Pinsirite));
        
        public static MegaStone Sablenite { get; } = new MegaStone(nameof(Sablenite));

        public static MegaStone Salamencite { get; } = new MegaStone(nameof(Salamencite));

        public static MegaStone Sceptilite { get; } = new MegaStone(nameof(Sceptilite));

        public static MegaStone Scizorite { get; } = new MegaStone(nameof(Scizorite));

        public static MegaStone Sharpedonite { get; } = new MegaStone(nameof(Sharpedonite));

        public static MegaStone Slowbronite { get; } = new MegaStone(nameof(Slowbronite));

        public static MegaStone Steelixite { get; } = new MegaStone(nameof(Steelixite));

        public static MegaStone Swampertite { get; } = new MegaStone(nameof(Swampertite));

        public static MegaStone Tyranitarite { get; } = new MegaStone(nameof(Tyranitarite));

        public static MegaStone Venusaurite { get; } = new MegaStone(nameof(Venusaurite));
    }
}