using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Poke
{
    public class PokemonListViewModel : NotifyPropertyChanged
    {
        public PokemonListViewModel()
        {
            AllTypes.Add(new KeyValuePair<Types?, string>(null, "All"));

            for (var i = Types.Normal; i <= Types.Fairy; ++i)
                AllTypes.Add(new KeyValuePair<Types?, string>(i, i.ToString()));
            
            Filter();
        }

        public ObservableCollection<PokemonSpecies> Pokemons { get; } = new ObservableCollection<PokemonSpecies>();
        
        public ObservableCollection<KeyValuePair<Types?, string>> AllTypes { get; } = new ObservableCollection<KeyValuePair<Types?, string>>();
        
        Types? _selectedType;

        public Types? SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                
                OnPropertyChanged();

                Filter();
            }
        }

        string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                
                OnPropertyChanged();

                Filter();
            }
        }

        Task _lastTask;

        readonly SynchronizationContext _syncContext = SynchronizationContext.Current;

        async void Filter()
        {
            if (_lastTask != null)
            {
                await _lastTask;
            }

            _lastTask = Task.Run(() =>
            {
                IEnumerable<PokemonSpecies> filtered = Lists.PokemonSpecies;

                if (SelectedType != null)
                    filtered = filtered.Where(M => M.PrimaryType == SelectedType || M.SecondaryType == SelectedType);

                if (!string.IsNullOrWhiteSpace(SearchText))
                    filtered = filtered.Where(M => M.Name.ToLower().Contains(SearchText.ToLower()));
                
                _syncContext.Post(S =>
                {
                    Pokemons.Clear();

                    foreach (var pokemon in filtered)
                    {
                        Pokemons.Add(pokemon);
                    }
                }, null);
            });
        }
    }
}