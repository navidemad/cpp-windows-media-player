using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Playlist
    {
        // LIST OF MEDIAS
        public System.Collections.ObjectModel.ObservableCollection<Media> Medias { get; set; }

        // PLAYLIST NAME
        public String Name { get; set; }
    }
}
