import { useEffect, useRef, useState } from 'react';
import { MOVES, POKEMON } from '../data/gameData';
import { calcDamage, effectivenessLabel, makeBattlePokemon } from '../data/battle';
import type { BattlePokemon } from '../data/battle';
import type { Move } from '../data/gameData';
import { PokemonType, TYPE_COLORS, typeName } from '../data/types';

type BattleFormat = 1 | 2 | 3;
type Weather = 'None' | 'Sun' | 'Rain' | 'Sandstorm' | 'Hail';
type MenuState = 'main' | 'fight' | 'pokemon';
type ActiveAnimation = { side: 'player' | 'opponent'; slot: number } | null;

const ATTACK_PUSH_X = 14;
const ATTACK_PUSH_Y = -2;
const ATTACK_OFFSET_TRANSFORM = `translateX(-${ATTACK_PUSH_X}px) translateY(${ATTACK_PUSH_Y}px)`;
const ATTACK_RECOVER_MS = 220;
const TURN_ATTACK_FRAME_MS = 620;
const TURN_STATUS_FRAME_MS = 340;

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

function cloneBattleState(state: BattleState): BattleState {
  return {
    ...state,
    player: { ...state.player, party: state.player.party.map((pokemon) => ({ ...pokemon })), active: [...state.player.active] },
    opponent: { ...state.opponent, party: state.opponent.party.map((pokemon) => ({ ...pokemon })), active: [...state.opponent.active] },
    log: [...state.log],
  };
}

function sameActiveSlots(a: number[], b: number[]): boolean {
  if (a.length !== b.length) return false;
  return a.every((value, index) => value === b[index]);
}

function needsFinalFrame(latestFrameState: BattleState | undefined, finalState: BattleState): boolean {
  if (!latestFrameState) return true;
  return (
    latestFrameState.log.length !== finalState.log.length
    || latestFrameState.over !== finalState.over
    || latestFrameState.winner !== finalState.winner
    || !sameActiveSlots(latestFrameState.player.active, finalState.player.active)
    || !sameActiveSlots(latestFrameState.opponent.active, finalState.opponent.active)
  );
}

function clearTurnTimeouts(
  actionTimerRef: { current: number | null },
  frameTimerRef: { current: number | null },
): void {
  if (actionTimerRef.current !== null) {
    window.clearTimeout(actionTimerRef.current);
    actionTimerRef.current = null;
  }
  if (frameTimerRef.current !== null) {
    window.clearTimeout(frameTimerRef.current);
    frameTimerRef.current = null;
  }
}

function GameHpBar({ hp, maxHp, showNumbers }: { hp: number; maxHp: number; showNumbers?: boolean }) {
  const pct = Math.max(0, Math.min(100, (hp / maxHp) * 100));
  const color = pct > 50 ? '#48d048' : pct > 20 ? '#f8c820' : '#e82010';
  return (
    <div>
      <div style={{ display: 'flex', alignItems: 'center', gap: '4px' }}>
        <span style={{ fontSize: '9px', fontWeight: 800, color: '#484848', letterSpacing: '0.5px', fontFamily: 'monospace' }}>HP</span>
        <div style={{ flex: 1, height: '7px', background: '#383838', borderRadius: '4px', border: '1px solid #202020', overflow: 'hidden' }}>
          <div style={{ width: `${pct}%`, height: '100%', background: color, transition: 'width 0.4s ease', borderRadius: '4px' }} />
        </div>
      </div>
      {showNumbers && (
        <p style={{ textAlign: 'right', fontSize: '10px', color: '#282828', margin: '2px 0 0 0', fontFamily: 'monospace', fontWeight: 700 }}>
          {hp}<span style={{ color: '#888' }}>/{maxHp}</span>
        </p>
      )}
    </div>
  );
}

