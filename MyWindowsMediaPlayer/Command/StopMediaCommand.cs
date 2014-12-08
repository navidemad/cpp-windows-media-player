using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class StopMediaCommand : Command
    {
        Action Stop;

        public StopMediaCommand(Action stop)
        {
            Stop = stop;
        }

        public override bool CanExecute(object param)
        {
            return (param as bool?) == true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            Stop();
        }
    }
}
