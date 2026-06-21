import { NavLink } from 'react-router-dom';

const links = [
  { to: '/',                 label: 'Home' },
  { to: '/pokedex',          label: 'Pokédex' },
  { to: '/moves',            label: 'Moves' },
  { to: '/abilities',        label: 'Abilities' },
  { to: '/natures',          label: 'Natures' },
  { to: '/type-effectiveness', label: 'Type Chart' },
  { to: '/team-builder',     label: 'Team Builder' },
  { to: '/battle',           label: 'Battle' },
];

export function Navbar() {
  return (
    <nav className="bg-red-600 shadow-md sticky top-0 z-50">
      <div className="max-w-6xl mx-auto px-4">
        <div className="flex items-center gap-1 overflow-x-auto h-14 scrollbar-none">
          <span className="text-white font-bold text-lg mr-4 shrink-0">🎮 Poke</span>
          {links.map(({ to, label }) => (
            <NavLink
              key={to}
              to={to}
              end={to === '/'}
              className={({ isActive }) =>
                `shrink-0 px-3 py-1.5 rounded text-sm font-medium transition-colors ${
                  isActive
                    ? 'bg-white text-red-600'
                    : 'text-white hover:bg-red-500'
                }`
              }
            >
              {label}
            </NavLink>
          ))}
        </div>
      </div>
    </nav>
  );
}
