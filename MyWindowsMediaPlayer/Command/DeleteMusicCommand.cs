using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeleteMusicCommand : Command
    {
        Action<Model.Music> Delete;

        public DeleteMusicCommand(Action<Model.Music> delete)
        {
            Delete = delete;
        }

        public override bool CanExecute(object param)
        {
            var currentMusic = param as Model.Music;
            return currentMusic != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            var currentMusic = param as Model.Music;
            Delete(currentMusic);
        }
    }
}
