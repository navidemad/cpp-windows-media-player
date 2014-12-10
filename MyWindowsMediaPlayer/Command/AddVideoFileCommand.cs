using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddVideoFileCommand : Command
    {
        Action<Model.Video> Add;

        public AddVideoFileCommand(Action<Model.Video> add)
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
            openFileDialog.Filter = "MP4 Files (.mp4)|*.mp4|WMV Files (.wmv)|*.wmv|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Add(new Model.Video(openFileDialog.FileName));
        }
    }
}
