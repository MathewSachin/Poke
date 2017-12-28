namespace Poke
{
    public static class PokemonFactory
    {
        public static Pokemon Aerodactyl
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Aerodactyl, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Aerodactylite, Gem.Gems[Types.Rock], Gem.Gems[Types.Flying] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.ThunderFang, MoveInfo.IceFang, MoveInfo.FireFang, MoveInfo.DragonClaw, MoveInfo.Earthquake, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.RockSlide, MoveInfo.RockTomb, MoveInfo.StoneEdge }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AerialAce }.Random(),
                    new [] { MoveInfo.IronHead, MoveInfo.Bite, MoveInfo.Crunch, MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.TakeDown, MoveInfo.SteelWing, MoveInfo.BrutalSwing }.Random());

                return pokemon;
            }
        }

        public static Pokemon Arcanine
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Arcanine, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { Gem.Gems[Types.Fire], DamageReductionBerry.Passho }.Random()
                };

                pokemon.Moves.Assign(MoveInfo.Bite,
                    new [] { MoveInfo.FireFang, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.FlameCharge, MoveInfo.Overheat }.Random(),
                    new [] { MoveInfo.ExtremeSpeed, MoveInfo.HyperBeam, MoveInfo.AerialAce, MoveInfo.GigaImpact, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.ThunderFang, MoveInfo.WildCharge }.Random());

                return pokemon;
            }
        }

        public static Pokemon Alakazam
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Alakazam, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Alakazite, Gem.Gems[Types.Psychic] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Psychic, MoveInfo.PsychoCut, MoveInfo.Psybeam }.Random(),
                    new [] { MoveInfo.DazzlingGleam, MoveInfo.ChargeBeam }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.FocusBlast, MoveInfo.EnergyBall }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact }.Random());

                return pokemon;
            }
        }

        public static Pokemon Beedrill
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Beedrill, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Beedrillite, Gem.Gems[Types.Bug], Gem.Gems[Types.Poison], null }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.BrickBreak }.Random(),
                    new [] { MoveInfo.Venoshock, MoveInfo.PoisonJab, MoveInfo.SludgeBomb }.Random(),
                    MoveInfo.XScissor,
                    new [] { MoveInfo.AerialAce, MoveInfo.BrutalSwing, MoveInfo.Acrobatics }.Random());

                return pokemon;
            }
        }

        public static Pokemon Blastoise
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Blastoise, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Blastoisinite, Gem.Gems[Types.Water] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.BrickBreak, MoveInfo.FocusBlast }.Random(),
                    new [] { MoveInfo.Waterfall, MoveInfo.Surf, MoveInfo.AquaTail, MoveInfo.HydroPump, MoveInfo.HydroCannon, MoveInfo.Scald, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.Earthquake, MoveInfo.RockTomb, MoveInfo.GigaImpact, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.FlashCannon, MoveInfo.Bite, MoveInfo.DarkPulse }.Random());

                return pokemon;
            }
        }

        public static Pokemon Blaziken
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Blaziken, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Blazikenite, Gem.Gems[Types.Fire], Gem.Gems[Types.Fighting], null }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.BlazeKick, MoveInfo.FirePunch, MoveInfo.FlareBlitz, MoveInfo.FlameCharge, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.Overheat }.Random(),
                    new [] { MoveInfo.BraveBird, MoveInfo.HyperBeam, MoveInfo.Earthquake, MoveInfo.AerialAce, MoveInfo.Acrobatics, MoveInfo.GigaImpact, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.BrickBreak, MoveInfo.SkyUppercut, MoveInfo.LowSweep, MoveInfo.FocusBlast }.Random(),
                    new [] { MoveInfo.PoisonJab, MoveInfo.QuickAttack, MoveInfo.Slash, MoveInfo.RockTomb, MoveInfo.ShadowClaw, MoveInfo.StoneEdge }.Random());

                return pokemon;
            }
        }

        public static Pokemon Charizard
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Charizard, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.CharizarditeX, MegaStone.CharizarditeY, Gem.Gems[Types.Fire], Gem.Gems[Types.Flying] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Flamethrower, MoveInfo.HeatWave, MoveInfo.FlareBlitz, MoveInfo.BlastBurn, MoveInfo.FireFang, MoveInfo.Inferno, MoveInfo.FireBlast, MoveInfo.FlameCharge, MoveInfo.Overheat }.Random(),
                    MoveInfo.DragonClaw,
                    new [] { MoveInfo.Earthquake, MoveInfo.HyperBeam, MoveInfo.BrickBreak, MoveInfo.RockTomb, MoveInfo.SteelWing, MoveInfo.GigaImpact, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AirSlash, MoveInfo.ShadowClaw, MoveInfo.Slash, MoveInfo.AerialAce, MoveInfo.FocusBlast, MoveInfo.BrutalSwing }.Random());

                return pokemon;
            }
        }

        public static Pokemon Dragonite
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Dragonite, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.DragonFang, Gem.Gems[Types.Dragon], Gem.Gems[Types.Flying], DamageReductionBerry.Roseli }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.FirePunch, MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.Earthquake, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.RockTomb, MoveInfo.BrutalSwing, MoveInfo.StoneEdge, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.ThunderPunch, MoveInfo.Slam, MoveInfo.AquaTail, MoveInfo.HyperBeam, MoveInfo.Thunderbolt, MoveInfo.Thunder, MoveInfo.BrickBreak, MoveInfo.SteelWing, MoveInfo.FocusBlast, MoveInfo.GigaImpact, MoveInfo.Surf, MoveInfo.Waterfall }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AerialAce }.Random(),
                    new [] { MoveInfo.DracoMeteor, MoveInfo.DragonRush, MoveInfo.DragonClaw }.Random());

                return pokemon;
            }
        }

        public static Pokemon Electivire
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Electivire, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.Magnet, Gem.Gems[Types.Electric], DamageReductionBerry.Shuca }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.FirePunch, MoveInfo.Flamethrower }.Random(),
                    new [] { MoveInfo.Discharge, MoveInfo.ElectroBall, MoveInfo.Thunderbolt, MoveInfo.Thunder, MoveInfo.WildCharge }.Random(),
                    new [] { MoveInfo.BrickBreak, MoveInfo.RockTomb, MoveInfo.FocusBlast, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.GigaImpact, MoveInfo.HyperBeam, MoveInfo.Earthquake, MoveInfo.Bulldoze }.Random());

                return pokemon;
            }
        }

        public static Pokemon Empoleon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Empoleon, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MetalCoat, TypeEnhancement.MysticWater, Gem.Gems[Types.Water], Gem.Gems[Types.Steel] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.HydroCannon, MoveInfo.Brine, MoveInfo.HydroPump, MoveInfo.AquaJet, MoveInfo.Scald, MoveInfo.Surf, MoveInfo.Waterfall }.Random(),
                    new [] { MoveInfo.FlashCannon, MoveInfo.MetalClaw, MoveInfo.SteelWing }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.HyperBeam, MoveInfo.RockTomb, MoveInfo.GigaImpact, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.IceBeam, MoveInfo.DrillPeck, MoveInfo.Blizzard, MoveInfo.BrickBreak, MoveInfo.AerialAce, MoveInfo.ShadowClaw }.Random());

                return pokemon;
            }
        }

        public static Pokemon Espeon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Espeon, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.TwistedSpoon, Gem.Gems[Types.Psychic], DamageReductionBerry.Kasib }.Random()
                };

                pokemon.Moves.Assign(new[] { MoveInfo.Psychic, MoveInfo.Psybeam }.Random(),
                    new [] { MoveInfo.Swift, MoveInfo.QuickAttack }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.DazzlingGleam }.Random());

                return pokemon;
            }
        }

        public static Pokemon Feraligatr
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Feraligatr, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water], DamageReductionBerry.Wacan }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceFang, MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.ShadowClaw }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.Bite, MoveInfo.Earthquake, MoveInfo.RockTomb, MoveInfo.AerialAce, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.DragonClaw, MoveInfo.Slash, MoveInfo.Superpower, MoveInfo.BrickBreak, MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.FocusBlast }.Random(),
                    new [] { MoveInfo.AquaTail, MoveInfo.Scald, MoveInfo.Surf, MoveInfo.Waterfall, MoveInfo.HydroCannon }.Random());

                return pokemon;
            }
        }

        public static Pokemon Flygon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Flygon, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { Gem.Gems[Types.Dragon], Gem.Gems[Types.Ground], DamageReductionBerry.Yache }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DragonClaw, MoveInfo.DragonBreath, MoveInfo.DragonRush, MoveInfo.DracoMeteor }.Random(),
                    new [] { MoveInfo.SteelWing, MoveInfo.RockSlide, MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.RockTomb, MoveInfo.StoneEdge }.Random(),
                    new [] { MoveInfo.EarthPower, MoveInfo.Bulldoze, MoveInfo.Earthquake }.Random(),
                    new [] { MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.AerialAce, MoveInfo.BrutalSwing }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gardevoir
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gardevoir, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Gardevoirite, Gem.Gems[Types.Psychic], Gem.Gems[Types.Fairy] }.Random()
                };

                pokemon.Moves.Assign(MoveInfo.Psychic,
                    new [] { MoveInfo.Moonblast, MoveInfo.DrainingKiss, MoveInfo.DazzlingGleam }.Random(),
                    new [] { MoveInfo.MagicalLeaf, MoveInfo.Thunderbolt, MoveInfo.EnergyBall, MoveInfo.ChargeBeam }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.ShadowBall }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gengar
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gengar, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Gengarite, Gem.Gems[Types.Ghost], Gem.Gems[Types.Poison] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DazzlingGleam, MoveInfo.BrickBreak, MoveInfo.FocusBlast, MoveInfo.EnergyBall, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.SludgeBomb, MoveInfo.Venoshock, MoveInfo.PoisonJab }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.ShadowPunch, MoveInfo.ShadowClaw }.Random(), 
                    new [] { MoveInfo.Thunderbolt, MoveInfo.Thunder, MoveInfo.Psychic, MoveInfo.GigaImpact, MoveInfo.HyperBeam }.Random());

                return pokemon;
            }
        }

        public static Pokemon Glaceon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Glaceon, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.NeverMeltIce, Gem.Gems[Types.Ice] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceFang, MoveInfo.IceShard, MoveInfo.IcyWind }.Random(),
                    new [] { MoveInfo.Bite, MoveInfo.QuickAttack }.Random(),
                    new [] { MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.FrostBreath }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.HyperBeam, MoveInfo.GigaImpact }.Random());

                return pokemon;
            }
        }

        public static Pokemon Golduck
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Golduck, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.AerialAce, MoveInfo.HyperBeam, MoveInfo.GigaImpact }.Random(),
                    new [] { MoveInfo.Surf, MoveInfo.AquaTail, MoveInfo.HydroPump, MoveInfo.Scald, MoveInfo.Waterfall, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.IceBeam, MoveInfo.Blizzard }.Random(),
                    new [] { MoveInfo.ShadowClaw, MoveInfo.AquaJet, MoveInfo.Psychic, MoveInfo.BrickBreak }.Random());

                return pokemon;
            }
        }

        public static Pokemon Goodra
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Goodra, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = Gem.Gems[Types.Dragon]
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.Thunderbolt, MoveInfo.Thunder, MoveInfo.FocusBlast, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.DragonPulse, MoveInfo.DragonBreath, MoveInfo.DracoMeteor }.Random(),
                    new [] { MoveInfo.BodySlam, MoveInfo.AquaTail, MoveInfo.PowerWhip, MoveInfo.MuddyWater, MoveInfo.Earthquake, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.BrutalSwing, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.SludgeWave, MoveInfo.SludgeBomb }.Random());

                return pokemon;
            }
        }

        public static Pokemon Greninja
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Greninja, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water], Gem.Gems[Types.Dark], null }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Scald, MoveInfo.Waterfall, MoveInfo.HydroPump, MoveInfo.HydroCannon, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.QuickAttack, MoveInfo.ShadowSneak, MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.RockTomb, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.NightSlash, MoveInfo.BrutalSwing, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.AerialAce, MoveInfo.Extrasensory, MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.Acrobatics }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gyarados
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gyarados, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Gyaradosite, Gem.Gems[Types.Water], Gem.Gems[Types.Flying], TypeEnhancement.MysticWater }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Crunch, MoveInfo.Bite, MoveInfo.BrutalSwing, MoveInfo.Surf }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.IceFang, MoveInfo.IceBeam, MoveInfo.Blizzard, MoveInfo.Thunderbolt, MoveInfo.Thunder, MoveInfo.Flamethrower, MoveInfo.FireBlast }.Random(),
                    new [] { MoveInfo.Waterfall, MoveInfo.AquaTail, MoveInfo.HydroPump, MoveInfo.Scald, MoveInfo.Surf }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.StoneEdge, MoveInfo.Bulldoze }.Random());

                return pokemon;
            }
        }

        public static Pokemon Haxorus
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Haxorus, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = Gem.Gems[Types.Dragon]
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DragonClaw, MoveInfo.DragonPulse, MoveInfo.DracoMeteor }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.GigaImpact, MoveInfo.HyperBeam, MoveInfo.RockTomb, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    MoveInfo.PoisonJab,
                    new [] { MoveInfo.XScissor, MoveInfo.Slash, MoveInfo.BrickBreak, MoveInfo.AerialAce, MoveInfo.FocusBlast, MoveInfo.BrutalSwing, MoveInfo.ShadowClaw, MoveInfo.Surf }.Random());

                return pokemon;
            }
        }

        public static Pokemon Heracross
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Heracross, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Heracronite, Gem.Gems[Types.Bug], Gem.Gems[Types.Fighting] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.NightSlash, MoveInfo.Venoshock, MoveInfo.AerialAce, MoveInfo.BrutalSwing, MoveInfo.ShadowClaw }.Random(),
                    new [] { MoveInfo.DoubleEdge, MoveInfo.HornAttack, MoveInfo.TakeDown, MoveInfo.HyperBeam, MoveInfo.Earthquake, MoveInfo.GigaImpact, MoveInfo.RockTomb, MoveInfo.StoneEdge, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.CloseCombat, MoveInfo.BrickBreak }.Random(),
                    MoveInfo.Megahorn);

                return pokemon;
            }
        }

        public static Pokemon Houndoom
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Houndoom, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Houndoominite, Gem.Gems[Types.Fire], Gem.Gems[Types.Dark] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.ThunderFang, MoveInfo.ShadowBall, MoveInfo.SludgeBomb }.Random(),
                    new [] { MoveInfo.Flamethrower, MoveInfo.FireFang, MoveInfo.FireBlast, MoveInfo.FlameCharge, MoveInfo.Overheat }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.Bite, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.HyperBeam, MoveInfo.GigaImpact, MoveInfo.Inferno }.Random());

                return pokemon;
            }
        }

        public static Pokemon Infernape
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Infernape, 50)
                {
                    HeldItem = TypeEnhancement.BlackBelt
                };
                
                pokemon.Moves.Assign(MoveInfo.Flamethrower,
                    MoveInfo.Earthquake,
                    MoveInfo.BrickBreak,
                    MoveInfo.BlastBurn);

                return pokemon;
            }
        }

        public static Pokemon Kangaskhan
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Kangaskhan, 55)
                {
                    HeldItem = MegaStone.Kangaskhanite
                };

                pokemon.Moves.Assign(MoveInfo.DizzyPunch,
                    MoveInfo.IceBeam,
                    MoveInfo.Thunderbolt,
                    MoveInfo.Flamethrower);

                return pokemon;
            }
        }

        public static Pokemon Kommo
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Kommo, 55)
                {
                    HeldItem = Gem.Gems[Types.Dragon]
                };

                pokemon.Moves.Assign(MoveInfo.ClangingScales,
                    MoveInfo.PoisonJab,
                    MoveInfo.BrickBreak,
                    MoveInfo.FlashCannon);

                return pokemon;
            }
        }

        public static Pokemon Leafeon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Leafeon, 56)
                {
                    HeldItem = Gem.Gems[Types.Grass]
                };

                pokemon.Moves.Assign(MoveInfo.RazorLeaf,
                    MoveInfo.AerialAce,
                    MoveInfo.GigaDrain,
                    MoveInfo.XScissor);

                return pokemon;
            }
        }

        public static Pokemon Lilligant
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Lilligant, 55)
                {
                    HeldItem = Gem.Gems[Types.Grass]
                };

                pokemon.Moves.Assign(MoveInfo.PetalBlizzard,
                    MoveInfo.HyperBeam,
                    MoveInfo.GigaImpact,
                    MoveInfo.EnergyBall);

                return pokemon;
            }
        }

        public static Pokemon Lucario
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Lucario, 53)
                {
                    HeldItem = MegaStone.Lucarionite
                };

                pokemon.Moves.Assign(MoveInfo.AuraSphere,
                    MoveInfo.MetalClaw,
                    MoveInfo.DragonPulse,
                    MoveInfo.CloseCombat);

                return pokemon;
            }
        }

        public static Pokemon LycanrocMidday
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.LycanrocMidday, 55)
                {
                    HeldItem = Gem.Gems[Types.Rock]
                };

                pokemon.Moves.Assign(MoveInfo.Accelerock,
                    MoveInfo.Crunch,
                    MoveInfo.StoneEdge,
                    MoveInfo.BrickBreak);

                return pokemon;
            }
        }

        public static Pokemon LycanrocMidnight
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.LycanrocMidnight, 55)
                {
                    HeldItem = Gem.Gems[Types.Rock]
                };

                pokemon.Moves.Assign(MoveInfo.RockSlide,
                    MoveInfo.Crunch,
                    MoveInfo.StoneEdge,
                    MoveInfo.BrickBreak);

                return pokemon;
            }
        }

        public static Pokemon Magmortar
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Magmortar, 55)
                {
                    HeldItem = Gem.Gems[Types.Fire]
                };

                pokemon.Moves.Assign(MoveInfo.Thunderbolt,
                    MoveInfo.Flamethrower,
                    MoveInfo.BrickBreak,
                    MoveInfo.Earthquake);

                return pokemon;
            }
        }

        public static Pokemon Mawile
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Mawile, 55)
                {
                    HeldItem = MegaStone.Mawilite
                };

                pokemon.Moves.Assign(MoveInfo.IronHead,
                    MoveInfo.PlayRough,
                    MoveInfo.Crunch,
                    MoveInfo.RockTomb);

                return pokemon;
            }
        }

        public static Pokemon Meganium
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Meganium, 55)
                {
                    HeldItem = Gem.Gems[Types.Grass]
                };

                pokemon.Moves.Assign(MoveInfo.PetalBlizzard,
                    MoveInfo.BodySlam,
                    MoveInfo.Earthquake,
                    MoveInfo.FrenzyPlant);

                return pokemon;
            }
        }

        public static Pokemon Milotic
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Milotic, 55)
                {
                    HeldItem = Gem.Gems[Types.Water]
                };

                pokemon.Moves.Assign(MoveInfo.WaterPulse,
                    MoveInfo.DragonPulse,
                    MoveInfo.IceBeam,
                    MoveInfo.BrutalSwing);

                return pokemon;
            }
        }

        public static Pokemon Mimikyu
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Mimikyu, 55)
                {
                    HeldItem = new[] { Gem.Gems[Types.Fairy], Gem.Gems[Types.Ghost] }.Random()
                };

                pokemon.Moves.Assign(MoveInfo.PlayRough,
                    MoveInfo.ShadowClaw,
                    MoveInfo.WoodHammer,
                    MoveInfo.Thunderbolt);

                return pokemon;
            }
        }

        public static Pokemon Ninetales
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Ninetales, 55)
                {
                    HeldItem = TypeEnhancement.Charcoal
                };

                pokemon.Moves.Assign(MoveInfo.Flamethrower,
                    MoveInfo.QuickAttack,
                    MoveInfo.Psychic,
                    MoveInfo.EnergyBall);

                return pokemon;
            }
        }

        public static Pokemon NinetalesAlolan
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.NinetalesAlolan, 55, nameof(Ninetales))
                {
                    HeldItem = HeldItem.IcyRock
                };

                pokemon.Moves.Assign(MoveInfo.DazzlingGleam,
                    MoveInfo.IceBeam,
                    MoveInfo.DarkPulse,
                    MoveInfo.IceShard);

                return pokemon;
            }
        }

        public static Pokemon Noivern
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Noivern, 55)
                {
                    HeldItem = new[] { Gem.Gems[Types.Dragon], Gem.Gems[Types.Flying] }.Random()
                };

                pokemon.Moves.Assign(MoveInfo.Acrobatics,
                    MoveInfo.DragonClaw,
                    MoveInfo.Boomburst,
                    MoveInfo.WildCharge);

                return pokemon;
            }
        }

        public static Pokemon Pangoro
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Pangoro, 55);

                pokemon.Moves.Assign(MoveInfo.BrickBreak,
                    new []{ MoveInfo.DragonClaw, MoveInfo.ShadowClaw, MoveInfo.XScissor, MoveInfo.Earthquake }.Random(),
                    MoveInfo.DarkPulse,
                    new[]{ MoveInfo.Surf,  MoveInfo.PoisonJab, MoveInfo.StoneEdge, MoveInfo.GigaImpact, MoveInfo.SludgeBomb, MoveInfo.RockTomb, MoveInfo.HyperBeam  }.Random());

                return pokemon;
            }
        }

        public static Pokemon Pelipper
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Pelipper, 55);

                pokemon.HeldItem = pokemon.Ability == Ability.Drizzle ? HeldItem.DampRock
                    : new[] { Gem.Gems[Types.Water], Gem.Gems[Types.Flying] }.Random();

                pokemon.Moves.Assign(MoveInfo.Scald,
                    MoveInfo.WingAttack,
                    MoveInfo.IceBeam,
                    MoveInfo.AerialAce);

                return pokemon;
            }
        }

        public static Pokemon Pidgeot
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Pidgeot, 55)
                {
                    HeldItem = MegaStone.Pidgeotite
                };

                pokemon.Moves.Assign(MoveInfo.QuickAttack,
                    MoveInfo.AerialAce,
                    MoveInfo.AirSlash,
                    MoveInfo.SteelWing);

                return pokemon;
            }
        }

        public static Pokemon Pikachu
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Pikachu, 60, "Spark")
                {
                    HeldItem = new[] { HeldItem.LightBall, ExclusiveZCrystal.Pikanium }.Random()
                };

                pokemon.Stats.EV[Stats.Speed] = 252;

                pokemon.Moves.Assign(MoveInfo.QuickAttack,
                    MoveInfo.Thunderbolt,
                    pokemon.HeldItem == ExclusiveZCrystal.Pikanium ? MoveInfo.VoltTackle : MoveInfo.ElectroBall,
                    MoveInfo.IronTail);

                return pokemon;
            }
        }

        public static Pokemon Politoed
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Politoed, 55);

                pokemon.Moves.Assign(MoveInfo.Waterfall,
                    MoveInfo.HyperVoice,
                    MoveInfo.IceBeam,
                    MoveInfo.BrickBreak);

                return pokemon;
            }
        }

        public static Pokemon Salamence
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Salamence, BattleViewModel.Random.Next(50, 60))
                {
                    HeldItem = new HeldItem[] { MegaStone.Salamencite, Gem.Gems[Types.Dragon], Gem.Gems[Types.Flying] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Bite, MoveInfo.Crunch, MoveInfo.Headbutt, MoveInfo.ZenHeadbutt, MoveInfo.Earthquake, MoveInfo.BrickBreak, MoveInfo.RockTomb, MoveInfo.BrutalSwing, MoveInfo.ShadowBall, MoveInfo.Bulldoze, MoveInfo.RockSlide, MoveInfo.StoneEdge }.Random(),
                    new [] { MoveInfo.ThunderFang, MoveInfo.FireFang, MoveInfo.Flamethrower, MoveInfo.DoubleEdge, MoveInfo.GigaImpact, MoveInfo.HyperBeam, MoveInfo.FireBlast, MoveInfo.SteelWing }.Random(),
                    new [] { MoveInfo.AerialAce }.Random(),
                    new [] { MoveInfo.DragonClaw, MoveInfo.DracoMeteor, MoveInfo.DragonBreath }.Random());

                return pokemon;
            }
        }

        public static Pokemon Salazzle
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Salazzle, 55);

                pokemon.Moves.Assign(MoveInfo.Flamethrower,
                    MoveInfo.Venoshock,
                    MoveInfo.DragonPulse,
                    MoveInfo.Acrobatics);

                return pokemon;
            }
        }

        public static Pokemon Sceptile
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Sceptile, 55)
                {
                    HeldItem = MegaStone.Sceptilite
                };

                pokemon.Moves.Assign(MoveInfo.XScissor,
                    MoveInfo.Earthquake,
                    MoveInfo.GigaDrain,
                    MoveInfo.DragonClaw);

                return pokemon;
            }
        }

        public static Pokemon Scizor
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Scizor, 55)
                {
                    HeldItem = MegaStone.Scizorite
                };

                pokemon.Moves.Assign(MoveInfo.RazorWind,
                    MoveInfo.XScissor,
                    MoveInfo.FlashCannon,
                    MoveInfo.NightSlash);

                return pokemon;
            }
        }

        public static Pokemon Steelix
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Steelix, 55)
                {
                    HeldItem = MegaStone.Steelixite
                };

                pokemon.Moves.Assign(MoveInfo.ThunderFang,
                    MoveInfo.IceFang,
                    MoveInfo.Earthquake,
                    MoveInfo.FlashCannon);

                return pokemon;
            }
        }

        public static Pokemon Swampert
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Swampert, 55)
                {
                    HeldItem = MegaStone.Swampertite
                };

                pokemon.Moves.Assign(MoveInfo.Waterfall,
                    MoveInfo.MudShot,
                    MoveInfo.HammerArm,
                    MoveInfo.IceBeam);

                return pokemon;
            }
        }

        public static Pokemon Sylveon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Sylveon, 56)
                {
                    HeldItem = Plate.Plates[Types.Fairy]
                };

                pokemon.Moves.Assign(MoveInfo.Swift,
                    MoveInfo.DrainingKiss,
                    MoveInfo.DazzlingGleam,
                    MoveInfo.ShadowBall);

                return pokemon;
            }
        }

        public static Pokemon Talonflame
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Talonflame, 56)
                {
                    HeldItem = TypeEnhancement.SharpBeak
                };

                pokemon.Moves.Assign(MoveInfo.FlameCharge,
                    MoveInfo.BraveBird,
                    MoveInfo.FireBlast,
                    MoveInfo.SteelWing);

                return pokemon;
            }
        }

        public static Pokemon Torterra
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Torterra, 55);

                pokemon.Moves.Assign(MoveInfo.Earthquake,
                    MoveInfo.WoodHammer,
                    MoveInfo.Crunch,
                    MoveInfo.GigaDrain);

                return pokemon;
            }
        }

        public static Pokemon Toxicroak
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Toxicroak, 55)
                {
                    HeldItem = TypeEnhancement.PoisonBarb
                };

                pokemon.Moves.Assign(MoveInfo.PoisonJab,
                    MoveInfo.MudBomb,
                    MoveInfo.BrickBreak,
                    MoveInfo.DarkPulse);

                return pokemon;
            }
        }

        public static Pokemon Typhlosion
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Typhlosion, 55);

                pokemon.Moves.Assign(MoveInfo.Eruption,
                    MoveInfo.DoubleEdge,
                    MoveInfo.Flamethrower,
                    MoveInfo.WildCharge);

                return pokemon;
            }
        }

        public static Pokemon Tyranitar
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Tyranitar, 55)
                {
                    HeldItem = MegaStone.Tyranitarite
                };

                pokemon.Moves.Assign(MoveInfo.RockSlide,
                    MoveInfo.DarkPulse,
                    MoveInfo.Flamethrower,
                    MoveInfo.HyperBeam);

                return pokemon;
            }
        }

        public static Pokemon Umbreon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Umbreon, 55);

                pokemon.Moves.Assign(MoveInfo.ShadowBall,
                    MoveInfo.DarkPulse,
                    MoveInfo.HyperBeam,
                    MoveInfo.QuickAttack);

                return pokemon;
            }
        }

        public static Pokemon Venusaur
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Venusaur, 55)
                {
                    HeldItem = MegaStone.Venusaurite
                };

                pokemon.Moves.Assign(MoveInfo.PetalBlizzard,
                    MoveInfo.Earthquake,
                    MoveInfo.DoubleEdge,
                    MoveInfo.SludgeBomb);

                return pokemon;
            }
        }
    }
}