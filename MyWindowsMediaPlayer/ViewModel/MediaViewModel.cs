using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MediaViewModel : ViewModel
    {
        private bool _IsPlayingMedia = false;
        public bool IsPlayingMedia {
            get { return _IsPlayingMedia; }
            set
            {
                _IsPlayingMedia = value;
                RaisePropertyChanged("IsPlayingMedia");
                PlayMediaCommand.RaiseCanExecuteChanged();
                PauseMediaCommand.RaiseCanExecuteChanged();
                StopMediaCommand.RaiseCanExecuteChanged();
            }
        }

        public Command.SelectMediaCommand SelectMediaCommand { get; set; }
        public Command.SelectPlaylistCommand SelectPlaylistCommand { get; set; }
        public Command.PlayMediaCommand PlayMediaCommand { get; set; }
        public Command.PauseMediaCommand PauseMediaCommand { get; set; }
        public Command.StopMediaCommand StopMediaCommand { get; set; }
        public Command.SpeedUpMediaCommand SpeedUpMediaCommand { get; set; }
        public Command.SpeedDownMediaCommand SpeedDownMediaCommand { get; set; }

        public Media.Video MediaElement { get; set; }
        public Media.Image Image { get; set; }

        public System.Windows.Media.ImageSource PrevIcon { get; set; }
        public System.Windows.Media.ImageSource NextIcon { get; set; }
        public System.Windows.Media.ImageSource PlayIcon { get; set; }
        public System.Windows.Media.ImageSource StopIcon { get; set; }
        public System.Windows.Media.ImageSource PauseIcon { get; set; }
        public System.Windows.Media.ImageSource SpeedDownIcon { get; set; }
        public System.Windows.Media.ImageSource SpeedUpIcon { get; set; }

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
            SelectMediaCommand = new Command.SelectMediaCommand(PlayMedia);
            SelectPlaylistCommand = new Command.SelectPlaylistCommand(PlayPlaylist);
            PlayMediaCommand = new Command.PlayMediaCommand(Play);
            PauseMediaCommand = new Command.PauseMediaCommand(Pause);
            StopMediaCommand = new Command.StopMediaCommand(Stop);
            SpeedUpMediaCommand = new Command.SpeedUpMediaCommand(UpgradeSpeed);
            SpeedDownMediaCommand = new Command.SpeedDownMediaCommand(DowngradeSpeed);

            CurrentMediaName = "Current Media";

            PrevIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/prev_icon.png"));
            NextIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/next_icon.png"));
            PlayIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/play_icon.png"));
            PauseIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/pause_icon.png"));
            StopIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/stop_icon.png"));
            SpeedUpIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/speed_up_icon.png"));
            SpeedDownIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../images/speed_down_icon.png"));

            Image = new Media.Image();
            MediaElement = new Media.Video();
            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.jpg");
        }

        public void PlayPlaylist(Model.Playlist playlist)
        {
            // handle playlists;
        }

        public void PlayMedia(Model.Media media)
        {
            if (System.IO.File.Exists(media.Path) == false)
                return;

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
            MediaElement.Show();
            Image.Hide();
            Play();

            IsPlayingMedia = true;
        }

        public void PlayMusic(Model.Music media)
        {
            MediaElement.Display(media.Path);
            MediaElement.Hide();
            Play();

            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.jpg");
            Image.Show();

            IsPlayingMedia = true;
        }

        public void PlayPicture(Model.Picture media)
        {
            MediaElement.Stop();
            MediaElement.Hide();

            Image.Display(media.Path);
            Image.Show();

            IsPlayingMedia = false;
        }

        public void Play()
        {
            MediaElement.Play();
        }

        public void Pause()
        {
            MediaElement.Pause();
        }

        public void Stop()
        {
            MediaElement.Stop();
        }

        public void UpgradeSpeed()
        {
            MediaElement.UpgradeSpeed();
        }

        public void DowngradeSpeed()
        {
            MediaElement.DowngradeSpeed();
        }
    }
}
