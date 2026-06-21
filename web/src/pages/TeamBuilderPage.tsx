import { useMemo, useState } from 'react';
import { ABILITIES, MOVES, NATURES, POKEMON, spriteUrl } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import type { PokemonSpecies } from '../data/gameData';

type Gender = 'Male' | 'Female' | 'Genderless';

interface TeamMemberConfig {
  nickname: string;
  gender: Gender;
  nature: string;
  ability: string;
  heldItem: string;
  moves: string[];
}

interface Slot {
  pokemon: PokemonSpecies | null;
  config: TeamMemberConfig | null;
}

const TEAM_STORAGE_KEY = 'poke-team-builder-v2';
const HELD_ITEMS = [
  'None',
  'Normalium Z',
  'Firium Z',
  'Waterium Z',
  'Electrium Z',
  'Grassium Z',
  'Fightinium Z',
  'Flyinium Z',
  'Poisonium Z',
  'Groundium Z',
  'Rockium Z',
  'Buginium Z',
  'Ghostium Z',
  'Steelium Z',
  'Psychium Z',
  'Icium Z',
  'Dragonium Z',
  'Darkinium Z',
  'Fairium Z',
];

function buildDefaultConfig(pokemon: PokemonSpecies): TeamMemberConfig {
  const learnsetMoves = pokemon.learnset
    .map((name) => MOVES.find((move) => move.name === name))
    .filter((move): move is NonNullable<typeof move> => move != null);
  const preferredMoves = learnsetMoves.filter((move) => move.kind !== 'Status').slice(0, 4);
  const fallback = learnsetMoves.slice(0, 4);
  const selected = (preferredMoves.length >= 4 ? preferredMoves : fallback).map((move) => move.name);
  while (selected.length < 4) selected.push('');

  return {
    nickname: pokemon.name,
    gender: 'Male',
    nature: NATURES[0]?.name ?? 'Hardy',
    ability: pokemon.ability1,
    heldItem: HELD_ITEMS[0],
    moves: selected,
  };
}

function createEmptySlots(): Slot[] {
  return Array.from({ length: 6 }, () => ({ pokemon: null, config: null }));
}

function parseStoredSlots(): Slot[] {
  const raw = localStorage.getItem(TEAM_STORAGE_KEY);
  if (!raw) return createEmptySlots();
  try {
    const parsed = JSON.parse(raw) as Slot[];
    if (!Array.isArray(parsed) || parsed.length !== 6) return createEmptySlots();
    return parsed.map((slot) => {
      const storedPokemon = slot?.pokemon;
      if (!storedPokemon || !slot.config) return { pokemon: null, config: null };
      const pokemon = POKEMON.find((p) => p.number === storedPokemon.number && p.name === storedPokemon.name);
      if (!pokemon) return { pokemon: null, config: null };
      return {
        pokemon,
        config: {
          ...slot.config,
          nickname: slot.config.nickname || pokemon.name,
          gender: slot.config.gender || 'Male',
          nature: slot.config.nature || NATURES[0]?.name || 'Hardy',
          ability: slot.config.ability || pokemon.ability1,
          heldItem: slot.config.heldItem || HELD_ITEMS[0],
          moves: Array.isArray(slot.config.moves) ? [...slot.config.moves].slice(0, 4) : ['', '', '', ''],
        },
      };
    });
  } catch {
    return createEmptySlots();
  }
}

