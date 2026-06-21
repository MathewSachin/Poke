import { useEffect, useRef, useState } from 'react';
import { MOVES, POKEMON } from '../data/gameData';
import { calcDamage, effectivenessLabel, makeBattlePokemon } from '../data/battle';
import type { BattlePokemon } from '../data/battle';
import type { Move } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import { PokemonType } from '../data/types';

type BattleFormat = 1 | 2 | 3;
type Weather = 'None' | 'Sun' | 'Rain' | 'Sandstorm' | 'Hail';

interface SideState {
  party: BattlePokemon[];
  active: number[];
}

interface BattleState {
  format: BattleFormat;
  weather: Weather;
  player: SideState;
  opponent: SideState;
  log: string[];
  over: boolean;
  winner: 'player' | 'opponent' | 'draw' | null;
  playerMegaUsed: boolean;
  playerZUsed: boolean;
}

function randomInt(maxExclusive: number): number {
  if (maxExclusive <= 0) return 0;
  return Math.floor(Math.random() * maxExclusive);
}

function randomPick<T>(arr: T[]): T | null {
  if (arr.length === 0) return null;
  return arr[randomInt(arr.length)];
}

function getMovesForSpecies(pokemon: BattlePokemon): Move[] {
  const fromLearnset = pokemon.species.learnset
    .map((name) => MOVES.find((move) => move.name === name))
    .filter((move): move is Move => move != null);
  const damaging = fromLearnset.filter((move) => move.kind !== 'Status');
  if (damaging.length >= 4) return damaging.slice(0, 4);
  if (fromLearnset.length >= 4) return fromLearnset.slice(0, 4);
  return MOVES.filter((move) => move.kind !== 'Status').slice(0, 4);
}

function buildParty(excluded: Set<string>): BattlePokemon[] {
  const party: BattlePokemon[] = [];
  while (party.length < 6 && POKEMON.length > 0) {
    const available = POKEMON.filter((species) => !excluded.has(`${species.number}_${species.name}`));
    const source = available.length > 0 ? available : POKEMON;
    const species = randomPick(source);
    if (!species) break;
    if (available.length > 0) {
      const key = `${species.number}_${species.name}`;
      excluded.add(key);
    }
    party.push(makeBattlePokemon(species));
  }
  return party;
}

function firstAliveBench(side: SideState): number | null {
  const activeSet = new Set(side.active);
  for (let i = 0; i < side.party.length; i += 1) {
    if (activeSet.has(i)) continue;
    if (side.party[i].hp > 0) return i;
  }
  return null;
}

function ensureActiveSlots(side: SideState): SideState {
  const nextActive = [...side.active];
  for (let i = 0; i < nextActive.length; i += 1) {
    const partyIndex = nextActive[i];
    const battler = side.party[partyIndex];
    if (battler && battler.hp > 0) continue;
    const replacement = firstAliveBench({ ...side, active: nextActive });
    if (replacement == null) continue;
    nextActive[i] = replacement;
  }
  return { ...side, active: nextActive };
}

function allFainted(side: SideState): boolean {
  return side.party.every((pokemon) => pokemon.hp <= 0);
}

function weatherMultiplier(weather: Weather, move: Move): number {
  if (weather === 'Sun') {
    if (move.type === PokemonType.Fire) return 1.5;
    if (move.type === PokemonType.Water) return 0.5;
  }
  if (weather === 'Rain') {
    if (move.type === PokemonType.Water) return 1.5;
    if (move.type === PokemonType.Fire) return 0.5;
  }
  return 1;
}

function newBattle(format: BattleFormat): BattleState {
  const excluded = new Set<string>();
  const playerParty = buildParty(excluded);
  const opponentParty = buildParty(excluded);
  return {
    format,
    weather: 'None',
    player: { party: playerParty, active: Array.from({ length: format }, (_, i) => i) },
    opponent: { party: opponentParty, active: Array.from({ length: format }, (_, i) => i) },
    log: ['A battle started!'],
    over: false,
    winner: null,
    playerMegaUsed: false,
    playerZUsed: false,
  };
}

