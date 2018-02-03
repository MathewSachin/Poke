using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Poke
{
    public class MovesViewModel : NotifyPropertyChanged
    {
        public MovesViewModel()
        {
            AllTypes.Add(new KeyValuePair<Types?, string>(null, "All"));

            for (var i = Types.Normal; i <= Types.Fairy; ++i)
                AllTypes.Add(new KeyValuePair<Types?, string>(i, i.ToString()));

            AllKinds.Add(new KeyValuePair<MoveKind?, string>(null, "All"));

            foreach (var moveKind in new[] { MoveKind.Physical, MoveKind.Special, MoveKind.Status })
            {
                AllKinds.Add(new KeyValuePair<MoveKind?, string>(moveKind, moveKind.ToString()));
            }

            Filter();
        }

        public ObservableCollection<MoveInfo> Moves { get; } = new ObservableCollection<MoveInfo>();
        
        public ObservableCollection<KeyValuePair<Types?, string>> AllTypes { get; } = new ObservableCollection<KeyValuePair<Types?, string>>();

        public ObservableCollection<KeyValuePair<MoveKind?, string>> AllKinds { get; } = new ObservableCollection<KeyValuePair<MoveKind?, string>>();

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

        MoveKind? _selectedKind;

        public MoveKind? SelectedKind
        {
            get => _selectedKind;
            set
            {
                _selectedKind = value;
                
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
                IEnumerable<MoveInfo> filtered = Lists.Moves;

                if (SelectedKind != null)
                    filtered = filtered.Where(M => M.Kind == SelectedKind);

                if (SelectedType != null)
                    filtered = filtered.Where(M => M.Type == SelectedType);

                if (!string.IsNullOrWhiteSpace(SearchText))
                    filtered = filtered.Where(M => M.Name.ToLower().Contains(SearchText.ToLower()));
                
                _syncContext.Post(S =>
                {
                    Moves.Clear();

                    foreach (var moveInfo in filtered)
                    {
                        Moves.Add(moveInfo);
                    }
                }, null);
            });
        }
    }
}