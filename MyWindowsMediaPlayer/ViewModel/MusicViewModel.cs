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
            Add = new Command.AddMusicCommand();
            Delete = new Command.DeleteMusicCommand();

            // static data in order to test display and features
            Musics = new System.Collections.ObjectModel.ObservableCollection<Model.Music> {
                new Model.Music { Path = "Path1", Name = "Music1" },
                new Model.Music { Path = "Path2", Name = "Music3" },
                new Model.Music { Path = "Path3", Name = "Music3" }
            };
        }

        public void RemovePlaylist(Model.Music music)
        {
            Musics.Remove(music);
        }

        public void AddPlaylist(Model.Music music)
        {
            Musics.Add(music);
        }

        // COMMANDS
        public Command.DeleteMusicCommand Delete { get; set; }
        public Command.AddMusicCommand Add { get; set; }
    }
}
