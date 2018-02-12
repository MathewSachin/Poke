using System;

namespace Poke
{
    public class Pokemon : NotifyPropertyChanged
    {
        public Pokemon(PokemonSpecies Species, int Level, string NickName = null, Nature Nature = null, int? Ability = null)
        {
            Name = NickName;
            this.Level = Level;
            this.Nature = Nature ?? Lists.Natures.Random();
            
            if (Species.GenderRatio == GenderRatio.Genderless)
                Gender = Gender.Genderless;
            else if (Species.GenderRatio == GenderRatio.MaleOnly)
                Gender = Gender.Male;
            else if (Species.GenderRatio == GenderRatio.FemaleOnly)
                Gender = Gender.Female;
            else
            {
                var random = BattleViewModel.Random.Next(100);

                Gender = random < Species.GenderRatio.Female ? Gender.Female : Gender.Male;
            }

            Shiny = BattleViewModel.Random.Next(8192) == 4096;

            SetSpecies(Species, Ability);
        }

        void SetSpecies(PokemonSpecies PokemonSpecies, int? AbilityIndex = null)
        {
            // Update if not nick name
            if (Name == null || Species != null && Name == Species.Name)
                Name = PokemonSpecies.Name;

            Species = PokemonSpecies;

            PrimaryType = Species.PrimaryType;
            SecondaryType = Species.SecondaryType;
            
            var newStats = new PokemonStats(this);

            if (Stats != null)
            {
                newStats.OnMegaEvolve(Stats);
            }

            Stats = newStats;

            if (AbilityIndex != null && AbilityIndex >= 1 && AbilityIndex <= 3)
            {
                Ability = Species.GetAbility(AbilityIndex.Value);
                AbilitySlot = AbilityIndex.Value;
            }
            else
            {
                Ability = Species.GetAbility(out var slot);
                AbilitySlot = slot;
            }
        }
        
        public bool CanMegaEvolve(out MegaEvolution Mega)
        {
            foreach (var mega in Species.MegaEvolutions)
            {
                if (HeldItem == mega.MegaStone)
                {
                    Mega = mega;

                    return true;
                }
            }

            Mega = null;

            return false;
        }

        public void MegaEvolve()
        {
            foreach (var mega in Species.MegaEvolutions)
            {
                if (HeldItem == mega.MegaStone)
                {
                    SetSpecies(mega.Species);

                    return;
                }
            }
        }

        public bool Shiny { get; }

        PokemonSpecies _species;

        public PokemonSpecies Species
        {
            get => _species;
            private set
            {
                _species = value;
                
                OnPropertyChanged();
            }
        }

        string _name;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                
                OnPropertyChanged();
            }
        }

        Types _primaryType;
        Types? _secondaryType;

        public Types PrimaryType
        {
            get => _primaryType;
            private set
            {
                _primaryType = value;
                
                OnPropertyChanged();
            }
        }

        public Types? SecondaryType
        {
            get => _secondaryType;
            private set
            {
                _secondaryType = value;
                
                OnPropertyChanged();
            }
        }

        PokemonStats _stats;

        public PokemonStats Stats
        {
            get => _stats;
            private set
            {
                _stats = value;
                
                OnPropertyChanged();
            }
        }

        public int AbilitySlot { get; private set; }

        public Ability Ability { get; private set; }

        public int AbilityData { get; set; }

        public HeldItem HeldItem { get; set; }

        public Gender Gender { get; }

        public int Level { get; }
        
        public Nature Nature { get; }

        public Side Side { get; set; }
        
        public bool AlreadyMoved { get; set; }

        public bool Flinched { get; set; }

        public bool Recharging { get; set; }
        
        NonVolatileStatus _nonVolatileStatus;

        public NonVolatileStatus NonVolatileStatus
        {
            get => _nonVolatileStatus;
            set
            {
                _nonVolatileStatus = value;
                
                OnPropertyChanged();
            }
        }

        public MoveSet Moves { get; } = new MoveSet();

        public int SleepCounter { get; set; }

        public int ConfusionCounter { get; set; }

        public override string ToString() => Name;

        public bool IsFainted => Stats.CurrentHP == 0;

        public void RaiseShowNonVolativeStatusAnimation()
        {
            ShowNonVolativeStatusAnimation?.Invoke();
        }

        public event Action ShowNonVolativeStatusAnimation;

        bool _transforming;

        public bool Transforming
        {
            get => _transforming;
            set
            {
                _transforming = value;

                OnPropertyChanged();
            }
        }
    }
}