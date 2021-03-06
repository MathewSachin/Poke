﻿namespace Poke
{
    // TODO: Verify Abilities
    public partial class PokemonSpecies
    {
        public static PokemonSpecies Aerodactyl { get; } = new PokemonSpecies(142, nameof(Aerodactyl), Types.Rock, Types.Flying,
            80, 105, 65, 60, 75, 130,
            Ability.RockHead, Ability.Pressure)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(142, "Mega Aerodactyl", Types.Rock, Types.Flying,
                    80, 135, 85, 70, 95, 150, Ability.ToughClaws), MegaStone.Aerodactylite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.Bite,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Crunch,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonBreath,
                MoveInfo.DragonClaw,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.FireFang,
                MoveInfo.Flamethrower,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.IceFang,
                MoveInfo.IronHead,
                MoveInfo.RainDance,
                MoveInfo.RockPolish,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Sandstorm,
                MoveInfo.ScaryFace,
                MoveInfo.SteelWing,
                MoveInfo.StoneEdge,
                MoveInfo.SunnyDay,
                MoveInfo.TakeDown,
                MoveInfo.ThunderFang,
                MoveInfo.WingAttack
            }
        };

        public static PokemonSpecies Aggron { get; } = new PokemonSpecies(306, nameof(Aggron), Types.Steel, Types.Rock,
            70, 110, 180, 60, 60, 50,
            Ability.Sturdy, Ability.RockHead)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(306, "Mega Aggron", Types.Steel, null,
                    70, 140, 230, 60, 80, 50, Ability.Filter), MegaStone.Aggronite)
            },
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Autotomize,
                MoveInfo.Blizzard,
                MoveInfo.BodySlam,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DarkPulse,
                MoveInfo.DoubleEdge,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonClaw,
                MoveInfo.DragonRush,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.Flamethrower,
                MoveInfo.FlashCannon,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Harden,
                MoveInfo.Headbutt,
                MoveInfo.HeadSmash,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IronDefense,
                MoveInfo.IronHead,
                MoveInfo.IronTail,
                MoveInfo.MetalClaw,
                MoveInfo.MetalSound,
                MoveInfo.MudSlap,
                MoveInfo.RainDance,
                MoveInfo.RockPolish,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Sandstorm,
                MoveInfo.Screech,
                MoveInfo.ShadowClaw,
                MoveInfo.StoneEdge,
                MoveInfo.SunnyDay,
                MoveInfo.Superpower,
                MoveInfo.Surf,
                MoveInfo.Tackle,
                MoveInfo.TakeDown,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderWave,
            }
        };

        public static PokemonSpecies Arcanine { get; } = new PokemonSpecies(59, nameof(Arcanine), Types.Fire, null,
            90, 110, 80, 100, 80, 95,
            Ability.Intimidate, Ability.FlashFire, Ability.Justified)
        {
            GenderRatio = new GenderRatio(75, 25),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Bite,
                MoveInfo.BodySlam,
                MoveInfo.Bulldoze,
                MoveInfo.CloseCombat,
                MoveInfo.Confide,
                MoveInfo.Crunch,
                MoveInfo.DoubleEdge,
                MoveInfo.DoubleTeam,
                MoveInfo.ExtremeSpeed,
                MoveInfo.FireBlast,
                MoveInfo.FireFang,
                MoveInfo.FlameCharge,
                MoveInfo.Flamethrower,
                MoveInfo.FlareBlitz,
                MoveInfo.GigaImpact,
                MoveInfo.HeatWave,
                MoveInfo.Howl,
                MoveInfo.HyperBeam,
                MoveInfo.IronTail,
                MoveInfo.Overheat,
                MoveInfo.Snarl,
                MoveInfo.SunnyDay,
                MoveInfo.ThunderPunch,
                MoveInfo.WildCharge,
                MoveInfo.WillOWisp
            }
        };

        public static PokemonSpecies Alakazam { get; } = new PokemonSpecies(65, nameof(Alakazam), Types.Psychic, null,
            55, 50, 45, 135, 95, 120,
            Ability.Synchronize, Ability.InnerFocus)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(65, "Mega Alakazam", Types.Psychic, null,
                    55, 50, 65, 175, 105, 150, null), MegaStone.Alakazite)
            },
            GenderRatio = new GenderRatio(75, 25),
            LearnSet =
            {
                MoveInfo.CalmMind,
                MoveInfo.ChargeBeam,
                MoveInfo.Confide,
                MoveInfo.Confusion,
                MoveInfo.DazzlingGleam,
                MoveInfo.DoubleTeam,
                MoveInfo.EnergyBall,
                MoveInfo.FirePunch,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.IcePunch,
                MoveInfo.Kinesis,
                MoveInfo.Psybeam,
                MoveInfo.Psychic,
                MoveInfo.PsychoCut,
                MoveInfo.RainDance,
                MoveInfo.ShadowBall,
                MoveInfo.SunnyDay,
                MoveInfo.ThunderPunch
            }
        };

        public static PokemonSpecies Beedrill { get; } = new PokemonSpecies(15, nameof(Beedrill), Types.Bug, Types.Poison,
            65, 90, 40, 45, 80, 75,
            Ability.Swarm, HiddenAbility: Ability.Sniper)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(15, "Mega Beedrill", Types.Bug, Types.Poison,
                    65, 150, 40, 15, 80, 145, Ability.Adaptability), MegaStone.Beedrillite)
            },
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.DoubleTeam,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.PoisonJab,
                MoveInfo.SludgeBomb,
                MoveInfo.SunnyDay,
                MoveInfo.SwordsDance,
                MoveInfo.Venoshock,
                MoveInfo.XScissor
            }
        };

        public static PokemonSpecies Blastoise { get; } = new PokemonSpecies(9, nameof(Blastoise), Types.Water, null,
            79, 83, 100, 85, 105, 78,
            Ability.Torrent, HiddenAbility: Ability.RainDish)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(9, "Mega Blastoise", Types.Water, null,
                    79, 103, 120, 135, 115, 78, Ability.MegaLauncher), MegaStone.Blastoisinite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AquaJet,
                MoveInfo.AquaTail,
                MoveInfo.AuraSphere,
                MoveInfo.Bite,
                MoveInfo.Blizzard,
                MoveInfo.BrickBreak,
                MoveInfo.Brine,
                MoveInfo.Bubble,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DarkPulse,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonPulse,
                MoveInfo.Earthquake,
                MoveInfo.FlashCannon,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.HydroCannon,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IronDefense,
                MoveInfo.MuddyWater,
                MoveInfo.RainDance,
                MoveInfo.RockTomb,
                MoveInfo.RockSlide,
                MoveInfo.Scald,
                MoveInfo.Surf,
                MoveInfo.Tackle,
                MoveInfo.TailWhip,
                MoveInfo.Waterfall,
                MoveInfo.WaterGun,
                MoveInfo.WaterPulse,
                MoveInfo.Withdraw,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Blaziken { get; } = new PokemonSpecies(257, nameof(Blaziken), Types.Fire, Types.Fighting,
            80, 120, 70, 110, 70, 80,
            Ability.Blaze, HiddenAbility: Ability.SpeedBoost)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(257, "Mega Blaziken", Types.Fire, Types.Fighting,
                    80, 160, 80, 130, 80, 100, Ability.SpeedBoost), MegaStone.Blazikenite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.BlazeKick,
                MoveInfo.BlastBurn,
                MoveInfo.BraveBird,
                MoveInfo.BrickBreak,
                MoveInfo.BulkUp,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.CrushClaw,
                MoveInfo.DoubleTeam,
                MoveInfo.Earthquake,
                MoveInfo.Ember,
                MoveInfo.FeatherDance,
                MoveInfo.FireBlast,
                MoveInfo.FirePunch,
                MoveInfo.FlameCharge,
                MoveInfo.Flamethrower,
                MoveInfo.FlareBlitz,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Growl,
                MoveInfo.HyperBeam,
                MoveInfo.LowSweep,
                MoveInfo.NightSlash,
                MoveInfo.Overheat,
                MoveInfo.Peck,
                MoveInfo.PoisonJab,
                MoveInfo.QuickAttack,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.SandAttack,
                MoveInfo.Scratch,
                MoveInfo.ShadowClaw,
                MoveInfo.SkyUppercut,
                MoveInfo.Slash,
                MoveInfo.StoneEdge,
                MoveInfo.SunnyDay,
                MoveInfo.SwordsDance,
                MoveInfo.WillOWisp,
                MoveInfo.WorkUp
            }
        };
        
        public static PokemonSpecies Charizard { get; } = new PokemonSpecies(6, nameof(Charizard), Types.Fire, Types.Flying,
            78, 84, 78, 109, 85, 100,
            Ability.Blaze, HiddenAbility: Ability.SolarPower)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(6, "Mega Charizard X", Types.Fire, Types.Dragon,
                    78, 130, 111, 130, 85, 100, Ability.ToughClaws), MegaStone.CharizarditeX),

                new MegaEvolution(new PokemonSpecies(6, "Mega Charizard Y", Types.Fire, Types.Flying,
                    78, 104, 78, 159, 115, 100, Ability.Drought), MegaStone.CharizarditeY)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.AirCutter,
                MoveInfo.AirSlash,
                MoveInfo.BellyDrum,
                MoveInfo.Bite,
                MoveInfo.BlastBurn,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.Crunch,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonClaw,
                MoveInfo.DragonDance,
                MoveInfo.DragonPulse,
                MoveInfo.DragonRush,
                MoveInfo.Ember,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.FireFang,
                MoveInfo.FlameCharge,
                MoveInfo.Flamethrower,
                MoveInfo.FlareBlitz,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Growl,
                MoveInfo.HeatWave,
                MoveInfo.HyperBeam,
                MoveInfo.Inferno,
                MoveInfo.MetalClaw,
                MoveInfo.Overheat,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.ScaryFace,
                MoveInfo.Scratch,
                MoveInfo.ShadowClaw,
                MoveInfo.Slash,
                MoveInfo.SmokeScreen,
                MoveInfo.SteelWing,
                MoveInfo.SunnyDay,
                MoveInfo.SwordsDance,
                MoveInfo.WillOWisp,
                MoveInfo.WingAttack,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Dragonite { get; } = new PokemonSpecies(149, nameof(Dragonite), Types.Dragon, Types.Flying,
            91, 134, 95, 100, 100, 80,
            Ability.InnerFocus, HiddenAbility: Ability.Multiscale)
        {
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.AquaJet,
                MoveInfo.AquaTail,
                MoveInfo.Blizzard,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DoubleTeam,
                MoveInfo.DracoMeteor,
                MoveInfo.DragonBreath,
                MoveInfo.DragonClaw,
                MoveInfo.DragonDance,
                MoveInfo.DragonPulse,
                MoveInfo.DragonRush,
                MoveInfo.Earthquake,
                MoveInfo.ExtremeSpeed,
                MoveInfo.FireBlast,
                MoveInfo.FirePunch,
                MoveInfo.Flamethrower,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.Hurricane,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IronTail,
                MoveInfo.Leer,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Slam,
                MoveInfo.SteelWing,
                MoveInfo.StoneEdge,
                MoveInfo.SunnyDay,
                MoveInfo.Surf,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderPunch,
                MoveInfo.ThunderWave,
                MoveInfo.Waterfall,
                MoveInfo.WaterPulse,
                MoveInfo.WingAttack
            }
        };

        public static PokemonSpecies Electivire { get; } = new PokemonSpecies(466, nameof(Electivire), Types.Electric, null,
            75, 123, 67, 95, 85, 95,
            Ability.MotorDrive, HiddenAbility: Ability.VitalSpirit)
        {
            GenderRatio = new GenderRatio(75, 25),
            LearnSet =
            {
                MoveInfo.BrickBreak,
                MoveInfo.Bulldoze,
                MoveInfo.ChargeBeam,
                MoveInfo.Confide,
                MoveInfo.CrossChop,
                MoveInfo.Discharge,
                MoveInfo.DoubleTeam,
                MoveInfo.DynamicPunch,
                MoveInfo.Earthquake,
                MoveInfo.ElectroBall,
                MoveInfo.FirePunch,
                MoveInfo.Flamethrower,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.HammerArm,
                MoveInfo.HyperBeam,
                MoveInfo.IcePunch,
                MoveInfo.KarateChop,
                MoveInfo.Leer,
                MoveInfo.Meditate,
                MoveInfo.Psychic,
                MoveInfo.QuickAttack,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Screech,
                MoveInfo.ShockWave,
                MoveInfo.Swift,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderPunch,
                MoveInfo.Thundershock,
                MoveInfo.ThunderWave,
                MoveInfo.WildCharge
            }
        };

        public static PokemonSpecies Empoleon { get; } = new PokemonSpecies(395, nameof(Empoleon), Types.Water, Types.Steel,
            84, 86, 88, 111, 101, 60,
            Ability.Torrent)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.AquaJet,
                MoveInfo.Blizzard,
                MoveInfo.Brine,
                MoveInfo.BrickBreak,
                MoveInfo.Bubble,
                MoveInfo.BubbleBeam,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DoubleTeam,
                MoveInfo.DrillPeck,
                MoveInfo.Earthquake,
                MoveInfo.FeatherDance,
                MoveInfo.FlashCannon,
                MoveInfo.Growl,
                MoveInfo.Hail,
                MoveInfo.HydroCannon,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IcyWind,
                MoveInfo.MetalClaw,
                MoveInfo.MudSlap,
                MoveInfo.Peck,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Scald,
                MoveInfo.ShadowClaw,
                MoveInfo.SteelWing,
                MoveInfo.Surf,
                MoveInfo.SwordsDance,
                MoveInfo.Tackle,
                MoveInfo.Waterfall,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Espeon { get; } = new PokemonSpecies(196, nameof(Espeon), Types.Psychic, null,
            65, 65, 60, 130, 95, 110,
            Ability.Synchronize)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.BabyDollEyes,
                MoveInfo.CalmMind,
                MoveInfo.Confusion,
                MoveInfo.DazzlingGleam,
                MoveInfo.DoubleTeam,
                MoveInfo.FakeTears,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.Psybeam,
                MoveInfo.Psychic,
                MoveInfo.QuickAttack,
                MoveInfo.RainDance,
                MoveInfo.SandAttack,
                MoveInfo.ShadowBall,
                MoveInfo.SunnyDay,
                MoveInfo.Swift,
                MoveInfo.Tackle,
                MoveInfo.TailWhip,
                MoveInfo.Tickle,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Feraligatr { get; } = new PokemonSpecies(160, nameof(Feraligatr), Types.Water, null,
            85, 105, 100, 79, 83, 78,
            Ability.Torrent)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Agility,
                MoveInfo.AquaJet,
                MoveInfo.AquaTail,
                MoveInfo.Bite,
                MoveInfo.Blizzard,
                MoveInfo.BrickBreak,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.Crunch,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonClaw,
                MoveInfo.DragonDance,
                MoveInfo.Earthquake,
                MoveInfo.FakeTears,
                MoveInfo.Flatter,
                MoveInfo.FocusBlast,
                MoveInfo.Hail,
                MoveInfo.GigaImpact,
                MoveInfo.HydroCannon,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IceFang,
                MoveInfo.IcePunch,
                MoveInfo.Leer,
                MoveInfo.MetalClaw,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Scald,
                MoveInfo.ScaryFace,
                MoveInfo.Scratch,
                MoveInfo.Screech,
                MoveInfo.ShadowClaw,
                MoveInfo.Slash,
                MoveInfo.Superpower,
                MoveInfo.Surf,
                MoveInfo.SwordsDance,
                MoveInfo.Waterfall,
                MoveInfo.WaterGun,
                MoveInfo.WaterPulse,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Flygon { get; } = new PokemonSpecies(330, nameof(Flygon), Types.Ground, Types.Dragon,
            80, 100, 80, 80, 80, 100,
            Ability.Levitate)
        {
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DoubleTeam,
                MoveInfo.DracoMeteor,
                MoveInfo.DragonBreath,
                MoveInfo.DragonClaw,
                MoveInfo.DragonDance,
                MoveInfo.DragonRush,
                MoveInfo.EarthPower,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.Flamethrower,
                MoveInfo.GigaImpact,
                MoveInfo.Gust,
                MoveInfo.HyperBeam,
                MoveInfo.MudShot,
                MoveInfo.MudSlap,
                MoveInfo.QuickAttack,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.SandAttack,
                MoveInfo.Sandstorm,
                MoveInfo.Screech,
                MoveInfo.SteelWing,
                MoveInfo.StoneEdge,
                MoveInfo.SunnyDay
            }
        };
        
        public static PokemonSpecies Gardevoir { get; } = new PokemonSpecies(282, nameof(Gardevoir), Types.Psychic, Types.Fairy,
            68, 65, 65, 125, 115, 80,
            Ability.Synchronize, HiddenAbility: Ability.Telepathy)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(282, "Mega Gardevoir", Types.Psychic, Types.Fairy,
                    68, 85, 65, 165, 135, 100, Ability.Pixilate), MegaStone.Gardevoirite)
            },
            LearnSet =
            {
                MoveInfo.CalmMind,
                MoveInfo.ChargeBeam,
                MoveInfo.Confide,
                MoveInfo.ConfuseRay,
                MoveInfo.Confusion,
                MoveInfo.DazzlingGleam,
                MoveInfo.DisarmingVoice,
                MoveInfo.DoubleTeam,
                MoveInfo.DrainingKiss,
                MoveInfo.EnergyBall,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Growl,
                MoveInfo.HyperBeam,
                MoveInfo.MagicalLeaf,
                MoveInfo.Moonblast,
                MoveInfo.Psychic,
                MoveInfo.RainDance,
                MoveInfo.ShadowBall,
                MoveInfo.ShadowSneak,
                MoveInfo.SunnyDay,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderWave,
                MoveInfo.WillOWisp
            }
        };

        public static PokemonSpecies Gengar { get; } = new PokemonSpecies(94, nameof(Gengar), Types.Ghost, Types.Poison,
            60, 65, 60, 130, 75, 110,
            Ability.Levitate, Ability.CursedBody)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(94, "Mega Gengar", Types.Ghost, Types.Poison,
                    60, 65, 80, 170, 95, 130, null), MegaStone.Gengarite)
            },
            LearnSet =
            {
                MoveInfo.Astonish,
                MoveInfo.BrickBreak,
                MoveInfo.Confide,
                MoveInfo.ConfuseRay,
                MoveInfo.DarkPulse,
                MoveInfo.DazzlingGleam,
                MoveInfo.DoubleTeam,
                MoveInfo.EnergyBall,
                MoveInfo.FirePunch,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Hex,
                MoveInfo.HyperBeam,
                MoveInfo.IcePunch,
                MoveInfo.Lick,
                MoveInfo.PoisonJab,
                MoveInfo.Psychic,
                MoveInfo.RainDance,
                MoveInfo.ScaryFace,
                MoveInfo.ShadowBall,
                MoveInfo.ShadowClaw,
                MoveInfo.ShadowPunch,
                MoveInfo.SludgeBomb,
                MoveInfo.SunnyDay,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderPunch,
                MoveInfo.Venoshock,
                MoveInfo.WillOWisp
            }
        };

        public static PokemonSpecies Glaceon { get; } = new PokemonSpecies(471, nameof(Glaceon), Types.Ice, null,
            65, 60, 110, 130, 95, 65,
            Ability.SnowCloak, HiddenAbility: Ability.IceBody)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.BabyDollEyes,
                MoveInfo.Bite,
                MoveInfo.Blizzard,
                MoveInfo.Confide,
                MoveInfo.DoubleTeam,
                MoveInfo.FrostBreath,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IceFang,
                MoveInfo.IceShard,
                MoveInfo.IcyWind,
                MoveInfo.QuickAttack,
                MoveInfo.RainDance,
                MoveInfo.SandAttack,
                MoveInfo.ShadowBall,
                MoveInfo.SunnyDay,
                MoveInfo.Tackle,
                MoveInfo.TailWhip,
                MoveInfo.Tickle,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Golduck { get; } = new PokemonSpecies(55, nameof(Golduck), Types.Water, null,
            80, 82, 78, 95, 80, 85,
            Ability.CloudNine, HiddenAbility: Ability.SwiftSwim)
        {
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.AquaJet,
                MoveInfo.Blizzard,
                MoveInfo.BrickBreak,
                MoveInfo.CalmMind,
                MoveInfo.Confide,
                MoveInfo.ConfuseRay,
                MoveInfo.Confusion,
                MoveInfo.CrossChop,
                MoveInfo.DoubleTeam,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.LowSweep,
                MoveInfo.MudBomb,
                MoveInfo.Psybeam,
                MoveInfo.Psychic,
                MoveInfo.RainDance,
                MoveInfo.Scald,
                MoveInfo.Scratch,
                MoveInfo.Screech,
                MoveInfo.ShadowClaw,
                MoveInfo.Surf,
                MoveInfo.TailWhip,
                MoveInfo.Waterfall,
                MoveInfo.WaterGun,
                MoveInfo.WaterPulse,
                MoveInfo.ZenHeadbutt
            }
        };

        public static PokemonSpecies Goodra { get; } = new PokemonSpecies(706, nameof(Goodra), Types.Dragon, null,
            90, 100, 70, 110, 150, 80,
            Ability.SapSipper, Ability.Hydration, Ability.Gooey)
        {
            LearnSet =
            {
                MoveInfo.AcidArmor,
                MoveInfo.Absorb,
                MoveInfo.AquaTail,
                MoveInfo.Blizzard,
                MoveInfo.BodySlam,
                MoveInfo.BrutalSwing,
                MoveInfo.Bubble,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.DoubleTeam,
                MoveInfo.DracoMeteor,
                MoveInfo.DragonBreath,
                MoveInfo.DragonPulse,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.Flamethrower,
                MoveInfo.FocusBlast,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IronTail,
                MoveInfo.MuddyWater,
                MoveInfo.PoisonTail,
                MoveInfo.PowerWhip,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.SludgeBomb,
                MoveInfo.SludgeWave,
                MoveInfo.SunnyDay,
                MoveInfo.Tackle,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt
            }
        };

        public static PokemonSpecies Greninja { get; } = new PokemonSpecies(658, nameof(Greninja), Types.Water, Types.Dark,
            72, 95, 67, 103, 71, 122,
            Ability.Torrent)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.AerialAce,
                MoveInfo.Blizzard,
                MoveInfo.Bubble,
                MoveInfo.BrutalSwing,
                MoveInfo.Confide,
                MoveInfo.Crunch,
                MoveInfo.DarkPulse,
                MoveInfo.DoubleTeam,
                MoveInfo.Extrasensory,
                MoveInfo.GigaImpact,
                MoveInfo.Growl,
                MoveInfo.HydroCannon,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.Lick,
                MoveInfo.NightSlash,
                MoveInfo.Pound,
                MoveInfo.QuickAttack,
                MoveInfo.RainDance,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.Scald,
                MoveInfo.ShadowSneak,
                MoveInfo.SmokeScreen,
                MoveInfo.Surf,
                MoveInfo.Waterfall,
                MoveInfo.WaterPulse,
                MoveInfo.WorkUp
            }
        };

        public static PokemonSpecies Gyarados { get; } = new PokemonSpecies(130, nameof(Gyarados), Types.Water, Types.Flying,
            95, 125, 79, 60, 100, 81,
            Ability.Intimidate)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(130, "Mega Gyarados", Types.Water, Types.Dark,
                    95, 155, 109, 70, 130, 81, null), MegaStone.Gyaradosite)
            },
            LearnSet =
            {
                MoveInfo.AquaTail,
                MoveInfo.Bite,
                MoveInfo.Blizzard,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Confide,
                MoveInfo.Crunch,
                MoveInfo.DarkPulse,
                MoveInfo.DoubleTeam,
                MoveInfo.DragonDance,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.Flamethrower,
                MoveInfo.GigaImpact,
                MoveInfo.Hail,
                MoveInfo.Hurricane,
                MoveInfo.HydroPump,
                MoveInfo.HyperBeam,
                MoveInfo.IceBeam,
                MoveInfo.IceFang,
                MoveInfo.Leer,
                MoveInfo.RainDance,
                MoveInfo.Sandstorm,
                MoveInfo.Scald,
                MoveInfo.ScaryFace,
                MoveInfo.StoneEdge,
                MoveInfo.Surf,
                MoveInfo.Thunder,
                MoveInfo.Thunderbolt,
                MoveInfo.ThunderWave,
                MoveInfo.Waterfall
            }
        };

        public static PokemonSpecies Haxorus { get; } = new PokemonSpecies(612, nameof(Haxorus), Types.Dragon, null,
            76, 147, 90, 60, 70, 97,
            Ability.Rivalry)
        {
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.DragonClaw,
                MoveInfo.DragonPulse,
                MoveInfo.Earthquake,
                MoveInfo.PoisonJab,
                MoveInfo.RockSlide,
                MoveInfo.ShadowClaw,
                MoveInfo.Slash,
                MoveInfo.Surf,
                MoveInfo.XScissor
            }
        };

        public static PokemonSpecies Heracross { get; } = new PokemonSpecies(214, nameof(Heracross), Types.Bug, Types.Fighting,
            80, 125, 75, 40, 95, 85,
            Ability.Swarm, Ability.Guts)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(214, "Mega Heracross", Types.Bug, Types.Fighting,
                    80, 185, 115, 40, 105, 75, null), MegaStone.Heracronite)
            },
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Earthquake,
                MoveInfo.HornAttack,
                MoveInfo.Megahorn,
                MoveInfo.NightSlash,
                MoveInfo.ShadowClaw,
                MoveInfo.StoneEdge,
                MoveInfo.Venoshock
            }
        };

        public static PokemonSpecies Houndoom { get; } = new PokemonSpecies(229, nameof(Houndoom), Types.Dark, Types.Fire,
            75, 90, 50, 110, 80, 95,
            Ability.EarlyBird, Ability.FlashFire)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(229, "Mega Houndoom", Types.Dark, Types.Fire,
                    75, 90, 90, 140, 90, 115, Ability.SolarPower), MegaStone.Houndoominite)
            },
            LearnSet =
            {
                MoveInfo.Crunch,
                MoveInfo.DarkPulse,
                MoveInfo.FireFang,
                MoveInfo.Flamethrower,
                MoveInfo.ShadowBall,
                MoveInfo.SludgeBomb,
                MoveInfo.ThunderFang
            }
        };

        public static PokemonSpecies Infernape { get; } = new PokemonSpecies(392, nameof(Infernape), Types.Fire, Types.Fighting,
            76, 104, 71, 104, 71, 108,
            Ability.Blaze, HiddenAbility: Ability.IronFist)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.BrickBreak,
                MoveInfo.Earthquake,
                MoveInfo.Flamethrower,
                MoveInfo.MachPunch,
                MoveInfo.ShadowClaw,
                MoveInfo.ThunderPunch
            }
        };
        
        public static PokemonSpecies Kangaskhan { get; } = new PokemonSpecies(115, nameof(Kangaskhan), Types.Normal, null,
            105, 95, 80, 40, 80, 90,
            Ability.EarlyBird, Ability.Scrappy, Ability.InnerFocus)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(115, "Mega Kangaskhan", Types.Normal, null,
                    105, 125, 100, 60, 100, 100, null), MegaStone.Kangaskhanite)
            },
            GenderRatio = GenderRatio.FemaleOnly,
            LearnSet =
            {
                MoveInfo.DizzyPunch,
                MoveInfo.Flamethrower,
                MoveInfo.IceBeam,
                MoveInfo.Thunderbolt
            }
        };

        public static PokemonSpecies Kommo { get; } = new PokemonSpecies(784, "Kommo-o", Types.Dragon, Types.Fighting,
            75, 110, 125, 100, 105, 85,
            Ability.BulletProof, Ability.Soundproof, Ability.Overcoat)
        {
            LearnSet =
            {
                MoveInfo.BrickBreak,
                MoveInfo.ClangingScales,
                MoveInfo.FlashCannon,
                MoveInfo.PoisonJab
            }
        };

        public static PokemonSpecies Leafeon { get; } = new PokemonSpecies(470, nameof(Leafeon), Types.Grass, null,
            65, 110, 130, 60, 65, 95,
            Ability.LeafGuard, HiddenAbility: Ability.Chlorophyll)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.GigaDrain,
                MoveInfo.RazorLeaf,
                MoveInfo.XScissor
            }
        };

        public static PokemonSpecies Lilligant { get; } = new PokemonSpecies(549, nameof(Lilligant), Types.Grass, null,
            70, 60, 75, 110, 75, 90,
            Ability.Chlorophyll, Ability.OwnTempo, Ability.LeafGuard)
        {
            GenderRatio = GenderRatio.FemaleOnly,
            LearnSet =
            {
                MoveInfo.EnergyBall,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.PetalBlizzard
            }
        };

        public static PokemonSpecies Lucario { get; } = new PokemonSpecies(448, nameof(Lucario), Types.Fighting, Types.Steel,
            70, 110, 70, 115, 70, 90,
            Ability.Steadfast, Ability.InnerFocus, Ability.Justified)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(448, "Mega Lucario", Types.Fighting, Types.Steel,
                    70, 145, 88, 140, 70, 112, Ability.Adaptability), MegaStone.Lucarionite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.AuraSphere,
                MoveInfo.CloseCombat,
                MoveInfo.DragonPulse,
                MoveInfo.MetalClaw
            }
        };

        public static PokemonSpecies LycanrocMidday { get; } = new PokemonSpecies(745, "Midday Lycanroc", Types.Rock, null,
            75, 115, 65, 55, 65, 112,
            Ability.KeenEye, Ability.SandRush, Ability.Steadfast)
        {
            LearnSet =
            {
                MoveInfo.Accelerock,
                MoveInfo.Crunch,
                MoveInfo.StoneEdge,
                MoveInfo.BrickBreak
            }
        };

        public static PokemonSpecies LycanrocMidnight { get; } = new PokemonSpecies(745, "Midnight Lycanroc", Types.Rock, null,
            85, 115, 75, 55, 75, 82,
            Ability.KeenEye, Ability.VitalSpirit, Ability.NoGuard)
        {
            LearnSet =
            {
                MoveInfo.BrickBreak,
                MoveInfo.Crunch,
                MoveInfo.RockSlide,
                MoveInfo.StoneEdge
            }
        };

        public static PokemonSpecies Magmortar { get; } = new PokemonSpecies(467, nameof(Magmortar), Types.Fire, null,
            75, 95, 67, 125, 95, 83,
            Ability.FlameBody, HiddenAbility: Ability.VitalSpirit)
        {
            GenderRatio = new GenderRatio(75, 25),
            LearnSet =
            {
                MoveInfo.BrickBreak,
                MoveInfo.Earthquake,
                MoveInfo.Flamethrower,
                MoveInfo.Thunderbolt
            }
        };

        public static PokemonSpecies Mawile { get; } = new PokemonSpecies(303, nameof(Mawile), Types.Steel, Types.Fairy,
            50, 85, 85, 55, 55, 50,
            Ability.HyperCutter, Ability.Intimidate)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(303, "Mega Mawile", Types.Steel, Types.Fairy,
                    50, 105, 125, 55, 95, 50, Ability.HugePower), MegaStone.Mawilite)
            },
            LearnSet =
            {
                MoveInfo.Crunch,
                MoveInfo.IronHead,
                MoveInfo.PlayRough,
                MoveInfo.RockTomb
            }
        };

        public static PokemonSpecies Meganium { get; } = new PokemonSpecies(154, nameof(Meganium), Types.Grass, null,
            80, 82, 100, 83, 100, 80,
            Ability.Overgrow, HiddenAbility: Ability.LeafGuard)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.PetalBlizzard,
                MoveInfo.BodySlam,
                MoveInfo.Earthquake,
                MoveInfo.FrenzyPlant
            }
        };

        public static PokemonSpecies Milotic { get; } = new PokemonSpecies(350, nameof(Milotic), Types.Water, null,
            95, 60, 79, 100, 125, 81,
            Ability.MarvelScale)
        {
            LearnSet =
            {
                MoveInfo.WaterPulse,
                MoveInfo.DragonPulse,
                MoveInfo.IceBeam,
                MoveInfo.BrutalSwing
            }
        };

        public static PokemonSpecies Mimikyu { get; } = new PokemonSpecies(778, nameof(Mimikyu), Types.Ghost, Types.Fairy,
            55, 90, 80, 50, 105, 96,
            Ability.Disguise)
        {
            LearnSet =
            {
                MoveInfo.PlayRough,
                MoveInfo.ShadowClaw,
                MoveInfo.WoodHammer,
                MoveInfo.Thunderbolt
            }
        };

        public static PokemonSpecies Ninetales { get; } = new PokemonSpecies(38, nameof(Ninetales), Types.Fire, null,
            73, 76, 75, 81, 100, 100,
            Ability.FlashFire, HiddenAbility: Ability.Drought)
        {
            GenderRatio = new GenderRatio(25, 75),
            LearnSet =
            {
                MoveInfo.Flamethrower,
                MoveInfo.QuickAttack,
                MoveInfo.Psychic,
                MoveInfo.EnergyBall
            }
        };

        public static PokemonSpecies NinetalesAlolan { get; } = new PokemonSpecies(38, "Alolan Ninetales", Types.Ice, Types.Fairy,
            73, 67, 75, 81, 100, 100,
            Ability.SnowCloak, HiddenAbility: Ability.SnowWarning)
        {
            GenderRatio = new GenderRatio(25, 75),
            LearnSet =
            {
                MoveInfo.DazzlingGleam,
                MoveInfo.IceBeam,
                MoveInfo.DarkPulse,
                MoveInfo.Blizzard,
                MoveInfo.IceShard
            }
        };

        public static PokemonSpecies Noivern { get; } = new PokemonSpecies(715, nameof(Noivern), Types.Flying, Types.Dragon,
            85, 70, 80, 97, 80, 123,
            Ability.Frisk, HiddenAbility: Ability.Telepathy)
        {
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.DragonClaw,
                MoveInfo.Boomburst,
                MoveInfo.WildCharge
            }
        };

        public static PokemonSpecies Pangoro { get; } = new PokemonSpecies(675, nameof(Pangoro), Types.Fighting, Types.Dark,
            95, 124, 78, 69, 71, 58,
            Ability.IronFist, HiddenAbility: Ability.Scrappy)
        {
            LearnSet =
            {
                MoveInfo.BrickBreak,
                MoveInfo.DarkPulse,
                MoveInfo.DragonClaw,
                MoveInfo.Earthquake,
                MoveInfo.GigaImpact,
                MoveInfo.HyperBeam,
                MoveInfo.PoisonJab,
                MoveInfo.RockTomb,
                MoveInfo.ShadowClaw,
                MoveInfo.SludgeBomb,
                MoveInfo.StoneEdge,
                MoveInfo.Surf,
                MoveInfo.XScissor
            }
        };

        public static PokemonSpecies Pelipper { get; } = new PokemonSpecies(279, nameof(Pelipper), Types.Water, Types.Flying,
            60, 50, 100, 95, 70, 65,
            Ability.KeenEye, Ability.Drizzle, Ability.RainDish)
        {
            LearnSet =
            {
                MoveInfo.Scald,
                MoveInfo.WingAttack,
                MoveInfo.IceBeam,
                MoveInfo.Hurricane,
                MoveInfo.AerialAce
            }
        };

        public static PokemonSpecies Pidgeot { get; } = new PokemonSpecies(18, nameof(Pidgeot), Types.Normal, Types.Flying,
            83, 80, 75, 70, 70, 101,
            Ability.KeenEye, Ability.TangledFeet, Ability.BigPecks)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(18, "Mega Pidgeot", Types.Normal, Types.Flying,
                    83, 80, 80, 135, 80, 121, Ability.NoGuard), MegaStone.Pidgeotite)
            },
            LearnSet =
            {
                MoveInfo.QuickAttack,
                MoveInfo.AerialAce,
                MoveInfo.AirSlash,
                MoveInfo.SteelWing
            }
        };

        public static PokemonSpecies Pikachu { get; } = new PokemonSpecies(25, nameof(Pikachu), Types.Electric, null,
            35, 55, 40, 50, 50, 90,
            Ability.Static)
        {
            LearnSet =
            {
                MoveInfo.QuickAttack,
                MoveInfo.Thunderbolt,
                MoveInfo.VoltTackle,
                MoveInfo.ElectroBall,
                MoveInfo.IronTail
            }
        };

        public static PokemonSpecies Politoed { get; } = new PokemonSpecies(186, nameof(Politoed), Types.Water, null,
            90, 75, 75, 90, 100, 70,
            Ability.WaterAbsorb, HiddenAbility: Ability.Drizzle)
        {
            LearnSet =
            {
                MoveInfo.Waterfall,
                MoveInfo.HyperVoice,
                MoveInfo.IceBeam,
                MoveInfo.BrickBreak
            }
        };

        public static PokemonSpecies Salamence { get; } = new PokemonSpecies(373, nameof(Salamence), Types.Dragon, Types.Flying,
            95, 135, 80, 110, 80, 100,
            Ability.Intimidate)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(373, "Mega Salamence", Types.Dragon, Types.Flying,
                    95, 145, 130, 120, 90, 120, Ability.Aerilate), MegaStone.Salamencite)
            },
            LearnSet =
            {
                MoveInfo.AerialAce,
                MoveInfo.Bite,
                MoveInfo.BrickBreak,
                MoveInfo.BrutalSwing,
                MoveInfo.Bulldoze,
                MoveInfo.Crunch,
                MoveInfo.DoubleEdge,
                MoveInfo.DracoMeteor,
                MoveInfo.DragonBreath,
                MoveInfo.DragonClaw,
                MoveInfo.Earthquake,
                MoveInfo.FireBlast,
                MoveInfo.FireFang,
                MoveInfo.Flamethrower,
                MoveInfo.GigaImpact,
                MoveInfo.Headbutt,
                MoveInfo.HyperBeam,
                MoveInfo.RockSlide,
                MoveInfo.RockTomb,
                MoveInfo.ShadowBall,
                MoveInfo.SteelWing,
                MoveInfo.StoneEdge,
                MoveInfo.ThunderFang,
                MoveInfo.ZenHeadbutt
            }
        };

        public static PokemonSpecies Salazzle { get; } = new PokemonSpecies(758, nameof(Salazzle), Types.Poison, Types.Fire,
            68, 64, 60, 111, 60, 117,
            Ability.Corrosion)
        {
            GenderRatio = GenderRatio.FemaleOnly,
            LearnSet =
            {
                MoveInfo.Acrobatics,
                MoveInfo.PoisonJab,
                MoveInfo.Flamethrower,
                MoveInfo.Venoshock,
                MoveInfo.DragonPulse,
                MoveInfo.PoisonGas
            }
        };

        public static PokemonSpecies Sceptile { get; } = new PokemonSpecies(254, nameof(Sceptile), Types.Grass, null,
            70, 85, 65, 105, 85, 120,
            Ability.Overgrow)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(254, "Mega Sceptile", Types.Grass, Types.Dragon,
                    70, 110, 75, 145, 85, 145, null), MegaStone.Sceptilite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.XScissor,
                MoveInfo.Earthquake,
                MoveInfo.GigaDrain,
                MoveInfo.DragonClaw
            }
        };

        public static PokemonSpecies Scizor { get; } = new PokemonSpecies(212, nameof(Scizor), Types.Bug, Types.Steel,
            70, 130, 100, 5, 80, 65,
            Ability.Swarm, Ability.Technician)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(212, "Mega Scizor", Types.Bug, Types.Steel,
                    70, 150, 140, 65, 100, 75, Ability.Technician), MegaStone.Scizorite)
            },
            LearnSet =
            {
                MoveInfo.RazorWind,
                MoveInfo.XScissor,
                MoveInfo.FlashCannon,
                MoveInfo.NightSlash
            }
        };
        
        public static PokemonSpecies Steelix { get; } = new PokemonSpecies(208, nameof(Steelix), Types.Steel, Types.Ground,
            75, 85, 200, 55, 65, 30,
            Ability.RockHead, Ability.Sturdy)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(208, "Mega Steelix", Types.Steel, Types.Ground,
                    75, 125, 230, 55, 95, 30, Ability.SandForce), MegaStone.Steelixite)
            },
            LearnSet =
            {
                MoveInfo.ThunderFang,
                MoveInfo.IceFang,
                MoveInfo.Earthquake,
                MoveInfo.FlashCannon
            }
        };

        public static PokemonSpecies Swampert { get; } = new PokemonSpecies(260, nameof(Swampert), Types.Water, Types.Ground,
            100, 110, 90, 85, 90, 60,
            Ability.Torrent)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(260, "Mega Swampert", Types.Water, Types.Ground,
                    100, 150, 110, 95, 110, 70, Ability.SwiftSwim), MegaStone.Swampertite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Waterfall,
                MoveInfo.MudShot,
                MoveInfo.HammerArm,
                MoveInfo.IceBeam
            }
        };

        public static PokemonSpecies Sylveon { get; } = new PokemonSpecies(700, nameof(Sylveon), Types.Fairy, null,
            95, 65, 65, 110, 130, 60,
            Ability.Pixilate)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Swift,
                MoveInfo.DrainingKiss,
                MoveInfo.DazzlingGleam,
                MoveInfo.ShadowBall
            }
        };

        public static PokemonSpecies Talonflame { get; } = new PokemonSpecies(663, nameof(Talonflame), Types.Fire, Types.Flying,
            78, 81, 71, 74, 69, 126,
            Ability.FlameBody, HiddenAbility: Ability.GaleWings)
        {
            LearnSet =
            {
                MoveInfo.FlameCharge,
                MoveInfo.BraveBird,
                MoveInfo.FireBlast,
                MoveInfo.SteelWing
            }
        };

        public static PokemonSpecies Torterra { get; } = new PokemonSpecies(389, nameof(Torterra), Types.Grass, Types.Ground,
            95, 109, 105, 75, 85, 56,
            Ability.Overgrow, HiddenAbility: Ability.ShellArmor)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Earthquake,
                MoveInfo.WoodHammer,
                MoveInfo.Crunch,
                MoveInfo.GigaDrain
            }
        };

        public static PokemonSpecies Toxicroak { get; } = new PokemonSpecies(454, nameof(Toxicroak), Types.Poison, Types.Fighting,
            83, 106, 65, 86, 65, 85,
            Ability.DrySkin, HiddenAbility: Ability.PoisonTouch)
        {
            LearnSet =
            {
                MoveInfo.PoisonJab,
                MoveInfo.MudBomb,
                MoveInfo.BrickBreak,
                MoveInfo.DarkPulse
            }
        };

        public static PokemonSpecies Typhlosion { get; } = new PokemonSpecies(157, nameof(Typhlosion), Types.Fire, null,
            78, 84, 78, 109, 85, 100,
            Ability.Blaze, HiddenAbility: Ability.FlashFire)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.Eruption,
                MoveInfo.DoubleEdge,
                MoveInfo.Flamethrower,
                MoveInfo.WildCharge
            }
        };

        public static PokemonSpecies Tyranitar { get; } = new PokemonSpecies(248, nameof(Tyranitar), Types.Rock, Types.Dark,
            100, 134, 110, 95, 100, 61,
            Ability.SandStream)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(248, "Mega Tyranitar", Types.Rock, Types.Dark,
                    100, 164, 150, 95, 120, 71, Ability.SandStream), MegaStone.Tyranitarite)
            },
            LearnSet =
            {
                MoveInfo.RockSlide,
                MoveInfo.DarkPulse,
                MoveInfo.Flamethrower,
                MoveInfo.HyperBeam
            }
        };

        public static PokemonSpecies Umbreon { get; } = new PokemonSpecies(197, nameof(Umbreon), Types.Dark, null,
            95, 65, 110, 60, 130, 65,
            Ability.Synchronize, HiddenAbility: Ability.InnerFocus)
        {
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.ShadowBall,
                MoveInfo.DarkPulse,
                MoveInfo.HyperBeam,
                MoveInfo.QuickAttack
            }

        };

        public static PokemonSpecies Venusaur { get; } = new PokemonSpecies(3, nameof(Venusaur), Types.Grass, Types.Poison,
            80, 82, 83, 100, 100, 80,
            Ability.Overgrow, HiddenAbility: Ability.Chlorophyll)
        {
            MegaEvolutions =
            {
                new MegaEvolution(new PokemonSpecies(3, "Mega Venusaur", Types.Grass, Types.Poison,
                    80, 100, 123, 122, 120, 80, Ability.ThickFat), MegaStone.Venusaurite)
            },
            GenderRatio = new GenderRatio(87.5, 12.5),
            LearnSet =
            {
                MoveInfo.PetalBlizzard,
                MoveInfo.Earthquake,
                MoveInfo.DoubleEdge,
                MoveInfo.SludgeBomb
            }
        };
    }
}