function HpBar({ hp, maxHp }: { hp: number; maxHp: number }) {
  const pct = Math.max(0, Math.min(100, (hp / maxHp) * 100));
  const color = pct > 50 ? '#22c55e' : pct > 20 ? '#f59e0b' : '#ef4444';
  return (
    <div className="mt-1">
      <div className="w-full bg-gray-200 rounded-full h-2">
        <div className="h-2 rounded-full transition-all" style={{ width: `${pct}%`, backgroundColor: color }} />
      </div>
      <p className="text-xs text-gray-500 mt-0.5">{hp} / {maxHp} HP</p>
    </div>
  );
}

function BattlerCard({
  battler,
  label,
  fainted,
}: {
  battler: BattlePokemon;
  label: string;
  fainted: boolean;
}) {
  return (
    <div className={`rounded-xl border p-2 ${fainted ? 'opacity-60 bg-gray-100 border-gray-200' : 'bg-white border-gray-200'}`}>
      <p className="text-xs text-gray-400">{label}</p>
      <img src={battler.spriteUrl} alt={battler.species.name} className="w-16 h-16 mx-auto object-contain" />
      <p className="font-bold text-xs text-center text-gray-800">{battler.species.name}</p>
      <div className="flex gap-1 justify-center mt-0.5">
        <TypeBadge type={battler.species.primaryType} small />
        {battler.species.secondaryType != null && <TypeBadge type={battler.species.secondaryType} small />}
      </div>
      <HpBar hp={battler.hp} maxHp={battler.maxHp} />
    </div>
  );
}

