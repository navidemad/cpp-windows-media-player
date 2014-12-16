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
        class ViewDataContext
        {
            public ViewModel.VideoViewModel ViewModel { get; set; }
            public ViewModel.MediaViewModel MediaViewModel { get; set; }
        }

        public Videos()
        {
            InitializeComponent();

            DataContext = new ViewDataContext { ViewModel = ViewModel.VideoViewModel.getInstance(), MediaViewModel = ViewModel.MediaViewModel.getInstance() };
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            ((ViewDataContext)DataContext).ViewModel.DropFile.Execute(e);
        }
    }
}
