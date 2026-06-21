import type { PokemonSpecies } from './pokemon';
import { spriteUrl } from './pokemon';
import type { Move } from './move';
import { PokemonType } from './types';
import { getCombinedEffectiveness } from './typeEffectiveness';

const LEVEL = 50;

export function calcHp(base: number): number {
  return Math.floor((2 * base * LEVEL) / 100) + LEVEL + 10;
}

export function calcStat(base: number): number {
  return Math.floor((2 * base * LEVEL) / 100) + 5;
}

export interface BattlePokemon {
  species: PokemonSpecies;
  maxHp: number;
  hp: number;
  attack: number;
  defense: number;
  spAttack: number;
  spDefense: number;
  speed: number;
  spriteUrl: string;
}

export function makeBattlePokemon(species: PokemonSpecies): BattlePokemon {
  const maxHp = calcHp(species.hp);
  return {
    species,
    maxHp,
    hp: maxHp,
    attack: calcStat(species.attack),
    defense: calcStat(species.defense),
    spAttack: calcStat(species.spAttack),
    spDefense: calcStat(species.spDefense),
    speed: calcStat(species.speed),
    spriteUrl: spriteUrl(species.number),
  };
}

export function calcDamage(
  attacker: BattlePokemon,
  move: Move,
  defender: BattlePokemon,
): number {
  if (move.power == null || move.kind === 'Status') return 0;

  const atk = move.kind === 'Physical' ? attacker.attack : attacker.spAttack;
  const def = move.kind === 'Physical' ? defender.defense : defender.spDefense;

  const typeEff = getCombinedEffectiveness(
    move.type,
    defender.species.primaryType,
    defender.species.secondaryType,
  );
  const stab =
    move.type === attacker.species.primaryType ||
    move.type === attacker.species.secondaryType
      ? 1.5
      : 1;

  const randomFactor = Math.random() * 0.15 + 0.85;

  const damage = Math.floor(
    Math.floor(
      (Math.floor((2 * LEVEL) / 5 + 2) * move.power * (atk / def)) / 50 + 2,
    ) *
      stab *
      typeEff *
      randomFactor,
  );
  return Math.max(1, damage);
}

export function effectivenessLabel(
  moveType: PokemonType,
  defenderPrimary: PokemonType,
  defenderSecondary: PokemonType | null | undefined,
): string {
  const eff = getCombinedEffectiveness(moveType, defenderPrimary, defenderSecondary);
  if (eff === 0) return ' It had no effect!';
  if (eff < 1) return " It's not very effective...";
  if (eff > 1) return " It's super effective!";
  return '';
}
