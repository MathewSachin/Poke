using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Poke
{
    public class AbilitiesViewModel : NotifyPropertyChanged
    {
        public AbilitiesViewModel()
        {
            Filter();
        }

        public ObservableCollection<Ability> Abilities { get; } = new ObservableCollection<Ability>();

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
                IEnumerable<Ability> filtered = Lists.Abilities;
                
                if (!string.IsNullOrWhiteSpace(SearchText))
                    filtered = filtered.Where(M => M.Name.ToLower().Contains(SearchText.ToLower()));
                
                _syncContext.Post(S =>
                {
                    Abilities.Clear();

                    foreach (var moveInfo in filtered)
                    {
                        Abilities.Add(moveInfo);
                    }
                }, null);
            });
        }
    }
}