namespace Poke
{
    public class Move : NotifyPropertyChanged
    {
        public MoveInfo Info { get; }

        public Move(MoveInfo Info)
        {
            this.Info = Info;

            Name = Info.Name;
            Type = Info.Type;
            Kind = Info.Kind;

            _ppLeft = Info.PP;
        }
        
        public string Name { get; }

        public bool Disabled { get; set; }

        // Set before every attack
        public bool Multitargets { get; set; }

        Types _type;

        public Types Type
        {
            get => _type;
            set
            {
                _type = value;
                
                OnPropertyChanged();
            }
        }

        public MoveKind Kind { get; }

        int _ppLeft;

        public virtual int PPLeft
        {
            get => _ppLeft;
            set
            {
                _ppLeft = value;
                
                OnPropertyChanged();
            }
        }

        public override string ToString() => Name;
    }
}