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

            PPLeft = PP = Info.PP;
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
        
        public int PP { get; }

        int _ppLeft;

        public int PPLeft
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