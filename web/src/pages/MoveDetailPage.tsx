import { useParams, Link } from 'react-router-dom';
import { MOVES, POKEMON, spriteUrl } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';

export function MoveDetailPage() {
  const { name } = useParams<{ name: string }>();
  const move = MOVES.find((m) => m.name === decodeURIComponent(name ?? ''));

  if (!move) {
    return (
      <div className="max-w-2xl mx-auto px-4 py-16 text-center">
        <p className="text-gray-500">Move not found.</p>
        <Link to="/moves" className="text-red-500 hover:underline mt-2 inline-block">← Back to Moves</Link>
      </div>
    );
  }

  const rows = [
    { label: 'Type',     value: <TypeBadge type={move.type} /> },
    { label: 'Category', value: move.kind },
    { label: 'Power',    value: move.power != null ? String(move.power) : '—' },
    { label: 'Accuracy', value: move.accuracy != null ? `${move.accuracy}%` : '—' },
    { label: 'PP',       value: String(move.pp) },
    { label: 'Priority', value: move.priority !== 0 ? `${move.priority > 0 ? '+' : ''}${move.priority}` : '0' },
  ];

  const learners = POKEMON.filter((p) => p.learnset.includes(move.name));

  return (
    <div className="max-w-xl mx-auto px-4 py-6">
      <Link to="/moves" className="text-red-500 hover:underline text-sm mb-4 inline-block">← Moves</Link>
      <div className="bg-white rounded-2xl shadow p-6">
        <h1 className="text-2xl font-bold text-gray-800 mb-1">{move.name}</h1>
        <p className="text-gray-500 text-sm mb-4">{move.description}</p>
        <dl className="divide-y divide-gray-100">
          {rows.map(({ label, value }) => (
            <div key={label} className="flex justify-between py-2.5 text-sm">
              <dt className="text-gray-500 font-medium">{label}</dt>
              <dd className="text-gray-800 font-semibold">{value}</dd>
            </div>
          ))}
        </dl>

        <section className="mt-6">
          <h2 className="font-semibold text-gray-700 mb-2">Pokémon that learn this move</h2>
          {learners.length === 0 ? (
            <p className="text-sm text-gray-400">No Pokémon currently mapped to this move.</p>
          ) : (
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-2">
              {learners.map((pokemon) => (
                <Link
                  key={`${pokemon.number}_${pokemon.name}`}
                  to={`/pokedex/${pokemon.number}_${encodeURIComponent(pokemon.name)}`}
                  className="flex items-center gap-2 border border-gray-200 rounded-xl px-3 py-2 hover:bg-gray-50"
                >
                  <img src={spriteUrl(pokemon.number)} alt={pokemon.name} className="w-8 h-8 object-contain" />
                  <span className="text-sm font-medium text-gray-700">{pokemon.name}</span>
                </Link>
              ))}
            </div>
          )}
        </section>
      </div>
    </div>
  );
}
