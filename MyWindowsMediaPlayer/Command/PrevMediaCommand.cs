using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class PrevMediaCommand : Command
    {
        Action PrevMedia;

        public PrevMediaCommand(Action prevMedia)
        {
            PrevMedia = prevMedia;
        }

        public override bool CanExecute(object param)
        {
            return true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            PrevMedia();
        }
    }
}
