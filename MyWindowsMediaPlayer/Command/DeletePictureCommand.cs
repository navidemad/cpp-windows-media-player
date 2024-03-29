﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DeletePictureCommand : Command
    {
        Action<Model.Picture> Delete;

        public DeletePictureCommand(Action<Model.Picture> delete)
        {
            Delete = delete;
        }

        public override bool CanExecute(object param)
        {
            return (param as Model.Picture) != null;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Delete(param as Model.Picture);
        }
    }
}
