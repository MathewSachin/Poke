using System.Threading.Tasks;

namespace Poke
{
    public partial class MoveInfo
    {
        public static MoveInfo AcidArmor { get; } = new MoveInfo("Acid Armor", Types.Poison, MoveKind.Status, null, null, 20)
        {
            Flags = MoveFlags.Snatch,
            PreStatChanges = { new StatChange(Stats.Defense, StageChange: 2) },
            Target = MoveTarget.Self
        };

        public static MoveInfo Agility { get; } = new MoveInfo(nameof(Agility), Types.Psychic, MoveKind.Status, null, null, 30)
        {
            Flags = MoveFlags.Snatch,
            PreStatChanges = { new StatChange(Stats.Speed, StageChange: 2) },
            Target = MoveTarget.Self
        };

        public static MoveInfo Amnesia { get; } = new MoveInfo(nameof(Amnesia), Types.Psychic, MoveKind.Status, null, null, 20)
        {
            Flags = MoveFlags.Snatch,
            PreStatChanges = { new StatChange(Stats.SpecialDefense, StageChange: 2) },
            Target = MoveTarget.Self
        };

        // TODO: Modify Weight
        public static MoveInfo Autotomize { get; } = new MoveInfo(nameof(Autotomize), Types.Steel, MoveKind.Status, null, null, 15)
        {
            Flags = MoveFlags.Snatch,
            PreStatChanges = { new StatChange(Stats.Speed, StageChange: 2) },
            Target = MoveTarget.Self
        };

        public static MoveInfo BabyDollEyes { get; } = new MoveInfo("Baby-Doll Eyes", Types.Fairy, MoveKind.Status, null, 100, 30)
        {
            Priority = 1,
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: -1, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery
        };

        public static MoveInfo BellyDrum { get; } = new MoveInfo("Belly Drum", Types.Normal, MoveKind.Status, null, null, 10,
            async (A, M, O, B) =>
            {
                if (A.Stats.CurrentHP <= A.Stats.MaxHP / 2)
                {
                    await B.WriteStatus("But it failed");
                    
                    return;
                }

                A.Stats.ChangeStage(Stats.Attack, 12);
                
                await A.Stats.Damage(A.Stats.MaxHP / 2, B);

                await B.WriteStatus($"{B.GetStatusName(A)} maximized its Attack for half its HP");
            })
        {
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo Bestow { get; } = new MoveInfo(nameof(Bestow), Types.Normal, MoveKind.Status, null, null, 15,
            async (A, M, O, B) =>
            {
                if (A.HeldItem == null || O.HeldItem != null)
                {
                    await B.WriteStatus("But it failed");

                    return;
                }

                O.HeldItem = A.HeldItem;
                A.HeldItem = null;

                await B.WriteStatus($"{B.GetStatusName(A)} transferred its Held Item");
            })
        {
            Flags = MoveFlags.Mirror | MoveFlags.Authentic | MoveFlags.Mystery
        };
        
        public static MoveInfo BulkUp { get; } = new MoveInfo("Bulk Up", Types.Fighting, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.Defense, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo CalmMind { get; } = new MoveInfo("Calm Mind", Types.Psychic, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.SpecialAttack, StageChange: 1),
                new StatChange(Stats.SpecialDefense, StageChange: 1)
            },
            Target = MoveTarget.Self
        };

        public static MoveInfo Charm { get; } = new MoveInfo(nameof(Charm), Types.Fairy, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery
        };

        public static MoveInfo Coil { get; } = new MoveInfo(nameof(Coil), Types.Poison, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.Defense, StageChange: 1),
                new StatChange(Stats.Accuracy, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo Confide { get; } = new MoveInfo(nameof(Confide), Types.Normal, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -1, Self: false) },
            Flags = MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic
        };

        public static MoveInfo ConfuseRay { get; } = new MoveInfo("Confuse Ray", Types.Ghost, MoveKind.Status, null, 100, 10)
        {
            ConfuseTarget = 1
        };

