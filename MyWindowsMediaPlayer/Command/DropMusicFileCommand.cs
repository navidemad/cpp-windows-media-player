﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class DropMusicFileCommand : Command
    {
        Action<Model.Music> Add;

        public DropMusicFileCommand(Action<Model.Music> add)
        {
            Add = add;
        }

        public override bool CanExecute(object param)
        {
            var dragEventArgs = param as System.Windows.DragEventArgs;

            return dragEventArgs != null && dragEventArgs.Data.GetDataPresent(System.Windows.DataFormats.FileDrop) && ((Array)dragEventArgs.Data.GetData(System.Windows.DataFormats.FileDrop)).Length > 0;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            var dragEventArgs = param as System.Windows.DragEventArgs;
            
            foreach (String file in (Array)dragEventArgs.Data.GetData(System.Windows.Forms.DataFormats.FileDrop))
                Add(new Model.Music(file));
        }
    }
}
