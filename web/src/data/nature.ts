export interface Nature {
  name: string;
  increased: string | null;
  decreased: string | null;
}

export const NATURES: Nature[] = [
  { name: 'Hardy',   increased: null,       decreased: null },
  { name: 'Lonely',  increased: 'Attack',   decreased: 'Defense' },
  { name: 'Brave',   increased: 'Attack',   decreased: 'Speed' },
  { name: 'Adamant', increased: 'Attack',   decreased: 'Sp. Atk' },
  { name: 'Naughty', increased: 'Attack',   decreased: 'Sp. Def' },
  { name: 'Bold',    increased: 'Defense',  decreased: 'Attack' },
  { name: 'Docile',  increased: null,       decreased: null },
  { name: 'Relaxed', increased: 'Defense',  decreased: 'Speed' },
  { name: 'Impish',  increased: 'Defense',  decreased: 'Sp. Atk' },
  { name: 'Lax',     increased: 'Defense',  decreased: 'Sp. Def' },
  { name: 'Timid',   increased: 'Speed',    decreased: 'Attack' },
  { name: 'Hasty',   increased: 'Speed',    decreased: 'Defense' },
  { name: 'Serious', increased: null,       decreased: null },
  { name: 'Jolly',   increased: 'Speed',    decreased: 'Sp. Atk' },
  { name: 'Naive',   increased: 'Speed',    decreased: 'Sp. Def' },
  { name: 'Modest',  increased: 'Sp. Atk',  decreased: 'Attack' },
  { name: 'Mild',    increased: 'Sp. Atk',  decreased: 'Defense' },
  { name: 'Quiet',   increased: 'Sp. Atk',  decreased: 'Speed' },
  { name: 'Bashful', increased: null,       decreased: null },
  { name: 'Rash',    increased: 'Sp. Atk',  decreased: 'Sp. Def' },
  { name: 'Calm',    increased: 'Sp. Def',  decreased: 'Attack' },
  { name: 'Gentle',  increased: 'Sp. Def',  decreased: 'Defense' },
  { name: 'Sassy',   increased: 'Sp. Def',  decreased: 'Speed' },
  { name: 'Careful', increased: 'Sp. Def',  decreased: 'Sp. Atk' },
  { name: 'Quirky',  increased: null,       decreased: null },
];
