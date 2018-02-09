using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Poke
{
    public partial class BattleViewModel : NotifyPropertyChanged
    {
        public BattleViewModel()
        {
            _pokemonMovePairComparer = new PokemonMovePairComparer(this);

            MoveCommand = new DelegateCommand(OnMoveExecute, M => BattleState == BattleState.Move);

            ZMoveCommand = new DelegateCommand(OnMoveExecute, OnZMoveCanExecute);

            SwitchCommand = new DelegateCommand(OnSwitchExecute, OnSwitchCanExecute);

            ContinueCommand = new DelegateCommand(M => _continueEvent.Set(), M => true);

            CancelCommand = new DelegateCommand(M => _cancelEvent.Set(), M => true);

            TargetCommand = new DelegateCommand(OnTargetExecute, M => BattleState == BattleState.Target);
        }

        public event DamageFunction DoAnimation;
        
        async Task Reset()
        {
            UseMegaEvolution = UseZ = false;
            PlayerSide = OpponentSide = null;
            
            BattleState = BattleState.Wait;
            
            Weather = Weather.None;
            
            var arr = PokemonGenerators.Shuffle();
            
            OpponentSide = new Side(Format, arr[0].Invoke(), arr[1].Invoke(), arr[2].Invoke(), arr[3].Invoke(), arr[4].Invoke(), arr[5].Invoke());

            var text = $"The opposing player sent out {OpponentSide.Battling[0]}";

            for (var i = 1; i < Format; ++i)
            {
                text += i == Format - 1 ? " and " : ", ";

                text += OpponentSide.Battling[i];
            }
            
            await WriteStatus(text);

            try
            {
                if (_playerSideGenerator == null)
                    throw new ArgumentNullException();

                var side = _playerSideGenerator.Invoke();

                if (side.Party.Count == 6)
                {
                    PlayerSide = side;
                }
                else throw new ArgumentOutOfRangeException();
            }
            catch
            {
                PlayerSide = new Side(Format, arr[6].Invoke(), arr[7].Invoke(), arr[8].Invoke(), arr[9].Invoke(), arr[10].Invoke(), arr[11].Invoke());
            }
            
            // Assign a single Z Crystal
            var zIndex = Random.Next(6);

            PlayerSide.Party[zIndex].HeldItem = TypeZCrystal.Crystrals[PlayerSide.Party[zIndex].Moves[0].Type];

            OpponentSide.OpposingSide = PlayerSide;
            PlayerSide.OpposingSide = OpponentSide;

            text = $"Go {PlayerSide.Battling[0]}";

            for (var i = 1; i < Format; ++i)
            {
                text += i == Format - 1 ? " and " : ", ";

                text += PlayerSide.Battling[i];
            }

            await WriteStatus(text);

            var ordered = MoveOrder(AllBattling()).ToArray();

            foreach (var data in ordered)
            {
                await SwitchInEffects(data.Attacker);
            }

            foreach (var data in ordered)
            {
                await PostTurnStatusEffects(data.Attacker);
                await PostTurnWeatherEffects(data.Attacker);
            }
        }
        
        IEnumerable<PokemonMovePair> MoveOrder(IEnumerable<PokemonMovePair> List)
        {
            return List.OrderBy(O => O, _pokemonMovePairComparer);
        }
        
        async Task MegaEvolve(Pokemon Pokemon)
        {
            var statusName = GetStatusName(Pokemon);

            if (Pokemon.CanMegaEvolve(out var mega))
            {
                Pokemon.Transforming = true;
                
                await WriteStatus($"The light from the Key Stone is reacting with {mega.MegaStone}");

                SwitchOutEffects(Pokemon);
                
                Pokemon.MegaEvolve();

                await WriteStatus($"{statusName} Mega Evolved into {Pokemon.Species.Name}");

                Pokemon.Transforming = false;

                await SwitchInEffects(Pokemon);
            }
        }
        
        async Task SwitchInEffects(Pokemon Pokemon)
        {
            if (Pokemon.Ability is NormalizingAbility normalizingAbility)
            {
                foreach (var move in Pokemon.Moves)
                {
                    if (move.Type == Types.Normal)
                    {
                        move.Type = normalizingAbility.Type;
                    }
                }
            }

            // TODO: Does not work on Substitute
            // TODO: Only for adjacent Pokemon
            // Intimidate
            if (Pokemon.Ability == Ability.Intimidate)
            {
                await ShowAbility(Pokemon);

                foreach (var pokemon in Pokemon.GetAdjacentFoes())
                {
                    await DamageFunctionFactory.StatChange(pokemon, Stats.Attack, -1, this);
                }
            }

            // Download
            // TODO: Verify for Triple Battles
            // TODO: Consider Power Trick
            else if (Pokemon.Ability == Ability.Download)
            {
                await ShowAbility(Pokemon);

                var defense = 0;
                var specialDefense = 0;

                foreach (var pokemon in Pokemon.Side.OpposingSide.Battling)
                {
                    if (pokemon != null)
                    {
                        defense += pokemon.Stats.GetValue(Stats.Defense);
                        specialDefense += pokemon.Stats.GetValue(Stats.SpecialDefense);
                    }
                }

                await DamageFunctionFactory.StatChange(Pokemon,
                    defense <= specialDefense ? Stats.SpecialAttack : Stats.Attack, 1, this);
            }

            // Pressure
            else if (Pokemon.Ability == Ability.Pressure)
            {
                await ShowAbility(Pokemon);

                await WriteStatus($"{GetStatusName(Pokemon)} is exerting its Pressure!");
            }

            // Air Lock, Cloud Nine
            else if (Pokemon.Ability is WeatherEffectNegatorAbility)
            {
                await ShowAbility(Pokemon);

                ++SuppressWeather;

                await WriteStatus("The effects of the weather disappeared.");
            }

            // Frisk
            else if (Pokemon.Ability == Ability.Frisk)
            {
                await ShowAbility(Pokemon);

                foreach (var pokemon in Pokemon.Side.OpposingSide.Battling)
                {
                    if (pokemon?.HeldItem != null)
                        await WriteStatus($"{GetStatusName(Pokemon)} frisked and found {pokemon}'s {pokemon.HeldItem}");
                }
            }

            await WeatherAbility(Pokemon);
        }
        
        void SwitchOutEffects(Pokemon Pokemon)
        {
            foreach (var move in Pokemon.Moves)
            {
                move.Type = move.Info.Type;
            }

            // Air Lock, Cloud Nine
            if (Pokemon.Ability is WeatherEffectNegatorAbility)
            {
                --SuppressWeather;
            }

            if (!Pokemon.IsFainted)
            {
                // Regenerator
                if (Pokemon.Ability == Ability.Regenerator)
                    Pokemon.Stats.Heal(Pokemon.Stats.MaxHP / 3);
            }
        }
        
        async Task PostTurnStatusEffects(Pokemon Pokemon)
        {
            switch (Pokemon.NonVolatileStatus)
            {
                case NonVolatileStatus.Burn:
                    var damage = Pokemon.Stats.MaxHP / 16;

                    // Heatproof
                    if (Pokemon.Ability == Ability.Heatproof)
                        damage /= 2;

                    await Pokemon.Stats.Damage(damage, this);

                    Pokemon.RaiseShowNonVolativeStatusAnimation();

                    await WriteStatus($"{GetStatusName(Pokemon)} is hurt by burn");
                    break;

                case NonVolatileStatus.Poison:
                // TODO: Correct implementation of Bad Poison
                case NonVolatileStatus.BadPoison:
                    var posion = Pokemon.Stats.MaxHP / 8;

                    if (Pokemon.Ability == Ability.PoisonHeal)
                    {
                        Pokemon.Stats.Heal(posion);

                        await WriteStatus($"{GetStatusName(Pokemon)} healed due to Poison Heal");
                    }
                    else
                    {
                        await Pokemon.Stats.Damage(posion, this);

                        Pokemon.RaiseShowNonVolativeStatusAnimation();

                        await WriteStatus($"{GetStatusName(Pokemon)} is hurt by poison");
                    }
                    
                    break;
            }

            if (Pokemon.Stats.CurrentHP == 0)
            {
                SwitchOutEffects(Pokemon);

                await WriteStatus($"{GetStatusName(Pokemon)} fainted");
            }
        }
        
        async Task Attack(Pokemon Attacker, Move Move, Pokemon Opponent)
        {
            Attacker.AlreadyMoved = true;

            if (Attacker.Flinched)
            {
                await WriteStatus($"{GetStatusName(Attacker)} flinched and could not move");

                Attacker.Flinched = false;

                if (Attacker.Ability == Ability.Steadfast)
                {
                    await ShowAbility(Attacker);

                    await DamageFunctionFactory.StatChange(Attacker, Stats.Speed, 1, this);
                }
                
                return;
            }

            switch (Attacker.NonVolatileStatus)
            {
                case NonVolatileStatus.Freeze:
                    if (Move.Info.Flags.HasFlag(MoveFlags.Defrost)
                        || Random.NextDouble() < 0.2)
                    {
                        Attacker.NonVolatileStatus = NonVolatileStatus.None;

                        await WriteStatus($"{GetStatusName(Attacker)} thawed");
                    }
                    else
                    {
                        Attacker.RaiseShowNonVolativeStatusAnimation();

                        await WriteStatus($"{GetStatusName(Attacker)} is frozen. It is unable to move.");

                        return;
                    }
                    break;
                    
                case NonVolatileStatus.Paralysis:
                    if (Random.NextDouble() < 0.25)
                    {
                        Attacker.RaiseShowNonVolativeStatusAnimation();

                        await WriteStatus($"{GetStatusName(Attacker)} is paralysed. It is unable to move.");
                        
                        return;
                    }
                    break;
                
                // TODO: Snore and Sleep Talk can be used while sleeping
                case NonVolatileStatus.Sleep:
                    --Attacker.SleepCounter;

                    if (Attacker.Ability == Ability.EarlyBird)
                        --Attacker.SleepCounter;

                    if (Attacker.SleepCounter < 0)
                    {
                        Attacker.SleepCounter = 0;

                        Attacker.NonVolatileStatus = NonVolatileStatus.None;

                        await WriteStatus($"{GetStatusName(Attacker)} woke up");
                    }
                    else
                    {
                        await WriteStatus($"{GetStatusName(Attacker)} is asleep");

                        return;
                    }
                    
                    break;
            }

            if (Attacker.ConfusionCounter > 0)
            {
                --Attacker.ConfusionCounter;

                await WriteStatus($"{GetStatusName(Attacker)} is confused");

                if (Random.Next(100) < 33)
                {
                    await DamageFunctionFactory.ConfusedSelfAttack(Attacker, this);

                    return;
                }
            }

            if (Move.Info.IsZ)
            {
                Attacker.Transforming = true;

                await WriteStatus($"{GetStatusName(Attacker)} surrounded itself with its Z-Power");
                await WriteStatus($"{GetStatusName(Attacker)} unleashes its full force Z-Move");
                await WriteStatus(Move.Name.ToUpper());

                Attacker.Transforming = false;
            }
            else
            {
                await WriteStatus($"{GetStatusName(Attacker)} used {Move}{(Format != 1 && Opponent != null ? $" on {Opponent}" : "")}");

                if (DoAnimation != null)
                    await DoAnimation.Invoke(Attacker, Move, Opponent, this);
            }
            
            Move.Multitargets = false;

            async Task OnFainted(Pokemon Pokemon)
            {
                if (Pokemon?.Stats.CurrentHP == 0)
                {
                    SwitchOutEffects(Pokemon);

                    await WriteStatus($"{GetStatusName(Pokemon)} fainted");
                }
            }

            if (Format == 1)
            {
                await Move.Info.DamageFunction(Attacker, Move, Opponent, this);

                await OnFainted(Opponent);
            }
            else
            {
                switch (Move.Info.Target)
                {
                    case MoveTarget.Normal:
                    case MoveTarget.Self:
                        await Move.Info.DamageFunction(Attacker, Move, Opponent, this);

                        await OnFainted(Opponent);
                        break;

                    case MoveTarget.AllAdjacentFoes:
                        var adjacentFoes = Attacker.GetAdjacentFoes().ToArray();

                        Move.Multitargets = adjacentFoes.Length > 1;

                        foreach (var adjacentFoe in adjacentFoes)
                        {
                            await Move.Info.DamageFunction(Attacker, Move, adjacentFoe, this);

                            await OnFainted(adjacentFoe);
                        }
                        
                        break;

                    case MoveTarget.AllAdjacent:
                        var adjacents = Attacker.GetAdjacent(true).ToArray();

                        Move.Multitargets = adjacents.Length > 1;

                        foreach (var adjacent in adjacents)
                        {
                            await Move.Info.DamageFunction(Attacker, Move, adjacent, this);

                            await OnFainted(adjacent);
                        }

                        break;
                }
            }
            
            // Recoil
            if (Attacker.Stats.CurrentHP == 0)
            {
                SwitchOutEffects(Attacker);

                await WriteStatus($"{GetStatusName(Attacker)} fainted");
            }

            // Pressure
            if (Opponent?.Ability == Ability.Pressure)
                --Move.PPLeft;

            --Move.PPLeft;
        }

        async Task<bool> WaitForPlayer(bool Cancellable = false)
        {
            _battleEvent.Reset();

            try
            {
                if (Cancellable)
                {
                    _cancelEvent.Reset();

                    var signalled = await Task.Factory.StartNew(() => WaitHandle.WaitAny(new WaitHandle[]
                    {
                        _battleEvent,
                        _cancelEvent
                    }));

                    // Not the cancelled event
                    return signalled == 0;
                }
                else
                {
                    await Task.Factory.StartNew(_battleEvent.WaitOne);

                    return true;
                }
            }
            finally
            {
                BattleState = BattleState.Wait;
            }
        }

        IEnumerable<PokemonMovePair> AllBattling()
        {
            foreach (var pokemon in PlayerSide.Battling)
                if (pokemon != null)
                    yield return new PokemonMovePair(pokemon, null);

            foreach (var pokemon in OpponentSide.Battling)
                if (pokemon != null)
                    yield return new PokemonMovePair(pokemon, null);
        }
        
        async void BattleLoop()
        {
            while (true)
            {
                await Reset();

                do
                {
                    #region Switch Fainted
                    // Switch In Queue
                    var switchedIn = new List<PokemonMovePair>();

                    // Replace Player's fainted Pokemon
                    for (var i = 0; i < Format; ++i)
                    {
                        if (PlayerSide.Battling[i] != null && PlayerSide.Battling[i].IsFainted)
                        {
                            if (PlayerSide.Party.Any(Pokemon => !Pokemon.IsFainted && !PlayerSide.Battling.Contains(Pokemon)))
                            {
                                await WriteStatus("Which Pokemon do you want to send next?", false);

                                BattleState = BattleState.Switch;

                                await WaitForPlayer();

                                PlayerSide.Battling[i] = _toSwitch;

                                await WriteStatus($"Go {_toSwitch}");

                                switchedIn.Add(new PokemonMovePair(_toSwitch, null));
                            }
                            else PlayerSide.Battling[i] = null;
                        }
                    }

                    // Replace Opponent's fainted Pokemon
                    for (var i = 0; i < Format; ++i)
                    {
                        if (OpponentSide.Battling[i] != null && OpponentSide.Battling[i].IsFainted)
                        {
                            var switchable = OpponentSide.Party.FirstOrDefault(Pokemon => !Pokemon.IsFainted && !OpponentSide.Battling.Contains(Pokemon));

                            if (switchable != null)
                            {
                                OpponentSide.Battling[i] = switchable;

                                await WriteStatus($"The opposing player sent {switchable}");

                                switchedIn.Add(new PokemonMovePair(switchable, null));
                            }
                            else OpponentSide.Battling[i] = null;
                        }
                    }

                    // Switch In effects work in order of Pokemons' Speed
                    var switchOrder = MoveOrder(switchedIn).ToArray();

                    foreach (var data in switchOrder)
                    {
                        await SwitchInEffects(data.Attacker);
                    }

                    foreach (var data in switchOrder)
                    {
                        await PostTurnStatusEffects(data.Attacker);
                        await PostTurnWeatherEffects(data.Attacker);
                    }

                    switchedIn.Clear();
                    #endregion

                    // Move Queue
                    var moveQueue = new List<PokemonMovePair>();

                    // Mega Evolution Queue
                    var megaQueue = new List<PokemonMovePair>();

                    // TODO: Check Move Target type

                    // Player's moves
                    for (var i = 0; i < Format; ++i)
                    {
                        if (PlayerSide.Battling[i] == null)
                            continue;

                        // Recharging Pokemon skip a turn
                        if (PlayerSide.Battling[i].Recharging)
                        {
                            await WriteStatus($"{PlayerSide.Battling[i]} is recharging");

                            PlayerSide.Battling[i].Recharging = false;

                            continue;
                        }

                        // Until a valid move is chosen or Pokemon is switched out
                        while (true)
                        {
                            BattleState = BattleState.Move;

                            MovingPokemon = PlayerSide.Battling[i];

                            await WriteStatus($"What will {PlayerSide.Battling[i]} do?", false);

                            _toMove = null;
                            _toSwitch = null;

                            CanMegaEvolve = !PlayerSide.UsedMegaEvolution && PlayerSide.Battling[i].CanMegaEvolve(out var _);

                            CanZ = !PlayerSide.UsedZ
                                && PlayerSide.Battling[i].HeldItem is ZCrystal zCrystal
                                && PlayerSide.Battling[i].Moves.Any(M => zCrystal.Supports(PlayerSide.Battling[i], M));

                            if (CanZ)
                                ZSelector = new ZMoveSelectionViewModel(PlayerSide.Battling[i]);

                            await WaitForPlayer();

                            CanMegaEvolve = CanZ = false;
                            
                            // Switch
                            if (_toSwitch != null)
                            {
                                SwitchOutEffects(PlayerSide.Battling[i]);

                                await WriteStatus($"{PlayerSide.Battling[i]}, Come back!");

                                PlayerSide.Battling[i] = _toSwitch;

                                await WriteStatus($"Go {_toSwitch}");

                                switchedIn.Add(new PokemonMovePair(_toSwitch, null));

                                break;
                            }

                            // Move
                            if (_toMove != null)
                            {
                                var move = PlayerSide.Battling[i].Moves[_toMove.Value];

                                if (move.PPLeft == 0)
                                {
                                    await WriteStatus("This move has no PP Left");

                                    continue;
                                }

                                if (move.Disabled)
                                {
                                    await WriteStatus($"{GetStatusName(PlayerSide.Battling[i])}'s {move} was disabled");

                                    continue;
                                }

                                if (UseZ && PlayerSide.Battling[i].HeldItem is ZCrystal z)
                                {
                                    move = new Move(z.Upgrade(move));

                                    UseZ = false;
                                    PlayerSide.UsedZ = true;
                                    BattleState = BattleState.Wait;
                                }

                                Pokemon target = null;

                                if (Format == 1)
                                    target = OpponentSide.Battling[0];
                                else if (move.Info.Target == MoveTarget.Normal)
                                {
                                    SelectOpponent.Clear();

                                    foreach (var pokemon in PlayerSide.Battling[i].GetAdjacentFoes())
                                    {
                                        SelectOpponent.Add(pokemon);
                                    }

                                    if (SelectOpponent.Count == 0)
                                    {
                                        await WriteStatus("No available targets");

                                        break;
                                    }

                                    if (SelectOpponent.Count == 1)
                                    {
                                        target = SelectOpponent[0];
                                    }
                                    else
                                    {
                                        BattleState = BattleState.Target;

                                        await WriteStatus("Select Target", false);

                                        if (!await WaitForPlayer(true))
                                            continue;

                                        target = _target;
                                    }
                                }

                                if (UseMegaEvolution
                                    && !PlayerSide.UsedMegaEvolution
                                    && PlayerSide.Battling[i].CanMegaEvolve(out var _))
                                {
                                    megaQueue.Add(new PokemonMovePair(PlayerSide.Battling[i], null));

                                    PlayerSide.UsedMegaEvolution = true;
                                }

                                moveQueue.Add(new PokemonMovePair(PlayerSide.Battling[i], move)
                                {
                                    Target = target
                                });

                                break;
                            }
                        }
                    }

                    // Opponent's moves
                    for (var i = 0; i < Format; ++i)
                    {
                        if (OpponentSide.Battling[i] == null)
                            continue;

                        // Recharging Pokemon skip a turn
                        if (OpponentSide.Battling[i].Recharging)
                        {
                            await WriteStatus($"{OpponentSide.Battling[i]} is recharging");

                            OpponentSide.Battling[i].Recharging = false;

                            continue;
                        }

                        if (!OpponentSide.UsedMegaEvolution && OpponentSide.Battling[i].CanMegaEvolve(out var _))
                        {
                            megaQueue.Add(new PokemonMovePair(OpponentSide.Battling[i], null));

                            OpponentSide.UsedMegaEvolution = true;
                        }
                        
                        var moves = new List<Move>();

                        for (var j = 0; j < 4; ++j)
                        {
                            var move = OpponentSide.Battling[i].Moves[j];

                            if (move.PPLeft != 0 && move.Kind != MoveKind.Status && !move.Disabled)
                                moves.Add(move);
                        }

                        Pokemon target = null;
                        Move moveToUse;

                        if (Format == 1)
                        {
                            target = PlayerSide.Battling.Where(Pokemon => Pokemon != null)
                                .OrderBy(M => Random.Next())
                                .First();

                            moveToUse = moves.OrderByDescending(M => target.GetTypeEffectiveness(M.Type))
                                .ThenBy(M => Random.Next())
                                .First();
                        }
                        else
                        {
                            moveToUse = moves.OrderBy(M => Random.Next()).First();

                            if (moveToUse.Info.Target == MoveTarget.Normal)
                            {
                                target = OpponentSide.Battling[i].GetAdjacentFoes()
                                    .OrderByDescending(P => P.GetTypeEffectiveness(moveToUse.Type))
                                    .ThenBy(P => Random.Next())
                                    .FirstOrDefault();

                                if (target == null)
                                {
                                    await WriteStatus($"{GetStatusName(OpponentSide.Battling[i])} is loafing around");

                                    continue;
                                }
                            }
                        }

                        moveQueue.Add(new PokemonMovePair(OpponentSide.Battling[i], moveToUse)
                        {
                            Target = target
                        });
                    }

                    switchOrder = MoveOrder(switchedIn).ToArray();

                    // Switch In Effects
                    foreach (var data in switchOrder)
                    {
                        await SwitchInEffects(data.Attacker);
                    }

                    foreach (var data in switchOrder)
                    {
                        await PostTurnStatusEffects(data.Attacker);
                        await PostTurnWeatherEffects(data.Attacker);
                    }

                    // Mega Evolve
                    foreach (var data in megaQueue)
                    {
                        await MegaEvolve(data.Attacker);
                    }

                    // Move
                    foreach (var data in MoveOrder(moveQueue))
                    {
                        // If Attacker and Target are alive
                        if (!data.Attacker.IsFainted && (data.Target == null || !data.Target.IsFainted))
                            await Attack(data.Attacker, data.Move, data.Target);
                    }

                    var ordered = MoveOrder(AllBattling()).ToArray();

                    foreach (var data in ordered)
                    {
                        if (!data.Attacker.IsFainted)
                        {
                            await PostTurnWeatherEffects(data.Attacker);
                        }
                    }

                    foreach (var data in ordered)
                    {
                        if (!data.Attacker.IsFainted)
                        {
                            // Speed Boost
                            if (data.Attacker.Ability == Ability.SpeedBoost)
                            {
                                await ShowAbility(data.Attacker);

                                await DamageFunctionFactory.StatChange(data.Attacker, Stats.Speed, 1, this);
                            }

                            await PostTurnStatusEffects(data.Attacker);
                        }
                    }

                    await EndWeather();

                } while (!PlayerSide.AllFainted && !OpponentSide.AllFainted);

                // Result
                var playerFaint = PlayerSide.AllFainted;
                var opponentFaint = OpponentSide.AllFainted;

                PlayerSide = OpponentSide = null;

                if (playerFaint && opponentFaint)
                    await WriteStatus("DRAW");
                else if (playerFaint)
                    await WriteStatus("YOU LOST");
                else await WriteStatus("YOU WON");

                await WriteStatus("START NEW GAME");
            }
        }
    }
}