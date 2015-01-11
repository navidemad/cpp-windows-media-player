using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePlaylistItemCommand : Command
    {
        Action<Model.Media> DeleteItem;
        public DeletePlaylistItemCommand(Action<Model.Media> deleteItem)
        {
            DeleteItem = deleteItem;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Media) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
            DeleteItem(param as Model.Media);
        }
    }
}
