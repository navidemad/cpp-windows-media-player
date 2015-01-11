using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePlaylistItemCommand : Command
    {
        Action<Model.Playlist> DeleteItem;
        public DeletePlaylistItemCommand(Action<Model.Playlist> deleteItem)
        {
            DeleteItem = deleteItem;
        }

        public override bool CanExecute(object param)
        {
            Console.WriteLine("DeletePlaylistItem canExecute: {0}", param);
            return (param as Model.Playlist) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
            DeleteItem(param as Model.Playlist);
        }
    }
}