function OppHpBox({ battler, fainted }: { battler: BattlePokemon; fainted: boolean }) {
  return (
    <div style={{
      background: 'linear-gradient(160deg, #f0efe8 0%, #dddcd4 100%)',
      border: '2.5px solid #282828',
      borderRadius: '8px',
      padding: '5px 10px 6px 10px',
      minWidth: '160px',
      opacity: fainted ? 0.45 : 1,
      boxShadow: '3px 3px 0 rgba(0,0,0,0.35)',
    }}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'baseline', marginBottom: '3px' }}>
        <span style={{ fontWeight: 800, fontSize: '12px', letterSpacing: '0.4px' }}>{battler.species.name.toUpperCase()}</span>
        <span style={{ fontSize: '10px', color: '#505050' }}>Lv<b>50</b></span>
      </div>
      <GameHpBar hp={battler.hp} maxHp={battler.maxHp} />
    </div>
  );
}

function PlayerHpBox({ battler, fainted }: { battler: BattlePokemon; fainted: boolean }) {
  return (
    <div style={{
      background: 'linear-gradient(160deg, #f0efe8 0%, #dddcd4 100%)',
      border: '2.5px solid #282828',
      borderRadius: '8px',
      padding: '5px 10px 6px 10px',
      minWidth: '185px',
      opacity: fainted ? 0.45 : 1,
      boxShadow: '3px 3px 0 rgba(0,0,0,0.35)',
    }}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'baseline', marginBottom: '3px' }}>
        <span style={{ fontWeight: 800, fontSize: '12px', letterSpacing: '0.4px' }}>{battler.species.name.toUpperCase()}</span>
        <span style={{ fontSize: '10px', color: '#505050' }}>Lv<b>50</b></span>
      </div>
      <GameHpBar hp={battler.hp} maxHp={battler.maxHp} showNumbers />
    </div>
  );
}

function PartyBalls({ party }: { party: BattlePokemon[] }) {
  return (
    <div style={{ display: 'flex', gap: '5px', alignItems: 'center' }}>
      {party.map((p, i) => {
        const pct = p.maxHp > 0 ? p.hp / p.maxHp : 0;
        const color = p.hp <= 0 ? '#888' : pct > 0.5 ? '#30b030' : pct > 0.2 ? '#f8c820' : '#e82010';
        return (
          <div key={i} style={{
            width: '13px', height: '13px', borderRadius: '50%',
            background: color, border: '2px solid #282828',
            boxShadow: p.hp > 0 ? `0 0 4px ${color}88` : 'none',
          }} />
        );
      })}
    </div>
  );
}

