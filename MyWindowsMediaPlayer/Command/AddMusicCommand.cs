using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddMusicCommand : Command
    {
        Action<Model.Music> Add;

        public AddMusicCommand(Action<Model.Music> add)
        {
            Add = add;
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
            openFileDialog.Filter = "MP3 Files (.mp3)|*.mp3|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Add(new Model.Music { Path = openFileDialog.FileName, Name = System.IO.Path.GetFileName(openFileDialog.FileName) });
        }
    }
}