export function TeamBuilderPage() {
  const [slots, setSlots] = useState<Slot[]>(parseStoredSlots);
  const [pickerFor, setPickerFor] = useState<number | null>(null);
  const [pickerSearch, setPickerSearch] = useState('');
  const [expandedSlot, setExpandedSlot] = useState<number | null>(null);

  const filteredPicker = useMemo(
    () => POKEMON.filter((p) => p.name.toLowerCase().includes(pickerSearch.toLowerCase())),
    [pickerSearch],
  );

  const teamSummary = slots.filter((slot) => slot.pokemon != null).map((slot) => ({
    pokemon: slot.pokemon!,
    config: slot.config!,
  }));

  function updateSlots(next: Slot[]) {
    setSlots(next);
    localStorage.setItem(TEAM_STORAGE_KEY, JSON.stringify(next));
  }

  function setPokemon(index: number, pokemon: PokemonSpecies | null) {
    const next = slots.map((slot, i) => {
      if (i !== index) return slot;
      if (!pokemon) return { pokemon: null, config: null };
      return { pokemon, config: buildDefaultConfig(pokemon) };
    });
    updateSlots(next);
    setExpandedSlot(pokemon ? index : null);
  }

  function updateConfig(index: number, updater: (config: TeamMemberConfig) => TeamMemberConfig) {
    const next = slots.map((slot, i) => {
      if (i !== index || !slot.pokemon || !slot.config) return slot;
      return { ...slot, config: updater(slot.config) };
    });
    updateSlots(next);
  }

  function saveTeamToClipboard() {
    const payload = teamSummary.map(({ pokemon, config }) => ({
      pokemon: pokemon.name,
      number: pokemon.number,
      ...config,
    }));
    navigator.clipboard.writeText(JSON.stringify(payload, null, 2));
  }

  function resetTeam() {
    const empty = createEmptySlots();
    updateSlots(empty);
    setExpandedSlot(null);
  }

  function importSampleBuild() {
    const seed = POKEMON.slice(0, 6).map((pokemon) => ({
      pokemon,
      config: buildDefaultConfig(pokemon),
    }));
    const seeded = createEmptySlots().map((slot, index) => seed[index] ?? slot);
    updateSlots(seeded);
    setExpandedSlot(0);
  }

  return (
    <div className="max-w-4xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Team Builder</h1>

      <div className="bg-white rounded-xl border border-gray-200 shadow-sm p-3 mb-4 flex flex-wrap gap-2">
        <button
          onClick={saveTeamToClipboard}
          disabled={teamSummary.length === 0}
          className="px-3 py-2 rounded-lg text-sm font-medium border border-gray-200 bg-gray-50 disabled:opacity-40"
        >
          Export Team JSON
        </button>
        <button
          onClick={importSampleBuild}
          className="px-3 py-2 rounded-lg text-sm font-medium border border-gray-200 bg-gray-50"
        >
          Quick-fill Team
        </button>
        <button
          onClick={resetTeam}
          className="px-3 py-2 rounded-lg text-sm font-medium border border-red-200 text-red-700 bg-red-50"
        >
          Reset Team
        </button>
      </div>

      <div className="flex flex-col gap-3">
        {slots.map((slot, i) => {
          const config = slot.config;
          const slotPokemonName = slot.pokemon?.name ?? `slot_${i}`;
          const learnset = slot.pokemon
            ? slot.pokemon.learnset
              .map((name) => MOVES.find((m) => m.name === name))
              .filter((m): m is NonNullable<typeof m> => m != null)
            : [];
          const availableAbilities = slot.pokemon
            ? [slot.pokemon.ability1, slot.pokemon.ability2, slot.pokemon.hiddenAbility].filter(Boolean) as string[]
            : [];

          return (
            <div key={i} className="bg-white rounded-xl border border-gray-200 shadow-sm px-4 py-3">
              <div className="flex items-center gap-3">
                <span className="text-gray-400 font-bold text-sm w-5">{i + 1}.</span>
                {slot.pokemon ? (
                  <>
                    <img src={spriteUrl(slot.pokemon.number)} alt={slot.pokemon.name} className="w-12 h-12 object-contain" />
                    <div className="flex-1 min-w-0">
                      <p className="font-semibold text-gray-800 text-sm truncate">
                        {config?.nickname || slot.pokemon.name}
                        {config?.nickname && config.nickname !== slot.pokemon.name && (
                          <span className="text-gray-500 font-normal"> ({slot.pokemon.name})</span>
                        )}
                      </p>
                      <div className="flex gap-1 mt-0.5">
                        <TypeBadge type={slot.pokemon.primaryType} small />
                        {slot.pokemon.secondaryType != null && <TypeBadge type={slot.pokemon.secondaryType} small />}
                      </div>
                    </div>
                    <button
                      onClick={() => setExpandedSlot(expandedSlot === i ? null : i)}
                      className="text-sm px-2 py-1 rounded border border-gray-200 hover:bg-gray-50"
                    >
                      {expandedSlot === i ? 'Hide' : 'Edit'}
                    </button>
                    <button
                      onClick={() => setPokemon(i, null)}
                      className="text-gray-400 hover:text-red-500 transition-colors text-lg leading-none px-1"
                      title="Remove"
                    >
                      ×
                    </button>
                  </>
                ) : (
                  <>
                    <div className="w-12 h-12 rounded-lg bg-gray-100 flex items-center justify-center text-gray-400 text-xl">?</div>
                    <span className="flex-1 text-gray-400 text-sm">Empty slot</span>
                    <button
                      onClick={() => {
                        setPickerFor(i);
                        setPickerSearch('');
                      }}
                      className="text-blue-600 hover:text-blue-800 text-sm font-medium"
                    >
                      + Add
                    </button>
                  </>
                )}
              </div>

              {slot.pokemon && config && expandedSlot === i && (
                <div className="mt-4 pt-3 border-t border-gray-100 grid grid-cols-1 md:grid-cols-2 gap-3">
                  <label className="text-sm">
                    <span className="text-gray-600">Nickname</span>
                    <input
                      value={config.nickname}
                      onChange={(e) => updateConfig(i, (current) => ({ ...current, nickname: e.target.value }))}
                      className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                    />
                  </label>

                  <label className="text-sm">
                    <span className="text-gray-600">Gender</span>
                    <select
                      value={config.gender}
                      onChange={(e) => updateConfig(i, (current) => ({ ...current, gender: e.target.value as Gender }))}
                      className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                    >
                      <option value="Male">Male</option>
                      <option value="Female">Female</option>
                      <option value="Genderless">Genderless</option>
                    </select>
                  </label>

                  <label className="text-sm">
                    <span className="text-gray-600">Nature</span>
                    <select
                      value={config.nature}
                      onChange={(e) => updateConfig(i, (current) => ({ ...current, nature: e.target.value }))}
                      className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                    >
                      {NATURES.map((nature) => (
                        <option key={nature.name} value={nature.name}>{nature.name}</option>
                      ))}
                    </select>
                  </label>

                  <label className="text-sm">
                    <span className="text-gray-600">Ability</span>
                    <select
                      value={config.ability}
                      onChange={(e) => updateConfig(i, (current) => ({ ...current, ability: e.target.value }))}
                      className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                    >
                      {availableAbilities.map((ability) => (
                        <option key={ability} value={ability}>{ability}</option>
                      ))}
                    </select>
                  </label>

                  <label className="text-sm md:col-span-2">
                    <span className="text-gray-600">Held Item</span>
                    <select
                      value={config.heldItem}
                      onChange={(e) => updateConfig(i, (current) => ({ ...current, heldItem: e.target.value }))}
                      className="mt-1 w-full border border-gray-300 rounded-lg px-3 py-2"
                    >
                      {HELD_ITEMS.map((item) => (
                        <option key={item} value={item}>{item}</option>
                      ))}
                    </select>
                  </label>

                  <div className="md:col-span-2">
                    <p className="text-sm text-gray-600 mb-2">Moves</p>
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-2">
                      {config.moves.map((selectedMove, moveIndex) => (
                        <select
                          key={`${slotPokemonName}_move_${moveIndex}`}
                          value={selectedMove}
                          onChange={(e) =>
                            updateConfig(i, (current) => {
                              const nextMoves = [...current.moves];
                              nextMoves[moveIndex] = e.target.value;
                              return { ...current, moves: nextMoves };
                            })}
                          className="border border-gray-300 rounded-lg px-3 py-2 text-sm"
                        >
                          <option value="">(none)</option>
                          {learnset.map((move) => (
                            <option key={move.name} value={move.name}>{move.name}</option>
                          ))}
                        </select>
                      ))}
                    </div>
                  </div>
                </div>
              )}
            </div>
          );
        })}
      </div>

      {pickerFor !== null && (
        <div className="fixed inset-0 bg-black/40 flex items-center justify-center z-50 p-4">
          <div className="bg-white rounded-2xl shadow-xl w-full max-w-sm max-h-[80vh] flex flex-col">
            <div className="p-4 border-b border-gray-100 flex justify-between items-center">
              <h2 className="font-bold text-gray-800">Choose a Pokémon</h2>
              <button onClick={() => setPickerFor(null)} className="text-gray-400 hover:text-gray-600 text-xl">×</button>
            </div>
            <div className="p-3 border-b border-gray-100">
              <input
                type="text"
                placeholder="Search…"
                autoFocus
                value={pickerSearch}
                onChange={(e) => setPickerSearch(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
              />
            </div>
            <div className="overflow-y-auto flex-1">
              {filteredPicker.map((pokemon) => (
                <button
                  key={`${pokemon.number}_${pokemon.name}`}
                  onClick={() => {
                    setPokemon(pickerFor, pokemon);
                    setPickerFor(null);
                  }}
                  className="w-full flex items-center gap-3 px-4 py-2.5 hover:bg-gray-50 border-b border-gray-50 text-left"
                >
                  <img src={spriteUrl(pokemon.number)} alt={pokemon.name} className="w-10 h-10 object-contain" />
                  <div>
                    <p className="font-medium text-sm text-gray-800">{pokemon.name}</p>
                    <div className="flex gap-1">
                      <TypeBadge type={pokemon.primaryType} small />
                      {pokemon.secondaryType != null && <TypeBadge type={pokemon.secondaryType} small />}
                    </div>
                  </div>
                </button>
              ))}
              {filteredPicker.length === 0 && (
                <p className="text-center text-gray-400 py-8 text-sm">No Pokémon found.</p>
              )}
            </div>
          </div>
        </div>
      )}

      <div className="mt-6 bg-white rounded-xl border border-gray-200 shadow-sm p-4">
        <h2 className="font-semibold text-gray-700 mb-3">Current Team Summary</h2>
        {teamSummary.length === 0 ? (
          <p className="text-gray-400 text-sm">Add Pokémon to build your team.</p>
        ) : (
          <div className="flex flex-col gap-3">
            {teamSummary.map(({ pokemon, config }) => (
              <div key={`${pokemon.number}_${pokemon.name}`}>
                <p className="text-sm font-semibold text-gray-700">
                  {config.nickname} — {config.nature} — {config.ability} — {config.heldItem}
                </p>
                <div className="flex flex-wrap gap-1.5 mt-1">
                  {config.moves.filter(Boolean).map((moveName) => {
                    const move = MOVES.find((m) => m.name === moveName);
                    if (!move) return null;
                    return (
                      <span key={`${pokemon.name}_${move.name}`} className="text-xs px-2 py-0.5 rounded-full bg-gray-100 text-gray-600 border border-gray-200">
                        {move.name}
                      </span>
                    );
                  })}
                </div>
              </div>
            ))}
          </div>
        )}
      </div>

      <div className="mt-4 text-xs text-gray-500">
        Ability database contains {ABILITIES.length} entries.
      </div>
    </div>
  );
}
