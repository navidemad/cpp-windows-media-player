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
            Delete = new Command.DeletePictureCommand();

            // static data in order to test display and features
            Pictures = new System.Collections.ObjectModel.ObservableCollection<Model.Picture> {
                new Model.Picture { Path = "Path1", Name = "Picture1" },
                new Model.Picture { Path = "Path2", Name = "Picture3" },
                new Model.Picture { Path = "Path3", Name = "Picture3" }
            };
        }

        public void RemovePicture(Model.Picture picture)
        {
            Pictures.Remove(picture);
        }

        public void AddPicture(Model.Picture picture)
        {
            Pictures.Add(picture);
        }

        // COMMANDS
        public Command.DeletePictureCommand Delete { get; set; }
        public Command.AddPictureCommand Add { get; set; }
    }
}
