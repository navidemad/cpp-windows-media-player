using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer
{
    class MainWindowDataContext
    {
        public ViewModel.PlayListViewModel PlayListViewModel { get; set; }
        public ViewModel.MusicViewModel MusicViewModel { get; set; }
        public ViewModel.PictureViewModel PictureViewModel { get; set; }
        public ViewModel.VideoViewModel VideoViewModel { get; set; }
    }
}
