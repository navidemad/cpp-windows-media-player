using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class SpeedDownMediaCommand : Command
    {
        Action DowngradeSpeed;

        public SpeedDownMediaCommand(Action downgradeSpeed)
        {
            DowngradeSpeed = downgradeSpeed;
        }

        public override bool CanExecute(object param)
        {
            return true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            DowngradeSpeed();
        }
    }
}
