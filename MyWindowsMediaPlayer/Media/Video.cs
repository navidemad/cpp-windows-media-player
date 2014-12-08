using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Media
{
    class Video : System.Windows.Controls.MediaElement
    {
        public Video()
        {
            LoadedBehavior = System.Windows.Controls.MediaState.Manual;
        }

        public void Display(String path)
        {
            Source = new Uri(path);
        }

        public void Hide()
        {
            Visibility = System.Windows.Visibility.Hidden;
        }

        public void Show()
        {
            Visibility = System.Windows.Visibility.Visible;
        }

        public void UpgradeSpeed()
        {
            ++SpeedRatio;
        }

        public void DowngradeSpeed()
        {
            if (SpeedRatio > 0)
                --SpeedRatio;
        }

    }
}