export function BattlePage() {
  const [state, setState] = useState<BattleState>(() => newBattle(1));
  const [playerSlot, setPlayerSlot] = useState(0);
  const [targetSlot, setTargetSlot] = useState(0);
  const [menuState, setMenuState] = useState<MenuState>('main');
  const [pendingMega, setPendingMega] = useState(false);
  const [pendingZMove, setPendingZMove] = useState(false);
  const [hoveredMove, setHoveredMove] = useState<Move | null>(null);
  const [showLog, setShowLog] = useState(false);
  const [isAnimatingTurn, setIsAnimatingTurn] = useState(false);
  const [activeAnimation, setActiveAnimation] = useState<ActiveAnimation>(null);
  const logRef = useRef<HTMLDivElement | null>(null);
  const actionTimerRef = useRef<number | null>(null);
  const frameTimerRef = useRef<number | null>(null);

  useEffect(() => () => clearTurnTimeouts(actionTimerRef, frameTimerRef), []);

  const resetTurnControls = () => {
    setPendingMega(false);
    setPendingZMove(false);
    setMenuState('main');
    setHoveredMove(null);
  };

  const playerParty = state.player.party;
  const opponentParty = state.opponent.party;
  const playerActives = state.player.active.map((i) => playerParty[i]);
  const opponentActives = state.opponent.active.map((i) => opponentParty[i]);
  const currentPlayerBattler = playerActives[playerSlot] ?? playerActives[0];
  const currentMoveOptions = getMovesForSpecies(currentPlayerBattler);

  function executeTurn(selectedMove: Move) {
    if (state.over || !currentPlayerBattler || isAnimatingTurn) return;

    const next = cloneBattleState(state);
    const turnFrames: Array<{ state: BattleState; animation: ActiveAnimation }> = [];

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
      turnFrames.push({
        state: cloneBattleState(next),
        animation: { side: action.actorSide, slot: action.actorSlot },
      });
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

    const finalState = cloneBattleState(next);
    const latestFrameState = turnFrames[turnFrames.length - 1]?.state;
    if (needsFinalFrame(latestFrameState, finalState)) {
      turnFrames.push({ state: finalState, animation: null });
    }

    resetTurnControls();

    if (turnFrames.length === 0) {
      setState(finalState);
      return;
    }

    clearTurnTimeouts(actionTimerRef, frameTimerRef);
    setIsAnimatingTurn(true);
    const playFrame = (frameIndex: number) => {
      const frame = turnFrames[frameIndex];
      if (!frame) {
        setActiveAnimation(null);
        setIsAnimatingTurn(false);
        return;
      }
      setState(frame.state);
      setActiveAnimation(frame.animation);
      const clearAttackAnimation = () => {
        setActiveAnimation(null);
      };
      actionTimerRef.current = window.setTimeout(clearAttackAnimation, ATTACK_RECOVER_MS);
      frameTimerRef.current = window.setTimeout(() => playFrame(frameIndex + 1), frame.animation ? TURN_ATTACK_FRAME_MS : TURN_STATUS_FRAME_MS);
    };
    playFrame(0);
  }

  function doSwitch(toIndex: number) {
    if (state.over || isAnimatingTurn) return;
    const side = { ...state.player, active: [...state.player.active], party: state.player.party.map((p) => ({ ...p })) };
    const activePartyIndex = side.active[playerSlot];
    const replacement = side.party[toIndex];
    if (activePartyIndex === toIndex || !replacement || replacement.hp <= 0 || side.active.includes(toIndex)) return;
    const oldName = side.party[activePartyIndex].species.name;
    side.active[playerSlot] = toIndex;
    const newName = side.party[toIndex].species.name;
    setState((prev) => ({
      ...prev,
      player: side,
      log: [...prev.log, `You withdrew ${oldName} and sent out ${newName}!`],
    }));
    setMenuState('main');
  }

  function changeFormat(format: BattleFormat) {
    clearTurnTimeouts(actionTimerRef, frameTimerRef);
    setIsAnimatingTurn(false);
    setActiveAnimation(null);
    setState(newBattle(format));
    setPlayerSlot(0);
    setTargetSlot(0);
    resetTurnControls();
  }

  const latestMessage = isAnimatingTurn ? 'Actions are playing out...' : (state.log[state.log.length - 1] ?? 'A battle started!');

  const weatherIcon: Record<Weather, string> = {
    None: '', Sun: '☀️', Rain: '🌧️', Sandstorm: '🌪️', Hail: '❄️',
  };

  const spriteSize = state.format === 1 ? 88 : state.format === 2 ? 72 : 60;
  const TAB_NAME_LEN = 7;
  const actionUiDisabled = state.over || isAnimatingTurn;
  const spriteAttackTransform = (side: 'player' | 'opponent', slot: number) => {
    const isAttacking = activeAnimation?.side === side && activeAnimation.slot === slot;
    if (side === 'player') {
      if (!isAttacking) return 'scaleX(-1)';
      return `scaleX(-1) ${ATTACK_OFFSET_TRANSFORM}`;
    }
    if (!isAttacking) return 'none';
    return ATTACK_OFFSET_TRANSFORM;
  };

  // Shared button base style
  const menuBtn = (bg: string): React.CSSProperties => ({
    background: bg,
    border: '2.5px solid #282828',
    borderRadius: '8px',
    color: 'white',
    fontWeight: 800,
    fontSize: '14px',
    letterSpacing: '0.5px',
    padding: '10px 4px',
    cursor: 'pointer',
    boxShadow: '0 3px 0 rgba(0,0,0,0.4)',
    textShadow: '1px 1px 0 rgba(0,0,0,0.4)',
    transition: 'filter 0.1s, transform 0.1s',
    width: '100%',
  });

  const backBtn: React.CSSProperties = {
    background: '#606878',
    border: '2px solid #282828',
    borderRadius: '6px',
    color: 'white',
    fontWeight: 700,
    fontSize: '12px',
    padding: '6px 14px',
    cursor: 'pointer',
    boxShadow: '0 2px 0 rgba(0,0,0,0.3)',
  };

  return (
    <div style={{ maxWidth: '780px', margin: '0 auto', padding: '16px', fontFamily: "'Segoe UI', system-ui, sans-serif" }}>

      {/* ── Settings bar ── */}
      <div style={{ display: 'flex', gap: '8px', marginBottom: '10px', flexWrap: 'wrap', alignItems: 'center' }}>
        <select
          value={state.format}
          disabled={isAnimatingTurn}
          onChange={(e) => changeFormat(Number(e.target.value) as BattleFormat)}
          style={{ border: '2px solid #404040', borderRadius: '6px', padding: '5px 8px', fontWeight: 700, fontSize: '13px', background: '#f0f0f0', cursor: isAnimatingTurn ? 'not-allowed' : 'pointer', opacity: isAnimatingTurn ? 0.65 : 1 }}
        >
          <option value={1}>Singles (1v1)</option>
          <option value={2}>Doubles (2v2)</option>
          <option value={3}>Triples (3v3)</option>
        </select>
        <select
          value={state.weather}
          disabled={isAnimatingTurn}
          onChange={(e) => setState((prev) => ({ ...prev, weather: e.target.value as Weather }))}
          style={{ border: '2px solid #404040', borderRadius: '6px', padding: '5px 8px', fontWeight: 700, fontSize: '13px', background: '#f0f0f0', cursor: isAnimatingTurn ? 'not-allowed' : 'pointer', opacity: isAnimatingTurn ? 0.65 : 1 }}
        >
          <option value="None">☀️ Clear</option>
          <option value="Sun">🌞 Harsh Sun</option>
          <option value="Rain">🌧️ Rain</option>
          <option value="Sandstorm">🌪️ Sandstorm</option>
          <option value="Hail">❄️ Hail</option>
        </select>
        <button
          disabled={isAnimatingTurn}
          onClick={() => {
            clearTurnTimeouts(actionTimerRef, frameTimerRef);
            setIsAnimatingTurn(false);
            setActiveAnimation(null);
            setState(newBattle(state.format));
            resetTurnControls();
          }}
          style={{ ...menuBtn('#c03030'), padding: '6px 14px', fontSize: '13px', width: 'auto', opacity: isAnimatingTurn ? 0.65 : 1, cursor: isAnimatingTurn ? 'not-allowed' : 'pointer' }}
        >
          🔄 New Battle
        </button>
        <button
          onClick={() => setShowLog((v) => !v)}
          style={{ ...menuBtn('#405880'), padding: '6px 14px', fontSize: '13px', width: 'auto' }}
        >
          📜 {showLog ? 'Hide Log' : 'Battle Log'}
        </button>
      </div>

      {/* ── Battle scene ── */}
      <div style={{
        position: 'relative',
        width: '100%',
        aspectRatio: '16 / 7',
        overflow: 'hidden',
        borderRadius: '14px 14px 0 0',
        border: '3px solid #282828',
        borderBottom: 'none',
        userSelect: 'none',
      }}>
        {/* Sky gradient */}
        <div style={{ position: 'absolute', inset: 0, background: 'linear-gradient(to bottom, #6cb4f0 0%, #a8d8f8 55%, #a8d8f8 55%, #68a850 55%, #4a8840 100%)' }} />

        {/* Opponent platform (raised oval on upper-right ground line) */}
        <div style={{ position: 'absolute', top: '48%', right: '12%', width: '22%', height: '9%', background: 'radial-gradient(ellipse, #b8d890 60%, #88b860 100%)', borderRadius: '50%', boxShadow: '0 5px 0 #6a9848' }} />
        {/* Player platform */}
        <div style={{ position: 'absolute', top: '55%', left: '10%', width: '28%', height: '12%', background: 'radial-gradient(ellipse, #c0e098 60%, #90c070 100%)', borderRadius: '50%', boxShadow: '0 6px 0 #6a9848' }} />

        {/* Opponent HP boxes — top-left */}
        <div style={{ position: 'absolute', top: '6%', left: '3%', display: 'flex', flexDirection: 'column', gap: '5px' }}>
          {opponentActives.map((battler, i) => (
            <OppHpBox key={`ohp_${i}`} battler={battler} fainted={battler.hp <= 0} />
          ))}
        </div>

        {/* Opponent sprites — upper right, on platform */}
        <div style={{ position: 'absolute', top: '5%', right: '5%', display: 'flex', gap: '6px', alignItems: 'flex-end' }}>
          {opponentActives.map((battler, i) => (
            <div
              key={`osp_${i}`}
              style={{ textAlign: 'center', cursor: actionUiDisabled ? 'default' : 'pointer' }}
              onClick={() => { if (!actionUiDisabled) setTargetSlot(i); }}
            >
              <img
                src={battler.spriteUrl}
                alt={battler.species.name}
                style={{
                  width: `${spriteSize}px`,
                  height: `${spriteSize}px`,
                  objectFit: 'contain',
                  opacity: battler.hp <= 0 ? 0.25 : 1,
                  imageRendering: 'pixelated',
                  transform: spriteAttackTransform('opponent', i),
                  transition: 'transform 0.18s ease-out',
                }}
              />
              {targetSlot === i && battler.hp > 0 && (
                <div style={{ height: '3px', background: '#e83030', borderRadius: '2px', margin: '1px auto 0', width: '60%' }} />
              )}
            </div>
          ))}
        </div>

        {/* Player sprites — lower left, on platform, mirrored */}
        <div style={{ position: 'absolute', bottom: '18%', left: '6%', display: 'flex', gap: '6px', alignItems: 'flex-end' }}>
          {playerActives.map((battler, i) => (
            <div
              key={`psp_${i}`}
              style={{ textAlign: 'center', cursor: state.format > 1 && !actionUiDisabled ? 'pointer' : 'default' }}
              onClick={() => { if (state.format > 1 && !actionUiDisabled) setPlayerSlot(i); }}
            >
              <img
                src={battler.spriteUrl}
                alt={battler.species.name}
                style={{
                  width: `${spriteSize}px`,
                  height: `${spriteSize}px`,
                  objectFit: 'contain',
                  opacity: battler.hp <= 0 ? 0.25 : 1,
                  transform: spriteAttackTransform('player', i),
                  transition: 'transform 0.18s ease-out',
                  imageRendering: 'pixelated',
                }}
              />
              {playerSlot === i && state.format > 1 && (
                <div style={{ height: '3px', background: '#3878e8', borderRadius: '2px', margin: '1px auto 0', width: '60%' }} />
              )}
            </div>
          ))}
        </div>

        {/* Player HP boxes — bottom-right */}
        <div style={{ position: 'absolute', bottom: '5%', right: '3%', display: 'flex', flexDirection: 'column', gap: '5px', alignItems: 'flex-end' }}>
          {playerActives.map((battler, i) => (
            <PlayerHpBox key={`php_${i}`} battler={battler} fainted={battler.hp <= 0} />
          ))}
        </div>

        {/* Weather badge */}
        {state.weather !== 'None' && (
          <div style={{ position: 'absolute', top: '6%', right: '3%', background: 'rgba(0,0,0,0.5)', borderRadius: '20px', padding: '3px 10px', color: 'white', fontSize: '11px', fontWeight: 700 }}>
            {weatherIcon[state.weather]} {state.weather}
          </div>
        )}
      </div>

      {/* ── Bottom panel ── */}
      {!state.over ? (
        <div style={{
          border: '3px solid #282828',
          borderTop: 'none',
          borderRadius: '0 0 14px 14px',
          background: '#c8d8e8',
          padding: '10px',
          display: 'grid',
          gridTemplateColumns: '1fr 1fr',
          gap: '10px',
          minHeight: '130px',
        }}>
          {/* Left: message box */}
          <div style={{
            background: 'white',
            border: '2.5px solid #282828',
            borderRadius: '10px',
            padding: '10px 14px',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'space-between',
            boxShadow: 'inset 0 1px 0 rgba(255,255,255,0.8)',
          }}>
            <p style={{ fontSize: '13px', lineHeight: 1.55, margin: 0, color: '#181818' }}>
              {menuState === 'fight' && hoveredMove
                ? <>
                    <b>{hoveredMove.name.toUpperCase()}</b>
                    <br />
                    <span style={{ color: '#555', fontSize: '11px' }}>
                      Type: {typeName(hoveredMove.type)} &nbsp;·&nbsp; Power: {hoveredMove.power ?? '—'} &nbsp;·&nbsp; {hoveredMove.kind}
                    </span>
                  </>
                : menuState === 'pokemon'
                  ? `Choose a Pokémon to send out${state.format > 1 ? ` (slot ${playerSlot + 1})` : ''}!`
                  : <>What will <b>{currentPlayerBattler?.species.name.toUpperCase() ?? '...'}</b> do?</>
              }
            </p>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginTop: '6px' }}>
              <PartyBalls party={state.player.party} />
              {state.weather !== 'None' && (
                <span style={{ fontSize: '10px', color: '#555', fontWeight: 600 }}>{weatherIcon[state.weather]} {state.weather}</span>
              )}
            </div>
          </div>

          {/* Right: action menu */}
          <div>
            {menuState === 'main' && (
              <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '7px' }}>
                <button disabled={actionUiDisabled} onClick={() => setMenuState('fight')} style={{ ...menuBtn('#d03030'), opacity: actionUiDisabled ? 0.6 : 1, cursor: actionUiDisabled ? 'not-allowed' : 'pointer' }}>⚔️ FIGHT</button>
                <button style={{ ...menuBtn('#909090'), cursor: 'not-allowed', opacity: 0.6 }}>🎒 BAG</button>
                <button disabled={actionUiDisabled} onClick={() => setMenuState('pokemon')} style={{ ...menuBtn('#2888a0'), opacity: actionUiDisabled ? 0.6 : 1, cursor: actionUiDisabled ? 'not-allowed' : 'pointer' }}>🔄 POKÉMON</button>
                <button style={{ ...menuBtn('#909090'), cursor: 'not-allowed', opacity: 0.6 }}>🏃 RUN</button>
              </div>
            )}

            {menuState === 'fight' && (
              <div>
                {/* Slot tabs for doubles/triples */}
                {state.format > 1 && (
                  <div style={{ display: 'flex', gap: '4px', marginBottom: '6px' }}>
                    {playerActives.map((b, i) => (
                      <button
                        key={i}
                        disabled={actionUiDisabled}
                        onClick={() => setPlayerSlot(i)}
                        style={{
                          padding: '3px 9px',
                          fontSize: '10px',
                          fontWeight: 800,
                          border: '2px solid #282828',
                          borderRadius: '4px',
                          background: playerSlot === i ? '#3870e0' : '#d0d0d0',
                          color: playerSlot === i ? 'white' : '#282828',
                          cursor: actionUiDisabled ? 'not-allowed' : 'pointer',
                          letterSpacing: '0.3px',
                          opacity: actionUiDisabled ? 0.6 : 1,
                        }}
                      >
                        {b.species.name.substring(0, TAB_NAME_LEN).toUpperCase()}
                      </button>
                    ))}
                  </div>
                )}

                {/* 2×2 move grid */}
                <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '6px', marginBottom: '6px' }}>
                  {currentMoveOptions.map((move) => {
                    const bg = TYPE_COLORS[move.type] ?? '#a0a0a0';
                    return (
                      <button
                        key={move.name}
                        disabled={actionUiDisabled}
                        onClick={() => executeTurn(move)}
                        onMouseEnter={() => setHoveredMove(move)}
                        onMouseLeave={() => setHoveredMove(null)}
                        style={{
                          background: bg,
                          border: '2.5px solid #282828',
                          borderRadius: '8px',
                          color: 'white',
                          fontWeight: 800,
                          fontSize: '11px',
                          letterSpacing: '0.3px',
                          padding: '9px 4px',
                          cursor: actionUiDisabled ? 'not-allowed' : 'pointer',
                          textShadow: '1px 1px 0 rgba(0,0,0,0.45)',
                          boxShadow: `0 3px 0 rgba(0,0,0,0.35)`,
                          lineHeight: 1.2,
                          textTransform: 'uppercase',
                          opacity: actionUiDisabled ? 0.6 : 1,
                        }}
                      >
                        {move.name}
                      </button>
                    );
                  })}
                </div>

                {/* Special + back row */}
                <div style={{ display: 'flex', gap: '5px', alignItems: 'center' }}>
                  {!state.playerMegaUsed && (
                    <button
                      disabled={actionUiDisabled}
                      onClick={() => setPendingMega((v) => !v)}
                      style={{
                        ...backBtn,
                        background: pendingMega ? '#d050b0' : '#888898',
                        fontSize: '11px',
                        padding: '5px 8px',
                        cursor: actionUiDisabled ? 'not-allowed' : 'pointer',
                        opacity: actionUiDisabled ? 0.6 : 1,
                      }}
                    >
                      ✧ MEGA
                    </button>
                  )}
                  {!state.playerZUsed && (
                    <button
                      disabled={actionUiDisabled}
                      onClick={() => setPendingZMove((v) => !v)}
                      style={{
                        ...backBtn,
                        background: pendingZMove ? '#7038d0' : '#888898',
                        fontSize: '11px',
                        padding: '5px 8px',
                        cursor: actionUiDisabled ? 'not-allowed' : 'pointer',
                        opacity: actionUiDisabled ? 0.6 : 1,
                      }}
                    >
                      ⚡ Z
                    </button>
                  )}
                  <div style={{ flex: 1 }} />
                  <button
                    disabled={actionUiDisabled}
                    onClick={() => { setMenuState('main'); setHoveredMove(null); setPendingMega(false); setPendingZMove(false); }}
                    style={{ ...backBtn, cursor: actionUiDisabled ? 'not-allowed' : 'pointer', opacity: actionUiDisabled ? 0.6 : 1 }}
                  >
                    ◀ BACK
                  </button>
                </div>
              </div>
            )}

            {menuState === 'pokemon' && (
              <div>
                {/* Slot tabs for doubles/triples */}
                {state.format > 1 && (
                  <div style={{ display: 'flex', gap: '4px', marginBottom: '6px' }}>
                    {playerActives.map((b, i) => (
                      <button
                        key={i}
                        disabled={actionUiDisabled}
                        onClick={() => setPlayerSlot(i)}
                        style={{
                          padding: '3px 9px',
                          fontSize: '10px',
                          fontWeight: 800,
                          border: '2px solid #282828',
                          borderRadius: '4px',
                          background: playerSlot === i ? '#3870e0' : '#d0d0d0',
                          color: playerSlot === i ? 'white' : '#282828',
                          cursor: actionUiDisabled ? 'not-allowed' : 'pointer',
                          opacity: actionUiDisabled ? 0.6 : 1,
                        }}
                      >
                        {b.species.name.substring(0, TAB_NAME_LEN).toUpperCase()}
                      </button>
                    ))}
                  </div>
                )}

                <div style={{ display: 'grid', gridTemplateColumns: 'repeat(3, 1fr)', gap: '5px', marginBottom: '5px' }}>
                  {playerParty.map((pokemon, index) => {
                    const isActive = state.player.active.includes(index);
                    const isFainted = pokemon.hp <= 0;
                    const canSwitch = !isActive && !isFainted;
                    const pct = pokemon.maxHp > 0 ? (pokemon.hp / pokemon.maxHp) * 100 : 0;
                    const hpColor = isFainted ? '#888' : pct > 50 ? '#48d048' : pct > 20 ? '#f8c820' : '#e82010';
                    return (
                      <button
                        key={index}
                        onClick={() => canSwitch && !actionUiDisabled && doSwitch(index)}
                        disabled={!canSwitch || actionUiDisabled}
                        style={{
                          background: isActive ? '#c0dcf8' : isFainted ? '#e0e0e0' : '#f8f8f0',
                          border: `2px solid ${isActive ? '#3870e0' : '#383838'}`,
                          borderRadius: '8px',
                          padding: '5px 3px',
                          opacity: isFainted ? 0.5 : 1,
                          cursor: canSwitch && !actionUiDisabled ? 'pointer' : 'default',
                          textAlign: 'center',
                          boxShadow: canSwitch ? '0 2px 0 rgba(0,0,0,0.25)' : 'none',
                        }}
                      >
                        <img
                          src={pokemon.spriteUrl}
                          alt={pokemon.species.name}
                          style={{ width: '38px', height: '38px', objectFit: 'contain', imageRendering: 'pixelated' }}
                        />
                        <p style={{ fontSize: '8px', fontWeight: 800, margin: '1px 0 2px', overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap', letterSpacing: '0.2px' }}>
                          {pokemon.species.name.toUpperCase()}
                        </p>
                        <div style={{ height: '4px', background: '#404040', borderRadius: '2px', margin: '0 3px', overflow: 'hidden' }}>
                          <div style={{ width: `${pct}%`, height: '100%', background: hpColor }} />
                        </div>
                        <p style={{ fontSize: '8px', color: '#484848', margin: '2px 0 0', fontFamily: 'monospace' }}>{pokemon.hp}/{pokemon.maxHp}</p>
                        {isActive && <p style={{ fontSize: '8px', color: '#3060c0', fontWeight: 800, margin: '1px 0 0' }}>OUT</p>}
                      </button>
                    );
                  })}
                </div>
                <button
                  disabled={actionUiDisabled}
                  onClick={() => setMenuState('main')}
                  style={{ ...backBtn, width: '100%', textAlign: 'center', cursor: actionUiDisabled ? 'not-allowed' : 'pointer', opacity: actionUiDisabled ? 0.6 : 1 }}
                >
                  ◀ BACK
                </button>
              </div>
            )}
          </div>
        </div>
      ) : (
        /* Battle over */
        <div style={{
          border: '3px solid #282828',
          borderTop: 'none',
          borderRadius: '0 0 14px 14px',
          background: '#c8d8e8',
          padding: '20px',
          textAlign: 'center',
        }}>
          <div style={{
            background: state.winner === 'player' ? '#d0f8d0' : state.winner === 'draw' ? '#f8f8d0' : '#f8d0d0',
            border: '2.5px solid #282828',
            borderRadius: '12px',
            padding: '20px',
            marginBottom: '14px',
            boxShadow: '3px 3px 0 rgba(0,0,0,0.2)',
          }}>
            <p style={{ fontSize: '36px', margin: '0 0 6px' }}>
              {state.winner === 'player' ? '🏆' : state.winner === 'draw' ? '🤝' : '💀'}
            </p>
            <p style={{ fontSize: '20px', fontWeight: 800, margin: 0, letterSpacing: '0.5px' }}>
              {state.winner === 'player' ? 'You won!' : state.winner === 'draw' ? 'Draw!' : 'You lost...'}
            </p>
          </div>
          <button
            onClick={() => { setState(newBattle(state.format)); setMenuState('main'); setHoveredMove(null); }}
            style={{ ...menuBtn('#2848c0'), padding: '12px 40px', fontSize: '16px', width: 'auto' }}
          >
            Play Again
          </button>
        </div>
      )}

      {/* ── Latest message (below panel, always visible) ── */}
      <div style={{
        marginTop: '8px',
        background: 'white',
        border: '2.5px solid #282828',
        borderRadius: '10px',
        padding: '9px 14px',
        fontSize: '13px',
        color: '#181818',
        lineHeight: 1.5,
        boxShadow: '2px 2px 0 rgba(0,0,0,0.15)',
        display: 'flex',
        alignItems: 'center',
        gap: '8px',
      }}>
        <span style={{ color: '#404040' }}>▶</span>
        <span>{latestMessage}</span>
      </div>

      {/* ── Battle log (toggleable) ── */}
      {showLog && (
        <div
          ref={logRef}
          style={{
            marginTop: '8px',
            background: '#101820',
            borderRadius: '10px',
            border: '2px solid #282828',
            padding: '10px 12px',
            maxHeight: '160px',
            overflowY: 'auto',
            display: 'flex',
            flexDirection: 'column',
            gap: '2px',
          }}
        >
          {state.log.map((line, i) => (
            <p key={i} style={{ color: '#70e870', fontSize: '11px', fontFamily: 'monospace', margin: 0 }}>{line}</p>
          ))}
        </div>
      )}
    </div>
  );
}
