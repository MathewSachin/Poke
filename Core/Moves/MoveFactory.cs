namespace Poke
{
    public partial class MoveInfo
    {
        const string RegularDamage = "Inflicts regular damage.";
        const string IncPriority = "Has increased priority.";
        const string HalfDrain = "Drains half the damage inflicted to heal the user.";
        const string AlwaysHit = "Ignores accuracy and evasion modifiers.";
        const string CriticalMore = "User's critical hit ratio is one level higher when using this move.";
        const string RechargeRequired = "The user can't move on the next turn";
        const string HitsAdjacent = "Hits adjacent Pokemon.";
        const string HitsAdjacentFoes = "Hits adjacent foes.";
        const string ThawFrozen = "Frozen Pokeon may use this move, in which case they will thaw.";

        public static MoveInfo Absorb { get; } = new MoveInfo(nameof(Absorb), Types.Grass, MoveKind.Special, 20, 100, 25)
        {
            Drain = 0.5,
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {HalfDrain}"
        };

        public static MoveInfo Accelerock { get; } = new MoveInfo(nameof(Accelerock), Types.Rock, MoveKind.Physical, 40, 100, 20)
        {
            Priority = 1,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo Acid { get; } = new MoveInfo(nameof(Acid), Types.Poison, MoveKind.Special, 40, 100, 30)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 10% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo AcidSpray { get; } = new MoveInfo("Acid Spray", Types.Poison, MoveKind.Special, 40, 100, 20)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, Self: false, StageChange: -2) },
            Description = $"{RegularDamage} Lowers the target Special Defense by two stages."
        };

        public static MoveInfo Acrobatics { get; } = new MoveInfo(nameof(Acrobatics), Types.Flying, MoveKind.Physical, 55, 100, 15)
        {
            PowerFunction = (A, M, O, B) => (A.HeldItem == null ? 2 : 1) * M.Info.Power
        };

        public static MoveInfo AerialAce { get; } = new MoveInfo("Aerial Ace", Types.Flying, MoveKind.Physical, 60, null, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {AlwaysHit}"
        };

        public static MoveInfo Aeroblast { get; } = new MoveInfo(nameof(Aeroblast), Types.Flying, MoveKind.Special, 100, 95, 5)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo AirCutter { get; } = new MoveInfo("Air Cutter", Types.Flying, MoveKind.Special, 60, 95, 25)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {HitsAdjacentFoes} {CriticalMore}"
        };

        public static MoveInfo AirSlash { get; } = new MoveInfo("Air Slash", Types.Flying, MoveKind.Special, 75, 95, 15)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo AquaJet { get; } = new MoveInfo("Aqua Jet", Types.Water, MoveKind.Physical, 40, 100, 20)
        {
            Priority = 1,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo AquaTail { get; } = new MoveInfo("Aqua Tail", Types.Water, MoveKind.Physical, 90, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cute,
            Description = RegularDamage
        };

        public static MoveInfo Astonish { get; } = new MoveInfo(nameof(Astonish), Types.Ghost, MoveKind.Physical, 30, 100, 15)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo AttackOrder { get; } = new MoveInfo("Attack Order", Types.Bug, MoveKind.Physical, 90, 100, 15)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo AuraSphere { get; } = new MoveInfo("Aura Sphere", Types.Fighting, MoveKind.Special, 80, null, 20)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Pulse | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {AlwaysHit}"
        };

        public static MoveInfo AuroraBeam { get; } = new MoveInfo("Aurora Beam", Types.Ice, MoveKind.Special, 65, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Attack, 0.1, false, -1) },
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 30% chance to lower the target's Attack by one stage."
        };

        public static MoveInfo Bite { get; } = new MoveInfo(nameof(Bite), Types.Dark, MoveKind.Physical, 60, 100, 25)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo BlastBurn { get; } = new MoveInfo("Blast Burn", Types.Fire, MoveKind.Special, 150, 90, 5)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo BlazeKick { get; } = new MoveInfo("Blaze Kick", Types.Fire, MoveKind.Physical, 85, 90, 10)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {CriticalMore} Has a 10% chance to burn the target."
        };

        // TODO: (100-Accuracy)% chance of breaking through protect and detect
        public static MoveInfo Blizzard { get; } = new MoveInfo(nameof(Blizzard), Types.Ice, MoveKind.Special, 110, 70, 5)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Freeze, 0.1),
            Target = MoveTarget.AllAdjacentFoes,
            AccuracyFunction = (A, M, O, B) => B.SuppressWeather == 0 && B.Weather == Weather.Hail ? 100 : M.Info.Accuracy,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 10% chance to freeze the target. During hail, this move has 100% accuracy."
        };

        public static MoveInfo BlueFlare { get; } = new MoveInfo("Blue Flare", Types.Fire, MoveKind.Special, 130, 85, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.2),
            Description = $"{RegularDamage} Has a 20% chance to burn the target."
        };

        public static MoveInfo BodySlam { get; } = new MoveInfo("Body Slam", Types.Normal, MoveKind.Physical, 85, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 30% chance to paralyze the target."
        };

        public static MoveInfo BoltStrike { get; } = new MoveInfo("Bolt Strike", Types.Electric, MoveKind.Physical, 130, 85, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.2),
            Description = $"{RegularDamage} Has a 20% chance to paralyze the target."
        };

        public static MoveInfo BoneClub { get; } = new MoveInfo("Bone Club", Types.Ground, MoveKind.Physical, 65, 85, 20)
        {
            Flinch = 0.1,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 10% chance to make the target flinch."
        };

        public static MoveInfo Boomburst { get; } = new MoveInfo(nameof(Boomburst), Types.Normal, MoveKind.Special, 140, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic,
            Description = $"{RegularDamage} {HitsAdjacent}",
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo BraveBird { get; } = new MoveInfo("Brave Bird", Types.Flying, MoveKind.Physical, 120, 100, 15)
        {
            Recoil = 1.0 / 3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cute,
            Description = $"{RegularDamage}. User takes 1/3 the damage it inflicts in recoil."
        };

        // TODO: Can break barriers like Light Screen, Reflect, Auroraveil
        public static MoveInfo BrickBreak { get; } = new MoveInfo("Brick Break", Types.Fighting, MoveKind.Physical, 75, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = "Destroys any light screen or reflect on the target's side of the field, then inflicts regular damage."
        };

        public static MoveInfo Brine { get; } = new MoveInfo(nameof(Brine), Types.Water, MoveKind.Special, 65, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} If the target has less than half of its max HP remaining, this move has double power.",
            PowerFunction = (A, M, O, B) => (O.Stats.CurrentHP < O.Stats.MaxHP / 2 ? 2 : 1) * M.Info.Power
        };

        public static MoveInfo BrutalSwing { get; } = new MoveInfo("Brutal Swing", Types.Dark, MoveKind.Physical, 60, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {HitsAdjacent}",
            Target = MoveTarget.AllAdjacent
        };
        
        public static MoveInfo Bubble { get; } = new MoveInfo(nameof(Bubble), Types.Water, MoveKind.Special, 40, 100, 30)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, 0.1, false, -1) },
            ContestCategory = ContestCategory.Cute,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 10% chance to lower the target's Speed by one stage."
        };

        public static MoveInfo BubbleBeam { get; } = new MoveInfo("Bubble Beam", Types.Water, MoveKind.Special, 65, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, 0.1, false, -1) },
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Speed by one stage."
        };

        public static MoveInfo BugBuzz { get; } = new MoveInfo("Bug Buzz", Types.Bug, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Cute,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo Bulldoze { get; } = new MoveInfo(nameof(Bulldoze), Types.Ground, MoveKind.Physical, 60, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} {HitsAdjacent} Lowers the target's Speed by one stage.",
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo BulletPunch { get; } = new MoveInfo("Bullet Punch", Types.Steel, MoveKind.Physical, 40, 100, 30)
        {
            Priority = 1,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            ContestCategory = ContestCategory.Smart,
            Description = RegularDamage
        };

        public static MoveInfo ChargeBeam { get; } = new MoveInfo("Charge Beam", Types.Electric, MoveKind.Special, 50, 90, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, 0.7, true, 1) },
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 70% chance to raise the user's Special Attack by one stage."
        };

        public static MoveInfo ClangingScales { get; } = new MoveInfo("Clanging Scales", Types.Dragon, MoveKind.Special, 110, 100, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic,
            PostStatChanges = { new StatChange(Stats.Defense, StageChange: -1) },
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Lowers the user's Defense stat by one stage."
        };

        public static MoveInfo CloseCombat { get; } = new MoveInfo("Close Combat", Types.Fighting, MoveKind.Physical, 120, 100, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges =
            {
                new StatChange(Stats.Defense, StageChange: -1),
                new StatChange(Stats.SpecialDefense, StageChange: -1)
            },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Lowers the user's Defense and Special Defense by one stage each."
        };

        public static MoveInfo Confusion { get; } = new MoveInfo(nameof(Confusion), Types.Psychic, MoveKind.Special, 50, 100, 25)
        {
            ConfuseTarget = 0.1
        };

        public static MoveInfo Constrict { get; } = new MoveInfo(nameof(Constrict), Types.Normal, MoveKind.Physical, 10, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, 0.1, false, -1) },
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Speed by one stage."
        };

        public static MoveInfo Crabhammer { get; } = new MoveInfo(nameof(Crabhammer), Types.Water, MoveKind.Physical, 100, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo CrossChop { get; } = new MoveInfo("Cross Chop", Types.Fighting, MoveKind.Physical, 100, 80, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo CrossPoison { get; } = new MoveInfo("Cross Poison", Types.Poison, MoveKind.Physical, 70, 100, 20)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.1),
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {CriticalMore} Has a 10% chance to poison the target."
        };

        public static MoveInfo Crunch { get; } = new MoveInfo(nameof(Crunch), Types.Dark, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.2, false, -1) },
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 20% chance to lower the target's Defense by one stage."
        };

        public static MoveInfo CrushClaw { get; } = new MoveInfo("Crush Claw", Types.Normal, MoveKind.Physical, 75, 95, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.5, false, -1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 50% chance to lower the target's Defense by one stage."
        };

        public static MoveInfo Cut { get; } = new MoveInfo(nameof(Cut), Types.Normal, MoveKind.Physical, 50, 95, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };
        
        public static MoveInfo DarkPulse { get; } = new MoveInfo("Dark Pulse", Types.Dark, MoveKind.Special, 80, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Pulse | MoveFlags.Mirror | MoveFlags.Distance,
            Flinch = 0.2,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 20% chance to make the target flinch."
        };

        public static MoveInfo DazzlingGleam { get; } = new MoveInfo("Dazzling Gleam", Types.Fairy, MoveKind.Special, 80, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {HitsAdjacentFoes}",
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo DiamondStorm { get; } = new MoveInfo("Diamond Storm", Types.Rock, MoveKind.Physical, 100, 95, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.5, true, 1) },
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 30% chance to raise the user's Defense one stage.",
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo DisarmingVoice { get; } = new MoveInfo("Disarming Voice", Types.Fairy, MoveKind.Special, 40, null, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic,
            Description = $"{RegularDamage} {HitsAdjacentFoes} {AlwaysHit}",
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo Discharge { get; } = new MoveInfo(nameof(Discharge), Types.Electric, MoveKind.Special, 80, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {HitsAdjacent} Has a 30% chance to paralyze the target.",
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo DizzyPunch { get; } = new MoveInfo("Dizzy Punch", Types.Normal, MoveKind.Physical, 70, 100, 10)
        {
            ConfuseTarget = 0.2
        };

        public static MoveInfo DoubleEdge { get; } = new MoveInfo("Double-Edge", Types.Normal, MoveKind.Physical, 120, 100, 15)
        {
            Recoil = 1.0 / 3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} User takes 1/3 damage it inflicts in recoil."
        };

        public static MoveInfo DracoMeteor { get; } = new MoveInfo("Draco Meteor", Types.Dragon, MoveKind.Special, 130, 90, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Lowers the user's Special Attack by two stages."
        };

        public static MoveInfo DragonAscent { get; } = new MoveInfo("Dragon Ascent", Types.Flying, MoveKind.Physical, 120, 100, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            PostStatChanges =
            {
                new StatChange(Stats.Defense, StageChange: -1),
                new StatChange(Stats.SpecialDefense, StageChange: -1)
            },
            Description = $"{RegularDamage} Lowers the user's Defense and Special Defense by one stage each."
        };
        
        public static MoveInfo DragonBreath { get; } = new MoveInfo("Dragon Breath", Types.Dragon, MoveKind.Special, 60, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            Description = $"{RegularDamage} Has a 30% chance to paralyze the target."
        };

        public static MoveInfo DragonClaw { get; } = new MoveInfo("Dragon Claw", Types.Dragon, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo DragonHammer { get; } = new MoveInfo("Dragon Hammer", Types.Dragon, MoveKind.Physical, 90, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo DragonPulse { get; } = new MoveInfo("Dragon Pulse", Types.Dragon, MoveKind.Special, 85, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Pulse | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Smart,
            Description = RegularDamage
        };

        // TODO: double damage and no accuracy check if target used Minimize
        public static MoveInfo DragonRush { get; } = new MoveInfo("Dragon Rush", Types.Dragon, MoveKind.Physical, 100, 75, 10)
        {
            Flinch = 0.2,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 20% chance to make the target flinch."
        };

        public static MoveInfo DrainingKiss { get; } = new MoveInfo("Draining Kiss", Types.Fairy, MoveKind.Special, 50, 100, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            Drain = 0.75,
            Description = $"{RegularDamage} Drains 75% of the damage inflicted to heal the user."
        };

        public static MoveInfo DrainPunch { get; } = new MoveInfo("Drain Punch", Types.Fighting, MoveKind.Physical, 75, 100, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch | MoveFlags.Heal,
            Drain = 0.5,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Drains half of the damage inflicted to heal the user."
        };

        public static MoveInfo DrillPeck { get; } = new MoveInfo("Drill Peck", Types.Flying, MoveKind.Physical, 80, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo DrillRun { get; } = new MoveInfo("Drill Run", Types.Ground, MoveKind.Physical, 80, 90, 10)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo DynamicPunch { get; } = new MoveInfo("Dynamic Punch", Types.Fighting, MoveKind.Physical, 100, 50, 5)
        {
            ConfuseTarget = 1
        };

        public static MoveInfo EarthPower { get; } = new MoveInfo("Earth Power", Types.Ground, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };
        
        // TODO: Double power if target is in the first turn of dig
        public static MoveInfo Earthquake { get; } = new MoveInfo(nameof(Earthquake), Types.Ground, MoveKind.Physical, 100, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {HitsAdjacent}",
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo EggBomb { get; } = new MoveInfo("Egg Bomb", Types.Normal, MoveKind.Physical, 100, 75, 10)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = RegularDamage
        };

        public static MoveInfo ElectroBall { get; } = new MoveInfo("Electro Ball", Types.Electric, MoveKind.Special, null, 100, 10)
        {
            PowerFunction = (A, M, O, B) =>
            {
                // TODO: Consider Trick Room

                var aSpeed = A.GetEffectiveSpeed(B);
                var oSpeed = O.GetEffectiveSpeed(B);

                if (aSpeed > 4 * oSpeed)
                    return 150;

                if (aSpeed > 3 * oSpeed)
                    return 120;

                if (aSpeed > 2 * oSpeed)
                    return 80;

                return 60;
            }
        };

        public static MoveInfo Electroweb { get; } = new MoveInfo(nameof(Electroweb), Types.Electric, MoveKind.Special, 55, 95, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} {HitsAdjacentFoes} Lower's the target's Speed by one stage.",
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo Ember { get; } = new MoveInfo(nameof(Ember), Types.Fire, MoveKind.Special, 40, 100, 25)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target."
        };
        
        public static MoveInfo EnergyBall { get; } = new MoveInfo("Energy Ball", Types.Grass, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo Eruption { get; } = new MoveInfo(nameof(Eruption), Types.Fire, MoveKind.Special, 150, 100, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Power increases with user's remaining HP with a maximum of 150 at full HP.",
            PowerFunction = (A, M, O, B) => M.Info.Power * A.Stats.CurrentHP / A.Stats.MaxHP,
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo Extrasensory { get; } = new MoveInfo(nameof(Extrasensory), Types.Psychic, MoveKind.Special, 80, 100, 20)
        {
            Flinch = 0.1,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 10% chance to make the target flinch."
        };

        public static MoveInfo ExtremeSpeed { get; } = new MoveInfo("Extreme Speed", Types.Normal, MoveKind.Physical, 80, 100, 5)
        {
            Priority = 2,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo FairyWind { get; } = new MoveInfo("Fairy Wind", Types.Fairy, MoveKind.Special, 40, 100, 30)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo FeintAttack { get; } = new MoveInfo("Feint Attack", Types.Dark, MoveKind.Physical, 60, null, 20)
        {
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {AlwaysHit}"
        };
        
        public static MoveInfo FieryDance { get; } = new MoveInfo("Fiery Dance", Types.Fire, MoveKind.Special, 80, 100, 10)
        {
            PostStatChanges = { new StatChange(Stats.SpecialAttack, 0.5, StageChange: 1) },
            Description = $"{RegularDamage} Has a 50% chance to raise the user's Special Attack by one stage."
        };

        public static MoveInfo FireBlast { get; } = new MoveInfo("Fire Blast", Types.Fire, MoveKind.Special, 110, 85, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target."
        };

        public static MoveInfo FireFang { get; } = new MoveInfo("Fire Fang", Types.Fire, MoveKind.Physical, 65, 95, 15)
        {
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            Flinch = 0.1,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target and a separate 10% chance to make the target flinch."
        };

        public static MoveInfo FireLash { get; } = new MoveInfo("Fire Lash", Types.Fire, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} Lowers the target's Defense stat by one."
        };

        public static MoveInfo FirePunch { get; } = new MoveInfo("Fire Punch", Types.Fire, MoveKind.Physical, 75, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target."
        };

        public static MoveInfo FlameCharge { get; } = new MoveInfo("Flame Charge", Types.Fire, MoveKind.Physical, 50, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: 1) },
            Description = $"{RegularDamage} Raises the user's Speed by one stage."
        };

        public static MoveInfo FlameWheel { get; } = new MoveInfo("Flame Wheel", Types.Fire, MoveKind.Physical, 60, 100, 25)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Defrost,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target. Frozen Pokemon may use this move, in which case they will thaw."
        };

        public static MoveInfo Flamethrower { get; } = new MoveInfo(nameof(Flamethrower), Types.Fire, MoveKind.Special, 90, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to burn the target."
        };

        public static MoveInfo FlareBlitz { get; } = new MoveInfo("Flare Blitz", Types.Fire, MoveKind.Physical, 120, 100, 15)
        {
            Recoil = 1.0 / 3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Defrost,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Use takes 1/3 the damage it inflicts in recoil. Has a 10% chance to burn the target. Frozen Pokemon may use this move, in which case they will thaw."
        };

        public static MoveInfo FlashCannon { get; } = new MoveInfo("Flash Cannon", Types.Steel, MoveKind.Special, 80, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };
        
        public static MoveInfo FleurCannon { get; } = new MoveInfo("Fleur Cannon", Types.Fairy, MoveKind.Special, 130, 90, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2) },
            Description = $"{RegularDamage} Lowers the user's Special Attack by two stages."
        };

        public static MoveInfo FocusBlast { get; } = new MoveInfo("Focus Blast", Types.Fighting, MoveKind.Special, 120, 70, 5)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo ForcePalm { get; } = new MoveInfo("Force Palm", Types.Fighting, MoveKind.Physical, 60, 100, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 30% chance to paralyze the target."
        };

        public static MoveInfo FrenzyPlant { get; } = new MoveInfo("Frenzy Plant", Types.Grass, MoveKind.Special, 150, 90, 5)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo FrostBreath { get; } = new MoveInfo("Frost Breath", Types.Ice, MoveKind.Special, 60, 90, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.Always,
            Description = $"{RegularDamage} Always scores a critical hit."
        };

        public static MoveInfo GigaDrain { get; } = new MoveInfo("Giga Drain", Types.Grass, MoveKind.Special, 75, 100, 10)
        {
            Drain = 0.5,
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Drains half the damage inflicted to heal the user."
        };

        public static MoveInfo GigaImpact { get; } = new MoveInfo("Giga Impact", Types.Normal, MoveKind.Physical, 150, 90, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo Glaciate { get; } = new MoveInfo(nameof(Glaciate), Types.Ice, MoveKind.Special, 65, 95, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} {HitsAdjacentFoes} Lowers the target's Speed by one stage.",
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo GunkShot { get; } = new MoveInfo("Gunk Shot", Types.Poison, MoveKind.Physical, 120, 80, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.3),
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 30% chance to poison the target."
        };

        // TODO: Double power if target is in first turn of bounce, fly or sky drop
        public static MoveInfo Gust { get; } = new MoveInfo(nameof(Gust), Types.Flying, MoveKind.Special, 40, 100, 35)
        {
            ContestCategory = ContestCategory.Smart
        };

        public static MoveInfo HammerArm { get; } = new MoveInfo("Hammer Arm", Types.Fighting, MoveKind.Physical, 100, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Lowers the user's Speed by one stage."
        };

        public static MoveInfo Headbutt { get; } = new MoveInfo(nameof(Headbutt), Types.Normal, MoveKind.Physical, 70, 100, 15)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo HeadCharge { get; } = new MoveInfo("Head Charge", Types.Normal, MoveKind.Physical, 120, 100, 15)
        {
            Recoil = 0.25,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} User takes 1/4 the damage it inflicts in recoil."
        };

        public static MoveInfo HeadSmash { get; } = new MoveInfo("Head Smash", Types.Rock, MoveKind.Physical, 150, 80, 5)
        {
            Recoil = 0.5,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} User takes 1/2 the damage it inflicts in recoil."
        };

        public static MoveInfo HeartStamp { get; } = new MoveInfo("Heart Stamp", Types.Psychic, MoveKind.Physical, 60, 100, 25)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo HeatWave { get; } = new MoveInfo("Heat Wave", Types.Fire, MoveKind.Special, 95, 90, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 10% chance to burn the target."
        };

        // TODO: Update Flags
        public static MoveInfo Hex { get; } = new MoveInfo(nameof(Hex), Types.Ghost, MoveKind.Special, 65, 100, 10)
        {
            PowerFunction = (A, M, O, B) => (O.NonVolatileStatus != Poke.NonVolatileStatus.None ? 2 : 1) * M.Info.Power,
            Description = $"{RegularDamage} If the target has a major status ailment, this move has double power."
        };

        public static MoveInfo HighHorsepower { get; } = new MoveInfo("High Horsepower", Types.Ground, MoveKind.Physical, 95, 95, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo HornAttack { get; } = new MoveInfo("Horn Attack", Types.Normal, MoveKind.Physical, 65, 100, 25)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo HornLeech { get; } = new MoveInfo("Horn Leech", Types.Grass, MoveKind.Physical, 75, 100, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            Drain = 0.5,
            Description = $"{RegularDamage} Drains half of the damage inflicted to heal the user."
        };

        // TODO: Can hit pokemon under the effect of bounce, fly or sky drop
        public static MoveInfo Hurricane { get; } = new MoveInfo(nameof(Hurricane), Types.Flying, MoveKind.Special, 110, 70, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ConfuseTarget = 0.3,
            AccuracyFunction = (A, M, O, B) =>
            {
                if (B.SuppressWeather != 0)
                    return M.Info.Accuracy;

                switch (B.Weather)
                {
                    case Weather.Rain:
                    case Weather.HeavyRain:
                        return 100;

                    case Weather.HarshSunlight:
                    case Weather.ExtremelyHarshSunlight:
                        return 50;

                    default:
                        return M.Info.Accuracy;
                }
            }
        };

        public static MoveInfo HydroCannon { get; } = new MoveInfo("Hydro Cannon", Types.Water, MoveKind.Special, 150, 90, 5)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo HydroPump { get; } = new MoveInfo("Hydro Pump", Types.Water, MoveKind.Special, 110, 80, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = RegularDamage
        };

        public static MoveInfo HyperBeam { get; } = new MoveInfo("Hyper Beam", Types.Normal, MoveKind.Special, 150, 90, 5)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo HyperFang { get; } = new MoveInfo("Hyper Fang", Types.Normal, MoveKind.Physical, 80, 90, 15)
        {
            Flinch = 0.1,
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 10% chance to make the target flinch."
        };

        public static MoveInfo HyperVoice { get; } = new MoveInfo("Hyper Voice", Types.Normal, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic,
            ContestCategory = ContestCategory.Cool,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes}"
        };

        public static MoveInfo IceBeam { get; } = new MoveInfo("Ice Beam", Types.Ice, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Freeze, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to freeze the target."
        };

        public static MoveInfo IceFang { get; } = new MoveInfo("Ice Fang", Types.Ice, MoveKind.Physical, 65, 95, 15)
        {
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Freeze, 0.1),
            Flinch = 0.1,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 10% chance to freeze the target and a separate 10% chance to make the target flinch."
        };

        public static MoveInfo IceHammer { get; } = new MoveInfo("Ice Hammer", Types.Ice, MoveKind.Physical, 100, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1) },
            Description = $"{RegularDamage} Lower's the user's Speed by one stage."
        };

        public static MoveInfo IcePunch { get; } = new MoveInfo("Ice Punch", Types.Ice, MoveKind.Physical, 75, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Freeze, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Has a 10% chance to freeze the target."
        };

        public static MoveInfo IceShard { get; } = new MoveInfo("Ice Shard", Types.Ice, MoveKind.Physical, 40, 100, 30)
        {
            Priority = 1,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo IcicleCrash { get; } = new MoveInfo("Icicle Crash", Types.Ice, MoveKind.Physical, 85, 90, 10)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo IcyWind { get; } = new MoveInfo("Icy Wind", Types.Ice, MoveKind.Special, 55, 95, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            ContestCategory = ContestCategory.Beauty,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Lowers the target's Speed by one stage."
        };

        public static MoveInfo Inferno { get; } = new MoveInfo(nameof(Inferno), Types.Fire, MoveKind.Special, 100, 50, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn),
            Description = $"{RegularDamage} Burns the target."
        };

        public static MoveInfo IronHead { get; } = new MoveInfo("Iron Head", Types.Steel, MoveKind.Physical, 80, 100, 15)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo IronTail { get; } = new MoveInfo("Iron Tail", Types.Steel, MoveKind.Physical, 100, 75, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.3, false, -1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 30% chance to lower the target's Defense by one stage."
        };

        public static MoveInfo KarateChop { get; } = new MoveInfo("Karate Chop", Types.Fighting, MoveKind.Physical, 50, 100, 25)
        {
            CriticalHit = CriticalHit.OneHigher,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} {CriticalMore}"
        };
        
        public static MoveInfo LandsWrath { get; } = new MoveInfo("Land's Wrath", Types.Ground, MoveKind.Physical, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes}"
        };

        public static MoveInfo LavaPlume { get; } = new MoveInfo("Lava Plume", Types.Fire, MoveKind.Special, 80, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.3),
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} {HitsAdjacent} Has a 30% chance to burn the targets.",
            Target = MoveTarget.AllAdjacent
        };
        
        public static MoveInfo LeafBlade { get; } = new MoveInfo("Leaf Blade", Types.Grass, MoveKind.Physical, 90, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo Leafage { get; } = new MoveInfo(nameof(Leafage), Types.Grass, MoveKind.Physical, 40, 100, 40)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo LeafStorm { get; } = new MoveInfo("Leaf Storm", Types.Grass, MoveKind.Special, 130, 90, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2) },
            ContestCategory = ContestCategory.Cute,
            Description = $"{RegularDamage} Lowers the user's Special Attack by two stages."
        };

        public static MoveInfo LeafTornado { get; } = new MoveInfo("Leaf Tornado", Types.Grass, MoveKind.Special, 65, 90, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.5, false, -1) },
            Description = $"{RegularDamage} Has a 50% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo LeechLife { get; } = new MoveInfo("Leech Life", Types.Grass, MoveKind.Physical, 20, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            Drain = 0.5,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {HalfDrain}"
        };

        public static MoveInfo Lick { get; } = new MoveInfo(nameof(Lick), Types.Ghost, MoveKind.Physical, 30, 100, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 30% chance to paralyze the target."
        };

        public static MoveInfo LightOfRuin { get; } = new MoveInfo("Light of Ruin", Types.Fairy, MoveKind.Special, 140, 90, 5)
        {
            Recoil = 0.5,
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} User takes 1/2 the damage it inflicts in recoil."
        };

        public static MoveInfo Liquidation { get; } = new MoveInfo(nameof(Liquidation), Types.Water, MoveKind.Physical, 85, 100, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.2, false, -1) },
            Description = $"{RegularDamage} Has a 20% chance of lowering the target's Defense by one stage."
        };

        public static MoveInfo LowSweep { get; } = new MoveInfo("Low Sweep", Types.Fighting, MoveKind.Physical, 65, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} Lowers the target's Speed by one stage."
        };

        public static MoveInfo Lunge { get; } = new MoveInfo(nameof(Lunge), Types.Bug, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} Lowers the target's Attack by one stage."
        };

        public static MoveInfo LusterPurge { get; } = new MoveInfo("Luster Purge", Types.Psychic, MoveKind.Special, 70, 100, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.5, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 50% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo MachPunch { get; } = new MoveInfo("Mach Punch", Types.Fighting, MoveKind.Physical, 40, 100, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            Priority = 1,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo MagicalLeaf { get; } = new MoveInfo("Magical Leaf", Types.Grass, MoveKind.Special, 60, null, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {AlwaysHit}"
        };

        public static MoveInfo MagnetBomb { get; } = new MoveInfo("Magnet Bomb", Types.Steel, MoveKind.Physical, 60, null, 20)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {AlwaysHit}"
        };

        public static MoveInfo MegaDrain { get; } = new MoveInfo("Mega Drain", Types.Grass, MoveKind.Special, 40, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            Drain = 0.5,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {HalfDrain}"
        };

        public static MoveInfo Megahorn { get; } = new MoveInfo(nameof(Megahorn), Types.Bug, MoveKind.Physical, 120, 85, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo MegaKick { get; } = new MoveInfo("Mega Kick", Types.Normal, MoveKind.Physical, 120, 75, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo MegaPunch { get; } = new MoveInfo("Mega Punch", Types.Normal, MoveKind.Physical, 80, 85, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            ContestCategory = ContestCategory.Tough,
            Description = RegularDamage
        };

        public static MoveInfo MetalClaw { get; } = new MoveInfo("Metal Claw", Types.Steel, MoveKind.Physical, 50, 95, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Attack, 0.1, true, 1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 10% chance to raise the user's Attack by one stage."
        };

        public static MoveInfo MeteorMash { get; } = new MoveInfo("Meteor Mash", Types.Steel, MoveKind.Physical, 90, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            PostStatChanges = { new StatChange(Stats.Attack, 0.2, true, 1) },
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} Has a 20% chance to raise the user's Attack by one stage."
        };

        public static MoveInfo MirrorShot { get; } = new MoveInfo("Mirror Shot", Types.Steel, MoveKind.Special, 65, 85, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.3, false, -1) },
            ContestCategory = ContestCategory.Cute,
            Description = $"{RegularDamage} Has a 30% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo MistBall { get; } = new MoveInfo("Mist Ball", Types.Psychic, MoveKind.Special, 70, 100, 5)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, 0.5, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 50% chance to lower the target's Special Attack by one stage."
        };

        public static MoveInfo Moonblast { get; } = new MoveInfo(nameof(Moonblast), Types.Fairy, MoveKind.Special, 95, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, 0.3, false, -1) },
            Description = $"{RegularDamage} Has a 30% chance to lower the target's Special Attack by one stage."
        };

        public static MoveInfo MudBomb { get; } = new MoveInfo("Mud Bomb", Types.Ground, MoveKind.Special, 65, 85, 10)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.3, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 30% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo MudShot { get; } = new MoveInfo("Mud Shot", Types.Ground, MoveKind.Special, 55, 95, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Lowers the target's Speed by one stage."
        };

        public static MoveInfo MudSlap { get; } = new MoveInfo("Mud-Slap", Types.Ground, MoveKind.Special, 20, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, StageChange: -1, Self: false) },
            ContestCategory = ContestCategory.Cute,
            Description = $"{RegularDamage} Lowers the target's accuracy by one stage."
        };

        public static MoveInfo MuddyWater { get; } = new MoveInfo("Muddy Water", Types.Water, MoveKind.Special, 90, 85, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.3, false, -1) },
            ContestCategory = ContestCategory.Tough,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 30% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo MysticalFire { get; } = new MoveInfo("Mystical Fire", Types.Fire, MoveKind.Special, 65, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -1, Self: false) },
            Description = $"{RegularDamage} Lowers the target's Special Attack by one stage."
        };

        public static MoveInfo NeedleArm { get; } = new MoveInfo("Needle Arm", Types.Grass, MoveKind.Physical, 60, 100, 15)
        {
            Flinch = 0.3,
            ContestCategory = ContestCategory.Smart,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} Has a 30% chance to make the target flinch."
        };

        public static MoveInfo NightDaze { get; } = new MoveInfo("Night Daze", Types.Dark, MoveKind.Special, 85, 95, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.4, false, -1) },
            Description = $"{RegularDamage} Has a 40% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo NightSlash { get; } = new MoveInfo("Night Slash", Types.Dark, MoveKind.Physical, 70, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo Nuzzle { get; } = new MoveInfo(nameof(Nuzzle), Types.Electric, MoveKind.Physical, 20, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis),
            Description = $"{RegularDamage} Paralyses the target."
        };

        public static MoveInfo OblivionWing { get; } = new MoveInfo("Oblivion Wing", Types.Flying, MoveKind.Special, 80, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance | MoveFlags.Heal,
            Drain = 0.75,
            Description = $"{RegularDamage} Drains 75% of the damage inflicted to heal the user."
        };

        public static MoveInfo Octazooka { get; } = new MoveInfo(nameof(Octazooka), Types.Water, MoveKind.Special, 65, 85, 10)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Accuracy, 0.5, false, -1) },
            ContestCategory = ContestCategory.Tough,
            Description = $"{RegularDamage} Has a 50% chance to lower the target's accuracy by one stage."
        };

        public static MoveInfo OriginPulse { get; } = new MoveInfo("Origin Pulse", Types.Water, MoveKind.Special, 110, 85, 10)
        {
            Flags = MoveFlags.Pulse | MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes}"
        };

        public static MoveInfo Overheat { get; } = new MoveInfo(nameof(Overheat), Types.Fire, MoveKind.Special, 130, 90, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2) },
            ContestCategory = ContestCategory.Beauty,
            Description = $"{RegularDamage} Lowers the user's Special Attack by two stages."
        };

        public static MoveInfo ParabolicCharge { get; } = new MoveInfo("Parabolic Charge", Types.Electric, MoveKind.Special, 50, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Heal,
            Drain = 0.5,
            Target = MoveTarget.AllAdjacent,
            Description = $"{RegularDamage} {HitsAdjacent} {HalfDrain}"
        };

        public static MoveInfo Peck { get; } = new MoveInfo(nameof(Peck), Types.Flying, MoveKind.Physical, 35, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance,
            ContestCategory = ContestCategory.Cool,
            Description = RegularDamage
        };

        public static MoveInfo PetalBlizzard { get; } = new MoveInfo("Petal Blizzard", Types.Grass, MoveKind.Physical, 90, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacent,
            Description = $"{RegularDamage} {HitsAdjacent}"
        };

        public static MoveInfo PlayRough { get; } = new MoveInfo("Play Rough", Types.Fairy, MoveKind.Physical, 90, 90, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Attack, 0.1, false, -1) },
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Attack by one stage."
        };

        public static MoveInfo PoisonFang { get; } = new MoveInfo("Poison Fang", Types.Poison, MoveKind.Physical, 50, 100, 15)
        {
            Flags = MoveFlags.Bite | MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.BadPoison, 0.5),
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 50% chance to badly poison the target."
        };

        public static MoveInfo PoisonJab { get; } = new MoveInfo("Poison Jab", Types.Poison, MoveKind.Physical, 80, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.3),
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 30% chance to poison the target."
        };

        public static MoveInfo PoisonSting { get; } = new MoveInfo("Poison Sting", Types.Poison, MoveKind.Physical, 15, 100, 35)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.3),
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 30% chance to poison the target."
        };

        public static MoveInfo PoisonTail { get; } = new MoveInfo("Poison Tail", Types.Poison, MoveKind.Physical, 50, 100, 25)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.1),
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} {CriticalMore} Has a 10% chance to poison the target."
        };

        public static MoveInfo Pound { get; } = new MoveInfo(nameof(Pound), Types.Normal, MoveKind.Physical, 40, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Tough,
            Description = RegularDamage
        };

        public static MoveInfo PowderSnow { get; } = new MoveInfo("Powder Snow", Types.Ice, MoveKind.Special, 40, 100, 25)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Freeze, 0.1),
            ContestCategory = ContestCategory.Beauty,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 10% chance to freeze the target."
        };
        
        public static MoveInfo PowerGem { get; } = new MoveInfo("Power Gem", Types.Rock, MoveKind.Special, 80, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = RegularDamage
        };

        public static MoveInfo PowerUpPunch { get; } = new MoveInfo("Power-Up Punch", Types.Fighting, MoveKind.Physical, 40, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: 1) },
            Description = $"{RegularDamage} Raises the user's Attack by one stage."
        };

        public static MoveInfo PowerWhip { get; } = new MoveInfo("Power Whip", Types.Grass, MoveKind.Physical, 120, 85, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Description = RegularDamage
        };

        public static MoveInfo PrecipiceBlades { get; } = new MoveInfo("Precipice Blades", Types.Ground, MoveKind.Physical, 120, 85, 10)
        {
            Flags = MoveFlags.NonSky | MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes}"
        };

        public static MoveInfo PrismaticLaser { get; } = new MoveInfo("Prismatic Laser", Types.Psychic, MoveKind.Special, 160, 100, 10)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo Psybeam { get; } = new MoveInfo(nameof(Psybeam), Types.Psychic, MoveKind.Special, 65, 100, 20)
        {
            ConfuseTarget = 0.1
        };

        public static MoveInfo Psychic { get; } = new MoveInfo(nameof(Psychic), Types.Psychic, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.1, false, -1) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Has a 10% chance to lower the target's Special Defense by one stage."
        };

        public static MoveInfo PsychoBoost { get; } = new MoveInfo("Psycho Boost", Types.Psychic, MoveKind.Special, 140, 90, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2) },
            ContestCategory = ContestCategory.Smart,
            Description = $"{RegularDamage} Lowers the user's Special Attack by two stages."
        };

        public static MoveInfo PsychoCut { get; } = new MoveInfo("Psycho Cut", Types.Psychic, MoveKind.Physical, 70, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {CriticalMore}"
        };

        public static MoveInfo QuickAttack { get; } = new MoveInfo("Quick Attack", Types.Normal, MoveKind.Physical, 40, 100, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Priority = 1,
            ContestCategory = ContestCategory.Cool,
            Description = $"{RegularDamage} {IncPriority}"
        };

        public static MoveInfo RazorLeaf { get; } = new MoveInfo("Razor Leaf", Types.Grass, MoveKind.Physical, 55, 95, 25)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Cool,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} {CriticalMore}"
        };

        public static MoveInfo RazorShell { get; } = new MoveInfo("Razor Shell", Types.Water, MoveKind.Physical, 75, 95, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.5, false, -1) },
            Description = $"{RegularDamage} Has a 50% chance to lower the target's Defense by one stage."
        };

        // TODO: Incorrect Implementation. Has a charging turn.
        public static MoveInfo RazorWind { get; } = new MoveInfo("Razor Wind", Types.Normal, MoveKind.Special, 80, 100, 10)
        {
            CriticalHit = CriticalHit.OneHigher,
            ContestCategory = ContestCategory.Cool,
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo RoarOfTime { get; } = new MoveInfo("Roar of Time", Types.Dragon, MoveKind.Special, 150, 90, 5)
        {
            Flags = MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo RockSlide { get; } = new MoveInfo("Rock Slide", Types.Rock, MoveKind.Physical, 75, 90, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Flinch = 0.3,
            ContestCategory = ContestCategory.Tough,
            Target = MoveTarget.AllAdjacentFoes,
            Description = $"{RegularDamage} {HitsAdjacentFoes} Has a 30% chance to make the target flinch."
        };
        
        public static MoveInfo RockSmash { get; } = new MoveInfo("Rock Smash", Types.Fighting, MoveKind.Physical, 40, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.5, false, -1) },
            Description = $"{RegularDamage} Has a 50% chance to lower the target's Defense by one stage."
        };

        public static MoveInfo RockThrow { get; } = new MoveInfo("Rock Throw", Types.Rock, MoveKind.Physical, 50, 90, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo RockTomb { get; } = new MoveInfo("Rock Tomb", Types.Rock, MoveKind.Physical, 60, 95, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Speed, 1, false, -1) },
            Description = $"{RegularDamage} Lowers the target's Speed by one stage."
        };

        public static MoveInfo RockWrecker { get; } = new MoveInfo("Rock Wrecker", Types.Rock, MoveKind.Physical, 150, 90, 5)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Recharge | MoveFlags.Protect | MoveFlags.Mirror,
            Description = $"{RegularDamage} {RechargeRequired}"
        };

        public static MoveInfo SacredFire { get; } = new MoveInfo("Sacred Fire", Types.Fire, MoveKind.Physical, 100, 95, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Defrost,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.5),
            Description = $"{RegularDamage} {ThawFrozen} Has a 50% chance to burn the target."
        };

        public static MoveInfo Scald { get; } = new MoveInfo(nameof(Scald), Types.Water, MoveKind.Special, 80, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Defrost,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.3),
            Description = $"{RegularDamage} Has a 30% chance to burn the target."
        };

        public static MoveInfo Scratch { get; } = new MoveInfo(nameof(Scratch), Types.Normal, MoveKind.Physical, 40, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo SearingShot { get; } = new MoveInfo("Searing Shot", Types.Fire, MoveKind.Special, 100, 100, 5)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.3),
            Target = MoveTarget.AllAdjacent,
            Description = $"{RegularDamage} {HitsAdjacent} Has a 30% chance to burn the target."
        };

        public static MoveInfo SeedBomb { get; } = new MoveInfo("Seed Bomb", Types.Grass, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            Description = RegularDamage
        };

        public static MoveInfo SeedFlare { get; } = new MoveInfo("Seed Flare", Types.Grass, MoveKind.Special, 120, 85, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.4, false, -2) }
        };
        
        public static MoveInfo ShadowBall { get; } = new MoveInfo("Shadow Ball", Types.Ghost, MoveKind.Special, 80, 100, 15)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.SpecialDefense, 0.2, false, -1) }
        };

        public static MoveInfo ShadowBone { get; } = new MoveInfo("Shadow Bone", Types.Ghost, MoveKind.Physical, 85, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.2, false, -1) }
        };
        
        public static MoveInfo ShadowClaw { get; } = new MoveInfo("Shadow Claw", Types.Ghost, MoveKind.Physical, 70, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher
        };

        public static MoveInfo ShadowPunch { get; } = new MoveInfo("Shadow Punch", Types.Ghost, MoveKind.Physical, 60, null, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch
        };

        public static MoveInfo ShadowSneak { get; } = new MoveInfo("Shadow Sneak", Types.Ghost, MoveKind.Physical, 40, 100, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Priority = 1
        };

        public static MoveInfo ShockWave { get; } = new MoveInfo("Shock Wave", Types.Electric, MoveKind.Special, 60, null, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror
        };

        // TODO: Can hit Pokemon under effect of Bounce, Fly or Sky Drop
        public static MoveInfo SkyUppercut { get; } = new MoveInfo("Sky Uppercut", Types.Fighting, MoveKind.Physical, 85, 90, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            ContestCategory = ContestCategory.Cool
        };

        public static MoveInfo Slam { get; } = new MoveInfo(nameof(Slam), Types.Normal, MoveKind.Physical, 80, 75, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.NonSky
        };

        public static MoveInfo Slash { get; } = new MoveInfo(nameof(Slash), Types.Normal, MoveKind.Physical, 70, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Cool,
            CriticalHit = CriticalHit.OneHigher
        };

        public static MoveInfo Sludge { get; } = new MoveInfo(nameof(Sludge), Types.Poison, MoveKind.Special, 65, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.3)
        };

        public static MoveInfo SludgeBomb { get; } = new MoveInfo("Sludge Bomb", Types.Poison, MoveKind.Special, 90, 100, 10)
        {
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.3)
        };

        public static MoveInfo SludgeWave { get; } = new MoveInfo("Sludge Wave", Types.Poison, MoveKind.Special, 95, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.1),
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo SmartStrike { get; } = new MoveInfo("Smart Strike", Types.Steel, MoveKind.Physical, 70, null, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo Smog { get; } = new MoveInfo(nameof(Smog), Types.Poison, MoveKind.Special, 30, 70, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison, 0.4)
        };

        public static MoveInfo Snarl { get; } = new MoveInfo(nameof(Snarl), Types.Dark, MoveKind.Special, 55, 95, 15)
        {
            Flags = MoveFlags.Sound | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Authentic,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -1, Self: false) }
        };

        public static MoveInfo Spark { get; } = new MoveInfo(nameof(Spark), Types.Electric, MoveKind.Physical, 65, 100, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3)
        };

        public static MoveInfo SteamEruption { get; } = new MoveInfo("Steam Eruption", Types.Water, MoveKind.Special, 110, 95, 5)
        {
            Flags = MoveFlags.Defrost | MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn, 0.3)
        };

        public static MoveInfo SteelWing { get; } = new MoveInfo("Steel Wing", Types.Steel, MoveKind.Physical, 70, 90, 25)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Defense, 0.1, true, 1) }
        };

        public static MoveInfo StoneEdge { get; } = new MoveInfo("Stone Edge", Types.Rock, MoveKind.Physical, 100, 80, 5)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            CriticalHit = CriticalHit.OneHigher
        };

        public static MoveInfo Strength { get; } = new MoveInfo(nameof(Strength), Types.Normal, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };
        
        public static MoveInfo StruggleBug { get; } = new MoveInfo("Struggle Bug", Types.Bug, MoveKind.Special, 50, 100, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes,
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -1, Self: false) }
        };

        public static MoveInfo Submission { get; } = new MoveInfo(nameof(Submission), Types.Fighting, MoveKind.Physical, 80, 80, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Recoil = 0.25
        };

        public static MoveInfo Superpower { get; } = new MoveInfo(nameof(Superpower), Types.Fighting, MoveKind.Physical, 120, 100, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: -1),
                new StatChange(Stats.Defense, StageChange: -1)
            }
        };

        // TODO: If target is in first turn of dive, this move will hit with double power
        public static MoveInfo Surf { get; } = new MoveInfo(nameof(Surf), Types.Water, MoveKind.Special, 90, 100, 15)
        {
            Flags = MoveFlags.NonSky | MoveFlags.Protect | MoveFlags.Mirror,
            ContestCategory = ContestCategory.Beauty,
            Target = MoveTarget.AllAdjacent
        };

        public static MoveInfo Swift { get; } = new MoveInfo(nameof(Swift), Types.Normal, MoveKind.Special, 60, null, 20)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo Tackle { get; } = new MoveInfo(nameof(Tackle), Types.Normal, MoveKind.Physical, 50, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo TakeDown { get; } = new MoveInfo("Take Down", Types.Normal, MoveKind.Physical, 90, 85, 20)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Recoil = 0.25
        };

        // TODO: (100 - accuracy)% chance of breaking through protect and detect
        public static MoveInfo Thunder { get; } = new MoveInfo(nameof(Thunder), Types.Electric, MoveKind.Special, 110, 70, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.3),
            AccuracyFunction = (A, M, O, B) =>
            {
                if (B.SuppressWeather != 0)
                    return M.Info.Accuracy;

                switch (B.Weather)
                {
                    case Weather.Rain:
                    case Weather.HeavyRain:
                        return 100;

                    case Weather.HarshSunlight:
                    case Weather.ExtremelyHarshSunlight:
                        return 50;

                    default:
                        return M.Info.Accuracy;
                }
            }
        };
        
        public static MoveInfo Thunderbolt { get; } = new MoveInfo(nameof(Thunderbolt), Types.Electric, MoveKind.Special, 90, 100, 15)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.1)
        };

        public static MoveInfo ThunderFang { get; } = new MoveInfo("Thunder Fang", Types.Electric, MoveKind.Physical, 65, 95, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Bite,
            Flinch = 0.1,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.1)
        };

        public static MoveInfo ThunderPunch { get; } = new MoveInfo("Thunder Punch", Types.Electric, MoveKind.Physical, 75, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Punch,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.1)
        };

        public static MoveInfo Thundershock { get; } = new MoveInfo(nameof(Thundershock), Types.Electric, MoveKind.Special, 40, 100, 30)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.1)
        };

        public static MoveInfo TropKick { get; } = new MoveInfo("Trop Kick", Types.Grass, MoveKind.Physical, 70, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges = { new StatChange(Stats.Attack, 1, false, -1) }
        };
        
        public static MoveInfo VacuumWave { get; } = new MoveInfo("Vacuum Wave", Types.Fighting, MoveKind.Special, 40, 100, 30)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            Priority = 1
        };

        public static MoveInfo Venoshock { get; } = new MoveInfo(nameof(Venoshock), Types.Poison, MoveKind.Special, 65, 100, 10)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror,
            PowerFunction = (A, M, O, B) => (O.NonVolatileStatus.Is(Poke.NonVolatileStatus.Poison, Poke.NonVolatileStatus.BadPoison) ? 2 : 1) * M.Info.Power
        };

        public static MoveInfo VCreate { get; } = new MoveInfo("V-create", Types.Fire, MoveKind.Physical, 180, 95, 5)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            PostStatChanges =
            {
                new StatChange(Stats.Defense, StageChange: -1),
                new StatChange(Stats.SpecialDefense, StageChange: -1),
                new StatChange(Stats.Speed, StageChange: -1)
            }
        };

        public static MoveInfo ViceGrip { get; } = new MoveInfo("Vice Grip", Types.Normal, MoveKind.Physical, 55, 100, 30)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo VineWhip { get; } = new MoveInfo("Vine Whip", Types.Grass, MoveKind.Physical, 45, 100, 25)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo VitalThrow { get; } = new MoveInfo("Vital Throw", Types.Fighting, MoveKind.Physical, 70, null, 10)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo VoltTackle { get; } = new MoveInfo("Volt Tackle", Types.Electric, MoveKind.Physical, 120, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Recoil = 1.0 / 3,
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis, 0.1)
        };

        public static MoveInfo Waterfall { get; } = new MoveInfo(nameof(Waterfall), Types.Water, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo WaterGun { get; } = new MoveInfo("Water Gun", Types.Water, MoveKind.Special, 40, 100, 25)
        {
            Flags = MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo WaterPulse { get; } = new MoveInfo("Water Pulse", Types.Water, MoveKind.Special, 60, 100, 20)
        {
            ConfuseTarget = 0.2,
            Flags = MoveFlags.Pulse | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo WildCharge { get; } = new MoveInfo("Wild Charge", Types.Electric, MoveKind.Physical, 90, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror,
            Recoil = 0.25
        };

        public static MoveInfo WingAttack { get; } = new MoveInfo("Wing Attack", Types.Flying, MoveKind.Physical, 60, 100, 35)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror | MoveFlags.Distance
        };

        public static MoveInfo WoodHammer { get; } = new MoveInfo("Wood Hammer", Types.Grass, MoveKind.Physical, 120, 100, 15)
        {
            Recoil = 1.0 / 3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo XScissor { get; } = new MoveInfo("X-Scissor", Types.Bug, MoveKind.Physical, 80, 100, 15)
        {
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo ZapCannon { get; } = new MoveInfo("Zap Cannon", Types.Electric, MoveKind.Special, 120, 50, 5)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis),
            Flags = MoveFlags.Bullet | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo ZenHeadbutt { get; } = new MoveInfo("Zen Headbutt", Types.Psychic, MoveKind.Physical, 80, 90, 15)
        {
            Flinch = 0.2,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };

        public static MoveInfo ZingZap { get; } = new MoveInfo("Zing Zap", Types.Electric, MoveKind.Physical, 80, 100, 10)
        {
            Flinch = 0.3,
            Flags = MoveFlags.Contact | MoveFlags.Protect | MoveFlags.Mirror
        };
    }
}