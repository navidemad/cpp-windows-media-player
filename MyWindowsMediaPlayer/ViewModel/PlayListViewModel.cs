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

        private Model.Media _CurrentMedia = null;
        public Model.Media CurrentMedia
        {
            get { return _CurrentMedia; }
            set
            {
                _CurrentMedia = value;
                RaisePropertyChanged("CurrentMedia");
                DeleteItem.RaiseCanExecuteChanged();
                UpItem.RaiseCanExecuteChanged();
                DownItem.RaiseCanExecuteChanged();
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

            LoadData();
        }

        public void LoadData()
        {
            XML.PlaylistXML playlistXML = new XML.PlaylistXML();
            playlistXML.Load("playlists.xml");
            Playlists = playlistXML.GetPlaylists();
        }

        public void AddPlaylist(Model.Playlist newPlaylist)
        {
            if (Playlists.Any(cus => cus.Name == newPlaylist.Name) == false)
            {
                XML.PlaylistXML playlistXML = new XML.PlaylistXML();

                playlistXML.Load("playlists.xml");
                if (!playlistXML.HasPlaylist(newPlaylist.Name))
                {
                    playlistXML.AddPlaylist(newPlaylist.Name);
                    playlistXML.WriteInFile("playlists.xml");
                    Playlists.Add(newPlaylist);
                }
            }
        }

        public void RemovePlaylist(Model.Playlist selectedPlaylist)
        {
            if (Playlists.Any(cus => cus.Name == selectedPlaylist.Name) == true)
            {
                XML.PlaylistXML playlistXML = new XML.PlaylistXML();

                playlistXML.Load("playlists.xml");
                if (playlistXML.HasPlaylist(selectedPlaylist.Name))
                {
                    playlistXML.RemovePlaylist(selectedPlaylist.Name);
                    playlistXML.WriteInFile("playlists.xml");
                    Playlists.Remove(selectedPlaylist);
                }
            }
        }

        public void AddPlaylistItem(Model.Media media)
        {
            if (CurrentPlaylist != null && media != null)
            {
                XML.PlaylistXML playlistXML = new XML.PlaylistXML();

                playlistXML.Load("playlists.xml");
                if (!playlistXML.HasMedia(CurrentPlaylist.Name, media))
                {
                    playlistXML.AddPlaylistItem(CurrentPlaylist.Name, media);
                    playlistXML.WriteInFile("playlists.xml");
                    CurrentPlaylist.Medias.Add(media);
                }                
            }
        }

        public void DeletePlaylistItem(Model.Media media)
        {
            if (CurrentPlaylist != null && media != null)
            {
                XML.PlaylistXML playlistXML = new XML.PlaylistXML();

                playlistXML.Load("playlists.xml");
                if (playlistXML.HasMedia(CurrentPlaylist.Name, media))
                {
                    playlistXML.RemovePlaylistItem(CurrentPlaylist.Name, media);
                    playlistXML.WriteInFile("playlists.xml");
                    CurrentPlaylist.Medias.Remove(media);
                }
            }
        }

        public void UpPlaylistItem(Model.Media media)
        {
            if (CurrentPlaylist != null && media != null)
            {
                int index = CurrentPlaylist.Medias.IndexOf(media);
                if (index > 0 && index != -1)
                {
                    var swap = CurrentPlaylist.Medias[index - 1];
                    CurrentPlaylist.Medias.RemoveAt(index - 1);
                    CurrentPlaylist.Medias.Insert(index, swap);
                }
            }
        }

        public void DownPlaylistItem(Model.Media media)
        {
            if (CurrentPlaylist != null && media != null)
            {
                int index = CurrentPlaylist.Medias.IndexOf(media);
                if (index < CurrentPlaylist.Medias.Count - 1 && index != -1)
                {
                    var swap = CurrentPlaylist.Medias[index + 1];
                    CurrentPlaylist.Medias.RemoveAt(index + 1);
                    CurrentPlaylist.Medias.Insert(index, swap);
                }
            }
        }

        public Model.Playlist Next()
        {
            if (Playlists.Count() == 0)
                return null;

            ++CurrentPlaylist.CurrentIndex;
            CurrentPlaylist.CurrentIndex %= CurrentPlaylist.Medias.Count();

            return CurrentPlaylist;
        }

        public Model.Playlist Prev()
        {
            if (Playlists.Count() == 0)
                return null;

            if (CurrentPlaylist.CurrentIndex > 0)
                --CurrentPlaylist.CurrentIndex;
            else
                CurrentPlaylist.CurrentIndex = CurrentPlaylist.Medias.Count() - 1;

            return CurrentPlaylist;
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
