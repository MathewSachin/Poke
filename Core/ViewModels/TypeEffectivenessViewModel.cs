using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Poke
{
    public class TypeEffectivenessViewModel : NotifyPropertyChanged
    {
        static TypeEffectivenessViewModel()
        {
            for (var i = Types.Normal; i <= Types.Fairy; ++i)
                AllTypes.Add(i);
        }

        static readonly List<Types> AllTypes = new List<Types>();

        public TypeEffectivenessViewModel()
        {
            for (var i = Types.Normal + 1; i <= Types.Fairy; ++i)
            {
                PrimaryTypesAvailable.Add(i);
                SecondaryTypesAvailable.Add(new KeyValuePair<Types?, string>(i, i.ToString()));
            }

            Update();
        }

        public ObservableCollection<Types> PrimaryTypesAvailable { get; } = new ObservableCollection<Types> { Types.Normal };

        public ObservableCollection<KeyValuePair<Types?, string>> SecondaryTypesAvailable { get; } = new ObservableCollection<KeyValuePair<Types?, string>>
        {
            new KeyValuePair<Types?, string>(null, "None")
        };

        Types _primaryType;
        Types? _secondaryType;

        public Types PrimaryType
        {
            get => _primaryType;
            set
            {
                KeyValuePair<Types?, string>? toRemove = null;

                foreach (var type in SecondaryTypesAvailable)
                {
                    if (type.Key == value)
                    {
                        toRemove = type;
                        break;
                    }
                }

                if (toRemove != null)
                    SecondaryTypesAvailable.Remove(toRemove.Value);

                for (var i = 0; i < SecondaryTypesAvailable.Count; ++i)
                {
                    if (SecondaryTypesAvailable[i].Key > _primaryType)
                    {
                        SecondaryTypesAvailable.Insert(i, new KeyValuePair<Types?, string>(_primaryType, _primaryType.ToString()));

                        break;
                    }
                }
                
                _primaryType = value;
                
                OnPropertyChanged();

                Update();
            }
        }

        public Types? SecondaryType
        {
            get => _secondaryType;
            set
            {
                if (_secondaryType == value)
                    return;

                if (value != null && PrimaryTypesAvailable.Contains(value.Value))
                    PrimaryTypesAvailable.Remove(value.Value);

                if (_secondaryType != null)
                {
                    var added = false;

                    for (var i = 0; i < PrimaryTypesAvailable.Count; ++i)
                    {
                        if (PrimaryTypesAvailable[i] > _secondaryType.Value)
                        {
                            PrimaryTypesAvailable.Insert(i, _secondaryType.Value);

                            added = true;
                            
                            break;
                        }
                    }

                    // For Fairy type
                    if (!added)
                        PrimaryTypesAvailable.Add(_secondaryType.Value);
                }

                _secondaryType = value;
                
                OnPropertyChanged();

                Update();
            }
        }

        void Update()
        {
            WeakAgainst.Clear();
            ResistantAgainst.Clear();
            NormalDamage.Clear();

            for (var i = Types.Normal; i <= Types.Fairy; ++i)
            {
                var effect = TypeEffectiveness.Get(i, PrimaryType, SecondaryType);
                var typeEffect = new TypeEffect(i, effect);

                if (effect > 1)
                    WeakAgainst.Add(typeEffect);
                else if (effect < 1)
                    ResistantAgainst.Add(typeEffect);
                else NormalDamage.Add(typeEffect);
            }
        }

        public ObservableCollection<TypeEffect> WeakAgainst { get; } = new ObservableCollection<TypeEffect>();

        public ObservableCollection<TypeEffect> ResistantAgainst { get; } = new ObservableCollection<TypeEffect>();

        public ObservableCollection<TypeEffect> NormalDamage { get; } = new ObservableCollection<TypeEffect>();
    }
}