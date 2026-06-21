import { Link } from 'react-router-dom';
import type { PokemonSpecies } from '../data/gameData';
import { spriteUrl } from '../data/gameData';
import { TypeBadge } from './TypeBadge';

interface PokemonCardProps {
  pokemon: PokemonSpecies;
}

export function PokemonCard({ pokemon }: PokemonCardProps) {
  return (
    <Link
      to={`/pokedex/${pokemon.number}_${encodeURIComponent(pokemon.name)}`}
      className="bg-white rounded-xl shadow hover:shadow-md transition-shadow p-4 flex flex-col items-center gap-2 border border-gray-100 hover:border-red-200"
    >
      <img
        src={spriteUrl(pokemon.number)}
        alt={pokemon.name}
        className="w-20 h-20 object-contain"
        loading="lazy"
      />
      <p className="text-xs text-gray-400">#{String(pokemon.number).padStart(3, '0')}</p>
      <p className="font-semibold text-gray-800 text-sm text-center leading-tight">{pokemon.name}</p>
      <div className="flex gap-1 flex-wrap justify-center">
        <TypeBadge type={pokemon.primaryType} small />
        {pokemon.secondaryType != null && <TypeBadge type={pokemon.secondaryType} small />}
      </div>
    </Link>
  );
}
