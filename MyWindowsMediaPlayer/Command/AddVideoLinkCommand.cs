using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddVideoLinkCommand : Command
    {
        Action<Model.Video> Add;

        public AddVideoLinkCommand(Action<Model.Video> add)
        {
            Add = add;
        }

        public override bool CanExecute(object param)
        {
            String link = param as String;

            return link != null && link.Length > 0 && link.IndexOf("https") != 0;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Add(new Model.Video(param as String, true));
        }
    }
}
