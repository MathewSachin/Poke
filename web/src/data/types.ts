// Use a const-object pattern instead of enum (required by verbatimModuleSyntax / erasableSyntaxOnly)
export const PokemonType = {
  Normal:   0,
  Fighting: 1,
  Flying:   2,
  Poison:   3,
  Ground:   4,
  Rock:     5,
  Bug:      6,
  Ghost:    7,
  Steel:    8,
  Fire:     9,
  Water:    10,
  Grass:    11,
  Electric: 12,
  Psychic:  13,
  Ice:      14,
  Dragon:   15,
  Dark:     16,
  Fairy:    17,
} as const;

export type PokemonType = typeof PokemonType[keyof typeof PokemonType];

export const ALL_TYPES: PokemonType[] = [
  PokemonType.Normal,
  PokemonType.Fighting,
  PokemonType.Flying,
  PokemonType.Poison,
  PokemonType.Ground,
  PokemonType.Rock,
  PokemonType.Bug,
  PokemonType.Ghost,
  PokemonType.Steel,
  PokemonType.Fire,
  PokemonType.Water,
  PokemonType.Grass,
  PokemonType.Electric,
  PokemonType.Psychic,
  PokemonType.Ice,
  PokemonType.Dragon,
  PokemonType.Dark,
  PokemonType.Fairy,
];

const TYPE_NAME_MAP: Record<PokemonType, string> = {
  [PokemonType.Normal]:   'Normal',
  [PokemonType.Fighting]: 'Fighting',
  [PokemonType.Flying]:   'Flying',
  [PokemonType.Poison]:   'Poison',
  [PokemonType.Ground]:   'Ground',
  [PokemonType.Rock]:     'Rock',
  [PokemonType.Bug]:      'Bug',
  [PokemonType.Ghost]:    'Ghost',
  [PokemonType.Steel]:    'Steel',
  [PokemonType.Fire]:     'Fire',
  [PokemonType.Water]:    'Water',
  [PokemonType.Grass]:    'Grass',
  [PokemonType.Electric]: 'Electric',
  [PokemonType.Psychic]:  'Psychic',
  [PokemonType.Ice]:      'Ice',
  [PokemonType.Dragon]:   'Dragon',
  [PokemonType.Dark]:     'Dark',
  [PokemonType.Fairy]:    'Fairy',
};

export function typeName(t: PokemonType): string {
  return TYPE_NAME_MAP[t];
}

export const TYPE_COLORS: Record<PokemonType, string> = {
  [PokemonType.Normal]:   '#A8A878',
  [PokemonType.Fighting]: '#C03028',
  [PokemonType.Flying]:   '#A890F0',
  [PokemonType.Poison]:   '#A040A0',
  [PokemonType.Ground]:   '#E0C068',
  [PokemonType.Rock]:     '#B8A038',
  [PokemonType.Bug]:      '#A8B820',
  [PokemonType.Ghost]:    '#705898',
  [PokemonType.Steel]:    '#B8B8D0',
  [PokemonType.Fire]:     '#F08030',
  [PokemonType.Water]:    '#6890F0',
  [PokemonType.Grass]:    '#78C850',
  [PokemonType.Electric]: '#F8D030',
  [PokemonType.Psychic]:  '#F85888',
  [PokemonType.Ice]:      '#98D8D8',
  [PokemonType.Dragon]:   '#7038F8',
  [PokemonType.Dark]:     '#705848',
  [PokemonType.Fairy]:    '#EE99AC',
};
