﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.View
{
    class MainWindowDataContext
    {
        public ViewModel.PlayListViewModel PlayListViewModel { get; set; }
        public ViewModel.MusicViewModel MusicViewModel { get; set; }
        public ViewModel.PictureViewModel PictureViewModel { get; set; }
        public ViewModel.VideoViewModel VideoViewModel { get; set; }
        public ViewModel.MediaViewModel MediaViewModel { get; set; }
        public ViewModel.SettingsViewModel SettingsViewModel { get; set; }
    }
}
