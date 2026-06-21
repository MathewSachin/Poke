import { useState, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { ABILITIES } from '../data/gameData';

export function AbilitiesPage() {
  const [search, setSearch] = useState('');

  const filtered = useMemo(() =>
    ABILITIES.filter((a) =>
      a.name.toLowerCase().includes(search.toLowerCase()) ||
      a.description.toLowerCase().includes(search.toLowerCase())
    ), [search]);

  return (
    <div className="max-w-4xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Abilities</h1>
      <input
        type="text"
        placeholder="Search abilities…"
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        className="border border-gray-300 rounded-lg px-3 py-2 w-full max-w-md focus:outline-none focus:ring-2 focus:ring-red-400 text-sm mb-4"
      />
      <div className="bg-white rounded-xl shadow overflow-hidden">
        {filtered.length === 0 ? (
          <p className="text-gray-400 text-center py-10">No abilities found.</p>
        ) : (
          <div className="divide-y divide-gray-100">
            {filtered.map((a) => (
              <div key={a.name} className="px-4 py-3">
                <Link
                  to={`/abilities/${encodeURIComponent(a.name)}`}
                  className="font-semibold text-gray-800 text-sm hover:text-red-600"
                >
                  {a.name}
                </Link>
                {a.description && (
                  <p className="text-gray-500 text-sm mt-0.5">{a.description}</p>
                )}
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
