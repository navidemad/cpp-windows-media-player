using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DownPlaylistItemCommand : Command
    {
        Action<Model.Media> DownItem;
        public DownPlaylistItemCommand(Action<Model.Media> downItem)
        {
            DownItem = downItem;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Media) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
            DownItem(param as Model.Media);
        }
    }
}
