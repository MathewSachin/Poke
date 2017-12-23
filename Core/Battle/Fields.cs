using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Poke
{
    public partial class BattleViewModel
    {
        int? _format;

        public int Format
        {
            get => _format ?? 0;
            set
            {
                if (_format != null)
                    return;

                _format = value;

                OnPropertyChanged();

                BattleLoop();
            }
        }

        Pokemon _movingPokemon;

        public Pokemon MovingPokemon
        {
            get => _movingPokemon;
            private set
            {
                _movingPokemon = value;

                OnPropertyChanged();
            }
        }

        BattleState _battleState;

        public BattleState BattleState
        {
            get => _battleState;
            set
            {
                _battleState = value;

                MoveCommand.RaiseCanExecuteChanged();
                SwitchCommand.RaiseCanExecuteChanged();
                TargetCommand.RaiseCanExecuteChanged();

                OnPropertyChanged();
            }
        }

        Pokemon _toSwitch;
        int? _toMove;
        Pokemon _target;

        static readonly Func<Pokemon>[] PokemonGenerators =
        {
            () => PokemonFactory.Aerodactyl,
            () => PokemonFactory.Arcanine,
            () => PokemonFactory.Alakazam,
            () => PokemonFactory.Beedrill,
            () => PokemonFactory.Blastoise,
            () => PokemonFactory.Blaziken,
            () => PokemonFactory.Charizard,
            () => PokemonFactory.Dragonite,
            () => PokemonFactory.Electivire,
            () => PokemonFactory.Empoleon,
            () => PokemonFactory.Espeon,
            () => PokemonFactory.Feraligatr,
            () => PokemonFactory.Flygon,
            () => PokemonFactory.Gardevoir,
            () => PokemonFactory.Gengar,
            () => PokemonFactory.Glaceon,
            () => PokemonFactory.Golduck,
            () => PokemonFactory.Goodra,
            () => PokemonFactory.Greninja,
            () => PokemonFactory.Gyarados,
            () => PokemonFactory.Haxorus,
            () => PokemonFactory.Heracross,
            () => PokemonFactory.Houndoom,
            () => PokemonFactory.Infernape,
            () => PokemonFactory.Kangaskhan,
            () => PokemonFactory.Kommo,
            () => PokemonFactory.Leafeon,
            () => PokemonFactory.Lilligant,
            () => PokemonFactory.Lucario,
            () => PokemonFactory.LycanrocMidday,
            () => PokemonFactory.LycanrocMidnight,
            () => PokemonFactory.Magmortar,
            () => PokemonFactory.Mawile,
            () => PokemonFactory.Meganium,
            () => PokemonFactory.Milotic,
            () => PokemonFactory.Ninetales,
            () => PokemonFactory.NinetalesAlolan,
            () => PokemonFactory.Noivern,
            () => PokemonFactory.Pangoro,
            () => PokemonFactory.Pelipper,
            () => PokemonFactory.Pidgeot,
            () => PokemonFactory.Pikachu,
            () => PokemonFactory.Politoed,
            () => PokemonFactory.Salamence,
            () => PokemonFactory.Salazzle,
            () => PokemonFactory.Sceptile,
            () => PokemonFactory.Scizor,
            () => PokemonFactory.Swampert,
            () => PokemonFactory.Steelix,
            () => PokemonFactory.Sylveon,
            () => PokemonFactory.Talonflame,
            () => PokemonFactory.Torterra,
            () => PokemonFactory.Toxicroak,
            () => PokemonFactory.Typhlosion,
            () => PokemonFactory.Tyranitar,
            () => PokemonFactory.Umbreon,
            () => PokemonFactory.Venusaur
        };

        readonly PokemonMovePairComparer _pokemonMovePairComparer;
        
        bool _useMega;

        public bool UseMegaEvolution
        {
            get => _useMega;
            set
            {
                _useMega = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<Pokemon> SelectOpponent { get; } = new ObservableCollection<Pokemon>();

        bool _canMegaEvolve;

        public bool CanMegaEvolve
        {
            get => _canMegaEvolve;
            set
            {
                _canMegaEvolve = value;

                OnPropertyChanged();
            }
        }

        #region Status
        string _status;

        public string Status => _status;

        public string GetStatusName(Pokemon Pokemon)
        {
            return (Pokemon.Side == OpponentSide ? "The opposing " : "") + Pokemon;
        }

        public async Task WriteStatus(string Text, bool Wait = true)
        {
            _status = Text;

            OnPropertyChanged(nameof(Status));

            if (Wait)
            {
                _continueEvent.Reset();

                await Task.Factory.StartNew(() => _continueEvent.WaitOne(1000));
            }
        }
        #endregion

        public static Random Random { get; } = new Random(DateTime.Now.Millisecond);

        #region Sides
        Side _playerSide, _opponentSide;

        public Side PlayerSide
        {
            get => _playerSide;
            set
            {
                _playerSide = value;

                OnPropertyChanged();
            }
        }

        public Side OpponentSide
        {
            get => _opponentSide;
            set
            {
                _opponentSide = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Ability Display
        string _abilityPlayer, _abilityOpponent;

        public string AbilityPlayer
        {
            get => _abilityPlayer;
            private set
            {
                _abilityPlayer = value;

                OnPropertyChanged();
            }
        }

        public string AbilityOpponent
        {
            get => _abilityOpponent;
            private set
            {
                _abilityOpponent = value;

                OnPropertyChanged();
            }
        }

        public async Task ShowAbility(Pokemon Pokemon)
        {
            var playerTurn = Pokemon.Side == PlayerSide;

            if (playerTurn)
                AbilityPlayer = $"{Pokemon}'s {Pokemon.Ability}";
            else AbilityOpponent = $"{Pokemon}'s {Pokemon.Ability}";

            _continueEvent.Reset();

            await Task.Factory.StartNew(() => _continueEvent.WaitOne(1000));

            if (playerTurn)
                AbilityPlayer = null;
            else AbilityOpponent = null;
        }
        #endregion
    }
}