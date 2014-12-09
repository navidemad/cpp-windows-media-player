using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class NextMediaCommand : Command
    {
        Action NextMedia;

        public NextMediaCommand(Action nextMedia)
        {
            NextMedia = nextMedia;
        }

        public override bool CanExecute(object param)
        {
            return true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            NextMedia();
        }    }
}