export function BattlePage() {
  const [state, setState] = useState<BattleState>(() => newBattle(1));
  const [playerSlot, setPlayerSlot] = useState(0);
  const [targetSlot, setTargetSlot] = useState(0);
  const [selectedMoveName, setSelectedMoveName] = useState<string>('');
  const [pendingMega, setPendingMega] = useState(false);
  const [pendingZMove, setPendingZMove] = useState(false);
  const [switchSlot, setSwitchSlot] = useState(0);
  const [switchToIndex, setSwitchToIndex] = useState(0);
  const logRef = useRef<HTMLDivElement | null>(null);

  useEffect(() => {
    if (logRef.current) {
      logRef.current.scrollTop = logRef.current.scrollHeight;
    }
  }, [state.log]);

  const playerParty = state.player.party;
  const opponentParty = state.opponent.party;
  const playerActives = state.player.active.map((partyIndex) => playerParty[partyIndex]);
  const opponentActives = state.opponent.active.map((partyIndex) => opponentParty[partyIndex]);

  const currentPlayerBattler = playerActives[playerSlot] ?? playerActives[0];
  const currentMoveOptions = getMovesForSpecies(currentPlayerBattler);
  const selectedMoveResolved =
    currentMoveOptions.find((move) => move.name === selectedMoveName)?.name ??
    currentMoveOptions[0]?.name ??
    '';
  const activeGridClass =
    state.format === 1 ? 'grid-cols-1' : state.format === 2 ? 'grid-cols-2' : 'grid-cols-3';

  const switchCandidates = state.player.party
    .map((pokemon, index) => ({ pokemon, index }))
    .filter(({ pokemon, index }) => pokemon.hp > 0 && !state.player.active.includes(index));

  function applyActionTurn() {
    if (state.over || !currentPlayerBattler || !selectedMoveResolved) return;

    const selectedMove = MOVES.find((move) => move.name === selectedMoveResolved);
    if (!selectedMove) return;

    const next: BattleState = {
      ...state,
      player: { ...state.player, party: state.player.party.map((p) => ({ ...p })), active: [...state.player.active] },
      opponent: { ...state.opponent, party: state.opponent.party.map((p) => ({ ...p })), active: [...state.opponent.active] },
      log: [...state.log],
    };

    type Action = {
      actorSide: 'player' | 'opponent';
      actorSlot: number;
      targetSlot: number;
      move: Move;
      zBoost: boolean;
      megaBoost: boolean;
      speed: number;
    };

    const actions: Action[] = [];
    const selectedPlayerPartyIndex = next.player.active[playerSlot];

    next.player.active.forEach((partyIndex, slotIndex) => {
      const battler = next.player.party[partyIndex];
      if (!battler || battler.hp <= 0) return;
      if (slotIndex === playerSlot) {
        actions.push({
          actorSide: 'player',
          actorSlot: slotIndex,
          targetSlot,
          move: selectedMove,
          zBoost: pendingZMove && !next.playerZUsed,
          megaBoost: pendingMega && !next.playerMegaUsed,
          speed: battler.speed,
        });
      } else {
        const randomMove = randomPick(getMovesForSpecies(battler));
        if (!randomMove) return;
        const liveTargets = next.opponent.active.filter((idx) => next.opponent.party[idx].hp > 0);
        if (liveTargets.length === 0) return;
        const chosenTargetPartyIndex = randomPick(liveTargets);
        if (chosenTargetPartyIndex == null) return;
        const resolvedTarget = next.opponent.active.findIndex((idx) => idx === chosenTargetPartyIndex);
        if (resolvedTarget < 0) return;
        actions.push({
          actorSide: 'player',
          actorSlot: slotIndex,
          targetSlot: resolvedTarget,
          move: randomMove,
          zBoost: false,
          megaBoost: false,
          speed: battler.speed,
        });
      }
    });

    next.opponent.active.forEach((partyIndex, slotIndex) => {
      const battler = next.opponent.party[partyIndex];
      if (!battler || battler.hp <= 0) return;
      const randomMove = randomPick(getMovesForSpecies(battler));
      if (!randomMove) return;
      const liveTargets = next.player.active.filter((idx) => next.player.party[idx].hp > 0);
      if (liveTargets.length === 0) return;
      const targetPartyIndex = randomPick(liveTargets);
      if (targetPartyIndex == null) return;
      const resolvedTarget = next.player.active.findIndex((idx) => idx === targetPartyIndex);
      if (resolvedTarget < 0) return;
      actions.push({
        actorSide: 'opponent',
        actorSlot: slotIndex,
        targetSlot: resolvedTarget,
        move: randomMove,
        zBoost: false,
        megaBoost: false,
        speed: battler.speed,
      });
    });

    actions.sort((a, b) => b.speed - a.speed);

    for (const action of actions) {
      const atkSide = action.actorSide === 'player' ? next.player : next.opponent;
      const defSide = action.actorSide === 'player' ? next.opponent : next.player;
      const atkPartyIndex = atkSide.active[action.actorSlot];
      const attacker = atkSide.party[atkPartyIndex];
      if (!attacker || attacker.hp <= 0) continue;
      if (defSide.active.length === 0) continue;
      const targetSlotResolved = Math.min(action.targetSlot, defSide.active.length - 1);
      const defPartyIndex = defSide.active[targetSlotResolved];
      const defender = defSide.party[defPartyIndex];
      if (!defender || defender.hp <= 0) continue;

      const attackerForDamage = { ...attacker };
      if (action.megaBoost) {
        attackerForDamage.attack = Math.floor(attackerForDamage.attack * 1.25);
        attackerForDamage.spAttack = Math.floor(attackerForDamage.spAttack * 1.25);
        attackerForDamage.speed = Math.floor(attackerForDamage.speed * 1.1);
      }

      let damage = calcDamage(attackerForDamage, action.move, defender);
      damage = Math.floor(damage * weatherMultiplier(next.weather, action.move));
      if (action.zBoost) damage = Math.floor(damage * 1.5);
      damage = Math.max(1, damage);

      defender.hp = Math.max(0, defender.hp - damage);

      const actorName = attacker.species.name;
      const targetName = defender.species.name;
      const zLabel = action.zBoost ? ' as a Z-Move' : '';
      const megaLabel = action.megaBoost ? ' after Mega Evolution' : '';
      const effectivenessText = effectivenessLabel(
        action.move.type,
        defender.species.primaryType,
        defender.species.secondaryType,
      );
      next.log.push(
        `${actorName} used ${action.move.name}${zLabel}${megaLabel} on ${targetName}! Dealt ${damage} dmg.${effectivenessText}`,
      );
      if (defender.hp <= 0) {
        next.log.push(`${targetName} fainted!`);
      }

      if (action.megaBoost && action.actorSide === 'player') next.playerMegaUsed = true;
      if (action.zBoost && action.actorSide === 'player') next.playerZUsed = true;
    }

    next.player = ensureActiveSlots(next.player);
    next.opponent = ensureActiveSlots(next.opponent);

    if (allFainted(next.player) && allFainted(next.opponent)) {
      next.over = true;
      next.winner = 'draw';
    } else if (allFainted(next.opponent)) {
      next.over = true;
      next.winner = 'player';
    } else if (allFainted(next.player)) {
      next.over = true;
      next.winner = 'opponent';
    }

    if (!next.over && pendingMega && !state.playerMegaUsed) {
      const battler = next.player.party[selectedPlayerPartyIndex];
      if (battler) next.log.push(`${battler.species.name} Mega Evolved!`);
    }

    setPendingMega(false);
    setPendingZMove(false);
    setState(next);
  }

  function switchPokemon() {
    if (state.over) return;
    const side = { ...state.player, active: [...state.player.active], party: state.player.party.map((p) => ({ ...p })) };
    const activePartyIndex = side.active[switchSlot];
    const replacement = side.party[switchToIndex];
    if (
      activePartyIndex === switchToIndex ||
      !replacement ||
      replacement.hp <= 0 ||
      side.active.includes(switchToIndex)
    ) {
      return;
    }

    const oldName = side.party[activePartyIndex].species.name;
    side.active[switchSlot] = switchToIndex;
    const newName = side.party[switchToIndex].species.name;
    setState((prev) => ({
      ...prev,
      player: side,
      log: [...prev.log, `You withdrew ${oldName} and sent out ${newName}!`],
    }));
  }

  function changeFormat(format: BattleFormat) {
    setState(newBattle(format));
    setPlayerSlot(0);
    setTargetSlot(0);
    setPendingMega(false);
    setPendingZMove(false);
  }

  return (
    <div className="max-w-5xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Battle Simulator</h1>

      <div className="bg-white border border-gray-200 rounded-xl p-3 mb-4 grid grid-cols-1 md:grid-cols-3 gap-2">
        <label className="text-sm">
          <span className="text-gray-600">Battle Format</span>
          <select
            value={state.format}
            onChange={(e) => changeFormat(Number(e.target.value) as BattleFormat)}
            className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
          >
            <option value={1}>Singles (1v1)</option>
            <option value={2}>Doubles (2v2)</option>
            <option value={3}>Triples (3v3)</option>
          </select>
        </label>
        <label className="text-sm">
          <span className="text-gray-600">Weather</span>
          <select
            value={state.weather}
            onChange={(e) => setState((prev) => ({ ...prev, weather: e.target.value as Weather }))}
            className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
          >
            <option value="None">None</option>
            <option value="Sun">Sun</option>
            <option value="Rain">Rain</option>
            <option value="Sandstorm">Sandstorm</option>
            <option value="Hail">Hail</option>
          </select>
        </label>
        <button
          onClick={() => setState(newBattle(state.format))}
          className="mt-5 md:mt-0 h-10 self-end bg-red-600 hover:bg-red-700 text-white font-semibold rounded-lg"
        >
          New Battle
        </button>
      </div>

      <div className="bg-green-50 rounded-2xl p-4 border border-green-100 mb-4">
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-4">
          <div>
            <p className="font-semibold text-sm text-gray-700 mb-2">Your active Pokémon</p>
            <div className={`grid gap-2 ${activeGridClass}`}>
              {playerActives.map((battler, index) => (
                <button key={`p_${state.player.active[index]}`} onClick={() => setPlayerSlot(index)} className={playerSlot === index ? 'ring-2 ring-blue-400 rounded-xl' : ''}>
                  <BattlerCard battler={battler} label={`Slot ${index + 1}`} fainted={battler.hp <= 0} />
                </button>
              ))}
            </div>
          </div>
          <div>
            <p className="font-semibold text-sm text-gray-700 mb-2">Opponent active Pokémon</p>
            <div className={`grid gap-2 ${activeGridClass}`}>
              {opponentActives.map((battler, index) => (
                <button key={`o_${state.opponent.active[index]}`} onClick={() => setTargetSlot(index)} className={targetSlot === index ? 'ring-2 ring-red-400 rounded-xl' : ''}>
                  <BattlerCard battler={battler} label={`Target ${index + 1}`} fainted={battler.hp <= 0} />
                </button>
              ))}
            </div>
          </div>
        </div>
      </div>

      <div ref={logRef} className="bg-gray-900 rounded-xl p-3 h-40 overflow-y-auto mb-4 flex flex-col gap-0.5">
        {state.log.slice(-16).map((line, i) => (
          <p key={i} className="text-green-300 text-xs font-mono">{line}</p>
        ))}
      </div>

      {!state.over ? (
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-3">
          <div className="bg-white border border-gray-200 rounded-xl p-3">
            <p className="text-sm font-semibold text-gray-700 mb-2">Move command</p>
            <label className="text-sm block mb-2">
              <span className="text-gray-600">Move</span>
              <select
                value={selectedMoveResolved}
                onChange={(e) => setSelectedMoveName(e.target.value)}
                className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
              >
                {currentMoveOptions.map((move) => (
                  <option key={move.name} value={move.name}>
                    {move.name} ({move.kind})
                  </option>
                ))}
              </select>
            </label>
            <div className="grid grid-cols-2 gap-2 mb-2">
              <label className="text-xs flex items-center gap-2 border border-gray-200 rounded-lg px-2 py-1.5">
                <input
                  type="checkbox"
                  checked={pendingMega && !state.playerMegaUsed}
                  disabled={state.playerMegaUsed}
                  onChange={(e) => setPendingMega(e.target.checked)}
                />
                Mega Evolution
              </label>
              <label className="text-xs flex items-center gap-2 border border-gray-200 rounded-lg px-2 py-1.5">
                <input
                  type="checkbox"
                  checked={pendingZMove && !state.playerZUsed}
                  disabled={state.playerZUsed}
                  onChange={(e) => setPendingZMove(e.target.checked)}
                />
                Z-Move
              </label>
            </div>
            <button
              onClick={applyActionTurn}
              className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 rounded-lg"
            >
              Execute Turn
            </button>
          </div>

          <div className="bg-white border border-gray-200 rounded-xl p-3">
            <p className="text-sm font-semibold text-gray-700 mb-2">Switch command</p>
            <div className="grid grid-cols-2 gap-2">
              <label className="text-sm">
                <span className="text-gray-600">Active slot</span>
                <select
                  value={switchSlot}
                  onChange={(e) => setSwitchSlot(Number(e.target.value))}
                  className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                >
                  {state.player.active.map((_, index) => (
                    <option key={index} value={index}>{index + 1}</option>
                  ))}
                </select>
              </label>
              <label className="text-sm">
                <span className="text-gray-600">Switch to</span>
                <select
                  value={switchToIndex}
                  onChange={(e) => setSwitchToIndex(Number(e.target.value))}
                  className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                >
                  {switchCandidates.map(({ pokemon, index }) => (
                    <option key={index} value={index}>{pokemon.species.name}</option>
                  ))}
                </select>
              </label>
            </div>
            <button
              onClick={switchPokemon}
              disabled={switchCandidates.length === 0}
              className="mt-2 w-full bg-emerald-600 hover:bg-emerald-700 disabled:opacity-40 text-white font-semibold py-2 rounded-lg"
            >
              Switch Pokémon
            </button>
          </div>
        </div>
      ) : (
        <div>
          <div
            className={`rounded-xl p-5 text-center mb-4 ${
              state.winner === 'player'
                ? 'bg-green-100 border border-green-200'
                : state.winner === 'draw'
                  ? 'bg-amber-100 border border-amber-200'
                  : 'bg-red-100 border border-red-200'
            }`}
          >
            <p className="text-xl font-bold">
              {state.winner === 'player' ? '🏆 You won!' : state.winner === 'draw' ? '🤝 Draw!' : '💀 You lost...'}
            </p>
          </div>
          <button
            onClick={() => setState(newBattle(state.format))}
            className="w-full bg-red-600 hover:bg-red-700 text-white font-semibold py-3 rounded-xl transition-colors"
          >
            New Battle
          </button>
        </div>
      )}
    </div>
  );
}
