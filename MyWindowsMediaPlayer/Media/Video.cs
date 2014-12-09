using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Media
{
    class Video : System.Windows.Controls.MediaElement, System.ComponentModel.INotifyPropertyChanged
    {
        System.Windows.Threading.DispatcherTimer _timer = null;

        private int _CurrentTime = 0;
        public int CurrentTime
        {
            get { return _CurrentTime; }
            set
            {
                _CurrentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        private int _MaxDuration = 0;
        public int MaxDuration
        {
            get { return _MaxDuration; }
            set
            {
                _MaxDuration = value;
                RaisePropertyChanged("MaxDuration");
            }
        }

        public Video()
        {
            LoadedBehavior = System.Windows.Controls.MediaState.Manual;
        }

        public void updateTime(object sender, EventArgs e)
        {
            CurrentTime = (int)Position.TotalSeconds;
            if (NaturalDuration.HasTimeSpan)
                MaxDuration = (int)NaturalDuration.TimeSpan.TotalSeconds;
        }

        public void Display(String path)
        {
            try
            {
                Source = new Uri(path);

                _timer = new System.Windows.Threading.DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += new EventHandler(updateTime);
                _timer.Start();
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }
    }
}
