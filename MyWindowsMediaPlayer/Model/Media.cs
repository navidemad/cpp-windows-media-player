using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Media
    {
        // NAME
        public String Name { get; set; }

        // PATH
        public String Path { get; set; }

        // TYPE
        public enum MediaType { MUSIC, VIDEO, PICTURE };
        public MediaType Type { get; set; }
    }
}
