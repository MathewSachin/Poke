import { useState, useMemo } from 'react';
import { POKEMON, ALL_TYPES, PokemonType, typeName } from '../data/gameData';
import { PokemonCard } from '../components/PokemonCard';

export function PokedexPage() {
  const [search, setSearch] = useState('');
  const [typeFilter, setTypeFilter] = useState<PokemonType | null>(null);

  const filtered = useMemo(() => {
    return POKEMON.filter((p) => {
      const matchSearch = p.name.toLowerCase().includes(search.toLowerCase());
      const matchType =
        typeFilter == null ||
        p.primaryType === typeFilter ||
        p.secondaryType === typeFilter;
      return matchSearch && matchType;
    });
  }, [search, typeFilter]);

  return (
    <div className="max-w-6xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Pokédex</h1>
      <div className="flex flex-col sm:flex-row gap-3 mb-6">
        <input
          type="text"
          placeholder="Search Pokémon…"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="border border-gray-300 rounded-lg px-3 py-2 flex-1 focus:outline-none focus:ring-2 focus:ring-red-400 text-sm"
        />
        <select
          value={typeFilter ?? ''}
          onChange={(e) =>
            setTypeFilter(e.target.value === '' ? null : (Number(e.target.value) as PokemonType))
          }
          className="border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
        >
          <option value="">All Types</option>
          {ALL_TYPES.map((t) => (
            <option key={t} value={t}>{typeName(t)}</option>
          ))}
        </select>
      </div>
      {filtered.length === 0 ? (
        <p className="text-gray-400 text-center py-16">No Pokémon found.</p>
      ) : (
        <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 xl:grid-cols-6 gap-3">
          {filtered.map((p) => (
            <PokemonCard key={`${p.number}_${p.name}`} pokemon={p} />
          ))}
        </div>
      )}
    </div>
  );
}
