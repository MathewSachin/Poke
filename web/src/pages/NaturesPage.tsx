import { NATURES } from '../data/gameData';

export function NaturesPage() {
  return (
    <div className="max-w-3xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Natures</h1>
      <div className="bg-white rounded-xl shadow overflow-hidden">
        <table className="w-full text-sm">
          <thead className="bg-gray-50 text-gray-600 text-xs uppercase tracking-wide">
            <tr>
              <th className="text-left px-4 py-3">Nature</th>
              <th className="text-left px-4 py-3 text-green-600">↑ Increased</th>
              <th className="text-left px-4 py-3 text-red-500">↓ Decreased</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-gray-100">
            {NATURES.map((n) => (
              <tr
                key={n.name}
                className={n.increased == null ? 'bg-gray-50 text-gray-400' : 'hover:bg-gray-50'}
              >
                <td className="px-4 py-2.5 font-medium text-gray-800">{n.name}</td>
                <td className="px-4 py-2.5 text-green-600 font-medium">{n.increased ?? '—'}</td>
                <td className="px-4 py-2.5 text-red-500 font-medium">{n.decreased ?? '—'}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
