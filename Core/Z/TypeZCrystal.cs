using System;
using System.Collections.Generic;

namespace Poke
{
    public class TypeZCrystal : ZCrystal
    {
        readonly Func<Move, MoveInfo> _upgrader;
        
        TypeZCrystal(string Name, Types Type, string MoveName, Func<Move, MoveInfo> Upgrader) : base(Name, Type, MoveName)
        {
            _upgrader = Upgrader;

            Description = $"Upgrades a {Type} type move to {MoveName}";
        }
        
        public override bool Supports(Pokemon Pokemon, Move Move)
        {
            return Move.Type == Type && Move.Kind != MoveKind.Status;
        }

        public override ZMove Upgrade(Move Move)
        {
            return new ZMove(_upgrader(Move), Move);
        }

        public static int GetZPower(MoveInfo MoveInfo)
        {
            if (MoveInfo == MoveInfo.MegaDrain)
                return 120;

            if (MoveInfo == MoveInfo.Hex)
                return 160;

            if (MoveInfo == MoveInfo.VCreate)
                return 220;

            // Weather Ball: 160
            // Gear Grind: 180
            // Flying Press: 170
            // Core Enforcer: 140

            var power = MoveInfo.Power;

            if (power >= 140)
                return 200;

            if (power >= 130)
                return 195;

            if (power >= 120)
                return 190;

            if (power >= 110)
                return 185;

            if (power >= 100)
                return 180;

            if (power >= 90)
                return 175;

            if (power >= 80)
                return 160;

            if (power >= 70)
                return 140;

            if (power >= 60)
                return 120;
            
            return 100;
        }

        static TypeZCrystal MakeCrystal(string CrystalName, Types Type, string MoveName)
        {
            return new TypeZCrystal(CrystalName, Type, MoveName,
                M => new MoveInfo(MoveName, Type, M.Kind, GetZPower(M.Info), null, 1, null, true));
        }

        public static IReadOnlyDictionary<Types, TypeZCrystal> Crystrals { get; } = new Dictionary<Types, TypeZCrystal>
        {
            { Types.Normal, MakeCrystal("Normalium Z", Types.Normal, "Breakneck Blitz") },
            { Types.Fighting, MakeCrystal("Fightinium Z", Types.Fighting, "All-Out Pummeling") },
            { Types.Flying, MakeCrystal("Flyinium Z", Types.Flying, "Supersonic Skystrike") },
            { Types.Poison, MakeCrystal("Poisonium Z", Types.Poison, "Acid Downpour") },
            { Types.Ground, MakeCrystal("Groundium Z", Types.Ground, "Tectonic Rage") },
            { Types.Rock, MakeCrystal("Rockium Z", Types.Rock, "Continental Crush") },
            { Types.Bug, MakeCrystal("Buginium Z", Types.Bug, "Savage Spin-Out") },
            { Types.Ghost, MakeCrystal("Ghostium Z", Types.Ghost, "Never-Ending Nightmare") },
            { Types.Steel, MakeCrystal("Steelium Z", Types.Steel, "Corkscrew Crash") },
            { Types.Fire, MakeCrystal("Firium Z", Types.Fire, "Inferno Overdrive") },
            { Types.Water, MakeCrystal("Waterium Z", Types.Water, "Hydro Vortex") },
            { Types.Grass, MakeCrystal("Grassium Z", Types.Grass, "Bloom Doom") },
            { Types.Electric, MakeCrystal("Electrium Z", Types.Electric, "Gigavolt Havoc") },
            { Types.Psychic, MakeCrystal("Psychium Z", Types.Psychic, "Shattered Psyche") },
            { Types.Ice, MakeCrystal("Icium Z", Types.Ice, "Subzero Slammer") },
            { Types.Dragon, MakeCrystal("Dragonium Z", Types.Dragon, "Devastating Drake") },
            { Types.Dark, MakeCrystal("Darkinium Z", Types.Dark, "Black Hole Eclipse") },
            { Types.Fairy, MakeCrystal("Fairium Z", Types.Fairy, "Twinkle Tackle") }
        };
    }
}