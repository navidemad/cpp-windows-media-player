using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MediaViewModel : ViewModel
    {
        private System.Windows.Media.ImageSource _ImageSource;
        public System.Windows.Media.ImageSource ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }

        private static MediaViewModel instance = null;
        public static MediaViewModel GetInstance()
        {
            if (instance == null)
                instance = new MediaViewModel();

            return instance;
        }

        private MediaViewModel()
        {
            SelectMedia = new Command.SelectMediaCommand(PlayMedia);
            ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.jpg"));
        }

        public void PlayMedia(Model.Media media)
        {
            switch (media.Type)
            {
                case Model.Media.MediaType.MUSIC:
                    PlayMusic(media as Model.Music);
                    break;
                case Model.Media.MediaType.PICTURE:
                    PlayPicture(media as Model.Picture);
                    break;
                case Model.Media.MediaType.VIDEO:
                    PlayVideo(media as Model.Video);
                    break;
            }
        }

        public void PlayVideo(Model.Video media)
        {
        }

        public void PlayMusic(Model.Music media)
        {
        }

        public void PlayPicture(Model.Picture media)
        {
            ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(media.Path));
        }

        public Command.SelectMediaCommand SelectMedia { get; set; }
    }
}
