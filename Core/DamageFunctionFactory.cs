using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poke
{
    public static class DamageFunctionFactory
    {
        public static readonly PowerFunction DefaultPowerFunction = (A, M, O, B) => M.Info.Power;
        public static readonly PowerFunction DefaultAccuracyFunction = (A, M, O, B) => M.Info.Accuracy;
        public static readonly DamageFunction DefaultDamageFunction = async (A, M, O, B) => await Default(A, M, O, B);

        static double GetAccuracyMultiplier(int AccuracyStage, int EvasionStage)
        {
            // -6 to +6
            var stage = (AccuracyStage - EvasionStage).Clip(-6, 6);

            if (stage > 0)
                return (stage + 3) / 3.0;

            if (stage < 0)
                return 3.0 / (-stage + 3);

            return 1;
        }

        static async Task<bool> IsHit(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            var accuracy = Move.Info.AccuracyFunction?.Invoke(Attacker, Move, Opponent, Battle);

            if (accuracy == null)
                return true;

            // Wonder Skin
            if (Opponent.Ability == Ability.WonderSkin && Move.Kind == MoveKind.Status)
                accuracy /= 2;

            // No Guard
            if (Attacker.Ability == Ability.NoGuard || Opponent.Ability == Ability.NoGuard)
                return true;

            var accuracyMultiplier = GetAccuracyMultiplier(Attacker.Stats.GetStage(Stats.Accuracy), Opponent.Stats.GetStage(Stats.Evasiveness));

            // Compound Eyes
            if (Attacker.Ability == Ability.CompoundEyes && !Move.Info.OneHitKO)
                accuracyMultiplier *= 1.3;

            // Tangled Feet
            if (Attacker.Ability == Ability.TangledFeet && Attacker.ConfusionCounter > 0)
                accuracyMultiplier *= 2;

            // Bright Powder
            if (Opponent.HeldItem == HeldItem.BrightPowder)
                accuracyMultiplier *= 0.9;
            
            // Hustle
            if (Move.Kind == MoveKind.Physical && Attacker.Ability == Ability.Hustle)
                accuracy *= 0.8;

            var probability = accuracy * accuracyMultiplier;

            // Snow Cloak
            if (Battle.SuppressWeather == 0 && Opponent.Ability == Ability.SnowCloak && Battle.Weather == Weather.Hail)
                probability /= 1.25;

            if (BattleViewModel.Random.Next(100) > probability)
            {
                await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)} avoided the attack");

                return false;
            }

            return true;
        }
        
        public static async Task StatChanges(Pokemon Attacker, Pokemon Opponent, IEnumerable<StatChange> StatChanges, BattleViewModel Battle)
        {
            foreach (var statChange in StatChanges)
            {
                if (statChange.Probability < 1)
                {
                    if (BattleViewModel.Random.NextDouble() > statChange.Probability)
                        continue;
                }

                var stageChange = statChange.StageChange;

                var victim = statChange.Self ? Attacker : Opponent;

                if (victim.Stats.CurrentHP == 0)
                    continue;

                // Clear Body, White Smoke, Full Metal Body
                if (stageChange < 0 && !statChange.Self && victim.Ability.Is(Ability.ClearBody, Ability.WhiteSmoke, Ability.FullMetalBody))
                {
                    await Battle.ShowAbility(victim);

                    await Battle.WriteStatus($"{Battle.GetStatusName(victim)}'s {statChange.Stat.SpaceAtCapitals()} was not lowered.");

                    continue;
                }

                // Contrary
                if (victim.Ability == Ability.Contrary)
                {
                    stageChange = -stageChange;
                }

                switch (statChange.Stat)
                {
                    case Stats.Attack:
                        if (stageChange < 0 && victim.Ability == Ability.HyperCutter)
                        {
                            await Battle.ShowAbility(victim);

                            await Battle.WriteStatus($"{Battle.GetStatusName(victim)} Attack was not lowered");

                            continue;
                        }

                        break;

                    case Stats.Defense:
                        if (stageChange < 0 && victim.Ability == Ability.BigPecks)
                        {
                            await Battle.ShowAbility(victim);

                            await Battle.WriteStatus($"{Battle.GetStatusName(victim)} Defense was not lowered");

                            continue;
                        }

                        break;

                    case Stats.Accuracy:
                        if (stageChange < 0 && victim.Ability == Ability.KeenEye)
                        {
                            await Battle.ShowAbility(victim);

                            await Battle.WriteStatus($"{Battle.GetStatusName(victim)} Accuracy was not lowered");

                            continue;
                        }

                        break;
                }

                stageChange = victim.Stats.ChangeStage(statChange.Stat, stageChange);

                if (stageChange == 0)
                {
                    await Battle.WriteStatus($"{Battle.GetStatusName(victim)}'s {statChange.Stat.SpaceAtCapitals()} won't go any {(statChange.StageChange > 0 ? "higher" : "lower")}");
                }
                else
                {
                    var sharply = stageChange > 1 || stageChange < -1;

                    await Battle.WriteStatus($"{Battle.GetStatusName(victim)}'s {statChange.Stat.SpaceAtCapitals()} {(stageChange > 0 ? "rose" : "fell")}{(sharply ? " sharply" : "")}");
                }
            }
        }

        public static async Task StatChange(Pokemon Pokemon, Stats Stat, int StageChange, BattleViewModel Battle)
        {
            await StatChanges(Pokemon, null, new[] {new StatChange(Stat, StageChange: StageChange)}, Battle);
        }

        public static async Task Recover(Pokemon Attacker, int Amount, BattleViewModel Battle)
        {
            var maxHp = Attacker.Stats.MaxHP;

            if (Attacker.Stats.CurrentHP < maxHp)
            {
                Attacker.Stats.Heal(Amount);

                await Battle.WriteStatus($"{Battle.GetStatusName(Attacker)}'s HP was restored");
            }
            else await Battle.WriteStatus($"{Battle.GetStatusName(Attacker)}'s already has full HP");
        }

        public static async Task AlterWeather(Pokemon Pokemon, Weather Weather, BattleViewModel Battle)
        {
            if (Battle.Weather.Is(Weather.ExtremelyHarshSunlight, Weather.HeavyRain, Weather.MysteriousAirCurrent))
            {
                await Battle.WriteStatus("But it failed");

                return;
            }
            
            Battle.Weather = Weather;
            Battle.WeatherDuration = 5;

            switch (Weather)
            {
                case Weather.Rain:
                    if (Pokemon.HeldItem == HeldItem.DampRock)
                        Battle.WeatherDuration = 8;

                    await Battle.WriteStatus("It started to rain");
                    break;

                case Weather.HarshSunlight:
                    if (Pokemon.HeldItem == HeldItem.HeatRock)
                        Battle.WeatherDuration = 8;

                    await Battle.WriteStatus("The sunlight turned harsh");
                    break;

                case Weather.Hail:
                    if (Pokemon.HeldItem == HeldItem.IcyRock)
                        Battle.WeatherDuration = 8;

                    await Battle.WriteStatus("It started to hail");
                    break;

                case Weather.Sandstorm:
                    if (Pokemon.HeldItem == HeldItem.SmoothRock)
                        Battle.WeatherDuration = 8;

                    await Battle.WriteStatus("A sandstorm kicked in");
                    break;
            }
        }

        static double GetCriticalHitProbability(int Stage)
        {
            switch (Stage)
            {
                case 0:
                    return 0.0625;

                case 1:
                    return 0.125;

                case 2:
                    return 0.5;
            }

            return Stage >= 3 ? 1 : 0;
        }

        static bool IsCriticalHit(Pokemon Attacker, Move Move, Pokemon Opponent)
        {
            var stage = 0;
            
            // Battle Armor, Shell Armor
            if (Opponent.Ability.Is(Ability.BattleArmor, Ability.ShellArmor))
                return false;
            
            // Super Luck
            if (Attacker.Ability == Ability.SuperLuck)
                ++stage;

            // Merciless
            if (Attacker.Ability == Ability.Merciless
                && Opponent.NonVolatileStatus.Is(NonVolatileStatus.Poison, NonVolatileStatus.BadPoison))
                return true;

            switch (Move.Info.CriticalHit) {
                case CriticalHit.Never:
                    return false;

                case CriticalHit.Always:
                    return true;

                case CriticalHit.OneHigher:
                    ++stage;
                    break;
            }

            var probability = GetCriticalHitProbability(stage);
            
            return BattleViewModel.Random.NextDouble() < probability;
        }
        
        static double WeatherPowerMultiplier(Move Move, Weather Weather)
        {
            switch (Move.Type)
            {
                case Types.Fire:
                    switch (Weather)
                    {
                        case Weather.HarshSunlight:
                        case Weather.ExtremelyHarshSunlight:
                            return 1.5;

                        case Weather.Rain:
                            return 0.5;
                    }

                    break;

                case Types.Water:
                    switch (Weather)
                    {
                        case Weather.HarshSunlight:
                            return 0.5;

                        case Weather.Rain:
                        case Weather.HeavyRain:
                            return 1.5;
                    }

                    break;
            }

            return 1;
        }

        static double GetAttack(Pokemon Attacker, MoveKind MoveKind, BattleViewModel Battle, bool CriticalHit)
        {
            if (MoveKind == MoveKind.Special)
            {
                double special = Attacker.Stats.GetValue(Stats.SpecialAttack, CriticalHit);
                
                // Flare Boost
                if (Attacker.Ability == Ability.FlareBoost && Attacker.NonVolatileStatus == NonVolatileStatus.Burn)
                    special *= 1.5;

                // Defeatist
                else if (Attacker.Ability == Ability.Defeatist && Attacker.Stats.CurrentHP <= Attacker.Stats.MaxHP / 2)
                    special /= 2;

                // Solar Power
                else if (Battle.SuppressWeather == 0 && Attacker.Ability == Ability.SolarPower && Battle.Weather.Is(Weather.HarshSunlight, Weather.ExtremelyHarshSunlight))
                    special *= 1.5;

                // Light Ball
                if (Attacker.HeldItem == HeldItem.LightBall && Attacker.Species == PokemonSpecies.Pikachu)
                    special *= 2;

                return special;
            }
            
            double physical = Attacker.Stats.GetValue(Stats.Attack, CriticalHit);
            
            // Huge Power, Pure Power
            if (Attacker.Ability.Is(Ability.HugePower, Ability.PurePower))
                physical *= 2;

            // Toxic Boost
            else if (Attacker.Ability == Ability.ToxicBoost &&
                     Attacker.NonVolatileStatus.Is(NonVolatileStatus.Poison, NonVolatileStatus.BadPoison))
                physical *= 1.5;

            // Guts
            else if (Attacker.Ability == Ability.Guts
                && Attacker.NonVolatileStatus != NonVolatileStatus.None)
                physical *= 1.5;

            // Defeatist
            else if (Attacker.Ability == Ability.Defeatist && Attacker.Stats.CurrentHP <= Attacker.Stats.MaxHP / 2)
                physical /= 2;

            // Light Ball
            if (Attacker.HeldItem == HeldItem.LightBall && Attacker.Species == PokemonSpecies.Pikachu)
                physical *= 2;

            return physical;
        }

        static double GetDefense(Pokemon Opponent, MoveKind MoveKind, BattleViewModel Battle, bool CriticalHit)
        {
            if (MoveKind == MoveKind.Special)
            {
                double special = Opponent.Stats.GetValue(Stats.SpecialDefense, CriticalHit);
                
                if (Battle.SuppressWeather == 0 && Battle.Weather == Weather.Sandstorm && Opponent.Is(Types.Rock))
                    special *= 1.5;

                return special;
            }
            
            double physical = Opponent.Stats.GetValue(Stats.Defense, CriticalHit);
            
            // Marvel Scale
            if (Opponent.Ability == Ability.MarvelScale
                && Opponent.NonVolatileStatus != NonVolatileStatus.None)
                physical *= 1.5;

            return physical;
        }

        public static async Task ConfusedSelfAttack(Pokemon Pokemon, BattleViewModel Battle)
        {
            // Typeless 40 base power Physical attack
            var damage = GetBaseDamage(Pokemon.Level, 40,
                GetAttack(Pokemon, MoveKind.Physical, Battle, false),
                GetDefense(Pokemon, MoveKind.Physical, Battle, false));

            await Pokemon.Stats.Damage((int) damage, Battle);

            await Battle.WriteStatus($"{Battle.GetStatusName(Pokemon)} hurt itself in confusion");
        }

        static double GetBaseDamage(int Level, double Power, double Attack, double Defense)
        {
            return (2.0 * Level / 5 + 2) * Power * Attack / Defense / 50 + 2;
        }

        public static async Task Default(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            await StatChanges(Attacker, Opponent, Move.Info.PreStatChanges, Battle);

            if (!await IsHit(Attacker, Move, Opponent, Battle))
                return;

            if (await Absorb(Move, Opponent, Battle))
                return;

            var power = GetPower(Attacker, Move, Opponent, Battle);

            if (power != null)
            {
                var criticalHit = IsCriticalHit(Attacker, Move, Opponent);

                var attack = GetAttack(Attacker, Move.Kind, Battle, criticalHit);
                var defense = GetDefense(Opponent, Move.Kind, Battle, criticalHit);
                
                var damage = GetBaseDamage(Attacker.Level, power.Value, attack, defense);

                damage *= SameTypeAttackBoost(Attacker, Move.Type);

                if (Battle.SuppressWeather == 0)
                {
                    if (Battle.Weather == Weather.HeavyRain && Move.Type == Types.Fire)
                        damage = 0;

                    else if (Battle.Weather == Weather.ExtremelyHarshSunlight && Move.Type == Types.Water)
                        damage = 0;
                }

                // Weather can nullify damage
                if (damage == 0)
                {
                    await Battle.WriteStatus("But it failed");

                    return;
                }

                var typeEffectivenessDisplays = new List<string>();
                
                var typeEffect = TypeEffectiveness(Attacker, Move, Opponent, Battle, typeEffectivenessDisplays);

                if (typeEffect == 0)
                {
                    await Battle.WriteStatus(typeEffectivenessDisplays[0]);

                    return;
                }

                // Burn
                if (Move.Kind == MoveKind.Physical
                    && Attacker.Ability != Ability.Guts
                    && Attacker.NonVolatileStatus == NonVolatileStatus.Burn)
                    damage /= 2;

                // Heatproof
                if (Move.Type == Types.Fire && Opponent.Ability == Ability.Heatproof)
                    damage /= 2;

                // Fur Coat
                else if (Move.Kind == MoveKind.Physical && Opponent.Ability == Ability.FurCoat)
                    damage /= 2;

                // Water Bubble
                else if (Move.Type == Types.Fire && Opponent.Ability == Ability.WaterBubble)
                    damage /= 2;

                // Hustle
                if (Move.Kind == MoveKind.Physical && Attacker.Ability == Ability.Hustle)
                    damage *= 1.5;

                // Thick Fat
                else if (Move.Type.Is(Types.Fire, Types.Ice) && Attacker.Ability == Ability.ThickFat)
                    damage /= 2;

                // Tough Claws
                else if (Move.Info.Flags.HasFlag(MoveFlags.Contact) && Attacker.Ability == Ability.ToughClaws)
                    damage *= 1.33;

                damage *= typeEffect;
                
                if (criticalHit)
                    damage *= Attacker.Ability == Ability.Sniper ? 2.25 : 1.5;

                if (Attacker.Stats.CurrentHP <= Attacker.Stats.MaxHP / 3)
                {
                    // Blaze
                    if (Attacker.Ability == Ability.Blaze && Move.Type == Types.Fire)
                        damage *= 1.5;

                    // Overgrow
                    if (Attacker.Ability == Ability.Overgrow && Move.Type == Types.Grass)
                        damage *= 1.5;

                    // Torrent
                    if (Attacker.Ability == Ability.Torrent && Move.Type == Types.Water)
                        damage *= 1.5;

                    // Swarm
                    if (Attacker.Ability == Ability.Swarm && Move.Type == Types.Bug)
                        damage *= 1.5;
                }

                // Multiscale
                if (Opponent.Ability == Ability.Multiscale && Opponent.Stats.CurrentHP == Opponent.Stats.MaxHP)
                    damage /= 2;

                else if (Opponent.Ability == Ability.DrySkin)
                    damage *= 1.25;

                // Rivalry
                if (Attacker.Ability == Ability.Rivalry
                    && Attacker.Gender != Gender.Genderless
                    && Opponent.Gender != Gender.Genderless)
                {
                    damage *= Attacker.Gender == Opponent.Gender ? 1.25 : 0.75;
                }

                // Flash Fire
                if (Attacker.Ability == Ability.FlashFire
                    && Move.Type == Types.Fire
                    && Attacker.AbilityData == 1)
                    damage *= 1.5;

                // Random
                damage *= BattleViewModel.Random.Next(85, 101) / 100.0;

                // Damage is reduced by 25% when there are Multiple Targets
                if (Move.Multitargets)
                    damage *= 0.75;

                if (damage > Opponent.Stats.CurrentHP)
                {
                    damage = Opponent.Stats.CurrentHP;
                }

                if (damage < 1)
                    damage = 1;

                // Disguise
                if (Opponent.Ability == Ability.Disguise)
                {
                    await Battle.ShowAbility(Opponent);

                    await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)}'s disguise was busted");

                    return;
                }

                await Opponent.Stats.Damage((int)damage, Battle);

                foreach (var display in typeEffectivenessDisplays)
                {
                    await Battle.WriteStatus(display);
                }
                
                if (criticalHit)
                    await Battle.WriteStatus("It's a critical hit");

                if (damage > 0 && Move.Info.Drain > 0)
                {
                    await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)} had its energy drained");

                    var drain = (int)(Move.Info.Drain * damage);
                    
                    Attacker.Stats.Heal(drain);
                }

                if (damage > 0 && Move.Info.Recoil > 0 && Attacker.Ability != Ability.RockHead)
                {
                    await Battle.WriteStatus($"{Battle.GetStatusName(Attacker)} is hit by recoil");

                    var recoil = (int)(Move.Info.Recoil * damage);
                    
                    await Attacker.Stats.Damage(recoil, Battle);
                }

                // Cell Battery
                if (Opponent.HeldItem == HeldItem.CellBattery && Move.Type == Types.Electric)
                {
                    await StatChange(Opponent, Stats.Attack, 1, Battle);

                    Opponent.HeldItem = null;
                }

                // Anger Point
                if (criticalHit && Opponent.Ability == Ability.AngerPoint)
                {
                    await Battle.ShowAbility(Opponent);

                    await StatChange(Opponent, Stats.Attack, 12, Battle);
                }

                // Cursed Body
                if (Opponent.Ability == Ability.CursedBody && BattleViewModel.Random.Next(100) < 30)
                {
                    await Battle.ShowAbility(Opponent);

                    Move.Disabled = true;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Attacker)}'s {Move} was disabled");
                }
            }

            // Justified
            if (Move.Type == Types.Dark && Opponent.Ability == Ability.Justified)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Attack, 1, Battle);
            }

            // Stamina
            else if (Move.Kind != MoveKind.Status && Opponent.Ability == Ability.Stamina)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Defense, 1, Battle);
            }

            // Rattled
            else if (Opponent.Ability == Ability.Rattled)
            {
                if (Move.Type.Is(Types.Dark, Types.Ghost, Types.Bug))
                {
                    await Battle.ShowAbility(Opponent);

                    await StatChange(Opponent, Stats.Speed, 1, Battle);
                }
            }

            // Weak Armor
            else if (Move.Kind == MoveKind.Physical && Opponent.Ability == Ability.WeakArmor)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Speed, 1, Battle);
                await StatChange(Opponent, Stats.Defense, -1, Battle);
            }

            // Water Compaction
            else if (Opponent.Ability == Ability.WaterCompaction)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Defense, 2, Battle);
            }

            await ContactEffects(Attacker, Move, Opponent, Battle);

            await StatChanges(Attacker, Opponent, Move.Info.PostStatChanges, Battle);

            await GiveNonVolatileStatus(Move.Info.NonVolatileStatus, Opponent, Attacker, Battle);

            if (!Opponent.IsFainted)
            {
                if (Move.Info.Flinch != null)
                    Flinch(Opponent, Move.Info.Flinch.Value);
                else if (Attacker.Ability == Ability.Stench)
                {
                    Flinch(Opponent, 0.1);
                }

                if (Move.Info.ConfuseTarget != null)
                    await Confuse(Opponent, Move.Info.ConfuseTarget.Value, Battle);
            }

            if (Move.Info.Flags.HasFlag(MoveFlags.Recharge))
                Attacker.Recharging = true;
        }

        static async Task<bool> Absorb(Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            // Flash Fire
            if (Opponent.Ability == Ability.FlashFire && Move.Type == Types.Fire)
            {
                await Battle.ShowAbility(Opponent);

                await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)} absorbed the attack");

                // Hit by a fire type move
                Opponent.AbilityData = 1;

                return true;
            }

            // Motor Drive
            if (Opponent.Ability == Ability.MotorDrive && Move.Type == Types.Electric
                && Opponent.GetTypeEffectiveness(Types.Electric) > 0)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Speed, 1, Battle);

                return true;
            }

            // Sap Sipper
            if (Opponent.Ability == Ability.SapSipper && Move.Type == Types.Grass)
            {
                await Battle.ShowAbility(Opponent);

                await StatChange(Opponent, Stats.Attack, 1, Battle);

                return true;
            }

            // Volt Absorb
            if (Opponent.Ability == Ability.VoltAbsorb && Move.Type == Types.Electric
                && Opponent.GetTypeEffectiveness(Types.Electric) > 0)
            {
                await Battle.ShowAbility(Opponent);

                if (Opponent.Stats.Heal(Opponent.Stats.MaxHP / 4))
                {
                    await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)} absorbed the attack.");
                }

                return true;
            }

            // Water Absorb, Dry Skin
            if (Opponent.Ability.Is(Ability.WaterAbsorb, Ability.DrySkin) && Move.Type == Types.Water
                && Opponent.GetTypeEffectiveness(Types.Water) > 0)
            {
                await Battle.ShowAbility(Opponent);

                if (Opponent.Stats.Heal(Opponent.Stats.MaxHP / 4))
                {
                    await Battle.WriteStatus($"{Battle.GetStatusName(Opponent)} absorbed the attack.");
                }

                return true;
            }

            return false;
        }

        static double? GetPower(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            var power = Move.Info.PowerFunction?.Invoke(Attacker, Move, Opponent, Battle);

            if (power == null)
                return null;

            // Technician
            if (power <= 60 && Attacker.Ability == Ability.Technician)
                power *= 1.5;

            // Aerilate
            else if (Attacker.Ability == Ability.Aerilate && Move.Info.Type == Types.Normal)
                power *= 1.2;

            // Pixilate
            else if (Attacker.Ability == Ability.Pixilate && Move.Info.Type == Types.Normal)
                power *= 1.2;

            // Refrigerate
            else if (Attacker.Ability == Ability.Refrigerate && Move.Info.Type == Types.Normal)
                power *= 1.2;

            // Galvanize
            else if (Attacker.Ability == Ability.Galvanize && Move.Info.Type == Types.Normal)
                power *= 1.2;

            // Strong Jaws
            else if (Move.Info.Flags.HasFlag(MoveFlags.Bite) && Attacker.Ability == Ability.StrongJaws)
                power *= 1.5;

            // Mega Launcher
            else if (Move.Info.Flags.HasFlag(MoveFlags.Pulse) && Attacker.Ability == Ability.MegaLauncher)
                power *= 1.5;

            // Iron Fist
            else if (Move.Info.Flags.HasFlag(MoveFlags.Punch) && Attacker.Ability == Ability.IronFist)
                power *= 1.2;

            // Reckless
            else if (Move.Info.Recoil > 0 && Attacker.Ability == Ability.Reckless)
                power *= 1.2;

            // Sand Force
            else if (Battle.SuppressWeather == 0 && Attacker.Ability == Ability.SandForce && Battle.Weather == Weather.Sandstorm)
            {
                if (Move.Type == Types.Rock || Move.Type == Types.Ground || Move.Type == Types.Steel)
                    power *= 1.3;
            }

            // Water Bubble
            else if (Attacker.Ability == Ability.WaterBubble && Move.Type == Types.Water)
                power *= 2;

            // Steelworker
            else if (Attacker.Ability == Ability.Steelworker && Move.Type == Types.Steel)
                power *= 1.5;

            if (Battle.SuppressWeather == 0)
                power *= WeatherPowerMultiplier(Move, Battle.Weather);

            // Type Enhancement
            if (Attacker.HeldItem is TypeEnhancement enhancement && enhancement.Type == Move.Type)
                power *= enhancement.Multiplier;

            // Type Gems
            else if (Attacker.HeldItem is Gem gem && Move.Type == gem.Type)
            {
                power *= 1.3;

                Attacker.HeldItem = null;
            }

            return power;
        }

        static async Task ContactEffects(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle)
        {
            // Long Reach
            if (Attacker.Ability == Ability.LongReach)
                return;

            if (Move.Info.Flags.HasFlag(MoveFlags.Contact))
            {
                #region Opponent Abilities
                // Static
                if (Opponent.Ability == Ability.Static && Attacker.NonVolatileStatus == NonVolatileStatus.None)
                {
                    await GiveNonVolatileStatus(new NonVolatileStatusDefinition(NonVolatileStatus.Paralysis, 0.3), Attacker, Opponent, Battle, () => Battle.ShowAbility(Opponent));
                }

                // Flame Body
                else if (Opponent.Ability == Ability.FlameBody)
                {
                    await GiveNonVolatileStatus(new NonVolatileStatusDefinition(NonVolatileStatus.Burn, 0.3), Attacker, Opponent, Battle, () => Battle.ShowAbility(Opponent));
                }

                // Gooey, Tangling Hair
                else if (Opponent.Ability.Is(Ability.Gooey, Ability.TanglingHair))
                {
                    await StatChange(Attacker, Stats.Speed, -1, Battle);
                }

                // Iron Barbs, Rough Skin
                else if (Opponent.Ability.Is(Ability.IronBarbs, Ability.RoughSkin))
                {
                    await Battle.ShowAbility(Opponent);

                    await Battle.WriteStatus($"{Battle.GetStatusName(Attacker)} took damaged");

                    await Attacker.Stats.Damage(Attacker.Stats.MaxHP / 8, Battle);
                }

                // Poison Point
                else if (Opponent.Ability == Ability.PoisonPoint)
                {
                    await GiveNonVolatileStatus(new NonVolatileStatusDefinition(NonVolatileStatus.Poison, 0.3), Attacker, Opponent, Battle, () => Battle.ShowAbility(Opponent));
                }

                // Effect Spore
                else if (Opponent.Ability == Ability.EffectSpore)
                {
                    var status = NonVolatileStatus.None;

                    switch (BattleViewModel.Random.Next(3))
                    {
                        case 0:
                            status = NonVolatileStatus.Poison;
                            break;

                        case 1:
                            status = NonVolatileStatus.Paralysis;
                            break;

                        case 2:
                            status = NonVolatileStatus.Sleep;
                            break;
                    }

                    await GiveNonVolatileStatus(new NonVolatileStatusDefinition(status, 0.3), Attacker, Opponent, Battle, () => Battle.ShowAbility(Opponent));
                }
                #endregion

                #region Attacker abilities
                // Poison Touch
                if (Attacker.Ability == Ability.PoisonTouch)
                {
                    await GiveNonVolatileStatus(new NonVolatileStatusDefinition(NonVolatileStatus.Poison, 0.3), Opponent, Attacker, Battle, () => Battle.ShowAbility(Attacker));
                }
                #endregion
            }
        }

        static void Flinch(Pokemon Target, double Probability)
        {
            if (Target.AlreadyMoved)
                return;
            
            if (BattleViewModel.Random.NextDouble() > Probability)
                return;

            // Inner Focus
            if (Target.Ability == Ability.InnerFocus)
                return;

            Target.Flinched = true;
        }

        static async Task Confuse(Pokemon Target, double Probability, BattleViewModel Battle)
        {
            if (Target.ConfusionCounter > 0)
                return;

            if (BattleViewModel.Random.NextDouble() > Probability)
                return;

            // Own Tempo
            if (Target.Ability == Ability.OwnTempo)
                return;

            Target.ConfusionCounter = BattleViewModel.Random.Next(1, 5);

            await Battle.WriteStatus($"{Battle.GetStatusName(Target)} is confused.");
        }
        
        static async Task GiveNonVolatileStatus(NonVolatileStatusDefinition Definition, Pokemon Target, Pokemon Attacker, BattleViewModel Battle, Func<Task> AbilityCallback = null)
        {
            if (Definition == null)
                return;

            if (Target.Stats.CurrentHP == 0)
                return;

            if (Target.NonVolatileStatus != NonVolatileStatus.None)
                return;

            // Leaf Guard
            if (Battle.SuppressWeather == 0 && Target.Ability == Ability.LeafGuard &&
                Battle.Weather.Is(Weather.HarshSunlight, Weather.ExtremelyHarshSunlight))
            {
                return;
            }

            if (Definition.Probability < 1 && BattleViewModel.Random.NextDouble() > Definition.Probability)
                return;
            
            switch (Definition.Status)
            {
                case NonVolatileStatus.Burn:
                    if (Target.Is(Types.Fire))
                        return;

                    // Water Veil, Water Bubble
                    if (Target.Ability.Is(Ability.WaterVeil, Ability.WaterBubble))
                        return;
                    
                    if (AbilityCallback != null)
                        await AbilityCallback.Invoke();

                    Target.NonVolatileStatus = NonVolatileStatus.Burn;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Target)} is burned");

                    break;

                case NonVolatileStatus.Freeze:
                    if (Battle.SuppressWeather == 0 && Battle.Weather.Is(Weather.HarshSunlight, Weather.ExtremelyHarshSunlight))
                        return;

                    if (Target.Is(Types.Ice))
                        return;

                    // Magma Armor
                    if (Target.Ability == Ability.MagmaArmor)
                        return;

                    if (AbilityCallback != null)
                        await AbilityCallback.Invoke();

                    Target.NonVolatileStatus = NonVolatileStatus.Freeze;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Target)} is frozen");

                    break;

                case NonVolatileStatus.Paralysis:
                    if (Target.Is(Types.Electric))
                        return;

                    // Limber
                    if (Target.Ability == Ability.Limber)
                        return;

                    if (AbilityCallback != null)
                        await AbilityCallback.Invoke();

                    Target.NonVolatileStatus = NonVolatileStatus.Paralysis;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Target)} is paralysed. It may be unable to move.");

                    break;

                case NonVolatileStatus.Poison:
                case NonVolatileStatus.BadPoison:
                    if (Attacker?.Ability != Ability.Corrosion)
                    {
                        if (Target.Is(Types.Poison, Types.Steel))
                            return;
                    }

                    // Immunity
                    if (Target.Ability == Ability.Immunity)
                        return;

                    if (AbilityCallback != null)
                        await AbilityCallback.Invoke();

                    Target.NonVolatileStatus = Definition.Status;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Target)} is poisoned.");

                    break;

                case NonVolatileStatus.Sleep:
                    if (Target.Ability.Is(Ability.Insomnia, Ability.VitalSpirit))
                        return;

                    if (AbilityCallback != null)
                        await AbilityCallback.Invoke();

                    Target.SleepCounter = BattleViewModel.Random.Next(1, 4);
                    Target.NonVolatileStatus = NonVolatileStatus.Sleep;

                    await Battle.WriteStatus($"{Battle.GetStatusName(Target)} fell asleep.");

                    break;
            }

            // Synchronize
            if (Target.Ability == Ability.Synchronize && Attacker != null)
            {
                switch (Definition.Status)
                {
                    case NonVolatileStatus.Burn:
                    case NonVolatileStatus.Paralysis:
                    case NonVolatileStatus.Poison:
                    case NonVolatileStatus.BadPoison:
                        await Battle.ShowAbility(Target);

                        await GiveNonVolatileStatus(new NonVolatileStatusDefinition(Definition.Status), Attacker, Target, Battle);
                        break;
                }
            }
        }

        static double SameTypeAttackBoost(Pokemon Attacker, Types MoveType)
        {
            var baseMultiplier = 1.0;

            /*
            if (MoveType == Types.Normal && Attacker.Ability == Ability.Aerilate)
            {
                MoveType = Types.Flying;

                baseMultiplier *= 1.3;
            }
            // Also need to consider type effectiveness
            */

            if (Attacker.Is(MoveType))
                return baseMultiplier * (Attacker.Ability == Ability.Adaptability ? 2 : 1.5);

            return baseMultiplier;
        }

        static double TypeEffectiveness(Pokemon Attacker, Move Move, Pokemon Opponent, BattleViewModel Battle, List<string> TextsToDisplay)
        {
            var typeEffect = Poke.TypeEffectiveness.Get(Move.Type, Opponent.PrimaryType, Opponent.SecondaryType);
            
            // Levitate
            if (Move.Type == Types.Ground && Opponent.Ability == Ability.Levitate)
                typeEffect = 0;

            // Bulletproof
            if (Move.Info.Flags.HasFlag(MoveFlags.Bullet) && Opponent.Ability == Ability.BulletProof)
                typeEffect = 0;

            // Powder moves don't affect Grass type Pokemon
            if (Move.Info.Flags.HasFlag(MoveFlags.Powder) && (Opponent.Is(Types.Grass) || Opponent.Ability == Ability.Overcoat))
                typeEffect = 0;

            // Soundproof
            if (Move.Info.Flags.HasFlag(MoveFlags.Sound) && Opponent.Ability == Ability.Soundproof)
                typeEffect = 0;

            // Scrappy
            if (Attacker.Ability == Ability.Scrappy && Move.Type.Is(Types.Normal, Types.Fighting) && Opponent.Is(Types.Ghost))
                typeEffect = 1;

            var opposing = Opponent.Side != Battle.PlayerSide ? " opposing" : "";

            if (typeEffect == 0)
                TextsToDisplay.Add($"It does not affect{opposing} {Opponent}");
            else if (typeEffect < 1)
            {
                if (Attacker.Ability == Ability.TintedLens)
                    typeEffect = 2;

                TextsToDisplay.Add($"It is not very effective on{opposing} {Opponent}");
            }
            else if (typeEffect > 1)
            {
                // Prism Armor, Filter, Solid Rock
                if (Opponent.Ability.Is(Ability.PrismArmor, Ability.Filter, Ability.SolidRock))
                    typeEffect *= 0.75;
                
                TextsToDisplay.Add($"It is super effective on{opposing} {Opponent}");

                // Damage Reduction Berries
                if (Opponent.HeldItem is DamageReductionBerry berry && berry.Type == Move.Type)
                {
                    typeEffect /= 2;

                    TextsToDisplay.Add($"{Battle.GetStatusName(Opponent)} consumed it's {berry}");

                    Opponent.HeldItem = null;
                }
            }

            return typeEffect;
        }
    }
}