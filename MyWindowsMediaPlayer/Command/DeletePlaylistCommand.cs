using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePlaylistCommand : Command
    {
        Action<Model.Playlist> Delete;

        public DeletePlaylistCommand(Action<Model.Playlist> delete)
        {
            Delete = delete;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Playlist) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Delete(param as Model.Playlist);
        }
    }
}
