﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Video : Media
    {
        public Video()
        {
            Type = Media.MediaType.VIDEO;
        }
    }
}