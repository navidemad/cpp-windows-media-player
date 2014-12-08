﻿using System;
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
            try
            {
                Source = new Uri(path);
            }
            catch
            {
            }
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
            if (SpeedRatio > 1)
                ++SpeedRatio;
            else
                SpeedRatio += 0.1;
        }

        public void DowngradeSpeed()
        {
            if (SpeedRatio > 1)
                --SpeedRatio;
            else
                SpeedRatio -= 0.1;
        }

    }
}
