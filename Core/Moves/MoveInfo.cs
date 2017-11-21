using System.Collections.Generic;

namespace Poke
{
    public partial class MoveInfo
    {
        MoveInfo(string Name, Types Type, MoveKind Kind, int? Power, int? Accuracy, int PP, DamageFunction DamageFunction = null)
        {
            this.Name = Name;
            this.Type = Type;
            this.Kind = Kind;
            this.Power = Power;
            this.PP = PP;
            this.Accuracy = Accuracy;

            this.DamageFunction = DamageFunction ?? DamageFunctionFactory.DefaultDamageFunction;
            PowerFunction = DamageFunctionFactory.DefaultPowerFunction;
            AccuracyFunction = DamageFunctionFactory.DefaultAccuracyFunction;
            
            Lists.Moves.Add(this);
        }

        public PowerFunction PowerFunction { get; private set; }

        public PowerFunction AccuracyFunction { get; private set; }

        public string Description { get; private set; }

        public bool OneHitKO { get; private set; }
        
        public MoveTarget Target { get; private set; }

        public ContestCategory ContestCategory { get; private set; }

        public string Name { get; }

        public Types Type { get; }

        public MoveKind Kind { get; }

        public int? Power { get; }
        
        public int PP { get; }

        public int Priority { get; private set; }

        public int? Accuracy { get; }

        public MoveFlags Flags { get; private set; }

        public CriticalHit CriticalHit { get; private set; }

        public double Recoil { get; private set; }

        public double Drain { get; private set; }

        public double? Flinch { get; private set; }

        public double? ConfuseTarget { get; private set; }
        
        public List<StatChange> PreStatChanges { get; } = new List<StatChange>();

        public List<StatChange> PostStatChanges { get; } = new List<StatChange>();

        public NonVolatileStatusDefinition NonVolatileStatus { get; set; }

        public DamageFunction DamageFunction { get; }
    }
}