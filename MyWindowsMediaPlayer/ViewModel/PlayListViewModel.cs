using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PlayListViewModel : ViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<Model.Playlist> Playlists { get; set; }

        private Model.Playlist _CurrentPlaylist = null;
        public Model.Playlist CurrentPlaylist
        {
            get { return _CurrentPlaylist; }
            set
            {
                _CurrentPlaylist = value;
                RaisePropertyChanged("CurrentPlaylist");
                Delete.RaiseCanExecuteChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        static private PlayListViewModel _Instance = null;
        static public PlayListViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new PlayListViewModel();

            return _Instance;
        }

        private PlayListViewModel()
        {
            Add = new Command.AddPlaylistCommand();
            Edit = new Command.EditPlaylistCommand();
            Delete = new Command.DeletePlaylistCommand();

            // static data in order to test display and features
            /*
            Playlists = new System.Collections.ObjectModel.ObservableCollection<Model.Playlist> {
                new Model.Playlist {
                    Name = "Playlist 1",
                    Medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media> {
                        new Model.Music { Path = "Path1", Name = "Music" },
                        new Model.Picture { Path = "Path2", Name = "Picture" },
                        new Model.Video { Path = "Path3", Name = "Video" }
                    }
                },

                new Model.Playlist {
                    Name = "Playlist 2",
                    Medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media> {
                        new Model.Music { Path = "Path1", Name = "Music" },
                        new Model.Picture { Path = "Path2", Name = "Picture" },
                        new Model.Video { Path = "Path3", Name = "Video" }
                    }
                }
            };
            */
        }

        public void RemovePlaylist(Model.Playlist playlist)
        {
            Playlists.Remove(playlist);
        }

        public void AddPlaylist(Model.Playlist playlist)
        {
            Playlists.Add(playlist);
        }

        // COMMANDS
        public Command.DeletePlaylistCommand Delete { get; set; }
        public Command.EditPlaylistCommand Edit { get; set; }
        public Command.AddPlaylistCommand Add { get; set; }
    }
}
