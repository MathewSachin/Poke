namespace Poke
{
    public partial class Ability
    {
        public static Ability Adaptability { get; } = new Ability(nameof(Adaptability))
        {
            Description = "Increases the same-type attack boost from 1.5x to 2x."
        };

        public static NormalizingAbility Aerilate { get; } = new NormalizingAbility(nameof(Aerilate), Types.Flying);

        public static WeatherEffectNegatorAbility AirLock { get; } = new WeatherEffectNegatorAbility("Air Lock");

        public static Ability AngerPoint { get; } = new Ability(nameof(AngerPoint))
        {
            Description = "Raises Attack to the maximum of six stages upon receiving a critical hit."
        };

        public static Ability BattleArmor { get; } = new Ability("Battle Armor")
        {
            Description = "Protects against critical hits."
        };

        public static Ability BigPecks { get; } = new Ability("Big Pecks")
        {
            Description = "Protects against Defense drops."
        };

        public static PinchAbility Blaze { get; } = new PinchAbility(nameof(Blaze), Types.Fire);

        public static Ability BulletProof { get; } = new Ability("Bullet Proof")
        {
            Description = "Protects against bullet, ball and bomb based moves."
        };

        public static Ability Chlorophyll { get; } = new Ability(nameof(Chlorophyll))
        {
            Description = "Doubles Speed during strong sunlight."
        };

        public static Ability ClearBody { get; } = new Ability("Clear Body")
        {
            Description = "Prevents stats from being lowered by other Pokemon."
        };

        public static WeatherEffectNegatorAbility CloudNine { get; } = new WeatherEffectNegatorAbility("Cloud Nine");

        public static Ability CompoundEyes { get; } = new Ability("Compound Eyes")
        {
            Description = "Increases moves' accuracy to 1.3x."
        };

        public static Ability Contrary { get; } = new Ability(nameof(Contrary))
        {
            Description = "Inverts stat changes."
        };

        public static Ability Corrosion { get; } = new Ability(nameof(Corrosion))
        {
            Description = "With the Corrosion Ability, it becomes possible to inflict the Poisoned status condition even on Steel and Poison type Pokemon."
        };

        public static Ability CursedBody { get; } = new Ability(nameof(CursedBody))
        {
            Description = "Has a 30% chance of disabling any move that hits the Pokemon."
        };

        public static Ability Defeatist { get; } = new Ability(nameof(Defeatist))
        {
            Description = "Halves Attack and Special Attack at 50% max HP or less."
        };

        public static Ability DesolateLand { get; } = new Ability("Desolate Land")
        {
            Description = "Affects weather and nullifies any Water-type attacks."
        };

        public static Ability Disguise { get; } = new Ability(nameof(Disguise))
        {
            Description = "Allows the Pokemon to escape damage from an enemy's attack just one time, and then its appearance changes."
        };

        public static Ability Download { get; } = new Ability(nameof(Download))
        {
            Description = "Raises the attack stat corresponding to the opponents weaker defense one stage upon entering battle."
        };

        public static Ability Drizzle { get; } = new Ability(nameof(Drizzle))
        {
            Description = "Summons rain that lasts for 5 turns upon entering battle."
        };

        public static Ability Drought { get; } = new Ability(nameof(Drought))
        {
            Description = "Summons strong sunlight that lasts for 5 turns upon entering battle."
        };

        public static Ability DrySkin { get; } = new Ability("Dry Skin")
        {
            Description = "Causes 1/8 max HP damage each turn during strong sunlight, but heals for 1/8 max HP during rain. Increases damage from fire moves to 1.25x but absorbs water moves healing for 1/4 max HP."
        };

        public static Ability EarlyBird { get; } = new Ability("Early Bird")
        {
            Description = "Makes sleep pass twice as quickly."
        };

        public static Ability EffectSpore { get; } = new Ability("Effect Spore")
        {
            Description = "Has a 30% chance of inflicting either paralysis, poison or sleep on attacking Pokemon on contact."
        };

        public static Ability Filter { get; } = new Ability(nameof(Filter))
        {
            Description = "Decreases damage taken from super-effective moves by 1/4."
        };

        public static Ability FlameBody { get; } = new Ability("Flame Body")
        {
            Description = "Has a 30% chance of burning attacking Pokemon on contact."
        };

        public static Ability FlareBoost { get; } = new Ability("Flare Boost")
        {
            Description = "Increases Special Attack to 1.5x when burned."
        };

        public static Ability FlashFire { get; } = new Ability("Flash Fire")
        {
            Description = "Protects against fire moves. Once one has been blocked, the Pokemon's own Fire moves inflict 1.5x damage until it leaves battle."
        };

        public static Ability Frisk { get; } = new Ability(nameof(Frisk))
        {
            Description = "Reveals an opponent's held item upon entering battle."
        };

        public static Ability FullMetalBody { get; } = new Ability("Full Metal Body")
        {
            Description = "The Pokemon's stats will not be lowered by the effects of an opponents moves or Ability."
        };

        public static Ability FurCoat { get; } = new Ability("Fur Coat")
        {
            Description = "Halves damage from physical attacks."
        };

        public static Ability GaleWings { get; } = new Ability("Gale Wings")
        {
            Description = "Raises flying moves' priority by one stage."
        };

        public static NormalizingAbility Galvanize { get; } = new NormalizingAbility(nameof(Galvanize), Types.Electric);

        public static Ability Gooey { get; } = new Ability(nameof(Gooey))
        {
            Description = "Lowers attacking Pokemon's Speed by one stage on contact."
        };

        public static Ability Guts { get; } = new Ability(nameof(Guts))
        {
            Description = "Increases Attack to 1.5x with a major status ailment."
        };

        public static Ability Heatproof { get; } = new Ability(nameof(Heatproof))
        {
            Description = "Halves damage from fire moves and burns."
        };

        public static Ability HugePower { get; } = new Ability("Huge Power")
        {
            Description = "Doubles Attack in battle."
        };

        public static Ability Hydration { get; } = new Ability(nameof(Hydration))
        {
            Description = "Cures any major status ailment after each turn during rain."
        };

        public static Ability HyperCutter { get; } = new Ability("Hyper Cutter")
        {
            Description = "Prevents Attack from being lowered by other Pokemon."
        };

        public static Ability Hustle { get; } = new Ability(nameof(Hustle))
        {
            Description = "Strengthens physical moves to inflict 1.5x damage, but decreases their accuracy to 0.8x."
        };

        public static Ability IceBody { get; } = new Ability("Ice Body")
        {
            Description = "Heals for 1/16 max HP after each turn during hail. Protects against hail damage."
        };

        public static Ability Immunity { get; } = new Ability(nameof(Immunity))
        {
            Description = "Prevents Poison."
        };

        public static Ability InnerFocus { get; } = new Ability("Inner Focus")
        {
            Description = "Prevents flinching."
        };

        public static Ability Insomnia { get; } = new Ability(nameof(Insomnia))
        {
            Description = "Prevents sleep."
        };

        public static Ability Intimidate { get; } = new Ability(nameof(Intimidate))
        {
            Description = "Lowers opponents' Attack one stage upon entering battle."
        };

        public static Ability IronBarbs { get; } = new Ability("Iron Barbs")
        {
            Description = "Damages attacking Pokemon for 1/8 their max HP on contact."
        };

        public static Ability IronFist { get; } = new Ability("Iron Fist")
        {
            Description = "Strengthens punch-based moves to 1.2x their power."
        };

        public static Ability Justified { get; } = new Ability(nameof(Justified))
        {
            Description = "Raises Attack one stage upon taking damage from a dark move."
        };

        public static Ability KeenEye { get; } = new Ability("Keen Eye")
        {
            Description = "Prevents Accuracy from being lowered."
        };

        public static Ability LeafGuard { get; } = new Ability("Leaf Guard")
        {
            Description = "Protects against major status ailments during strong sunlight."
        };

        public static Ability Levitate { get; } = new Ability(nameof(Levitate))
        {
            Description = "Evades ground moves."
        };
        
        public static Ability Limber { get; } = new Ability(nameof(Limber))
        {
            Description = "Prevents paralysis."
        };

        public static Ability LongReach { get; } = new Ability("Long Reach")
        {
            Description = "When a Pokemon with this ability uses a move that makes contact, it will not trigger any effects caused by contact."
        };

        public static Ability MagmaArmor { get; } = new Ability("Magma Armor")
        {
            Description = "Prevents freezing."
        };

        public static Ability MarvelScale { get; } = new Ability("Marvel Scale")
        {
            Description = "Increases Defense to 1.5x with a major status ailment."
        };

        public static Ability MegaLauncher { get; } = new Ability("Mega Launcher")
        {
            Description = "Strengthens aura and pulse moves to 1.5x their power."
        };

        public static Ability Merciless { get; } = new Ability(nameof(Merciless))
        {
            Description = "The Pokemon's attacks become critical hits if the target is poisoned."
        };

        public static Ability MotorDrive { get; } = new Ability("Motor Drive")
        {
            Description = "Absorbs electric moves, raising Speed one stage."
        };

        public static Ability Multiscale { get; } = new Ability(nameof(Multiscale))
        {
            Description = "Halves damage taken from full HP."
        };

        public static Ability NoGuard { get; } = new Ability("No Guard")
        {
            Description = "Ensures all moves used by and against the Pokemon hit."
        };

        public static PinchAbility Overgrow { get; } = new PinchAbility(nameof(Overgrow), Types.Grass);

        public static Ability Overcoat { get; } = new Ability(nameof(Overcoat))
        {
            Description = "Protects against damage from weather and powder moves."
        };

        public static Ability OwnTempo { get; } = new Ability("Own Tempo")
        {
            Description = "Prevents confusion."
        };

        public static NormalizingAbility Pixilate { get; } = new NormalizingAbility(nameof(Pixilate), Types.Fairy);

        public static Ability PoisonHeal { get; } = new Ability("Poison Heal")
        {
            Description = "Heals for 1/8 max HP after each turn when poisoned in place of damage."
        };

        public static Ability PoisonPoint { get; } = new Ability("Poison Point")
        {
            Description = "Has a 30% chance of poisoning attacking Pokemon on contact."
        };

        public static Ability PoisonTouch { get; } = new Ability("Poison Touch")
        {
            Description = "Has a 30% chance of poisoning target Pokemon upon contact."
        };

        public static Ability Pressure { get; } = new Ability(nameof(Pressure))
        {
            Description = "Increases the PP cost of moves targetting the Pokemon by one."
        };

        public static Ability PrimordialSea { get; } = new Ability("Primordial Sea")
        {
            Description = "Affects weather and nullifies any Fire-type attacks."
        };
        
        public static Ability PrismArmor { get; } = new Ability("Prism Armor")
        {
            Description = "Reduces super effective damage by 25%"
        };

        public static Ability PurePower { get; } = new Ability("Pure Power")
        {
            Description = "Doubles Attack in battle."
        };

        public static Ability QuickFeet { get; } = new Ability("Quick Feet")
        {
            Description = "Increases Speed to 1.5x with a major status ailment."
        };

        public static Ability RainDish { get; } = new Ability("Rain Dish")
        {
            Description = "Heals for 1/16 max HP after each turn during rain."
        };

        public static Ability Rattled { get; } = new Ability(nameof(Rattled))
        {
            Description = "Raises Speed one stage upon being hit by a dark, ghost or bug move"
        };

        // TODO: Does not affect Struggle
        public static Ability Reckless { get; } = new Ability(nameof(Reckless))
        {
            Description = "Strengthens recoil moves to 1.2x their power."
        };

        public static NormalizingAbility Refrigerate { get; } = new NormalizingAbility(nameof(Refrigerate), Types.Ice);

        public static Ability Regenerator { get; } = new Ability(nameof(Regenerator))
        {
            Description = "Heals for 1/3 max HP upon switching out."
        };

        public static Ability Rivalry { get; } = new Ability(nameof(Rivalry))
        {
            Description = "Increases damage inflicted to 1.25x against Pokemon of the same gender, but decreases damage to 0.75x against the opposite gender."
        };

        // TODO: Does not affect Struggle recoil
        // TODO: Crash damage is unaffected
        public static Ability RockHead { get; } = new Ability("Rock Head")
        {
            Description = "Protects against recoil damage."
        };

        public static Ability RoughSkin { get; } = new Ability("Rough Skin")
        {
            Description = "Damages attacking Pokemon for 1/8 their max HP on contact."
        };

        public static Ability SandForce { get; } = new Ability("Sand Force")
        {
            Description = "Strengthens rock, ground and steel moves to 1.3x their power during a sandstorm. Protects against sandstorm damage."
        };

        public static Ability SandRush { get; } = new Ability("Sand Rush")
        {
            Description = "Doubles Speed during a sandstorm. Protects against sandstorm damage."
        };

        public static Ability SandStream { get; } = new Ability("Sand Stream")
        {
            Description = "Summons a sandstorm that lasts for 5 turns upon entering battle."
        };

        public static Ability SapSipper { get; } = new Ability("Sap Sipper")
        {
            Description = "Absorbs grass moves, raising Attack one stage."
        };

        public static Ability Scrappy { get; } = new Ability(nameof(Scrappy))
        {
            Description = "Let's the Pokemon's normal and fighting moves hit ghost Pokemon."
        };

        public static Ability ShellArmor { get; } = new Ability("Shell Armor")
        {
            Description = "Protects against critical hits."
        };

        public static Ability Simple { get; } = new Ability(nameof(Simple))
        {
            Description = "Doubles the Pokemon's stat modifiers. These doubled modifiers are still capped at -6 or +6 stages."
        };

        public static Ability Sniper { get; } = new Ability(nameof(Sniper))
        {
            Description = "Strengthens critical hits to inflict 2.25x damage rather than 1.5x."
        };

        public static Ability SnowCloak { get; } = new Ability("Snow Cloak")
        {
            Description = "Increases evasion to 1.25x during hail. Protects against hail damage."
        };

        public static Ability SnowWarning { get; } = new Ability("Snow Warning")
        {
            Description = "Summons hail that lasts for 5 turns upon entering battle."
        };

        public static Ability SolarPower { get; } = new Ability("Solar Power")
        {
            Description = "Increases Special Attack to 1.5x but costs 1/8 max HP after each turn during strong sunlight."
        };

        public static Ability SolidRock { get; } = new Ability("Solid Rock")
        {
            Description = "Decreases damage taken from super-effective moves by 1/4."
        };

        public static Ability Soundproof { get; } = new Ability(nameof(Soundproof))
        {
            Description = "Protects against sound based moves."
        };

        public static Ability SpeedBoost { get; } = new Ability("Speed Boost")
        {
            Description = "Raises Speed one stage after each turn."
        };

        public static Ability Stamina { get; } = new Ability(nameof(Stamina))
        {
            Description = "The Pokemon's Defense goes up by 1 stage when it's hit by an attack."
        };

        public static Ability Static { get; } = new Ability(nameof(Static))
        {
            Description = "Has a 30% chance of paralyzing attacking Pokemon on contact."
        };

        public static Ability Steadfast { get; } = new Ability(nameof(Steadfast))
        {
            Description = "Boots the Speed stat each time the Pokemon flinches."
        };

        public static Ability Steelworker { get; } = new Ability(nameof(Steelworker))
        {
            Description = "Powers up Steel type moves by 50%."
        };

        public static Ability Stench { get; } = new Ability(nameof(Stench))
        {
            Description = "Has a 10% chance of making target Pokemon flinch with each hit."
        };

        public static Ability StrongJaws { get; } = new Ability("Strong Jaws")
        {
            Description = "Strengthens biting moves to 1.5x their power."
        };

        // TODO: Protects against One-Hit KO moves regardless of HP
        public static Ability Sturdy { get; } = new Ability(nameof(Sturdy))
        {
            Description = "Prevents being KOed from full HP, leaving 1 HP instead."
        };

        public static Ability SuperLuck { get; } = new Ability("Super Luck")
        {
            Description = "Raises moves' critical hit rates one stage."
        };

        public static PinchAbility Swarm { get; } = new PinchAbility(nameof(Swarm), Types.Bug);

        public static Ability SwiftSwim { get; } = new Ability("Swift Swim")
        {
            Description = "Doubles Speed during rain."
        };

        public static Ability Synchronize { get; } = new Ability(nameof(Synchronize))
        {
            Description = "Copies burn, paralysis and poison received onto the Pokemon that inflicted them."
        };

        public static Ability TangledFeet { get; } = new Ability("Tangled Feet")
        {
            Description = "Doubles evasion when confused."
        };

        public static Ability TanglingHair { get; } = new Ability("Tangling Hair")
        {
            Description = "Lowers attacking Pokemon's Speed by one stage on contact."
        };

        public static Ability Technician { get; } = new Ability(nameof(Technician))
        {
            Description = "Strengthens moves of 60 base power or less to 1.5x their power."
        };

        public static Ability Telepathy { get; } = new Ability(nameof(Telepathy))
        {
            Description = "Anticipates an ally's attack and dodges it."
        };

        public static Ability ThickFat { get; } = new Ability("Thick Fat")
        {
            Description = "Halves damage from fire and ice moves."
        };

        public static Ability TintedLens { get; } = new Ability("Tinted Lens")
        {
            Description = "Doubles damage inflicted with not very effective moves."
        };
        
        public static PinchAbility Torrent { get; } = new PinchAbility(nameof(Torrent), Types.Water);

        public static Ability ToughClaws { get; } = new Ability("Tough Claws")
        {
            Description = "Strengthens moves that make conact to 1.33x their power."
        };

        public static Ability ToxicBoost { get; } = new Ability("Toxic Boost")
        {
            Description = "Increases Attack to 1.5x when poisoned."
        };

        public static Ability VitalSpirit { get; } = new Ability("Vital Spirit")
        {
            Description = "Prevents sleep."
        };

        public static Ability VoltAbsorb { get; } = new Ability("Volt Absorb")
        {
            Description = "Absorbs electric moves, healing for 1/4 max HP."
        };

        public static Ability WaterAbsorb { get; } = new Ability("Water Absorb")
        {
            Description = "Absorbs water moves, healing for 1/4 max HP."
        };

        public static Ability WaterBubble { get; } = new Ability("Water Bubble")
        {
            Description = "Halves the damage dealt to the Pokémon with this Ability by Fire-type attacks and doubles the power of Water-type moves used by the Pokémon with this Ability. It also prevents the Pokémon with the Ability from being burned."
        };

        public static Ability WaterCompaction { get; } = new Ability("Water Compaction")
        {
            Description = "The Pokemon's Defense stat will go up by 2 if it is hit with a Water-type move."
        };

        public static Ability WaterVeil { get; } = new Ability("Water Veil")
        {
            Description = "Prevents burns."
        };

        public static Ability WeakArmor { get; } = new Ability("Weak Armor")
        {
            Description = "Raises Speed and lowers Defense by one stage each upon being hit by a physical move."
        };

        public static Ability WhiteSmoke { get; } = new Ability("White Smoke")
        {
            Description = "Prevents stats from being lowered by other Pokemon."
        };

        public static Ability WonderSkin { get; } = new Ability("Wonder Skin")
        {
            Description = "Lowers incoming non-damaging moves' base accuracy to exactly 50%."
        };
    }
}
