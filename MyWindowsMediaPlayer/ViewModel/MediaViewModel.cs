using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MediaViewModel : ViewModel
    {
        public Command.SelectMediaCommand SelectMedia { get; set; }

        public Media.Video MediaElement { get; set; }
        public Media.Image Image { get; set; }

        public System.Windows.Media.ImageSource PrevIcon { get; set; }
        public System.Windows.Media.ImageSource NextIcon { get; set; }

        private System.Windows.Media.ImageSource _PlayPauseIcon;
        public System.Windows.Media.ImageSource PlayPauseIcon
        {
            get { return _PlayPauseIcon; }
            set
            {
                _PlayPauseIcon = value;
                RaisePropertyChanged("PlayPauseIcon");
            }
        }

        private String _CurrentMediaName;
        public String CurrentMediaName
        {
            get { return _CurrentMediaName; }
            set
            {
                _CurrentMediaName = value;
                RaisePropertyChanged("CurrentMediaName");
            }
        }

        public MediaViewModel()
        {
            SelectMedia = new Command.SelectMediaCommand(PlayMedia);
            CurrentMediaName = "Current Media";

            PrevIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/prev_icon.png"));
            NextIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/next_icon.png"));
            PlayPauseIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/play_icon.png"));

            Image = new Media.Image();
            MediaElement = new Media.Video();
            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.jpg");
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

            CurrentMediaName = media.Name;
        }

        public void PlayVideo(Model.Video media)
        {
            MediaElement.Source = new Uri(media.Path);
            MediaElement.Play();
            MediaElement.Show();
            Image.Hide();
        }

        public void PlayMusic(Model.Music media)
        {
            MediaElement.Display(media.Path);
            MediaElement.Play();
            MediaElement.Hide();

            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.jpg");
            Image.Show();
        }

        public void PlayPicture(Model.Picture media)
        {
            MediaElement.Stop();
            MediaElement.Hide();

            Image.Display(media.Path);
            Image.Show();
        }
    }
}
