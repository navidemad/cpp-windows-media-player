using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Media
{
    class Image : System.Windows.Controls.Image
    {
        public void Display(String path)
        {
            try
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(path));
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

    }
}
