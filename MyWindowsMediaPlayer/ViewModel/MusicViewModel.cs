using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MusicViewModel : ViewModel
    {
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

        public MusicViewModel()
        {
            Add = new Command.AddMusicCommand(AddMusic);
            Delete = new Command.DeleteMusicCommand(RemoveMusic);

            LoadData();
        }

        public void LoadData()
        {
            Musics = new System.Collections.ObjectModel.ObservableCollection<Model.Music>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("musics.xml");
            List<String> medias = mediaXML.GetMedias();
            foreach (var media in medias)
                Musics.Add(new Model.Music { Path = media, Name = System.IO.Path.GetFileName(media) });
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
                mediaXML.Add(music.Path);
                mediaXML.WriteInFile("musics.xml");

                Musics.Add(music);
            }
        }

        // COMMANDS
        public Command.DeleteMusicCommand Delete { get; set; }
        public Command.AddMusicCommand Add { get; set; }
    }
}
