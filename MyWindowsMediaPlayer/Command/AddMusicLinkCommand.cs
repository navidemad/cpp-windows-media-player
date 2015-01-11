using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddMusicLinkCommand : Command
    {
        Action<Model.Music> Add;

        public AddMusicLinkCommand(Action<Model.Music> add)
        {
            Add = add;
        }

        public override bool CanExecute(object param)
        {
            String link = param as String;
            return !string.IsNullOrEmpty(link) && link.IndexOf("https") != 0;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Add(new Model.Music(param as String, true));
        }
    }
}
