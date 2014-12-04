using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class SelectPlaylistCommand : Command
    {
        Action<Model.Playlist> Play;

        public SelectPlaylistCommand(Action<Model.Playlist> play)
        {
            Play = play;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Playlist) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Play(param as Model.Playlist);
        }
    }
}
