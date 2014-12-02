using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeleteVideoCommand : Command
    {
        public override bool CanExecute(object param)
        {
            var currentVideo = param as Model.Video;
            return currentVideo != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }

    }
}
