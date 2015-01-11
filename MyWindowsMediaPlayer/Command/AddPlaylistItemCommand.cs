using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddPlaylistItemCommand : Command
    {
        Action<Model.Media> AddItem;

        public AddPlaylistItemCommand(Action<Model.Media> addItem)
        {
            AddItem = addItem;
        }

        public override bool CanExecute(object param)
        {
            return true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*|MP4 Files (.mp4)|*.mp4|WMV Files (.wmv)|*.wmv|PNG Files (.png)|*.png|JPG Files (.jpg)|*.jpg|JPEG Files (.jpeg)|*.jpeg|MP3 Files (.mp3)|*.mp3";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch(System.IO.Path.GetExtension(openFileDialog.FileName))
                {
                    case ".mp4":
                    case ".wmv":
                        AddItem(new Model.Video(openFileDialog.FileName, false));
                        break;
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        AddItem(new Model.Picture(openFileDialog.FileName, false));
                        break;
                    case ".mp3":
                        AddItem(new Model.Music(openFileDialog.FileName, false));
                        break;
                    default:
                         Console.WriteLine("undefined");
                         break;
                }
            }
        }
    }
}
