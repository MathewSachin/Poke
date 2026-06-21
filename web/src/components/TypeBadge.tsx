import { PokemonType, TYPE_COLORS, typeName } from '../data/gameData';

interface TypeBadgeProps {
  type: PokemonType;
  small?: boolean;
}

export function TypeBadge({ type, small = false }: TypeBadgeProps) {
  const color = TYPE_COLORS[type];
  return (
    <span
      style={{ backgroundColor: color }}
      className={`inline-block rounded font-semibold text-white uppercase tracking-wide ${
        small ? 'px-1.5 py-0.5 text-[10px]' : 'px-2 py-0.5 text-xs'
      }`}
    >
      {typeName(type)}
    </span>
  );
}
