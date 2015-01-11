using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PlayListViewModel : ViewModel
    {
        private int _CurrentIndex = 0;
        public System.Collections.ObjectModel.ObservableCollection<Model.Playlist> Playlists { get; set; }

        private Model.Playlist _CurrentPlaylist = null;
        public Model.Playlist CurrentPlaylist
        {
            get { return _CurrentPlaylist; }
            set
            {
                _CurrentPlaylist = value;
                NamePlaylist = _CurrentPlaylist != null ? _CurrentPlaylist.Name : "";
                RaisePropertyChanged("CurrentPlaylist");
                Delete.RaiseCanExecuteChanged();
                AddItem.RaiseCanExecuteChanged();
            }
        }

        private String _NamePlaylist = "";
        public String NamePlaylist
        {
            get { return _NamePlaylist; }
            set
            {
                _NamePlaylist = value;
                RaisePropertyChanged("NamePlaylist");
                Add.RaiseCanExecuteChanged();
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
            Add = new Command.AddPlaylistCommand(AddPlaylist);
            Delete = new Command.DeletePlaylistCommand(RemovePlaylist);
            AddItem = new Command.AddPlaylistItemCommand(AddPlaylistItem);
            DeleteItem = new Command.DeletePlaylistItemCommand(DeletePlaylistItem);
            UpItem = new Command.UpPlaylistItemCommand(UpPlaylistItem);
            DownItem = new Command.DownPlaylistItemCommand(DownPlaylistItem);

            // static data in order to test display and features
            Playlists = new System.Collections.ObjectModel.ObservableCollection<Model.Playlist>();
           
            Playlists.Add(new Model.Playlist() {
                    Name = "Static Playlist 1",
                    Medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media> {
                        new Model.Music("Path1", false),
                        new Model.Picture("Path2", false),
                        new Model.Video("Path3", false)
                    }
                });

            Playlists.Add(new Model.Playlist() {
                    Name = "Static Playlist 2",
                    Medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media> {
                        new Model.Music("Path4", false),
                        new Model.Picture("Path5", false),
                        new Model.Video("Path6", false)
                    }
                });
        }

        public void AddPlaylist(Model.Playlist newPlaylist)
        {
            if (Playlists.Any(cus => cus.Name == newPlaylist.Name) == false)
                Playlists.Add(newPlaylist);
        }

        public void RemovePlaylist(Model.Playlist selectedPlaylist)
        {
            if (Playlists.Any(cus => cus.Name == selectedPlaylist.Name) == true)
                Playlists.Remove(selectedPlaylist);
        }

        public void AddPlaylistItem(Model.Media playlist)
        {
            Console.WriteLine("public void AddPlaylistItem(Model.Playlist playlist)");
        }

        public void DeletePlaylistItem(Model.Playlist playlist)
        {
            Console.WriteLine("public void DeletePlaylistItem(Model.Playlist playlist)");
        }

        public void UpPlaylistItem(Model.Media playlist)
        {
            Console.WriteLine("public void UpPlaylistItem(Model.Playlist playlist)");
        }
        public void DownPlaylistItem(Model.Media playlist)
        {
            Console.WriteLine("public void DownPlaylistItem(Model.Playlist playlist)");
        }

        public Model.Playlist Next()
        {
            if (Playlists.Count() == 0)
                return null;

            ++_CurrentIndex;
            _CurrentIndex %= Playlists.Count();

            return Playlists[_CurrentIndex];
        }

        public Model.Playlist Prev()
        {
            if (Playlists.Count() == 0)
                return null;

            if (_CurrentIndex > 0)
                --_CurrentIndex;
            else
                _CurrentIndex = Playlists.Count() - 1;

            return Playlists[_CurrentIndex];
        }

        // COMMANDS
        public Command.AddPlaylistCommand Add { get; set; }
        public Command.DeletePlaylistCommand Delete { get; set; }
        public Command.DeletePlaylistItemCommand DeleteItem { get; set; }
        public Command.AddPlaylistItemCommand AddItem { get; set; }
        public Command.UpPlaylistItemCommand UpItem { get; set; }
        public Command.DownPlaylistItemCommand DownItem { get; set; }

    }
}
