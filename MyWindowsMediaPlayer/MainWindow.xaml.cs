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

namespace MyWindowsMediaPlayer
{

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            ** set dataContext
            */
            MainWindowDataContext mainWindowDataContext = new MainWindowDataContext();
            mainWindowDataContext.PlayListViewModel = new PlayListViewModel();
            DataContext = mainWindowDataContext;

            /*
            ** display main window image
            */
            //img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "images/WindowsMediaPlayerLogo.jpg"));
        }
    }
}
