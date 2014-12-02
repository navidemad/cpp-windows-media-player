using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeleteMusicCommand : Command
    {
        public override bool CanExecute(object param)
        {
            var currentMusic = param as Model.Music;
            return currentMusic != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }
    }
}
