﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class AddPlaylistCommand : Command
    {
        Action<Model.Playlist> Add;

        public AddPlaylistCommand(Action<Model.Playlist> add)
        {
            Add = add;
        }

        public override bool CanExecute(object param)
        {
            return !string.IsNullOrEmpty(param as String);
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;
            Add(new Model.Playlist() { Name = param as String });
        }
    }
}
