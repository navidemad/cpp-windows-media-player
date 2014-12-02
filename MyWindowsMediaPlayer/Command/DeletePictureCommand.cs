using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePictureCommand : Command
    {
        public override bool CanExecute(object param)
        {
            var currentPicture = param as Model.Picture;
            return currentPicture != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }
    }
}
