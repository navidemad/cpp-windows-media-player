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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Link
        {
            public String Name { get; set; }
            public String Page { get; set; }
        }

        class ViewDataContext : System.ComponentModel.INotifyPropertyChanged
        {
            private Link _CurrentPage;
            public Link CurrentPage {
                get { return _CurrentPage; }
                set
                {
                    _CurrentPage = value;
                    RaisePropertyChanged("CurrentPage");
                }
            }
            
            public List<Link> Pages { get; set; }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(String property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            List<Link> pages = new List<Link> {
                new Link { Name = "Player", Page = "MediaPlayer.xaml" },
                new Link { Name = "Catégories", Page = "Menu.xaml" }
            };

            DataContext = new ViewDataContext { CurrentPage = pages[0], Pages = pages };
        }

    }
}
