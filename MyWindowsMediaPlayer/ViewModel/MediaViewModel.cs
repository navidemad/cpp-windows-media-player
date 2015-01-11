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
        public bool IsPlayingMedia
        {
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

        private bool _IsPlayingPlaylist = false;
        private Model.Media.MediaType _CurrentMediaType = Model.Media.MediaType.PICTURE;

        public Command.SelectMediaCommand SelectMediaCommand { get; set; }
        public Command.SelectPlaylistCommand SelectPlaylistCommand { get; set; }
        public Command.PlayMediaCommand PlayMediaCommand { get; set; }
        public Command.PauseMediaCommand PauseMediaCommand { get; set; }
        public Command.StopMediaCommand StopMediaCommand { get; set; }
        public Command.SpeedUpMediaCommand SpeedUpMediaCommand { get; set; }
        public Command.SpeedDownMediaCommand SpeedDownMediaCommand { get; set; }
        public Command.NextMediaCommand NextMediaCommand { get; set; }
        public Command.PrevMediaCommand PrevMediaCommand { get; set;}

        public Media.Video MediaElement { get; set; }
        public Media.Image Image { get; set; }

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

        static private MediaViewModel _Instance = null;
        static public MediaViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new MediaViewModel();

            return _Instance;
        }

        private MediaViewModel()
        {
            SelectMediaCommand = new Command.SelectMediaCommand(PlayMedia);
            SelectPlaylistCommand = new Command.SelectPlaylistCommand(PlayPlaylist);
            PlayMediaCommand = new Command.PlayMediaCommand(Play);
            PauseMediaCommand = new Command.PauseMediaCommand(Pause);
            StopMediaCommand = new Command.StopMediaCommand(Stop);
            SpeedUpMediaCommand = new Command.SpeedUpMediaCommand(UpgradeSpeed);
            SpeedDownMediaCommand = new Command.SpeedDownMediaCommand(DowngradeSpeed);
            NextMediaCommand = new Command.NextMediaCommand(NextMedia);
            PrevMediaCommand = new Command.PrevMediaCommand(PrevMedia);

            CurrentMediaName = "Current Media";

            Image = new Media.Image();
            MediaElement = new Media.Video();
            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.png");
        }

        public void PlayPlaylist(Model.Playlist playlist)
        {
            if (playlist == null)
                return;

            // handle playlists;
            _IsPlayingPlaylist = true;
        }

        public void PlayMedia(Model.Media media)
        {
            if (media == null || (media.Stream == false && System.IO.File.Exists(media.Path) == false))
                return;

            Console.WriteLine("playMedia");
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

            _IsPlayingPlaylist = false;
            CurrentMediaName = media.Name;
            _CurrentMediaType = media.Type;
        }

        public void PlayVideo(Model.Video media)
        {
            MediaElement.Display(media.Path);
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

            Image.Display(AppDomain.CurrentDomain.BaseDirectory + "../../images/WindowsMediaPlayerLogo.png");
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

        public void NextMedia()
        {
            SwitchMedia("Next");
        }

        public void PrevMedia()
        {
            SwitchMedia("Prev");
        }

        private void SwitchMedia(String methodName)
        {
            if (_IsPlayingPlaylist)
            {
                System.Reflection.MethodInfo method = Type.GetType("ViewModel.PlayListViewModel").GetMethod(methodName);
                PlayPlaylist(method.Invoke(PlayListViewModel.getInstance(), new object[] {}) as Model.Playlist);
            }
            else
            {
                Type type;
                object obj;

                switch (_CurrentMediaType)
                {
                    case Model.Media.MediaType.PICTURE:
                        type = typeof(PictureViewModel);
                        obj = PictureViewModel.getInstance();
                        break;
                    case Model.Media.MediaType.VIDEO:
                        type = typeof(VideoViewModel);
                        obj = VideoViewModel.getInstance();
                        break;
                    case Model.Media.MediaType.MUSIC:
                        type = typeof(MusicViewModel);
                        obj = MusicViewModel.getInstance();
                        break;
                    default:
                        return;
                }

                System.Reflection.MethodInfo method = type.GetMethod(methodName);
                PlayMedia(method.Invoke(obj, new object[] {}) as Model.Media);
            }
        }
    }
}
