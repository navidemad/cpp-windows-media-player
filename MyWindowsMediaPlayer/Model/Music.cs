using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Music : Media
    {
        public Music() {
            Type = Media.MediaType.MUSIC;
        }
    }
}
