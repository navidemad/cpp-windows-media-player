using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PictureViewModel : ViewModel
    {
        private int _CurrentIndex = 0;
        public System.Collections.ObjectModel.ObservableCollection<Model.Picture> Pictures { get; set; }

        private Model.Picture _CurrentPicture = null;
        public Model.Picture CurrentPicture
        {
            get { return _CurrentPicture; }
            set
            {
                _CurrentPicture = value;
                RaisePropertyChanged("CurrentPicture");
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

        static private PictureViewModel _Instance = null;
        static public PictureViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new PictureViewModel();

            return _Instance;
        }

        private PictureViewModel()
        {
            AddLink = new Command.AddPictureLinkCommand(AddPicture);
            AddFile = new Command.AddPictureFileCommand(AddPicture);
            Delete = new Command.DeletePictureCommand(RemovePicture);

            LoadData();
        }

        public void LoadData()
        {
            Pictures = new System.Collections.ObjectModel.ObservableCollection<Model.Picture>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("pictures.xml");
            List<Tuple<String, Boolean>> medias = mediaXML.GetMedias();
            foreach (var media in medias)
                Pictures.Add(new Model.Picture(media.Item1, media.Item2));
        }

        public void RemovePicture(Model.Picture picture)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("pictures.xml");
            mediaXML.Remove(picture.Path);
            mediaXML.WriteInFile("pictures.xml");

            Pictures.Remove(picture);
        }

        public void AddPicture(Model.Picture picture)
        {
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("pictures.xml");
            if (!mediaXML.HasMedia(picture.Path))
            {
                mediaXML.Add(picture.Path, picture.Stream);
                mediaXML.WriteInFile("pictures.xml");

                Pictures.Add(picture);
            }
        }

        public Model.Picture Next()
        {
            if (Pictures.Count() == 0)
                return null;

            ++_CurrentIndex;
            _CurrentIndex %= Pictures.Count();

            return Pictures[_CurrentIndex];
        }

        public Model.Picture Prev()
        {
            if (Pictures.Count() == 0)
                return null;

            if (_CurrentIndex > 0)
                --_CurrentIndex;
            else
                _CurrentIndex = Pictures.Count() - 1;

            return Pictures[_CurrentIndex];
        }

        // COMMANDS
        public Command.DeletePictureCommand Delete { get; set; }
        public Command.AddPictureFileCommand AddFile { get; set; }
        public Command.AddPictureLinkCommand AddLink { get; set; }
    }
}
