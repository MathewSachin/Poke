using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Poke
{
    public partial class DexWindow
    {
        public DexWindow()
        {
            InitializeComponent();
        }

        void Frame_OnNavigating(object Sender, NavigatingCancelEventArgs E)
        {
            if (E.Content is Page page)
            {
                var transform = new TranslateTransform();

                page.RenderTransform = transform;

                var anim = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.3),
                    DecelerationRatio = 0.7
                };

                switch (E.NavigationMode)
                {
                    case NavigationMode.New:
                        anim.From = 500;
                        anim.To = 0;
                        break;

                    case NavigationMode.Back:
                        anim.To = 0;
                        anim.From = -500;
                        break;
                }

                transform.BeginAnimation(TranslateTransform.XProperty, anim);
            }
        }

    }
}
