using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePlaylistCommand : Command
    {
        public override bool CanExecute(object param)
        {
            var currentPlaylist = param as Model.Playlist;
            return currentPlaylist != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }
    }
}
