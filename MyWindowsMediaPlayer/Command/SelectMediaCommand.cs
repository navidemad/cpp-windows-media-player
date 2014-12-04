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
            return (param as Model.Media) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Play(param as Model.Media);
        }
    }
}
