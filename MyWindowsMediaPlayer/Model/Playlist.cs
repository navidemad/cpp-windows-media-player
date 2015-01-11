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

        // MEDIA INDEX
        public int CurrentIndex { get; set; }

        public Playlist()
        {
            Name = "";
            Medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media>();
            CurrentIndex = 0;
        }
    }
}
