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
    /// Logique d'interaction pour Playlists.xaml
    /// </summary>
    public partial class Playlists : UserControl
    {
        class ViewDataContext
        {
            public ViewModel.PlayListViewModel ViewModel { get; set; }
            public ViewModel.MediaViewModel MediaViewModel { get; set; }
        }

        public Playlists()
        {
            InitializeComponent();

            DataContext = new ViewDataContext { ViewModel = ViewModel.PlayListViewModel.getInstance(), MediaViewModel = ViewModel.MediaViewModel.getInstance() };
        }
    }
}
