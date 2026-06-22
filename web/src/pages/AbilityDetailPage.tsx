import { Link, useParams } from 'react-router-dom';
import { ABILITIES, POKEMON, spriteUrl } from '../data/gameData';
import { TypeBadge } from '../components/TypeBadge';

export function AbilityDetailPage() {
  const { name } = useParams<{ name: string }>();
  const abilityName = decodeURIComponent(name ?? '');
  const ability = ABILITIES.find((a) => a.name === abilityName);

  if (!ability) {
    return (
      <div className="max-w-2xl mx-auto px-4 py-16 text-center">
        <p className="text-gray-500">Ability not found.</p>
        <Link to="/abilities" className="text-red-500 hover:underline mt-2 inline-block">← Back to Abilities</Link>
      </div>
    );
  }

  const pokemonWithAbility = POKEMON.filter(
    (p) => p.ability1 === ability.name || p.ability2 === ability.name || p.hiddenAbility === ability.name,
  );

  return (
    <div className="max-w-4xl mx-auto px-4 py-6">
      <Link to="/abilities" className="text-red-500 hover:underline text-sm mb-4 inline-block">← Abilities</Link>
      <div className="bg-white rounded-2xl shadow p-6">
        <h1 className="text-2xl font-bold text-gray-800">{ability.name}</h1>
        <p className="text-gray-500 text-sm mt-1">{ability.description}</p>

        <section className="mt-6">
          <h2 className="font-semibold text-gray-700 mb-3">Pokémon with this ability</h2>
          {pokemonWithAbility.length === 0 ? (
            <p className="text-sm text-gray-400">No Pokémon currently mapped to this ability.</p>
          ) : (
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-2">
              {pokemonWithAbility.map((pokemon) => {
                const isHidden = pokemon.hiddenAbility === ability.name;
                const isSecond = pokemon.ability2 === ability.name;
                const slot = isHidden ? 'Hidden Ability' : isSecond ? 'Ability 2' : 'Ability 1';
                return (
                  <Link
                    key={`${pokemon.number}_${pokemon.name}`}
                    to={`/pokedex/${pokemon.number}_${encodeURIComponent(pokemon.name)}`}
                    className="border border-gray-200 rounded-xl px-3 py-2.5 hover:bg-gray-50"
                  >
                    <div className="flex items-center gap-3">
                      <img src={spriteUrl(pokemon.number)} alt={pokemon.name} className="w-12 h-12 object-contain" />
                      <div className="min-w-0">
                        <p className="font-semibold text-sm text-gray-800 truncate">{pokemon.name}</p>
                        <div className="flex gap-1 mt-0.5">
                          <TypeBadge type={pokemon.primaryType} small />
                          {pokemon.secondaryType != null && <TypeBadge type={pokemon.secondaryType} small />}
                        </div>
                        <p className="text-xs text-gray-400 mt-1">{slot}</p>
                      </div>
                    </div>
                  </Link>
                );
              })}
            </div>
          )}
        </section>
      </div>
    </div>
  );
}
