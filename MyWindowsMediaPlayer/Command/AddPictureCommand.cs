using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddPictureCommand : Command
    {
        Action<Model.Picture> Add;

        public AddPictureCommand(Action<Model.Picture> add)
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
            openFileDialog.Filter = "PNG Files (.png)|*.png|JPG Files (.jpg)|*.jpg|JPEG Files (.jpeg)|*.jpeg|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Add(new Model.Picture { Path = openFileDialog.FileName, Name = System.IO.Path.GetFileName(openFileDialog.FileName) });
        }
    }
}
