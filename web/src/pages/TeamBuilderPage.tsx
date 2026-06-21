import { useState } from 'react';
import { POKEMON, MOVES, spriteUrl } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import type { PokemonSpecies } from '../data/gameData';

interface Slot {
  pokemon: PokemonSpecies | null;
}

export function TeamBuilderPage() {
  const [slots, setSlots] = useState<Slot[]>(Array(6).fill({ pokemon: null }));
  const [pickerFor, setPickerFor] = useState<number | null>(null);
  const [pickerSearch, setPickerSearch] = useState('');

  const filteredPicker = POKEMON.filter((p) =>
    p.name.toLowerCase().includes(pickerSearch.toLowerCase())
  );

  function setPokemon(index: number, pokemon: PokemonSpecies | null) {
    setSlots((prev) => prev.map((s, i) => (i === index ? { pokemon } : s)));
  }

  return (
    <div className="max-w-2xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Team Builder</h1>
      <div className="flex flex-col gap-3">
        {slots.map((slot, i) => (
          <div
            key={i}
            className="bg-white rounded-xl border border-gray-200 shadow-sm flex items-center gap-3 px-4 py-3"
          >
            <span className="text-gray-400 font-bold text-sm w-5">{i + 1}.</span>
            {slot.pokemon ? (
              <>
                <img
                  src={spriteUrl(slot.pokemon.number)}
                  alt={slot.pokemon.name}
                  className="w-12 h-12 object-contain"
                />
                <div className="flex-1 min-w-0">
                  <p className="font-semibold text-gray-800 text-sm truncate">{slot.pokemon.name}</p>
                  <div className="flex gap-1 mt-0.5">
                    <TypeBadge type={slot.pokemon.primaryType} small />
                    {slot.pokemon.secondaryType != null && <TypeBadge type={slot.pokemon.secondaryType} small />}
                  </div>
                </div>
                <button
                  onClick={() => setPokemon(i, null)}
                  className="text-gray-400 hover:text-red-500 transition-colors text-lg leading-none px-1"
                  title="Remove"
                >×</button>
              </>
            ) : (
              <>
                <div className="w-12 h-12 rounded-lg bg-gray-100 flex items-center justify-center text-gray-400 text-xl">?</div>
                <span className="flex-1 text-gray-400 text-sm">Empty slot</span>
                <button
                  onClick={() => { setPickerFor(i); setPickerSearch(''); }}
                  className="text-blue-600 hover:text-blue-800 text-sm font-medium"
                >+ Add</button>
              </>
            )}
          </div>
        ))}
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
              {filteredPicker.map((p) => (
                <button
                  key={`${p.number}_${p.name}`}
                  onClick={() => { setPokemon(pickerFor, p); setPickerFor(null); }}
                  className="w-full flex items-center gap-3 px-4 py-2.5 hover:bg-gray-50 border-b border-gray-50 text-left"
                >
                  <img src={spriteUrl(p.number)} alt={p.name} className="w-10 h-10 object-contain" />
                  <div>
                    <p className="font-medium text-sm text-gray-800">{p.name}</p>
                    <div className="flex gap-1">
                      <TypeBadge type={p.primaryType} small />
                      {p.secondaryType != null && <TypeBadge type={p.secondaryType} small />}
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
        <h2 className="font-semibold text-gray-700 mb-3">Team Learnsets</h2>
        {slots.every((s) => s.pokemon == null) ? (
          <p className="text-gray-400 text-sm">Add Pokémon to your team to see their moves.</p>
        ) : (
          <div className="flex flex-col gap-3">
            {slots.filter((s) => s.pokemon != null).map((s) => {
              const learnset = s.pokemon!.learnset
                .map((n) => MOVES.find((m) => m.name === n))
                .filter(Boolean);
              return (
                <div key={`${s.pokemon!.number}_${s.pokemon!.name}`}>
                  <p className="text-sm font-semibold text-gray-700 mb-1">{s.pokemon!.name}</p>
                  <div className="flex flex-wrap gap-1.5">
                    {learnset.map((m) => (
                      <span key={m!.name} className="text-xs px-2 py-0.5 rounded-full bg-gray-100 text-gray-600 border border-gray-200">
                        {m!.name}
                      </span>
                    ))}
                  </div>
                </div>
              );
            })}
          </div>
        )}
      </div>
    </div>
  );
}
