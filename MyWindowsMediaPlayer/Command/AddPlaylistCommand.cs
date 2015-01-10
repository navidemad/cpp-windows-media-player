using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddPlaylistCommand : Command
    {
        public override bool CanExecute(object param)
        {
            String link = param as String;

            return link != null && link.Length > 0;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }
    }
}
