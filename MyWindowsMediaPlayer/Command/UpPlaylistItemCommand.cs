using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class UpPlaylistItemCommand : Command
    {
        Action<Model.Media> UpItem;
        public UpPlaylistItemCommand(Action<Model.Media> upItem)
        {
            UpItem = upItem;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Media) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
        }
    }
}
