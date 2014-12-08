using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PictureViewModel : ViewModel
    {
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

        public PictureViewModel()
        {
            Add = new Command.AddPictureCommand(AddPicture);
            Delete = new Command.DeletePictureCommand(RemovePicture);

            LoadData();
        }

        public void LoadData()
        {
            Pictures = new System.Collections.ObjectModel.ObservableCollection<Model.Picture>();
            XML.MediaXML mediaXML = new XML.MediaXML();

            mediaXML.Load("pictures.xml");
            List<String> medias = mediaXML.GetMedias();
            foreach (var media in medias)
                Pictures.Add(new Model.Picture(media));
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
                mediaXML.Add(picture.Path);
                mediaXML.WriteInFile("pictures.xml");

                Pictures.Add(picture);
            }
        }

        // COMMANDS
        public Command.DeletePictureCommand Delete { get; set; }
        public Command.AddPictureCommand Add { get; set; }
    }
}
