import { useState, useCallback } from 'react';
import { POKEMON, MOVES } from '../data/gameData';
import { makeBattlePokemon, calcDamage, effectivenessLabel } from '../data/battle';
import type { BattlePokemon } from '../data/battle';
import type { Move } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';

interface BattleState {
  player: BattlePokemon;
  opponent: BattlePokemon;
  log: string[];
  over: boolean;
  winner: 'player' | 'opponent' | 'draw' | null;
}

function randomPick<T>(arr: T[], exclude?: T): T {
  const pool = exclude ? arr.filter((x) => x !== exclude) : arr;
  return pool[Math.floor(Math.random() * pool.length)];
}

function getPlayerMoves(player: BattlePokemon): Move[] {
  const learnset = player.species.learnset;
  if (learnset.length > 0) {
    const found = learnset
      .slice(0, 4)
      .map((n) => MOVES.find((m) => m.name === n))
      .filter((m): m is Move => m != null);
    if (found.length > 0) return found;
  }
  return MOVES.filter((m) => m.kind !== 'Status')
    .sort(() => Math.random() - 0.5)
    .slice(0, 4);
}

function newBattle(): BattleState {
  const playerSpecies = randomPick(POKEMON);
  const opponentSpecies = randomPick(POKEMON, playerSpecies);
  const player = makeBattlePokemon(playerSpecies);
  const opponent = makeBattlePokemon(opponentSpecies);
  return {
    player,
    opponent,
    log: [`A wild ${opponent.species.name} appeared!`],
    over: false,
    winner: null,
  };
}

function simulateTurn(
  state: BattleState,
  playerMove: Move,
  opponentMove: Move,
): BattleState {
  const log = [...state.log];
  let { player, opponent } = state;
  let playerHp = player.hp;
  let opponentHp = opponent.hp;

  const playerFirst = player.species.speed >= opponent.species.speed;

  function attackOpponent() {
    const dmg = calcDamage(player, playerMove, opponent);
    opponentHp = Math.max(0, opponentHp - dmg);
    const effStr = effectivenessLabel(playerMove.type, opponent.species.primaryType, opponent.species.secondaryType);
    log.push(`${player.species.name} used ${playerMove.name}! Dealt ${dmg} dmg.${effStr}`);
  }

  function attackPlayer() {
    const dmg = calcDamage(opponent, opponentMove, player);
    playerHp = Math.max(0, playerHp - dmg);
    const effStr = effectivenessLabel(opponentMove.type, player.species.primaryType, player.species.secondaryType);
    log.push(`${opponent.species.name} used ${opponentMove.name}! Dealt ${dmg} dmg.${effStr}`);
  }

  if (playerFirst) {
    attackOpponent();
    if (opponentHp > 0) attackPlayer();
  } else {
    attackPlayer();
    if (playerHp > 0) attackOpponent();
  }

  const over = playerHp <= 0 || opponentHp <= 0;
  let winner: BattleState['winner'] = null;
  if (playerHp <= 0 && opponentHp <= 0) { winner = 'draw'; }
  else if (opponentHp <= 0) { log.push(`${opponent.species.name} fainted!`); winner = 'player'; }
  else if (playerHp <= 0) { log.push(`${player.species.name} fainted!`); winner = 'opponent'; }

  return {
    player: { ...player, hp: playerHp },
    opponent: { ...opponent, hp: opponentHp },
    log,
    over,
    winner,
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

function BattlerCard({ battler, label }: { battler: BattlePokemon; label: string }) {
  return (
    <div className="flex flex-col items-center text-center flex-1">
      <p className="text-xs text-gray-400 mb-1">{label}</p>
      <img src={battler.spriteUrl} alt={battler.species.name} className="w-20 h-20 object-contain" />
      <p className="font-bold text-sm text-gray-800">{battler.species.name}</p>
      <div className="flex gap-1 justify-center mt-0.5">
        <TypeBadge type={battler.species.primaryType} small />
        {battler.species.secondaryType != null && <TypeBadge type={battler.species.secondaryType} small />}
      </div>
      <div className="w-full px-2 mt-2">
        <HpBar hp={battler.hp} maxHp={battler.maxHp} />
      </div>
    </div>
  );
}

export function BattlePage() {
  const [state, setState] = useState<BattleState>(newBattle);
  const playerMoves = getPlayerMoves(state.player);
  const logRef = useCallback((el: HTMLDivElement | null) => {
    if (el) el.scrollTop = el.scrollHeight;
  }, [state.log.length]);

  function handleMove(move: Move) {
    if (state.over) return;
    const oppDamagingMoves = MOVES.filter((m) => m.kind !== 'Status');
    const opponentMove = oppDamagingMoves[Math.floor(Math.random() * oppDamagingMoves.length)];
    setState((s) => simulateTurn(s, move, opponentMove));
  }

  function handleNewBattle() {
    setState(newBattle());
  }

  return (
    <div className="max-w-2xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Battle Simulator</h1>

      {/* Arena */}
      <div className="bg-green-50 rounded-2xl p-4 flex items-start gap-4 border border-green-100 mb-4">
        <BattlerCard battler={state.player} label="You" />
        <span className="font-bold text-gray-400 text-xl mt-8">VS</span>
        <BattlerCard battler={state.opponent} label="Foe" />
      </div>

      {/* Battle log */}
      <div
        ref={logRef}
        className="bg-gray-900 rounded-xl p-3 h-36 overflow-y-auto mb-4 flex flex-col gap-0.5"
      >
        {state.log.slice(-12).map((line, i) => (
          <p key={i} className="text-green-300 text-xs font-mono">{line}</p>
        ))}
      </div>

      {/* Move buttons or result */}
      {!state.over ? (
        <div>
          <p className="text-sm font-medium text-gray-600 mb-2">Choose a move:</p>
          <div className="grid grid-cols-2 gap-2">
            {playerMoves.map((move) => (
              <button
                key={move.name}
                onClick={() => handleMove(move)}
                className="border border-gray-200 rounded-xl px-3 py-2.5 bg-white hover:bg-gray-50 text-left shadow-sm hover:shadow transition-all"
              >
                <p className="font-semibold text-sm text-gray-800">{move.name}</p>
                <div className="mt-1">
                  <TypeBadge type={move.type} small />
                  <span className="ml-1 text-xs text-gray-500">{move.power != null ? `${move.power} pwr` : 'Status'}</span>
                </div>
              </button>
            ))}
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
            onClick={handleNewBattle}
            className="w-full bg-red-600 hover:bg-red-700 text-white font-semibold py-3 rounded-xl transition-colors"
          >
            New Battle
          </button>
        </div>
      )}
    </div>
  );
}
