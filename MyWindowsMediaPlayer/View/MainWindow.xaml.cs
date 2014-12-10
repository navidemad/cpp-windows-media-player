﻿using System;
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
using FirstFloor.ModernUI.Windows.Controls;

namespace MyWindowsMediaPlayer.View
{

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // set dataContext
            DataContext = new MainWindowDataContext {
                PlayListViewModel = ViewModel.PlayListViewModel.getInstance(),
                MusicViewModel = ViewModel.MusicViewModel.getInstance(),
                VideoViewModel = ViewModel.VideoViewModel.getInstance(),
                PictureViewModel = ViewModel.PictureViewModel.getInstance(),
                MediaViewModel = ViewModel.MediaViewModel.getInstance()
            };
        }

    }
}