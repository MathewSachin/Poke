using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Poke
{
    public partial class BattlingSprite
    {
        public BattlingSprite()
        {
            InitializeComponent();
        }

        DoubleAnimation _hpAnimation;
        ColorAnimation _tintAnimation;

        void FrameworkElement_OnDataContextChanged(object Sender, DependencyPropertyChangedEventArgs Args)
        {
            if (Args.NewValue is Pokemon pokemon && Sender is FrameworkElement frameworkElement && frameworkElement.Parent is FrameworkElement parent)
            {
                pokemon.Stats.PropertyChanged += (S, Arguments) =>
                {
                    if (Arguments.PropertyName == nameof(pokemon.Stats.CurrentHP))
                    {
                        if (_hpAnimation != null)
                            return;
                        
                        _hpAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.1)), FillBehavior.Stop)
                        {
                            RepeatBehavior = new RepeatBehavior(3)
                        };

                        _hpAnimation.Completed += (s, e) => _hpAnimation = null;
                        
                        parent.BeginAnimation(OpacityProperty, _hpAnimation);
                    }
                };
                
                pokemon.PropertyChanged += (S, Arguments) =>
                {
                    if (Arguments.PropertyName == nameof(pokemon.NonVolatileStatus))
                    {
                        DoNonVolativeStatusAnimation(pokemon);
                    }
                };

                pokemon.ShowNonVolativeStatusAnimation += () => DoNonVolativeStatusAnimation(pokemon);

                pokemon.Stats.StatStageChanged += Stage =>
                {
                    var targetColor = Stage > 0 ? Colors.DarkRed : Colors.DarkBlue;

                    DoTintAnimation(targetColor);
                };
            }
        }

        void DoNonVolativeStatusAnimation(Pokemon Pokemon)
        {
            Color targetColor;

            switch (Pokemon.NonVolatileStatus)
            {
                case NonVolatileStatus.Burn:
                    targetColor = Colors.Red;
                    break;

                case NonVolatileStatus.Paralysis:
                    targetColor = Colors.Yellow;
                    break;

                case NonVolatileStatus.Poison:
                case NonVolatileStatus.BadPoison:
                    targetColor = Colors.DarkViolet;
                    break;

                case NonVolatileStatus.Freeze:
                    targetColor = Colors.Aquamarine;
                    break;

                default:
                    return;
            }

            DoTintAnimation(targetColor);
        }

        void DoTintAnimation(Color TargetColor)
        {
            if (_tintAnimation != null)
                return;

            _tintAnimation = new ColorAnimation(TargetColor, new Duration(TimeSpan.FromSeconds(0.1)), FillBehavior.Stop)
            {
                RepeatBehavior = new RepeatBehavior(5)
            };

            _tintAnimation.Completed += (S, E) => _tintAnimation = null;

            TintColor.BeginAnimation(SolidColorBrush.ColorProperty, _tintAnimation);
        }
    }
}
