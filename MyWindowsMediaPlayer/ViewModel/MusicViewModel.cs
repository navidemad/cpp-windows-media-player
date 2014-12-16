using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MusicViewModel : ViewModel
    {
        private int _CurrentIndex = 0;
        public System.Collections.ObjectModel.ObservableCollection<Model.Music> Musics { get; set; }

        private Model.Music _CurrentMusic = null;
        public Model.Music CurrentMusic
        {
            get { return _CurrentMusic; }
            set
            {
                _CurrentMusic = value;
                RaisePropertyChanged("CurrentMusic");
                Delete.RaiseCanExecuteChanged();
            }
        }

        private String _LinkInput = "";
        public String LinkInput
        {
            get { return _LinkInput; }
            set
            {
                _LinkInput = value;
                RaisePropertyChanged("LinkInput");
                AddLink.RaiseCanExecuteChanged();
            }
        }

        static private MusicViewModel _Instance = null;
        static public MusicViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new MusicViewModel();

            return _Instance;
        }

        private MusicViewModel()
        {
            AddLink = new Command.AddMusicLinkCommand(AddMusic);
            AddFile = new Command.AddMusicFileCommand(AddMusic);
            DropFile = new Command.DropMusicFileCommand(AddMusic);
            Delete = new Command.DeleteMusicCommand(RemoveMusic);

            LoadData();
        }

        public void LoadData()
        {
            Musics = new System.Collections.ObjectModel.ObservableCollection<Model.Music>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("musics.xml");
            List<Tuple<String, Boolean>> medias = mediaXML.GetMedias();
            foreach (var media in medias)
                Musics.Add(new Model.Music(media.Item1, media.Item2));
        }

        public void RemoveMusic(Model.Music music)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("musics.xml");
            mediaXML.Remove(music.Path);
            mediaXML.WriteInFile("musics.xml");

            Musics.Remove(music);
        }

        public void AddMusic(Model.Music music)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("musics.xml");
            if (!mediaXML.HasMedia(music.Path))
            {
                mediaXML.Add(music.Path, music.Stream);
                mediaXML.WriteInFile("musics.xml");

                Musics.Add(music);
            }
        }

        public Model.Music Next()
        {
            if (Musics.Count() == 0)
                return null;

            ++_CurrentIndex;
            _CurrentIndex %= Musics.Count();

            return Musics[_CurrentIndex];
        }

        public Model.Music Prev()
        {
            if (Musics.Count() == 0)
                return null;

            if (_CurrentIndex > 0)
                --_CurrentIndex;
            else
                _CurrentIndex = Musics.Count() - 1;

            return Musics[_CurrentIndex];
        }

        // COMMANDS
        public Command.DeleteMusicCommand Delete { get; set; }
        public Command.AddMusicFileCommand AddFile { get; set; }
        public Command.AddMusicLinkCommand AddLink { get; set; }
        public Command.DropMusicFileCommand DropFile { get; set; }
    }
}
