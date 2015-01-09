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
        public System.Collections.ObjectModel.ObservableCollection<Model.Video> VideosTmp { get; set; }

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

        private String _SearchInput = "";
        public String SearchByText
        {
            get { return _SearchInput; }
            set
            {
                _SearchInput = value;
                Videos.Clear();

                var medias = from media in VideosTmp where (media.Name.ToLower().Contains(value.ToLower())) select media;

                foreach (var media in medias)
                {
                    Videos.Add(new Model.Video(media.Path, media.Stream));
                }
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
            AddLink = new Command.AddVideoLinkCommand(AddVideo);
            AddFile = new Command.AddVideoFileCommand(AddVideo);
            DropFile = new Command.DropVideoFileCommand(AddVideo);
            Delete = new Command.DeleteVideoCommand(RemoveVideo);

            LoadData();
        }

        public void LoadData()
        {
            Videos = new System.Collections.ObjectModel.ObservableCollection<Model.Video>();
            VideosTmp = new System.Collections.ObjectModel.ObservableCollection<Model.Video>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            List<Tuple<String, Boolean>> medias = mediaXML.GetMedias();

            foreach (var media in medias)
            {
                Model.Video pics_1 = new Model.Video(media.Item1, media.Item2);
                Model.Video pics_2 = new Model.Video(media.Item1, media.Item2);
                VideosTmp.Add(pics_1);
                Videos.Add(pics_2);
            }


        }

        public void RemoveVideo(Model.Video video)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            mediaXML.Remove(video.Path);
            mediaXML.WriteInFile("videos.xml");
            String namePathFile = video.Path;
            Videos.Remove(video);

          
            var medias = from media in VideosTmp where media.Path.Contains(namePathFile) select media;
            var selected = video;
            foreach (var media in medias)
                selected = media;
            VideosTmp.Remove(selected);

        }

        public void AddVideo(Model.Video video)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("videos.xml");
            if (!mediaXML.HasMedia(video.Path))
            {
                mediaXML.Add(video.Path, video.Stream);
                mediaXML.WriteInFile("videos.xml");
                
                if (video.Name.Contains(this._SearchInput))
                    Videos.Add(video);
                VideosTmp.Add(video);
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
        public Command.AddVideoFileCommand AddFile { get; set; }
        public Command.DropVideoFileCommand DropFile { get; set; }
        public Command.AddVideoLinkCommand AddLink { get; set; }
    }
}
