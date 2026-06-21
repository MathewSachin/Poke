import { useState, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { MOVES, ALL_TYPES, PokemonType, typeName } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import type { MoveKind } from '../data/gameData';

const KINDS: MoveKind[] = ['Physical', 'Special', 'Status'];

export function MovesPage() {
  const [search, setSearch] = useState('');
  const [typeFilter, setTypeFilter] = useState<PokemonType | null>(null);
  const [kindFilter, setKindFilter] = useState<MoveKind | null>(null);

  const filtered = useMemo(() => {
    return MOVES.filter((m) => {
      const matchSearch = m.name.toLowerCase().includes(search.toLowerCase());
      const matchType = typeFilter == null || m.type === typeFilter;
      const matchKind = kindFilter == null || m.kind === kindFilter;
      return matchSearch && matchType && matchKind;
    });
  }, [search, typeFilter, kindFilter]);

  return (
    <div className="max-w-5xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Moves</h1>
      <div className="flex flex-col sm:flex-row gap-3 mb-4">
        <input
          type="text"
          placeholder="Search moves…"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="border border-gray-300 rounded-lg px-3 py-2 flex-1 focus:outline-none focus:ring-2 focus:ring-red-400 text-sm"
        />
        <select
          value={typeFilter ?? ''}
          onChange={(e) => setTypeFilter(e.target.value === '' ? null : Number(e.target.value) as PokemonType)}
          className="border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
        >
          <option value="">All Types</option>
          {ALL_TYPES.map((t) => <option key={t} value={t}>{typeName(t)}</option>)}
        </select>
        <select
          value={kindFilter ?? ''}
          onChange={(e) => setKindFilter(e.target.value === '' ? null : e.target.value as MoveKind)}
          className="border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
        >
          <option value="">All Categories</option>
          {KINDS.map((k) => <option key={k} value={k}>{k}</option>)}
        </select>
      </div>
      <div className="bg-white rounded-xl shadow overflow-hidden">
        <table className="w-full text-sm">
          <thead className="bg-gray-50 text-gray-600 text-xs uppercase tracking-wide">
            <tr>
              <th className="text-left px-4 py-3">Name</th>
              <th className="text-left px-4 py-3">Type</th>
              <th className="text-left px-4 py-3">Category</th>
              <th className="text-right px-4 py-3">Power</th>
              <th className="text-right px-4 py-3">Acc</th>
              <th className="text-right px-4 py-3">PP</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-gray-100">
            {filtered.map((m) => (
              <tr key={m.name} className="hover:bg-gray-50 transition-colors">
                <td className="px-4 py-2.5">
                  <Link to={`/moves/${encodeURIComponent(m.name)}`} className="text-blue-600 hover:underline font-medium">
                    {m.name}
                  </Link>
                </td>
                <td className="px-4 py-2.5"><TypeBadge type={m.type} small /></td>
                <td className="px-4 py-2.5">
                  <span className={`text-xs font-medium px-2 py-0.5 rounded-full ${
                    m.kind === 'Physical' ? 'bg-orange-100 text-orange-700' :
                    m.kind === 'Special'  ? 'bg-blue-100 text-blue-700' :
                    'bg-gray-100 text-gray-600'
                  }`}>{m.kind}</span>
                </td>
                <td className="px-4 py-2.5 text-right text-gray-700">{m.power ?? '—'}</td>
                <td className="px-4 py-2.5 text-right text-gray-700">{m.accuracy != null ? `${m.accuracy}%` : '—'}</td>
                <td className="px-4 py-2.5 text-right text-gray-700">{m.pp}</td>
              </tr>
            ))}
          </tbody>
        </table>
        {filtered.length === 0 && (
          <p className="text-gray-400 text-center py-10">No moves found.</p>
        )}
      </div>
    </div>
  );
}
