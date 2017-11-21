namespace Poke
{
    public class Nature
    {
        public static Nature Hardy { get; } = new Nature(nameof(Hardy), null, null, null, null);
        public static Nature Lonely { get; } = new Nature(nameof(Lonely), Stats.Attack, Stats.Defense, Flavour.Spicy, Flavour.Sour);
        public static Nature Brave { get; } = new Nature(nameof(Brave), Stats.Attack, Stats.Speed, Flavour.Spicy, Flavour.Sweet);
        public static Nature Adamant { get; } = new Nature(nameof(Adamant), Stats.Attack, Stats.SpecialAttack, Flavour.Spicy, Flavour.Dry);
        public static Nature Naughty { get; } = new Nature(nameof(Naughty), Stats.Attack, Stats.SpecialDefense, Flavour.Spicy, Flavour.Bitter);
        public static Nature Bold { get; } = new Nature(nameof(Bold), Stats.Defense, Stats.Attack, Flavour.Sour, Flavour.Spicy);
        public static Nature Docile { get; } = new Nature(nameof(Docile), null, null, null, null);
        public static Nature Relaxed { get; } = new Nature(nameof(Relaxed), Stats.Defense, Stats.Speed, Flavour.Sour, Flavour.Sweet);
        public static Nature Impish { get; } = new Nature(nameof(Impish), Stats.Defense, Stats.SpecialAttack, Flavour.Sour, Flavour.Dry);
        public static Nature Lax { get; } = new Nature(nameof(Lax), Stats.Defense, Stats.SpecialDefense, Flavour.Sour, Flavour.Bitter);
        public static Nature Timid { get; } = new Nature(nameof(Timid), Stats.Speed, Stats.Attack, Flavour.Sweet, Flavour.Spicy);
        public static Nature Hasty { get; } = new Nature(nameof(Hasty), Stats.Speed, Stats.Defense, Flavour.Sweet, Flavour.Sour);
        public static Nature Serious { get; } = new Nature(nameof(Serious), null, null, null, null);
        public static Nature Jolly { get; } = new Nature(nameof(Jolly), Stats.Speed, Stats.SpecialAttack, Flavour.Sweet, Flavour.Dry);
        public static Nature Naive { get; } = new Nature(nameof(Naive), Stats.Speed, Stats.SpecialDefense, Flavour.Sweet, Flavour.Bitter);
        public static Nature Modest { get; } = new Nature(nameof(Modest), Stats.SpecialAttack, Stats.Attack, Flavour.Dry, Flavour.Spicy);
        public static Nature Mild { get; } = new Nature(nameof(Mild), Stats.SpecialAttack, Stats.Defense, Flavour.Dry, Flavour.Sour);
        public static Nature Quiet { get; } = new Nature(nameof(Quiet), Stats.SpecialAttack, Stats.Speed, Flavour.Dry, Flavour.Sweet);
        public static Nature Bashful { get; } = new Nature(nameof(Bashful), null, null, null, null);
        public static Nature Rash { get; } = new Nature(nameof(Rash), Stats.SpecialAttack, Stats.SpecialDefense, Flavour.Dry, Flavour.Bitter);
        public static Nature Calm { get; } = new Nature(nameof(Calm), Stats.SpecialDefense, Stats.Attack, Flavour.Bitter, Flavour.Spicy);
        public static Nature Gentle { get; } = new Nature(nameof(Gentle), Stats.SpecialDefense, Stats.Defense, Flavour.Bitter, Flavour.Sour);
        public static Nature Sassy { get; } = new Nature(nameof(Sassy), Stats.SpecialDefense, Stats.Speed, Flavour.Bitter, Flavour.Sweet);
        public static Nature Careful { get; } = new Nature(nameof(Careful), Stats.SpecialDefense, Stats.SpecialAttack, Flavour.Bitter, Flavour.Dry);
        public static Nature Quirky { get; } = new Nature(nameof(Quirky), null, null, null, null);
     
        public Stats? IncreasedStat { get; }
        public Stats? DecreasedStat { get; }
        public Flavour? FavouriteFlavour { get; }
        public Flavour? DislikedFlavour { get; }

        public string Name { get; }

        Nature(string Name, Stats? IncreasedStat, Stats? DecreasedStat, Flavour? FavouriteFlavour, Flavour? DislikedFlavour)
        {
            this.Name = Name;

            this.IncreasedStat = IncreasedStat;
            this.DecreasedStat = DecreasedStat;
            this.FavouriteFlavour = FavouriteFlavour;
            this.DislikedFlavour = DislikedFlavour;

            Lists.Natures.Add(this);
        }

        public override string ToString() => Name;
    }
}