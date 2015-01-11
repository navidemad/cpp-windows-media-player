using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWindowsMediaPlayer.View
{
    /// <summary>
    /// Logique d'interaction pour Media.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        class ViewDataContext
        {
            public ViewModel.MediaViewModel ViewModel { get; set; }
            public System.Windows.Media.ImageSource SpeedDownIcon { get; set; }
            public System.Windows.Media.ImageSource PrevIcon { get; set; }
            public System.Windows.Media.ImageSource PlayIcon { get; set; }
            public System.Windows.Media.ImageSource PauseIcon { get; set; }
            public System.Windows.Media.ImageSource StopIcon { get; set; }
            public System.Windows.Media.ImageSource NextIcon { get; set; }
            public System.Windows.Media.ImageSource SpeedUpIcon { get; set; }
            public System.Windows.Media.ImageSource FullScreenIcon { get; set; }
        }

        public MediaPlayer()
        {
            InitializeComponent();

            DataContext = new ViewDataContext
            {
                ViewModel = ViewModel.MediaViewModel.getInstance(),
                SpeedDownIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/speed_down_icon.png")),
                PrevIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/prev_icon.png")),
                PlayIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/play_icon.png")),
                PauseIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/pause_icon.png")),
                StopIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/stop_icon.png")),
                NextIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/next_icon.png")),
                SpeedUpIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/speed_up_icon.png")),
                FullScreenIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/full_screen_icon.png"))
            };

            App.Current.MainWindow.PreviewKeyDown += new KeyEventHandler(TurnOffFullScreen);
        }

        private void TurnOffFullScreen(object sender, KeyEventArgs e)
        {
            var window = App.Current.MainWindow as MainWindow;

            if (window != null && e.Key == Key.Escape)
            {
                MediaTitle.Visibility = System.Windows.Visibility.Visible;
                MediaControl.Visibility = System.Windows.Visibility.Visible;

                window.NavigationPanel.Visibility = System.Windows.Visibility.Visible;
                window.Languages.Visibility = System.Windows.Visibility.Visible;
                window.WindowStyle = WindowStyle.SingleBorderWindow;
                window.WindowState = WindowState.Normal;
            }
        }

        private void TurnOnFullScreen(object sender, RoutedEventArgs e)
        {
            var window = App.Current.MainWindow as MainWindow;

            if (window != null)
            {
                MediaTitle.Visibility = System.Windows.Visibility.Collapsed;
                MediaControl.Visibility = System.Windows.Visibility.Collapsed;

                window.NavigationPanel.Visibility = System.Windows.Visibility.Collapsed;
                window.Languages.Visibility = System.Windows.Visibility.Collapsed;
                window.WindowStyle = WindowStyle.None;
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
