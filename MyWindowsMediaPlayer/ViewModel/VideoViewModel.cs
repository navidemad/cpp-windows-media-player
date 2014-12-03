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

        private static VideoViewModel instance = null;
        public static VideoViewModel GetInstance()
        {
            if (instance == null)
                instance = new VideoViewModel();

            return instance;
        }

        private VideoViewModel()
        {
            Add = new Command.AddVideoCommand(AddVideo);
            Delete = new Command.DeleteVideoCommand(RemoveVideo);

            LoadData();
        }

        public void LoadData()
        {
            Videos = new System.Collections.ObjectModel.ObservableCollection<Model.Video>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            List<String> medias = mediaXML.GetMedias();
            foreach (var media in medias)
                Videos.Add(new Model.Video { Path = media, Name = System.IO.Path.GetFileName(media) });
        }

        public void RemoveVideo(Model.Video video)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            mediaXML.Remove(video.Path);
            mediaXML.WriteInFile("videos.xml");

            Videos.Remove(video);
        }

        public void AddVideo(Model.Video video)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            if (!mediaXML.HasMedia(video.Path))
            {
                mediaXML.Add(video.Path);
                mediaXML.WriteInFile("videos.xml");

                Videos.Add(video);
            }
        }

        // COMMANDS
        public Command.DeleteVideoCommand Delete { get; set; }
        public Command.AddVideoCommand Add { get; set; }
    }
}
