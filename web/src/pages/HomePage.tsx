import { Link } from 'react-router-dom';

const features = [
  { to: '/pokedex',            icon: '📖', title: 'Pokédex',          desc: 'Browse all Pokémon with search and type filter.' },
  { to: '/moves',              icon: '⚔️', title: 'Moves',            desc: 'Explore all moves with type and category filters.' },
  { to: '/abilities',          icon: '✨', title: 'Abilities',         desc: 'Search and browse Pokémon abilities.' },
  { to: '/natures',            icon: '🌿', title: 'Natures',           desc: 'View all 25 natures and their stat effects.' },
  { to: '/type-effectiveness', icon: '🔢', title: 'Type Effectiveness',desc: 'Calculate type matchups for any type combination.' },
  { to: '/team-builder',       icon: '👥', title: 'Team Builder',      desc: 'Build your team of up to 6 Pokémon.' },
  { to: '/battle',             icon: '⚡', title: 'Battle Simulator',  desc: 'Simulate turn-based battles with damage calculation.' },
];

export function HomePage() {
  return (
    <div className="max-w-4xl mx-auto px-4 py-10">
      <div className="text-center mb-10">
        <h1 className="text-4xl font-bold text-red-600 mb-2">🎮 Poke</h1>
        <p className="text-gray-500 text-lg">A simple Pokémon Battle Simulator &amp; Reference</p>
      </div>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
        {features.map(({ to, icon, title, desc }) => (
          <Link
            key={to}
            to={to}
            className="bg-white rounded-xl border border-gray-200 p-5 hover:border-red-300 hover:shadow-md transition-all flex flex-col gap-2"
          >
            <span className="text-3xl">{icon}</span>
            <h2 className="font-semibold text-gray-800">{title}</h2>
            <p className="text-sm text-gray-500">{desc}</p>
          </Link>
        ))}
      </div>
    </div>
  );
}
