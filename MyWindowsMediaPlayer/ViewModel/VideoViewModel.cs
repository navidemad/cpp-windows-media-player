using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class VideoViewModel : ViewModel
    {
        private int _CurrentIndex = 0;
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

        static private VideoViewModel _Instance = null;
        static public VideoViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new VideoViewModel();

            return _Instance;
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
                Videos.Add(new Model.Video(media));
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

        public Model.Video Next()
        {
            if (Videos.Count() == 0)
                return null;

            ++_CurrentIndex;
            _CurrentIndex %= Videos.Count();

            return Videos[_CurrentIndex];
        }

        public Model.Video Prev()
        {
            if (Videos.Count() == 0)
                return null;

            if (_CurrentIndex > 0)
                --_CurrentIndex;
            else
                _CurrentIndex = Videos.Count() - 1;

            return Videos[_CurrentIndex];
        }

        // COMMANDS
        public Command.DeleteVideoCommand Delete { get; set; }
        public Command.AddVideoCommand Add { get; set; }
    }
}
