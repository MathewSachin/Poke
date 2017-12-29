namespace Poke
{
    public static class PokemonFactory
    {
        static int GetLevel() => BattleViewModel.Random.Next(53, 58);

        public static Pokemon Aerodactyl
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Aerodactyl, GetLevel())
                {
                    HeldItem = MegaStone.Aerodactylite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.ThunderFang, MoveInfo.IceFang, MoveInfo.Flamethrower }.Random(),
                    new [] { MoveInfo.RockSlide, MoveInfo.RockTomb, MoveInfo.StoneEdge }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AerialAce }.Random(),
                    new [] { MoveInfo.IronHead, MoveInfo.Crunch, MoveInfo.Earthquake, MoveInfo.DragonClaw }.Random());

                return pokemon;
            }
        }

        public static Pokemon Aggron
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Aggron, GetLevel())
                {
                    HeldItem = MegaStone.Aggronite
                };

                pokemon.Moves.Assign(MoveInfo.Headbutt,
                    MoveInfo.IronHead,
                    MoveInfo.DragonClaw,
                    MoveInfo.Surf);

                return pokemon;
            }
        }

        public static Pokemon Arcanine
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Arcanine, GetLevel())
                {
                    HeldItem = new HeldItem[] { Gem.Gems[Types.Fire], DamageReductionBerry.Passho }.Random()
                };

                pokemon.Moves.Assign(MoveInfo.Bite,
                    new [] { MoveInfo.FireFang, MoveInfo.Flamethrower, MoveInfo.FireBlast, MoveInfo.FlameCharge }.Random(),
                    new [] { MoveInfo.ExtremeSpeed, MoveInfo.AerialAce, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.ThunderFang, MoveInfo.WildCharge }.Random());

                return pokemon;
            }
        }

        public static Pokemon Alakazam
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Alakazam, GetLevel())
                {
                    HeldItem = MegaStone.Alakazite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Psychic, MoveInfo.PsychoCut, MoveInfo.Psybeam }.Random(),
                    new [] { MoveInfo.DazzlingGleam, MoveInfo.ChargeBeam }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.FocusBlast, MoveInfo.EnergyBall }.Random(),
                    new [] { MoveInfo.ThunderPunch, MoveInfo.IcePunch, MoveInfo.FirePunch }.Random());

                return pokemon;
            }
        }

        public static Pokemon Beedrill
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Beedrill, GetLevel())
                {
                    HeldItem = MegaStone.Beedrillite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.BrickBreak, MoveInfo.BrutalSwing }.Random(),
                    new [] { MoveInfo.Venoshock, MoveInfo.PoisonJab, MoveInfo.SludgeBomb }.Random(),
                    MoveInfo.XScissor,
                    new [] { MoveInfo.AerialAce, MoveInfo.Acrobatics }.Random());

                return pokemon;
            }
        }

        public static Pokemon Blastoise
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Blastoise, GetLevel())
                {
                    HeldItem = MegaStone.Blastoisinite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceBeam }.Random(),
                    new [] { MoveInfo.Waterfall, MoveInfo.Surf, MoveInfo.HydroPump, MoveInfo.Scald, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.Bulldoze, MoveInfo.BrickBreak }.Random(),
                    new [] { MoveInfo.FlashCannon, MoveInfo.Bite, MoveInfo.DarkPulse }.Random());

                return pokemon;
            }
        }

        public static Pokemon Blaziken
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Blaziken, GetLevel())
                {
                    HeldItem = MegaStone.Blazikenite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.BlazeKick, MoveInfo.FlareBlitz, MoveInfo.Flamethrower }.Random(),
                    new [] { MoveInfo.BraveBird, MoveInfo.Earthquake, MoveInfo.AerialAce, MoveInfo.Acrobatics, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.BrickBreak, MoveInfo.SkyUppercut, MoveInfo.LowSweep }.Random(),
                    new [] { MoveInfo.PoisonJab, MoveInfo.QuickAttack, MoveInfo.Slash, MoveInfo.ShadowClaw, MoveInfo.StoneEdge }.Random());

                return pokemon;
            }
        }

        public static Pokemon Charizard
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Charizard, GetLevel())
                {
                    HeldItem = new HeldItem[] { MegaStone.CharizarditeX, MegaStone.CharizarditeY }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Flamethrower, MoveInfo.FlareBlitz }.Random(),
                    MoveInfo.DragonClaw,
                    new [] { MoveInfo.Earthquake, MoveInfo.BrickBreak, MoveInfo.SteelWing, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AirSlash, MoveInfo.ShadowClaw, MoveInfo.Slash, MoveInfo.AerialAce, MoveInfo.BrutalSwing }.Random());

                return pokemon;
            }
        }

        public static Pokemon Dragonite
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Dragonite, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.DragonFang, Gem.Gems[Types.Dragon], Gem.Gems[Types.Flying], DamageReductionBerry.Roseli }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.FirePunch, MoveInfo.IceBeam, MoveInfo.Earthquake, MoveInfo.Flamethrower, MoveInfo.BrutalSwing }.Random(),
                    new [] { MoveInfo.ThunderPunch, MoveInfo.Slam, MoveInfo.Thunderbolt, MoveInfo.BrickBreak, MoveInfo.Surf, MoveInfo.Waterfall }.Random(),
                    new [] { MoveInfo.WingAttack, MoveInfo.AerialAce, MoveInfo.SteelWing }.Random(),
                    new [] { MoveInfo.DragonRush, MoveInfo.DragonClaw }.Random());

                return pokemon;
            }
        }

        public static Pokemon Electivire
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Electivire, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.Magnet, Gem.Gems[Types.Electric], DamageReductionBerry.Shuca }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.FirePunch, MoveInfo.Flamethrower }.Random(),
                    new [] { MoveInfo.Discharge, MoveInfo.ElectroBall, MoveInfo.Thunderbolt }.Random(),
                    new [] { MoveInfo.BrickBreak, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.Bulldoze }.Random());

                return pokemon;
            }
        }

        public static Pokemon Empoleon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Empoleon, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MetalCoat, TypeEnhancement.MysticWater, Gem.Gems[Types.Water], Gem.Gems[Types.Steel] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Brine, MoveInfo.HydroPump, MoveInfo.AquaJet, MoveInfo.Scald, MoveInfo.Surf, MoveInfo.Waterfall }.Random(),
                    new [] { MoveInfo.FlashCannon, MoveInfo.MetalClaw, MoveInfo.SteelWing }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.IceBeam, MoveInfo.DrillPeck, MoveInfo.BrickBreak, MoveInfo.AerialAce, MoveInfo.ShadowClaw }.Random());

                return pokemon;
            }
        }

        public static Pokemon Espeon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Espeon, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Feraligatr, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water], DamageReductionBerry.Wacan }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceFang, MoveInfo.IceBeam, MoveInfo.ShadowClaw }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.Earthquake, MoveInfo.AerialAce, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.DragonClaw, MoveInfo.Slash, MoveInfo.BrickBreak }.Random(),
                    new [] { MoveInfo.Scald, MoveInfo.Surf, MoveInfo.Waterfall }.Random());

                return pokemon;
            }
        }

        public static Pokemon Flygon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Flygon, GetLevel())
                {
                    HeldItem = new HeldItem[] { Gem.Gems[Types.Dragon], Gem.Gems[Types.Ground], DamageReductionBerry.Yache }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DragonClaw, MoveInfo.DragonBreath, MoveInfo.DragonRush }.Random(),
                    new [] { MoveInfo.SteelWing, MoveInfo.RockSlide, MoveInfo.StoneEdge }.Random(),
                    new [] { MoveInfo.EarthPower, MoveInfo.Bulldoze, MoveInfo.Earthquake }.Random(),
                    new [] { MoveInfo.Flamethrower, MoveInfo.AerialAce, MoveInfo.BrutalSwing }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gardevoir
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gardevoir, GetLevel())
                {
                    HeldItem = MegaStone.Gardevoirite
                };

                pokemon.Moves.Assign(MoveInfo.Psychic,
                    new [] { MoveInfo.Moonblast, MoveInfo.DrainingKiss, MoveInfo.DazzlingGleam }.Random(),
                    new [] { MoveInfo.MagicalLeaf, MoveInfo.EnergyBall }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.Thunderbolt }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gengar
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gengar, GetLevel())
                {
                    HeldItem = MegaStone.Gengarite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DazzlingGleam, MoveInfo.BrickBreak, MoveInfo.EnergyBall, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.SludgeBomb, MoveInfo.Venoshock, MoveInfo.PoisonJab }.Random(),
                    new [] { MoveInfo.ShadowBall, MoveInfo.ShadowPunch, MoveInfo.ShadowClaw }.Random(), 
                    new [] { MoveInfo.Thunderbolt, MoveInfo.Psychic }.Random());

                return pokemon;
            }
        }

        public static Pokemon Glaceon
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Glaceon, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.NeverMeltIce, Gem.Gems[Types.Ice] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceFang, MoveInfo.IceShard, MoveInfo.IcyWind }.Random(),
                    new [] { MoveInfo.Bite, MoveInfo.QuickAttack }.Random(),
                    new [] { MoveInfo.IceBeam, MoveInfo.FrostBreath }.Random(),
                    new [] { MoveInfo.ShadowBall }.Random());

                return pokemon;
            }
        }

        public static Pokemon Golduck
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Golduck, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.AerialAce }.Random(),
                    new [] { MoveInfo.Surf, MoveInfo.HydroPump, MoveInfo.Scald, MoveInfo.Waterfall, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.IceBeam }.Random(),
                    new [] { MoveInfo.ShadowClaw, MoveInfo.AquaJet, MoveInfo.Psychic, MoveInfo.BrickBreak }.Random());

                return pokemon;
            }
        }

        public static Pokemon Goodra
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Goodra, GetLevel())
                {
                    HeldItem = Gem.Gems[Types.Dragon]
                };

                pokemon.Moves.Assign(new [] { MoveInfo.IceBeam, MoveInfo.Thunderbolt, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.DragonPulse, MoveInfo.DragonBreath }.Random(),
                    new [] { MoveInfo.BodySlam, MoveInfo.PowerWhip, MoveInfo.Earthquake, MoveInfo.Flamethrower, MoveInfo.BrutalSwing, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.SludgeWave, MoveInfo.SludgeBomb }.Random());

                return pokemon;
            }
        }

        public static Pokemon Greninja
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Greninja, GetLevel())
                {
                    HeldItem = new HeldItem[] { TypeEnhancement.MysticWater, Gem.Gems[Types.Water], Gem.Gems[Types.Dark] }.Random()
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Scald, MoveInfo.Waterfall, MoveInfo.HydroPump, MoveInfo.WaterPulse }.Random(),
                    new [] { MoveInfo.QuickAttack, MoveInfo.ShadowSneak, MoveInfo.RockSlide }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.NightSlash, MoveInfo.BrutalSwing, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.AerialAce, MoveInfo.Extrasensory, MoveInfo.IceBeam, MoveInfo.Acrobatics }.Random());

                return pokemon;
            }
        }

        public static Pokemon Gyarados
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Gyarados, GetLevel())
                {
                    HeldItem = MegaStone.Gyaradosite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.Crunch, MoveInfo.BrutalSwing, MoveInfo.Surf }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.IceFang, MoveInfo.IceBeam, MoveInfo.Thunderbolt, MoveInfo.Flamethrower }.Random(),
                    new [] { MoveInfo.Waterfall, MoveInfo.HydroPump, MoveInfo.Scald, MoveInfo.Surf }.Random(),
                    new [] { MoveInfo.StoneEdge, MoveInfo.Bulldoze }.Random());

                return pokemon;
            }
        }

        public static Pokemon Haxorus
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Haxorus, GetLevel())
                {
                    HeldItem = Gem.Gems[Types.Dragon]
                };

                pokemon.Moves.Assign(new [] { MoveInfo.DragonClaw, MoveInfo.DragonPulse }.Random(),
                    new [] { MoveInfo.Earthquake, MoveInfo.Bulldoze, MoveInfo.RockSlide }.Random(),
                    MoveInfo.PoisonJab,
                    new [] { MoveInfo.XScissor, MoveInfo.Slash, MoveInfo.BrickBreak, MoveInfo.AerialAce, MoveInfo.BrutalSwing, MoveInfo.ShadowClaw, MoveInfo.Surf }.Random());

                return pokemon;
            }
        }

        public static Pokemon Heracross
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Heracross, GetLevel())
                {
                    HeldItem = MegaStone.Heracronite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.NightSlash, MoveInfo.Venoshock, MoveInfo.AerialAce, MoveInfo.BrutalSwing, MoveInfo.ShadowClaw }.Random(),
                    new [] { MoveInfo.HornAttack, MoveInfo.Earthquake, MoveInfo.StoneEdge, MoveInfo.Bulldoze }.Random(),
                    new [] { MoveInfo.BrickBreak }.Random(),
                    MoveInfo.Megahorn);

                return pokemon;
            }
        }

        public static Pokemon Houndoom
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Houndoom, GetLevel())
                {
                    HeldItem = MegaStone.Houndoominite
                };

                pokemon.Moves.Assign(new [] { MoveInfo.ShadowBall, MoveInfo.SludgeBomb }.Random(),
                    new [] { MoveInfo.Flamethrower, MoveInfo.FireFang }.Random(),
                    new [] { MoveInfo.Crunch, MoveInfo.DarkPulse }.Random(),
                    new [] { MoveInfo.ThunderFang }.Random());

                return pokemon;
            }
        }

        public static Pokemon Infernape
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Infernape, GetLevel())
                {
                    HeldItem = TypeEnhancement.BlackBelt
                };
                
                pokemon.Moves.Assign(MoveInfo.Flamethrower,
                    new[] { MoveInfo.Earthquake, MoveInfo.Acrobatics, MoveInfo.ShadowClaw }.Random(),
                    new[] { MoveInfo.BrickBreak, MoveInfo.MachPunch }.Random(),
                    MoveInfo.ThunderPunch);

                return pokemon;
            }
        }

        public static Pokemon Kangaskhan
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Kangaskhan, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Kommo, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Lilligant, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.LycanrocMidday, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.LycanrocMidnight, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Magmortar, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Mawile, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Meganium, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Milotic, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Mimikyu, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Ninetales, GetLevel())
                {
                    HeldItem = Gem.Gems[Types.Fire]
                };

                if (pokemon.Ability == Ability.Drought)
                    pokemon.HeldItem = TypeEnhancement.Charcoal;

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
                var pokemon = new Pokemon(PokemonSpecies.NinetalesAlolan, GetLevel(), nameof(Ninetales))
                {
                    HeldItem = Gem.Gems[Types.Ice]
                };

                if (pokemon.Ability == Ability.SnowWarning)
                    pokemon.HeldItem = HeldItem.IcyRock;

                pokemon.Moves.Assign(MoveInfo.DazzlingGleam,
                    MoveInfo.IceBeam,
                    MoveInfo.DarkPulse,
                    pokemon.Ability == Ability.SnowWarning ? MoveInfo.Blizzard : MoveInfo.IceShard);

                return pokemon;
            }
        }

        public static Pokemon Noivern
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Noivern, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Pangoro, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Pelipper, GetLevel())
                {
                    HeldItem = new[] { Gem.Gems[Types.Water], Gem.Gems[Types.Flying] }.Random()
                };

                if (pokemon.Ability == Ability.Drizzle)
                    pokemon.HeldItem = HeldItem.DampRock;

                pokemon.Moves.Assign(MoveInfo.Scald,
                    MoveInfo.WingAttack,
                    MoveInfo.IceBeam,
                    pokemon.Ability == Ability.Drizzle ? MoveInfo.Hurricane : MoveInfo.AerialAce);

                return pokemon;
            }
        }

        public static Pokemon Pidgeot
        {
            get
            {
                var pokemon = new Pokemon(PokemonSpecies.Pidgeot, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Politoed, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Salamence, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Salazzle, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Sceptile, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Scizor, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Steelix, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Swampert, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Torterra, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Toxicroak, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Typhlosion, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Tyranitar, GetLevel())
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
                var pokemon = new Pokemon(PokemonSpecies.Umbreon, GetLevel());

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
                var pokemon = new Pokemon(PokemonSpecies.Venusaur, GetLevel())
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