using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddPictureLinkCommand : Command
    {
        Action<Model.Picture> Add;

        public AddPictureLinkCommand(Action<Model.Picture> add)
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

            Add(new Model.Picture(param as String, true));
        }
    }
}
