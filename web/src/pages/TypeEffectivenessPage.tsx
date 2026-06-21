import { useState } from 'react';
import { ALL_TYPES, PokemonType, typeName } from '../data/gameData';
import { getCombinedEffectiveness } from '../data/typeEffectiveness';
import { TypeBadge } from '../components/TypeBadge';

export function TypeEffectivenessPage() {
  const [primary, setPrimary] = useState<PokemonType>(PokemonType.Normal);
  const [secondary, setSecondary] = useState<PokemonType | null>(null);

  const weakTo    = ALL_TYPES.filter((t) => getCombinedEffectiveness(t, primary, secondary) > 1);
  const resistsTo = ALL_TYPES.filter((t) => {
    const e = getCombinedEffectiveness(t, primary, secondary);
    return e > 0 && e < 1;
  });
  const immuneTo  = ALL_TYPES.filter((t) => getCombinedEffectiveness(t, primary, secondary) === 0);
  const normalTo  = ALL_TYPES.filter((t) => getCombinedEffectiveness(t, primary, secondary) === 1);

  return (
    <div className="max-w-3xl mx-auto px-4 py-6">
      <h1 className="text-2xl font-bold text-gray-800 mb-4">Type Effectiveness</h1>
      <div className="bg-white rounded-xl shadow p-5 mb-6">
        <div className="flex flex-col sm:flex-row gap-4">
          <div className="flex-1">
            <label className="block text-sm font-medium text-gray-600 mb-1">Primary Type</label>
            <select
              value={primary}
              onChange={(e) => {
                const val = Number(e.target.value) as PokemonType;
                setPrimary(val);
                if (secondary === val) setSecondary(null);
              }}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
            >
              {ALL_TYPES.map((t) => (
                <option key={t} value={t}>{typeName(t)}</option>
              ))}
            </select>
          </div>
          <div className="flex-1">
            <label className="block text-sm font-medium text-gray-600 mb-1">Secondary Type</label>
            <select
              value={secondary ?? ''}
              onChange={(e) => setSecondary(e.target.value === '' ? null : Number(e.target.value) as PokemonType)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400"
            >
              <option value="">None</option>
              {ALL_TYPES.filter((t) => t !== primary).map((t) => (
                <option key={t} value={t}>{typeName(t)}</option>
              ))}
            </select>
          </div>
        </div>
        <div className="mt-3 flex gap-2 flex-wrap">
          <TypeBadge type={primary} />
          {secondary != null && <TypeBadge type={secondary} />}
        </div>
      </div>

      <Section title="Weak Against (2× or 4×)" types={weakTo} bg="bg-red-50" titleColor="text-red-700" />
      <Section title="Resists (½× or ¼×)" types={resistsTo} bg="bg-green-50" titleColor="text-green-700" />
      <Section title="Immune To (0×)" types={immuneTo} bg="bg-gray-100" titleColor="text-gray-600" />
      <Section title="Normal Damage (1×)" types={normalTo} bg="bg-white" titleColor="text-gray-700" />
    </div>
  );
}

function Section({
  title,
  types,
  bg,
  titleColor,
}: {
  title: string;
  types: PokemonType[];
  bg: string;
  titleColor: string;
}) {
  if (types.length === 0) return null;
  return (
    <div className={`rounded-xl border border-gray-200 ${bg} p-4 mb-4`}>
      <h2 className={`font-semibold text-sm mb-2 ${titleColor}`}>{title}</h2>
      <div className="flex flex-wrap gap-1.5">
        {types.map((t) => <TypeBadge key={t} type={t} small />)}
      </div>
    </div>
  );
}
