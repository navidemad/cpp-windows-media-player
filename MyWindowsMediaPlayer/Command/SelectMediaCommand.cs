using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class SelectMediaCommand : Command
    {
        Action<Model.Media> Play;

        public SelectMediaCommand(Action<Model.Media> play)
        {
            Play = play;
        }

        public override bool CanExecute(object param)
        {
            return param != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            var media = param as Model.Media;
            Play(media);
        }
    }
}
