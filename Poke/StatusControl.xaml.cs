using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Poke
{
    public partial class StatusControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        DoubleAnimation _animation;

        void HP_OnValueChanged(object Sender, RoutedPropertyChangedEventArgs<double> E)
        {
            if (Sender is ProgressBar progressBar)
            {
                if (_animation != null)
                    return;

                _animation = new DoubleAnimation(E.OldValue, E.NewValue, new Duration(TimeSpan.FromSeconds(0.2)), FillBehavior.Stop);

                _animation.Completed += (s, e) => _animation = null;

                progressBar.BeginAnimation(ProgressBar.ValueProperty, _animation);

                E.Handled = true;
            }
        }
    }
}
