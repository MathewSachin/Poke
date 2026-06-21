import { useParams, Link } from 'react-router-dom';
import { MOVES } from '../data/gameData';
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
      </div>
    </div>
  );
}
