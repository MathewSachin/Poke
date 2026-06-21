import { HashRouter, Routes, Route } from 'react-router-dom';
import { Navbar } from './components/Navbar';
import { HomePage } from './pages/HomePage';
import { PokedexPage } from './pages/PokedexPage';
import { PokemonDetailPage } from './pages/PokemonDetailPage';
import { MovesPage } from './pages/MovesPage';
import { MoveDetailPage } from './pages/MoveDetailPage';
import { AbilitiesPage } from './pages/AbilitiesPage';
import { AbilityDetailPage } from './pages/AbilityDetailPage';
import { NaturesPage } from './pages/NaturesPage';
import { TypeEffectivenessPage } from './pages/TypeEffectivenessPage';
import { TeamBuilderPage } from './pages/TeamBuilderPage';
import { BattlePage } from './pages/BattlePage';

export default function App() {
  return (
    <HashRouter>
      <div className="min-h-screen bg-gray-50">
        <Navbar />
        <main>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/pokedex" element={<PokedexPage />} />
            <Route path="/pokedex/:id" element={<PokemonDetailPage />} />
            <Route path="/moves" element={<MovesPage />} />
            <Route path="/moves/:name" element={<MoveDetailPage />} />
            <Route path="/abilities" element={<AbilitiesPage />} />
            <Route path="/abilities/:name" element={<AbilityDetailPage />} />
            <Route path="/natures" element={<NaturesPage />} />
            <Route path="/type-effectiveness" element={<TypeEffectivenessPage />} />
            <Route path="/team-builder" element={<TeamBuilderPage />} />
            <Route path="/battle" element={<BattlePage />} />
          </Routes>
        </main>
      </div>
    </HashRouter>
  );
}
