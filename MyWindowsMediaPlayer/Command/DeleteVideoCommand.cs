using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeleteVideoCommand : Command
    {
        Action<Model.Video> Delete;

        public DeleteVideoCommand(Action<Model.Video> delete)
        {
            Delete = delete;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Video) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Delete(param as Model.Video);
        }

    }
}
