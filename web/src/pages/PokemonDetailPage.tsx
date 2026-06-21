import { useParams, Link } from 'react-router-dom';
import { POKEMON, MOVES, spriteUrl, baseStatTotal } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';
import { StatBar } from '../components/StatBar';
import { getCombinedEffectiveness } from '../data/typeEffectiveness';
import { ALL_TYPES } from '../data/types';

export function PokemonDetailPage() {
  const { id } = useParams<{ id: string }>();
  // id is "number_name"
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
    { label: 'HP',         value: pokemon.hp },
    { label: 'Attack',     value: pokemon.attack },
    { label: 'Defense',    value: pokemon.defense },
    { label: 'Sp. Atk',   value: pokemon.spAttack },
    { label: 'Sp. Def',   value: pokemon.spDefense },
    { label: 'Speed',      value: pokemon.speed },
  ];

  const weaknesses = ALL_TYPES.filter((t) => {
    const eff = getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType);
    return eff > 1;
  });
  const resistances = ALL_TYPES.filter((t) => {
    const eff = getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType);
    return eff > 0 && eff < 1;
  });
  const immunities = ALL_TYPES.filter((t) => {
    return getCombinedEffectiveness(t, pokemon.primaryType, pokemon.secondaryType) === 0;
  });

  const abilities = [pokemon.ability1, pokemon.ability2, pokemon.hiddenAbility].filter(Boolean) as string[];

  const learnsetMoves = pokemon.learnset
    .map((n) => MOVES.find((m) => m.name === n))
    .filter(Boolean);

  return (
    <div className="max-w-3xl mx-auto px-4 py-6">
      <Link to="/pokedex" className="text-red-500 hover:underline text-sm mb-4 inline-block">← Pokédex</Link>

      <div className="bg-white rounded-2xl shadow p-6">
        <div className="flex flex-col sm:flex-row items-center gap-6">
          <img
            src={spriteUrl(pokemon.number)}
            alt={pokemon.name}
            className="w-32 h-32 object-contain"
          />
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

        <section className="mt-6">
          <h2 className="font-semibold text-gray-700 mb-2">Base Stats</h2>
          <div className="flex flex-col gap-1.5">
            {stats.map(({ label, value }) => (
              <StatBar key={label} label={label} value={value} />
            ))}
          </div>
        </section>

        <section className="mt-6">
          <h2 className="font-semibold text-gray-700 mb-2">Abilities</h2>
          <div className="flex flex-wrap gap-2">
            {abilities.map((a, i) => (
              <span
                key={a}
                className={`px-3 py-1 rounded-full text-sm border ${
                  i === abilities.length - 1 && pokemon.hiddenAbility != null
                    ? 'border-yellow-400 text-yellow-700 bg-yellow-50'
                    : 'border-gray-300 text-gray-700 bg-gray-50'
                }`}
              >
                {a}{i === abilities.length - 1 && pokemon.hiddenAbility != null ? ' (HA)' : ''}
              </span>
            ))}
          </div>
        </section>

        {weaknesses.length > 0 && (
          <section className="mt-6">
            <h2 className="font-semibold text-gray-700 mb-2">Weak Against</h2>
            <div className="flex flex-wrap gap-1">
              {weaknesses.map((t) => <TypeBadge key={t} type={t} small />)}
            </div>
          </section>
        )}

        {resistances.length > 0 && (
          <section className="mt-4">
            <h2 className="font-semibold text-gray-700 mb-2">Resists</h2>
            <div className="flex flex-wrap gap-1">
              {resistances.map((t) => <TypeBadge key={t} type={t} small />)}
            </div>
          </section>
        )}

        {immunities.length > 0 && (
          <section className="mt-4">
            <h2 className="font-semibold text-gray-700 mb-2">Immune To</h2>
            <div className="flex flex-wrap gap-1">
              {immunities.map((t) => <TypeBadge key={t} type={t} small />)}
            </div>
          </section>
        )}

        {learnsetMoves.length > 0 && (
          <section className="mt-6">
            <h2 className="font-semibold text-gray-700 mb-2">Learnset</h2>
            <div className="flex flex-wrap gap-2">
              {learnsetMoves.map((m) => (
                <Link
                  key={m!.name}
                  to={`/moves/${encodeURIComponent(m!.name)}`}
                  className="px-3 py-1 rounded-full text-sm border border-gray-200 text-gray-700 hover:bg-gray-50 hover:border-gray-400 transition-colors"
                >
                  {m!.name}
                </Link>
              ))}
            </div>
          </section>
        )}
      </div>
    </div>
  );
}
