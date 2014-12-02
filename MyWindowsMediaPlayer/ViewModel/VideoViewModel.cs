using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class VideoViewModel : ViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<Model.Video> Videos { get; set; }

        private Model.Video _CurrentVideo = null;
        public Model.Video CurrentVideo
        {
            get { return _CurrentVideo; }
            set
            {
                _CurrentVideo = value;
                RaisePropertyChanged("CurrentVideo");
                Delete.RaiseCanExecuteChanged();
            }
        }

        public VideoViewModel()
        {
            Add = new Command.AddVideoCommand(AddVideo);
            Delete = new Command.DeleteVideoCommand();

            // static data in order to test display and features
            Videos = new System.Collections.ObjectModel.ObservableCollection<Model.Video> {
                new Model.Video { Path = "Path1", Name = "Video1" },
                new Model.Video { Path = "Path2", Name = "Video2" },
                new Model.Video { Path = "Path3", Name = "Video3" }
            };
        }

        public void RemoveVideo(Model.Video video)
        {
            Videos.Remove(video);
        }

        public void AddVideo(Model.Video video)
        {
            Videos.Add(video);
        }

        // COMMANDS
        public Command.DeleteVideoCommand Delete { get; set; }
        public Command.AddVideoCommand Add { get; set; }
    }
}
