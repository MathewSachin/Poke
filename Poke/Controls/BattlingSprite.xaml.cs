using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Poke
{
    public partial class BattlingSprite
    {
        public BattlingSprite()
        {
            InitializeComponent();
        }

        DoubleAnimation _animation;

        void FrameworkElement_OnDataContextChanged(object Sender, DependencyPropertyChangedEventArgs E)
        {
            if (E.NewValue is Pokemon pokemon && Sender is FrameworkElement frameworkElement && frameworkElement.Parent is FrameworkElement parent)
            {
                pokemon.Stats.PropertyChanged += (S, Args) =>
                {
                    if (Args.PropertyName == nameof(pokemon.Stats.CurrentHP))
                    {
                        if (_animation != null)
                            return;
                        
                        _animation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.1)), FillBehavior.Stop)
                        {
                            RepeatBehavior = new RepeatBehavior(3)
                        };

                        _animation.Completed += (s, e) => _animation = null;
                        
                        parent.BeginAnimation(OpacityProperty, _animation);
                    }
                };
            }
        }
    }
}
