using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Command
{
    class SpeedUpMediaCommand : Command
    {
        Action UpgradeSpeed;

        public SpeedUpMediaCommand(Action upgradeSpeed)
        {
            UpgradeSpeed = upgradeSpeed;
        }

        public override bool CanExecute(object param)
        {
            return true;
        }

        public override void Execute(object param)
        {
            if (!CanExecute(param))
                return;

            UpgradeSpeed();
        }
    }
}
