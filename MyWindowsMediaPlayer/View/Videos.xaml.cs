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
    /// Logique d'interaction pour Videos.xaml
    /// </summary>
    public partial class Videos : UserControl
    {
        public Videos()
        {
            InitializeComponent();

            // set dataContext
            DataContext = new MainWindowDataContext
            {
                PlayListViewModel = ViewModel.PlayListViewModel.getInstance(),
                MusicViewModel = ViewModel.MusicViewModel.getInstance(),
                VideoViewModel = ViewModel.VideoViewModel.getInstance(),
                PictureViewModel = ViewModel.PictureViewModel.getInstance(),
                MediaViewModel = ViewModel.MediaViewModel.getInstance(),
                SettingsViewModel = ViewModel.SettingsViewModel.getInstance()
            };
        }
    }
}
