using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Video : Media
    {
        public Video(String path, bool stream = false) : base(path, stream)
        {
            Type = Media.MediaType.VIDEO;
        }
    }
}