        public static MoveInfo CosmicPower { get; } = new MoveInfo("Cosmic Power", Types.Psychic, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Defense, StageChange: 1),
                new StatChange(Stats.SpecialDefense, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo CottonGuard { get; } = new MoveInfo("Cotton Guard", Types.Grass, MoveKind.Status, null, null, 10)
        {
            PreStatChanges = { new StatChange(Stats.Defense, StageChange: 3) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo CottonSpore { get; } = new MoveInfo("Cotton Spore", Types.Grass, MoveKind.Status, null, 100, 40)
        {
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -2, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Powder | MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo DefendOrder { get; } = new MoveInfo("Defend Order", Types.Bug, MoveKind.Status, null, null, 10)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Defense, StageChange: 1),
                new StatChange(Stats.SpecialDefense, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo DoubleTeam { get; } = new MoveInfo("Double Team", Types.Normal, MoveKind.Status, null, null, 15)
        {
            PreStatChanges = { new StatChange(Stats.Evasiveness, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo DragonDance { get; } = new MoveInfo("Dragon Dance", Types.Dragon, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.Speed, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Dance
        };

        public static MoveInfo EerieImpulse { get; } = new MoveInfo("Eerie Impulse", Types.Electric, MoveKind.Status, null, 100, 15)
        {
            PostStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo FakeTears { get; } = new MoveInfo("Fake Tears", Types.Dark, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges = { new StatChange(Stats.SpecialDefense, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery
        };

        public static MoveInfo FeatherDance { get; } = new MoveInfo("Feather Dance", Types.Flying, MoveKind.Status, null, 100, 15)
        {
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery | MoveFlags.Dance
        };

        public static MoveInfo Flash { get; } = new MoveInfo(nameof(Flash), Types.Normal, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges = { new StatChange(Stats.Accuracy, StageChange: -1, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Flatter { get; } = new MoveInfo(nameof(Flatter), Types.Dark, MoveKind.Status, null, 100, 15)
        {
            PostStatChanges = { new StatChange(Stats.SpecialAttack, 1, false, 1) },
            ConfuseTarget = 1
        };

        public static MoveInfo Growl { get; } = new MoveInfo(nameof(Growl), Types.Normal, MoveKind.Status, null, 100, 40)
        {
            PostStatChanges = { new StatChange(Stats.Attack, StageChange: -1, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic
        };

        public static MoveInfo Hail { get; } = new MoveInfo(nameof(Hail), Types.Ice, MoveKind.Status, null, null, 10,
            (A, M, O, B) => DamageFunctionFactory.AlterWeather(A, Weather.Hail, B))
        {
            Target = MoveTarget.Self
        };

        public static MoveInfo Harden { get; } = new MoveInfo(nameof(Harden), Types.Normal, MoveKind.Special, null, null, 30)
        {
            PreStatChanges = { new StatChange(Stats.Defense, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo HoneClaws { get; } = new MoveInfo("Hone Claws", Types.Dark, MoveKind.Status, null, null, 15)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.Accuracy, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo Howl { get; } = new MoveInfo(nameof(Howl), Types.Normal, MoveKind.Status, null, null, 40)
        {
            PreStatChanges = { new StatChange(Stats.Attack, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo IronDefense { get; } = new MoveInfo("Iron Defense", Types.Steel, MoveKind.Status, null, null, 15)
        {
            PreStatChanges = { new StatChange(Stats.Defense, StageChange: 2) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo Kinesis { get; } = new MoveInfo(nameof(Kinesis), Types.Psychic, MoveKind.Status, null, 80, 15)
        {
            PostStatChanges = { new StatChange(Stats.Accuracy, StageChange: -1, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Leer { get; } = new MoveInfo(nameof(Leer), Types.Normal, MoveKind.Status, null, 100, 30)
        {
            PostStatChanges = { new StatChange(Stats.Defense, StageChange: -1, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Meditate { get; } = new MoveInfo(nameof(Meditate), Types.Psychic, MoveKind.Status, null, null, 40)
        {
            PreStatChanges = { new StatChange(Stats.Attack, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo MetalSound { get; } = new MoveInfo("Metal Sound", Types.Steel, MoveKind.Status, null, 85, 40)
        {
            PostStatChanges = { new StatChange(Stats.SpecialDefense, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic | MoveFlags.Mystery
        };

        public static MoveInfo NastyPlot { get; } = new MoveInfo("Nasty Plot", Types.Dark, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: 2) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo NobleRoar { get; } = new MoveInfo("Noble Roar", Types.Normal, MoveKind.Status, null, 100, 30)
        {
            PostStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: -1),
                new StatChange(Stats.SpecialAttack, StageChange: -1)
            },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic
        };

        public static MoveInfo PlayNice { get; } = new MoveInfo("Play Nice", Types.Normal, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.Attack, StageChange: -1, Self: false) },
            Flags = MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Authentic
        };

        public static MoveInfo PoisonGas { get; } = new MoveInfo("Poison Gas", Types.Poison, MoveKind.Status, null, 90, 40)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison),
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror,
            Target = MoveTarget.AllAdjacentFoes
        };

        public static MoveInfo PoisonPowder { get; } = new MoveInfo("Poison Powder", Types.Poison, MoveKind.Status, null, 75, 35)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Poison),
            Flags = MoveFlags.Powder | MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo QuiverDance { get; } = new MoveInfo("Quiver Dance", Types.Bug, MoveKind.Status, null, null, 20)
        {
            PreStatChanges =
            {
                new StatChange(Stats.SpecialAttack, StageChange: 1),
                new StatChange(Stats.SpecialDefense, StageChange: 1),
                new StatChange(Stats.Speed, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Dance
        };

        public static MoveInfo RainDance { get; } = new MoveInfo("Rain Dance", Types.Water, MoveKind.Status, null, null, 5,
            (A, M, O, B) => DamageFunctionFactory.AlterWeather(A, Weather.Rain, B))
        {
            Target = MoveTarget.Self
        };

        public static MoveInfo Recover { get; } = new MoveInfo(nameof(Recover), Types.Normal, MoveKind.Status, null, null, 10,
            (A, M, O, B) => DamageFunctionFactory.Recover(A, A.Stats.MaxHP / 2, B))
        {
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Heal
        };

        public static MoveInfo RockPolish { get; } = new MoveInfo("Rock Polish", Types.Rock, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.Speed, StageChange: 2) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo SandAttack { get; } = new MoveInfo("Sand Attack", Types.Ground, MoveKind.Status, null, 100, 15)
        {
            PostStatChanges = { new StatChange(Stats.Accuracy, StageChange: -1, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Sandstorm { get; } = new MoveInfo(nameof(Sandstorm), Types.Rock, MoveKind.Status, null, null, 10,
            (A, M, O, B) => DamageFunctionFactory.AlterWeather(A, Weather.Sandstorm, B))
        {
            Target = MoveTarget.Self
        };

        public static MoveInfo ScaryFace { get; } = new MoveInfo("Scary Face", Types.Normal, MoveKind.Status, null, 100, 10)
        {
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery
        };

        public static MoveInfo Screech { get; } = new MoveInfo(nameof(Screech), Types.Normal, MoveKind.Status, null, 85, 40)
        {
            PostStatChanges = { new StatChange(Stats.Defense, StageChange: -2, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic | MoveFlags.Mystery
        };

        public static MoveInfo Sharpen { get; } = new MoveInfo(nameof(Sharpen), Types.Normal, MoveKind.Status, null, null, 30)
        {
            PreStatChanges = { new StatChange(Stats.Attack, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo ShellSmash { get; } = new MoveInfo("Shell Smash", Types.Normal, MoveKind.Status, null, null, 15)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 2),
                new StatChange(Stats.SpecialAttack, StageChange: 2),
                new StatChange(Stats.Speed, StageChange: 2),
                new StatChange(Stats.Defense, StageChange: -1),
                new StatChange(Stats.SpecialDefense, StageChange: -1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo ShiftGear { get; } = new MoveInfo("Shift Gear", Types.Steel, MoveKind.Status, null, null, 10)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.Speed, StageChange: 2)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo Sing { get; } = new MoveInfo(nameof(Sing), Types.Normal, MoveKind.Status, null, 55, 15)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Sleep),
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Sound | MoveFlags.Authentic
        };

        public static MoveInfo SlackOff { get; } = new MoveInfo("Slack Off", Types.Normal, MoveKind.Status, null, null, 10,
            (A, M, O, B) => DamageFunctionFactory.Recover(A, A.Stats.MaxHP / 2, B))
        {
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Heal
        };

        public static MoveInfo SleepPowder { get; } = new MoveInfo("Sleep Powder", Types.Grass, MoveKind.Status, null, 75, 15)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Sleep),
            Flags = MoveFlags.Powder | MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo SmokeScreen { get; } = new MoveInfo("Smoke Screen", Types.Normal, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges = { new StatChange(Stats.Accuracy, StageChange: -1, Self: false) },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Splash { get; } = new MoveInfo(nameof(Splash), Types.Normal, MoveKind.Status, null, null, 40)
        {
            Target = MoveTarget.Self,
            Flags = MoveFlags.Gravity
        };

        public static MoveInfo StringShot { get; } = new MoveInfo("String Shot", Types.Bug, MoveKind.Status, null, 95, 40)
        {
            PostStatChanges = { new StatChange(Stats.Speed, StageChange: -1, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo StunSpore { get; } = new MoveInfo("Stun Spore", Types.Grass, MoveKind.Status, null, 75, 30)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis),
            Flags = MoveFlags.Powder | MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo SweetScent { get; } = new MoveInfo("Sweet Scent", Types.Normal, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges = { new StatChange(Stats.Evasiveness, StageChange: -1, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo SwordsDance { get; } = new MoveInfo("Swords Dance", Types.Normal, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.Attack, StageChange: 2) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Dance
        };
        
        public static MoveInfo Synthesis { get; } = new MoveInfo(nameof(Synthesis), Types.Grass, MoveKind.Status, null, null, 5,
            async (A, M, O, B) =>
            {
                var maxHp = A.Stats.MaxHP;
                var recover = maxHp / 2;

                if (B.SuppressWeather == 0)
                {
                    if (B.Weather.Is(Weather.HarshSunlight, Weather.ExtremelyHarshSunlight))
                        recover = 2 * maxHp / 3;
                    else if (B.Weather != Weather.None)
                        recover = maxHp / 4;
                }

                await DamageFunctionFactory.Recover(A, recover, B);
            })
        {
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch | MoveFlags.Heal
        };

        public static MoveInfo SunnyDay { get; } = new MoveInfo("Sunny Day", Types.Fire, MoveKind.Status, null, null, 5,
            (A, M, O, B) => DamageFunctionFactory.AlterWeather(A, Weather.HarshSunlight, B))
        {
            Target = MoveTarget.Self
        };

        public static MoveInfo TailGlow { get; } = new MoveInfo("Tail Glow", Types.Bug, MoveKind.Status, null, null, 20)
        {
            PreStatChanges = { new StatChange(Stats.SpecialAttack, StageChange: 3) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo TailWhip { get; } = new MoveInfo("Tail Whip", Types.Normal, MoveKind.Status, null, 100, 30)
        {
            PostStatChanges = { new StatChange(Stats.Defense, StageChange: -1, Self: false) },
            Target = MoveTarget.AllAdjacentFoes,
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo ThunderWave { get; } = new MoveInfo("Thunder Wave", Types.Electric, MoveKind.Status, null, 90, 20)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Paralysis),
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Tickle { get; } = new MoveInfo(nameof(Tickle), Types.Normal, MoveKind.Status, null, 100, 20)
        {
            PostStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: -1, Self: false),
                new StatChange(Stats.Defense, StageChange: -1, Self: false)
            },
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror | MoveFlags.Mystery
        };

        public static MoveInfo WillOWisp { get; } = new MoveInfo("Will-O-Wisp", Types.Fire, MoveKind.Status, null, 85, 15)
        {
            NonVolatileStatus = new NonVolatileStatusDefinition(Poke.NonVolatileStatus.Burn),
            Flags = MoveFlags.Protect | MoveFlags.Reflectable | MoveFlags.Mirror
        };

        public static MoveInfo Withdraw { get; } = new MoveInfo(nameof(Withdraw), Types.Water, MoveKind.Status, null, null, 40)
        {
            PreStatChanges = { new StatChange(Stats.Defense, StageChange: 1) },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };

        public static MoveInfo WorkUp { get; } = new MoveInfo("Work Up", Types.Normal, MoveKind.Status, null, null, 30)
        {
            PreStatChanges =
            {
                new StatChange(Stats.Attack, StageChange: 1),
                new StatChange(Stats.SpecialAttack, StageChange: 1)
            },
            Target = MoveTarget.Self,
            Flags = MoveFlags.Snatch
        };
    }
}