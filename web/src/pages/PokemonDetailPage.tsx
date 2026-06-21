import { useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { POKEMON, MOVES, spriteUrl, baseStatTotal } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import { StatBar } from '../components/StatBar';
import { getCombinedEffectiveness } from '../data/typeEffectiveness';
import { ALL_TYPES } from '../data/types';

type TabKey = 'abilities' | 'moves' | 'typechart';

const tabs: { key: TabKey; label: string }[] = [
  { key: 'abilities', label: 'Abilities' },
  { key: 'moves', label: 'Moves & Stats' },
  { key: 'typechart', label: 'Type Matchups' },
];

export function PokemonDetailPage() {
  const { id } = useParams<{ id: string }>();
  const [tab, setTab] = useState<TabKey>('abilities');
  const [numStr, ...nameParts] = (id ?? '').split('_');
  const name = decodeURIComponent(nameParts.join('_'));
  const number = Number(numStr);
  const pokemon = POKEMON.find((p) => p.number === number && p.name === name);

  if (!pokemon) {
    return (
      <div className="max-w-2xl mx-auto px-4 py-16 text-center">
        <p className="text-gray-500 text-lg">Pokémon not found.</p>
        <Link to="/pokedex" className="text-red-500 hover:underline mt-2 inline-block">← Back to Pokédex</Link>
      </div>
    );
  }

  const stats = [
    { label: 'HP', value: pokemon.hp },
    { label: 'Attack', value: pokemon.attack },
    { label: 'Defense', value: pokemon.defense },
    { label: 'Sp. Atk', value: pokemon.spAttack },
    { label: 'Sp. Def', value: pokemon.spDefense },
    { label: 'Speed', value: pokemon.speed },
  ];

  const abilities = [
    { name: pokemon.ability1, slot: 'Ability 1', hidden: false },
    pokemon.ability2 ? { name: pokemon.ability2, slot: 'Ability 2', hidden: false } : null,
    pokemon.hiddenAbility ? { name: pokemon.hiddenAbility, slot: 'Hidden Ability', hidden: true } : null,
  ].filter(Boolean) as { name: string; slot: string; hidden: boolean }[];

  const learnsetMoves = pokemon.learnset
    .map((moveName) => MOVES.find((m) => m.name === moveName))
    .filter((m): m is NonNullable<typeof m> => m != null)
    .sort((a, b) => {
      if (a.kind !== b.kind) {
        const rank = { Physical: 0, Special: 1, Status: 2 };
        return rank[a.kind] - rank[b.kind];
      }
      return a.name.localeCompare(b.name);
    });

  const weaknesses = ALL_TYPES.filter((t) => getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType) > 1);
  const resistances = ALL_TYPES.filter((t) => {
    const eff = getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType);
    return eff > 0 && eff < 1;
  });
  const immunities = ALL_TYPES.filter((t) => getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType) === 0);

  return (
    <div className="max-w-3xl mx-auto px-4 py-6">
      <Link to="/pokedex" className="text-red-500 hover:underline text-sm mb-4 inline-block">← Pokédex</Link>

      <div className="bg-white rounded-2xl shadow p-6">
        <div className="flex flex-col sm:flex-row items-center gap-6">
          <img src={spriteUrl(pokemon.number)} alt={pokemon.name} className="w-32 h-32 object-contain" />
          <div className="flex-1">
            <p className="text-gray-400 text-sm">#{String(pokemon.number).padStart(3, '0')}</p>
            <h1 className="text-3xl font-bold text-gray-800">{pokemon.name}</h1>
            <div className="flex gap-2 mt-2">
              <TypeBadge type={pokemon.primaryType} />
              {pokemon.secondaryType != null && <TypeBadge type={pokemon.secondaryType} />}
            </div>
            <p className="text-sm text-gray-500 mt-1">BST: <strong>{baseStatTotal(pokemon)}</strong></p>
          </div>
        </div>

        <div className="mt-6 border-b border-gray-100 flex gap-2 overflow-x-auto">
          {tabs.map((t) => (
            <button
              key={t.key}
              onClick={() => setTab(t.key)}
              className={`px-3 py-2 text-sm font-semibold rounded-t-lg border-b-2 ${
                tab === t.key
                  ? 'text-red-600 border-red-500'
                  : 'text-gray-500 border-transparent hover:text-gray-700'
              }`}
            >
              {t.label}
            </button>
          ))}
        </div>

        {tab === 'abilities' && (
          <section className="mt-5">
            <h2 className="font-semibold text-gray-700 mb-3">Available abilities</h2>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-2">
              {abilities.map((ability) => (
                <Link
                  key={ability.name}
                  to={`/abilities/${encodeURIComponent(ability.name)}`}
                  className={`border rounded-xl px-3 py-2 hover:bg-gray-50 ${
                    ability.hidden ? 'border-yellow-300 bg-yellow-50/60' : 'border-gray-200'
                  }`}
                >
                  <p className="font-semibold text-sm text-gray-800">{ability.name}</p>
                  <p className="text-xs text-gray-500">{ability.slot}</p>
                </Link>
              ))}
            </div>
          </section>
        )}

        {tab === 'moves' && (
          <>
            <section className="mt-5">
              <h2 className="font-semibold text-gray-700 mb-2">Base Stats</h2>
              <div className="flex flex-col gap-1.5">
                {stats.map(({ label, value }) => (
                  <StatBar key={label} label={label} value={value} />
                ))}
              </div>
            </section>

            {learnsetMoves.length > 0 && (
              <section className="mt-6">
                <h2 className="font-semibold text-gray-700 mb-2">Learnset</h2>
                <div className="flex flex-col gap-2">
                  {learnsetMoves.map((move) => (
                    <Link
                      key={move.name}
                      to={`/moves/${encodeURIComponent(move.name)}`}
                      className="border border-gray-200 rounded-xl px-3 py-2 hover:bg-gray-50"
                    >
                      <div className="flex items-center justify-between gap-2">
                        <p className="font-semibold text-sm text-gray-800">{move.name}</p>
                        <div className="flex gap-1">
                          <TypeBadge type={move.type} small />
                          <span className="text-xs px-2 py-0.5 rounded-full border border-gray-200 bg-gray-50 text-gray-600">
                            {move.kind}
                          </span>
                        </div>
                      </div>
                    </Link>
                  ))}
                </div>
              </section>
            )}
          </>
        )}

        {tab === 'typechart' && (
          <section className="mt-5">
            {weaknesses.length > 0 && (
              <div className="mb-4">
                <h2 className="font-semibold text-gray-700 mb-2">Weak Against</h2>
                <div className="flex flex-wrap gap-1">
                  {weaknesses.map((t) => <TypeBadge key={t} type={t} small />)}
                </div>
              </div>
            )}

            {resistances.length > 0 && (
              <div className="mb-4">
                <h2 className="font-semibold text-gray-700 mb-2">Resists</h2>
                <div className="flex flex-wrap gap-1">
                  {resistances.map((t) => <TypeBadge key={t} type={t} small />)}
                </div>
              </div>
            )}

            {immunities.length > 0 && (
              <div>
                <h2 className="font-semibold text-gray-700 mb-2">Immune To</h2>
                <div className="flex flex-wrap gap-1">
                  {immunities.map((t) => <TypeBadge key={t} type={t} small />)}
                </div>
              </div>
            )}
          </section>
        )}
      </div>
    </div>
  );
}
