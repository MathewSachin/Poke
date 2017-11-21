using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poke
{
    public class Side : NotifyPropertyChanged
    {
        public Side(int Format, params Pokemon[] Party)
        {
            if (Party == null || Party.Length == 0)
                throw new ArgumentException("Party Empty", nameof(Party));

            if (Party.Length > 6)
                throw new ArgumentOutOfRangeException(nameof(Party), "At most 6 Pokemon are allowed");

            if (Format > Party.Length)
                throw new ArgumentException("Party size lesser than required for the format", nameof(Format));

            this.Format = Format;
            _party = Party;

            for (var i = 0; i < Format; ++i)
                Battling.Add(Party[i]);

            foreach (var pokemon in Party)
                pokemon.Side = this;
        }

        public int Format { get; }

        public ObservableCollection<Pokemon> Battling { get; } = new ObservableCollection<Pokemon>();
        
        readonly Pokemon[] _party;

        public IReadOnlyList<Pokemon> Party => _party;
        
        public bool AllFainted => Party.All(Pokemon => Pokemon.IsFainted);

        bool _usedMega;

        public bool UsedMegaEvolution
        {
            get => _usedMega;
            set
            {
                _usedMega = value;
                
                OnPropertyChanged();
            }
        }
        
        public Side OpposingSide { get; set; }
    }
}