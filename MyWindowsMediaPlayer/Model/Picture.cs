using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Picture : Media
    {
        public Picture(String path) : base(path)
        {
            Type = Media.MediaType.PICTURE;
        }
    }
}
